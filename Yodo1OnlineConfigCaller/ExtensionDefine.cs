using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yodo1OnlineConfigCaller
{
    public static class ExtensionDefine
    {
        public static T RandomPop<T>(this List<T> aim)
        {
            if (aim.Count > 0)
            {
                Random ran = new Random();
                int RandKey = ran.Next(0, aim.Count);
                T result = aim[RandKey];
                aim.RemoveAt(RandKey);
                return result;
            }
            else
                return default(T);
        }
    }
}
