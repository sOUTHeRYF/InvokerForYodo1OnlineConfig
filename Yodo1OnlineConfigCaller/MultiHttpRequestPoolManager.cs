using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
namespace Yodo1OnlineConfigCaller
{
    public class MultiHttpRequestPoolManager
    {
        private static readonly MultiHttpRequestPoolManager _instance = new MultiHttpRequestPoolManager();

        #region Global Members
        private Boolean missionQueueReady = false;
        private Boolean isRequesting = false;
        private Boolean isTransferMission = false;
        private Queue<HttpRequestMission> missionQueue;
        private ThreadPoolWithLimit innerThreadPool;
        #endregion
        #region Current Queue Record
        private DateTime currentQueueStartTime;
        private int currentQueueCompleteMissionCount;
        private int currentQueueFailureMissionCount;
        private int currentQueueSuccessMissionCount;
        private long currentQueueTotalMissionTimeMSec;//当前任务队列的所有执行花费时间、平均时长*任务数
        #endregion
        public static Boolean NewQueue()
        {
            if (!_instance.isRequesting)
            {
                _instance.missionQueue = new Queue<HttpRequestMission>();
                _instance.currentQueueCompleteMissionCount = 0;
                _instance.currentQueueFailureMissionCount = 0;
                _instance.currentQueueSuccessMissionCount = 0;
                _instance.currentQueueTotalMissionTimeMSec = 0L;
                _instance.missionQueueReady = true;
                _instance.isTransferMission = true;
                return true;
            }
            else
                return false;
        }
        public static Boolean AddMission(String missionID, String httpFunc, String url, String content, Action<String, HttpStatusCode> callback)
        {
            if (_instance.missionQueueReady && _instance.isTransferMission)
            {
                _instance.missionQueue.Enqueue(_instance.createMission(missionID, httpFunc, url, content, callback));
                return true; ;
            }
            else
                return false;
        }
        public static void FinishAddMission()
        {
            _instance.isTransferMission = false;
        }
        public static Boolean StartRequest(int concurrency = 1)
        {
            if (_instance.missionQueueReady && !_instance.isRequesting)
            {
                _instance.innerThreadPool = new ThreadPoolWithLimit();
                _instance.innerThreadPool.maxThreadLimit = concurrency;
                _instance.innerThreadPool.StartRun(concurrency, 
                    () => {
                        return _instance.missionQueue.Count > 0 ? true : _instance.isTransferMission;
                    }, () => {
                        return _instance.missionQueue.Dequeue();
                }, (HttpRequestMission mission) => {

                }, (HttpRequestMission mission) => {

                });
             //   _instance
                return false;
            }
            else
                return false;
        }
        private HttpRequestMission createMission(String missionID, String httpFunc, String url, String content, Action<String, HttpStatusCode> callback)
        {
            HttpRequestMission result = new HttpRequestMission();
            result.retryTimes = 0;
            result.missionID = missionID;
            result.httpFunc = httpFunc;
            result.url = url;
            result.content = content;
            result.callback = callback;
            return result;
        }
        class HttpRequestMission
        {
            public int retryTimes = 0;
           
            public String missionID;
            public String httpFunc;
            public String url;
            public String content;
            public Action<String, HttpStatusCode> callback;
            public void Excute()
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(content);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "text/plain";
                //       request.ContentLength = byteArray.Length;
                Stream myRequestStream = request.GetRequestStream();
                myRequestStream.Write(byteArray, 0, byteArray.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                myRequestStream.Close();
                callback?.Invoke(retString, response.StatusCode);
            }
        }
        class ThreadPoolWithLimit
        {
            public int maxThreadLimit = 0;
            private int currentExcutingThread = 1;
            private Thread hostThread;
            public void StartRun(int max, Func<Boolean> ifContinueSource, Func<HttpRequestMission> missionSource,Action<HttpRequestMission> failureMissonThrowOut,Action<HttpRequestMission> successMissionThrowOut)
            {
                hostThread = new Thread(()=> {
                    while (ifContinueSource.Invoke())
                    {
                        if (currentExcutingThread < max)
                        {
                            HttpRequestMission missionDes = missionSource.Invoke();
                            Action<String, HttpStatusCode> originCallback = missionDes.callback;
                            missionDes.callback = (String resStr, HttpStatusCode code) => {
                                originCallback.Invoke(resStr, code);
                                if (code == HttpStatusCode.OK)
                                {
                                    successMissionThrowOut.Invoke(missionDes);
                                }
                                else
                                    failureMissonThrowOut.Invoke(missionDes);
                            };
                            Thread currentMission = new Thread(missionDes.Excute);
                            currentExcutingThread++;
                        }
                        Thread.Sleep(100);
                    }
                });
            }
        }
        struct HttpRequestResult
        {
            public String responseStr;
            public HttpStatusCode statusCode;
        }
    }
}
