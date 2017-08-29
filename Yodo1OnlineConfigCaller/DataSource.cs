using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yodo1OnlineConfigCaller
{
    public class DataSource
    {
        private String[] innerChannelList = new string[] {
            "UC","360","AppStore","91","ANZHI","OPPO","WANDOUJIA","JinShan","BAIDU","XIAOMI","lenovo","iapppay","CMCC","MUZHIWAN","GooglePlay","Default"
        };
        private String[] innerVersionList = new string[] {
            "1.0.0","1.0.1","1.2.0","2.0.1","1.0.5","1.3.4","1.3.0","1.2.4","2.0.0","3.1.0","Default"
        };
        private String[] innerTypeList = new string[] {
            "Bool","Int","String"
        };

        private static char[] constant =
      {
            '0','1','2','3','4','5','6','7','8','9',
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
            '_','-','=','&','%','#','@','*'
      };
        private int countOfChannelList = 16;
        private int countOfVersionList = 11;
        private int countOfTypeList = 3;

        private static readonly DataSource _instance = new DataSource();


        private static int getRandomInt(int start = 0, int end = 2)
        {
            Random ran = new Random(System.DateTime.Now.Millisecond);
            int RandKey = ran.Next(start, end);
            return RandKey;
        }
        public static String GetRandomChannel()
        {
            return _instance.innerChannelList[(getRandomInt(0, _instance.countOfChannelList))];
        }
        public static String GetRandomVersion()
        {
            return _instance.innerVersionList[(getRandomInt(0, _instance.countOfVersionList))];
        }
        public static String GetRandomType()
        {
            return _instance.innerTypeList[(getRandomInt(0, _instance.countOfTypeList))];
        }
        public static String GetRandomIntValue(int start, int end)
        {
            return getRandomInt(start, end).ToString();
        }
        public static String GetRandomStrValue(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(62);
            Random rd = new Random(System.DateTime.Now.Millisecond);
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(70)]);
            }
            return newRandom.ToString();
        }
        public static String GetRandomBoolValue()
        {
            return (getRandomInt(0, 10) == 0).ToString();
        }
        public static String GetRandomValue(String type)
        {
            switch (type)
            {
                case "Bool":return GetRandomBoolValue();
                case "Int":return GetRandomIntValue(0, 100000);
                case "String":return GetRandomStrValue(getRandomInt(0,20));
                default:return "error msg";
            }
        }
    }
}
