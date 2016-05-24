using Fissoft.SMS.Core;

namespace Fissoft.SMS
{
    public class SMSAccountInfoModel : SendModel
    {
        public string UserName { get; set; }        
        public string OperId { get; set; }        
        public int SMSNum { get; set; }        
        public int EmergentSMSNum { get; set; }       
        public int IsEnable { get; set; }       
    }
}
