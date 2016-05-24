 using System.ComponentModel;

namespace Fissoft.SMS.Core
{
    /// <summary>
    /// 短信发送类别
    /// </summary>
    public enum SMSSendType
    {
        [Description("文本")]
        Text = 1,
        [Description("彩信")]
        Multimedia = 2
    }
}