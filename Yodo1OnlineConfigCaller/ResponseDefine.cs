using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yodo1OnlineConfigCaller
{
    public class ResponseDefine
    {
        public String error_code = "0";
        public String msg = "";
        public int duration = 0;
        public int httpCode = 404;
        public List<Object> listData = new List<object>();
        public Dictionary<String, Object> objData = new Dictionary<string, object>();

        public String ToCustomStr()
        {
            return "[" + error_code + "]:[" + msg + "]" + "  <"+ httpCode +"> = "+duration+ "ms";
        }
        public String ToFullStr()
        {
            String result =  "[" + error_code + "]:[" + msg + "]" + "  <" + httpCode + "> = " + duration + "ms" + System.Environment.NewLine;
            foreach (KeyValuePair<String, Object> indexer in objData)
            {
                result += indexer.Key + ":" + indexer.Value.ToString() + System.Environment.NewLine;
            }
            return result;
        }
    }
    public enum DataType
    {
        NULL = 0,
        LIST = 1,
        DIC =2
    };
}
