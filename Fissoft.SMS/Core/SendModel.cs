using System;
using System.ComponentModel;
using System.Text;
using System.Web;

namespace Fissoft.SMS.Core
{
    /// <summary>
    /// 发送Model基类
    /// </summary>
    public abstract class SendModel
    {
        
        public string GetParamData(string perfix = "")
        {
            StringBuilder builder = new StringBuilder();
            var fromProperties = TypeDescriptor.GetProperties(this);
            foreach (PropertyDescriptor fromProperty in fromProperties)
            {        
                object fromValue = fromProperty.GetValue(this);
                string fromValueStr;
                if(fromValue==null)
                    fromValueStr = string.Empty;
                else if(fromValue is Enum)
                    fromValueStr = ((int)fromValue).ToString();
                else if(fromValue is DateTime)
                    fromValueStr = Convert.ToDateTime(fromValue).ToString("yyyy-MM-dd HH:mm:ss");
                else
                    fromValueStr = fromValue.ToString();

                fromValueStr = HttpUtility.UrlEncode(fromValueStr);

                SendAttribute sendAttribute = fromProperty.Attributes[typeof(SendAttribute)] as SendAttribute;
                if (sendAttribute != null)
                    builder.AppendFormat("{2}{0}={1}&", sendAttribute.ParamName, fromValueStr, perfix);
                else
                    builder.AppendFormat("{2}{0}={1}&", fromProperty.Name, fromValueStr, perfix);
            }
            if (builder.Length > 0)
                builder = builder.Remove(builder.Length - 1, 1);

            return builder.ToString();
        }
    }
}
