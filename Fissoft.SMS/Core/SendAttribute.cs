using System;

namespace Fissoft.SMS.Core
{
    /// <summary>
    /// 发送Model属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class SendAttribute:Attribute
    {
        public string ParamName {get; private set;}
        public SendAttribute(string paramName)
        {
            this.ParamName = paramName;
        }      
    }
}
