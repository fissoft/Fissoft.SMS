using Fissoft.SMS.Core;

namespace Fissoft.SMS
{
    public class SMSSendModel : SendModel
    {
        public string ServiceKey { get; set; }
        public string UniqueKey { get; set; }
        /// <summary>
        /// UnixTime.FromDateTime
        /// </summary>
        public long? SendTime { get; set; }
        public string AppendId { get; set; }
        public string Mobiles { get; set; }
        public string Message { get; set; }
        public int? Weight { get; set; }
        public SMSSendType? SendType { get; set; }
    }
}
