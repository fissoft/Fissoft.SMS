using System.Collections.Generic;
using System.Text;

namespace Fissoft.SMS.Core
{
    public static class ListExtension
    {
        public static string GetParamData<T>(this List<T> list, string objectName) where T : SendModel
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                builder.AppendFormat("{0}.index={1}&",objectName,i);
                builder.Append(list[i].GetParamData(string.Format("{0}[{1}].",objectName,i)));
                builder.Append("&");
            }
            if (builder.Length > 0)
                builder = builder.Remove(builder.Length - 1, 1);
            return builder.ToString();
        }
        public static string GetParamData(this List<int> list, string objectName) 
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                builder.AppendFormat("{0}[{1}]={2}&", objectName,i, list[i]);
            }
            if (builder.Length > 0)
                builder = builder.Remove(builder.Length - 1, 1);
            return builder.ToString();
        }
        
    }
}
