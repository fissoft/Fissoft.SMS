using System.Collections.Generic;
using Fissoft.SMS.Core;

namespace Fissoft.SMS
{

    public class SMSReceivesModel : SendModel
    {
        public List<SMSReceiveModel> SMSReceives { get; set; }
    }

    public class SMSReceiveModel : SendModel
    {
        public int Id { get; set; }
        public string SMSOperId { get; set; }
        public string SrcMobile { get; set; }
        public string AppendID { get; set; }
        public string ShortAppendID { get; set; }
        public string Content { get; set; }
        /// <summary>
        /// UnixTime.FromDateTime
        /// </summary>
        public long? RecvTime { get; set; }
        public long? ReadTime { get; set; }
        public long AddTime { get; set; }
        public int IsRead { get; set; }
    }
}
