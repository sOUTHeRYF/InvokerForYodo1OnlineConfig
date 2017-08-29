using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
namespace Yodo1OnlineConfigCaller
{
    public class ServiceCaller
    {
        private static readonly ServiceCaller _instance = new ServiceCaller();

        private TaskFactory<ResponseDefine> taskFactory = new TaskFactory<ResponseDefine>();
        private HttpClient innerClient = new HttpClient();
        private int CurrentTaskIndex = 0;
        public enum Domains
        {
            LOCALHOST = 0,
            DEV = 1,
            PROD = 2
        };
        public static void MakeMultiAddConfigSync(Domains domain, String game_appkey, String prefixOfKey , String prefixOfDes, int startIndexOfKey, int times, Action<String> perCallback)
        {
            if (!String.IsNullOrWhiteSpace(game_appkey) && times > 0)
            {
                string domainURL = "";
                switch (domain)
                {
                    case Domains.DEV: domainURL = DOMAIN_OLCONFIG_132; break;
                    case Domains.LOCALHOST: domainURL = DOMAIN_OLCONFIG_LOCAL; break;
                    case Domains.PROD: domainURL = DOMAIN_OLCONFIG_PROD; break;
                }
                for (int i= startIndexOfKey; i< times+ startIndexOfKey; i++)
                {
                    _instance.CurrentTaskIndex++;
                    String type = DataSource.GetRandomType();
                   AddConfigSync(
                        domainURL,
                        game_appkey, 
                        prefixOfKey + "_" +i,
                        DataSource.GetRandomValue(type),
                        type,
                        prefixOfDes + "_" +i ,
                        perCallback);
                    _instance.CurrentTaskIndex--;
                }
            }
        }
        public static void MakeMultiAddConfig(Domains domain, String game_appkey, String prefixOfKey, String prefixOfDes, int startIndexOfKey, int times, Action<String> perCallback)
        {
            if (!String.IsNullOrWhiteSpace(game_appkey) && times > 0)
            {
                string domainURL = "";
                switch (domain)
                {
                    case Domains.DEV: domainURL = DOMAIN_OLCONFIG_132; break;
                    case Domains.LOCALHOST: domainURL = DOMAIN_OLCONFIG_LOCAL; break;
                    case Domains.PROD: domainURL = DOMAIN_OLCONFIG_PROD; break;
                }
                for (int i = startIndexOfKey; i < times + startIndexOfKey; i++)
                {
                    _instance.CurrentTaskIndex++;
                    String type = DataSource.GetRandomType();
                    ResponseDefine result = AddConfig(
                        domainURL,
                        game_appkey,
                        prefixOfKey + "_" + i,
                        DataSource.GetRandomValue(type),
                        type,
                        prefixOfDes + "_" + i);
                    _instance.CurrentTaskIndex--;
                    perCallback?.Invoke("Task<" + _instance.CurrentTaskIndex + ">__" + game_appkey + ":Add=>" + prefixOfKey + "_" + i + ":" + result.ToCustomStr());
                }
            }
        }
        public static async Task MakeMultiModifyConfig(Domains domain, String game_appkey, int startIndexOfKey, int countOfKey, int perKeyTimes, Action<String> perCallback)
        {
            if (!String.IsNullOrWhiteSpace(game_appkey) && countOfKey > 0)
            {
                string domainURL = "";
                switch (domain)
                {
                    case Domains.DEV: domainURL = DOMAIN_OLCONFIG_132; break;
                    case Domains.LOCALHOST: domainURL = DOMAIN_OLCONFIG_LOCAL; break;
                    case Domains.PROD: domainURL = DOMAIN_OLCONFIG_PROD; break;
                }
                _instance.CurrentTaskIndex++;
                ResponseDefine listRes = await GetConfigList(domainURL, game_appkey);
                _instance.CurrentTaskIndex--;
                List<String> keys = GetKeys(listRes);
                for (int i = startIndexOfKey; i < countOfKey + startIndexOfKey; i++)
                {
                    String randomKey = keys.RandomPop();
                    String type = DataSource.GetRandomType();
                    if (!String.IsNullOrWhiteSpace(randomKey))
                    {
                        for (int j = 0; j < perKeyTimes; j++)
                        {
                            _instance.CurrentTaskIndex++;
                            ResponseDefine result = await ModifyConfig(
                                        domainURL,
                                        game_appkey,
                                        randomKey,
                                        DataSource.GetRandomValue(type),
                                        DataSource.GetRandomChannel(),
                                        DataSource.GetRandomVersion());
                            _instance.CurrentTaskIndex--;
                            perCallback?.Invoke("Task<" + _instance.CurrentTaskIndex + ">__" + game_appkey + ":Modify=>" + randomKey + "_" + i + ":" + result.ToCustomStr());
                        }
                    }
                }
            }
        }
        public static async Task MakeMultiGetConfig(Domains domain, String game_appkey, String channel, String version, Action<String> perCallback)
        {
            if (!String.IsNullOrWhiteSpace(game_appkey))
            {
                string domainURL = "";
                switch (domain)
                {
                    case Domains.DEV:domainURL = DOMAIN_OLCONFIG_132;break;
                    case Domains.LOCALHOST:domainURL = DOMAIN_OLCONFIG_LOCAL;break;
                    case Domains.PROD:domainURL = DOMAIN_OLCONFIG_PROD;break;
                }
                ResponseDefine result = await GetConfigData(
                        domainURL,
                        game_appkey,
                        channel,
                        version);
                    perCallback?.Invoke(game_appkey + ":Get=>" + channel + "@" + version + ":" + result.ToFullStr());
            }
        }
       /* public static async Task MakeModifyConfig(String game_appkey, String data_key, String channel, String version, int times, Action<String> perCallback)
        {
            if (!String.IsNullOrWhiteSpace(game_appkey) && times > 0)
            {
                for (int i = 0; i < times; i++)
                {
                    String type = DataSource.GetRandomType();
                    String result = await ModifyConfig(
                        game_appkey,
                        data_key,
                        DataSource.GetRandomValue(type),
                        channel,
                        version);
                    perCallback?.Invoke(game_appkey + ":Modify=>" + data_key + "_" + i + ":" + result);
                }
            }
        }*/
        #region OnlineConfig Services
        private static readonly String DOMAIN_OLCONFIG_132 = @"http://192.168.1.132:8083/config";
        private static readonly String DOMAIN_OLCONFIG_LOCAL = @"http://localhost:8080/config";
        private static readonly String DOMAIN_OLCONFIG_PROD = @"http://onlineconfig.yodo1api.com/config";
        private static readonly String URL_OLCONFIG_ADD = @"/add";
        private static readonly String URL_OLCONFIG_MODIFY = @"/modify";
        private static readonly String URL_OLCONFIG_GET_LIST = @"/getList";
        private static readonly String URL_OLCONFIG_GET_DATA = @"/getData";

        private static readonly String PARAM_SIGN = @"sign";
        private static readonly String PARAM_GAME_APPKEY = @"game_appkey";
        private static readonly String PARAM_CHANNEL = @"channel";
        private static readonly String PARAM_VERSION = @"version";
        private static readonly String PARAM_DATA = @"data";
        private static readonly String PARAM_DATA_KEY = @"data_key";
        private static readonly String PARAM_DATA_VALUE = @"data_value";
        private static readonly String PARAM_DATA_TYPE = @"data_type";
        private static readonly String PARAM_DATA_DES = @"data_des";
        private static readonly String PARAM_DATA_IDENTIFER = @"data_identifer";

        private static readonly String RES_PARAM_ERROR_CODE = @"error_code";
        private static readonly String RES_PARAM_MSG = @"error";
        private static readonly String RES_PARAM_DATA = @"data";
        private static async Task AddConfigSync(String domain, String game_appkey, String data_key, String data_value, String data_type, String data_des,Action<String> callback)
        {
            ResponseDefine result = new ResponseDefine();
            Dictionary<String, Object> postData = new Dictionary<string, object>();
            Dictionary<String, Object> postDataOfData = new Dictionary<string, object>();
            postDataOfData[PARAM_DATA_KEY] = data_key;
            postDataOfData[PARAM_DATA_VALUE] = data_value;
            postDataOfData[PARAM_DATA_TYPE] = data_type;
            postDataOfData[PARAM_DATA_DES] = data_des;
            postData[PARAM_GAME_APPKEY] = game_appkey;
            postData[PARAM_DATA] = postDataOfData;
            postData[PARAM_SIGN] = "123456";
            StringContent content = new StringContent(JSONHelper.Serialize(postData));
            try
            {
                DateTime preTime = System.DateTime.Now;
                HttpResponseMessage response = await _instance.innerClient.PostAsync(domain + URL_OLCONFIG_ADD,content);
                result = await GetResponseInfoSync(response, preTime,DataType.NULL);
            }
            catch (Exception e)
            {
                result.msg = "服务器异常";
            }
            if (null != callback)
            {
                callback.Invoke("Task<" + _instance.CurrentTaskIndex + ">__" + game_appkey + ":Add=>" + data_key + ":" + result.ToCustomStr());
            }
        }
        private static  ResponseDefine AddConfig(String domain, String game_appkey, String data_key, String data_value, String data_type, String data_des)
        {
            ResponseDefine result = new ResponseDefine();
            Dictionary<String, Object> postData = new Dictionary<string, object>();
            Dictionary<String, Object> postDataOfData = new Dictionary<string, object>();
            postDataOfData[PARAM_DATA_KEY] = data_key;
            postDataOfData[PARAM_DATA_VALUE] = data_value;
            postDataOfData[PARAM_DATA_TYPE] = data_type;
            postDataOfData[PARAM_DATA_DES] = data_des;
            postData[PARAM_GAME_APPKEY] = game_appkey;
            postData[PARAM_DATA] = postDataOfData;
            postData[PARAM_SIGN] = "123456";
            try
            {
                DateTime preTime = System.DateTime.Now;
                HttpWebResponse response = HttpPost(domain + URL_OLCONFIG_ADD, JSONHelper.Serialize(postData));
                result =  GetResponseInfo(response, preTime, DataType.NULL);
            }
            catch (Exception e)
            {
                result.msg = "服务器异常";
            }
            return result;
        }
        private static async Task<ResponseDefine> ModifyConfig(String domain, String game_appkey, String data_key, String data_value, String channel, String version)
        {
            ResponseDefine result = new ResponseDefine();
            Dictionary<String, Object> postData = new Dictionary<string, object>();
            Dictionary<String, Object> postDataOfData = new Dictionary<string, object>();
            postDataOfData[PARAM_DATA_KEY] = data_key;
            postDataOfData[PARAM_DATA_VALUE] = data_value;
            postData[PARAM_GAME_APPKEY] = game_appkey;
            postData[PARAM_CHANNEL] = channel;
            postData[PARAM_VERSION] = version;
            postData[PARAM_DATA] = postDataOfData;
            postData[PARAM_SIGN] = "123456";
            StringContent content = new StringContent(JSONHelper.Serialize(postData));
            try
            {
                DateTime preTime = System.DateTime.Now;
                HttpResponseMessage response = await _instance.innerClient.PostAsync(domain + URL_OLCONFIG_MODIFY, content);
                result = await GetResponseInfoSync(response, preTime,DataType.NULL);
            }
            catch (Exception e)
            {
                result.msg = "服务器异常";
            }
            return result;
        }
        private static async Task<ResponseDefine> GetConfigList(String domain, String game_appkey)
        {
            ResponseDefine result = new ResponseDefine();
            Dictionary<String, Object> postData = new Dictionary<string, object>();
            Dictionary<String, Object> postDataOfData = new Dictionary<string, object>();
            postData[PARAM_GAME_APPKEY] = game_appkey;
            postData[PARAM_DATA] = postDataOfData;
            postData[PARAM_SIGN] = "123456";
            StringContent content = new StringContent(JSONHelper.Serialize(postData));
            try
            {
                DateTime preTime = System.DateTime.Now;
                HttpResponseMessage response = await _instance.innerClient.PostAsync(domain + URL_OLCONFIG_GET_LIST, content);
                result = await GetResponseInfoSync(response, preTime,DataType.LIST);
            }
            catch (Exception e)
            {
                result.msg = "服务器异常";
            }
            return result;
        }
        private static async Task<ResponseDefine> GetConfigData(String domain, String game_appkey, String channel, String version)
        {
            ResponseDefine result = new ResponseDefine();
            Dictionary<String, Object> postData = new Dictionary<string, object>();
            postData[PARAM_GAME_APPKEY] = game_appkey;
            postData[PARAM_CHANNEL] = channel;
            postData[PARAM_VERSION] = version;
            postData[PARAM_DATA_IDENTIFER] = "0";
            postData[PARAM_SIGN] = "123456";
            StringContent content = new StringContent(JSONHelper.Serialize(postData));
            try
            {
                DateTime preTime = System.DateTime.Now;
                HttpResponseMessage response = await _instance.innerClient.PostAsync(domain + URL_OLCONFIG_GET_DATA, content);
                result = await GetResponseInfoSync(response, preTime, DataType.DIC);
            }
            catch (Exception e)
            {
                result.msg = "服务器连接异常";
            }
            return result;
        }
        private static List<string> GetKeys(ResponseDefine res)
        {
            List<String> result = new List<string>();
            foreach (Object indexObj in res.listData)
            {
                Dictionary<string, Object> perConfig = (Dictionary<string, Object>)indexObj;
                result.Add((string)perConfig[PARAM_DATA_KEY]);
            }
            return result;
        }

        private static HttpWebResponse HttpPost(string Url, string postDataStr)
        {
            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(postDataStr);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "POST";
                request.ContentType = "text/plain";
         //       request.ContentLength = byteArray.Length;
                Stream myRequestStream = request.GetRequestStream();
                myRequestStream.Write(byteArray, 0, byteArray.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                myRequestStream.Close();
                return response;
            }
            catch (Exception e)
            {
                return null;
            }
     
            /*
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;*/
        }
        private static async Task<ResponseDefine> GetResponseInfoSync(HttpResponseMessage res,DateTime preTime, DataType dataType)
        {
            try
            {
                ResponseDefine result = new ResponseDefine();
                String resultStr = await res.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine(resultStr);
                Dictionary<string, object> resultBody = (Dictionary<string, object>)JSONHelper.Deserialize(resultStr);
                int timeDuration = (int)(System.DateTime.Now - preTime).TotalMilliseconds;
                result.duration = timeDuration;
                result.error_code = (string)resultBody[RES_PARAM_ERROR_CODE];
                result.msg = resultBody.ContainsKey(RES_PARAM_MSG) ? (string)resultBody[RES_PARAM_MSG] : "";
                result.httpCode = (int)res.StatusCode;
                switch (dataType)
                {
                    case DataType.LIST: result.listData = (List<Object>)resultBody[RES_PARAM_DATA]; break;
                    case DataType.DIC: result.objData = (Dictionary<string, Object>)resultBody[RES_PARAM_DATA]; break;
                }
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
      
        }
        private static  ResponseDefine GetResponseInfo(HttpWebResponse res, DateTime preTime, DataType dataType)
        {
            ResponseDefine result = new ResponseDefine();
            Stream myResponseStream = res.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            System.Diagnostics.Debug.WriteLine(retString);
            Dictionary<string, object> resultBody = (Dictionary<string, object>)JSONHelper.Deserialize(retString);
            int timeDuration = (int)(System.DateTime.Now - preTime).TotalMilliseconds;
            result.duration = timeDuration;
            result.error_code = (string)resultBody[RES_PARAM_ERROR_CODE];
            result.msg = resultBody.ContainsKey(RES_PARAM_MSG) ? (string)resultBody[RES_PARAM_MSG] : "";
            result.httpCode = (int)res.StatusCode;
            switch (dataType)
            {
                case DataType.LIST: result.listData = (List<Object>)resultBody[RES_PARAM_DATA]; break;
                case DataType.DIC: result.objData = (Dictionary<string, Object>)resultBody[RES_PARAM_DATA]; break;
            }
            return result;
        }
        #endregion

    }
}
