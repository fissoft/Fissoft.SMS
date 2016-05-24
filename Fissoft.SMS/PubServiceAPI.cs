using System.Collections.Generic;
using Fissoft.SMS.Core;
using Newtonsoft.Json;

namespace Fissoft.SMS
{
    public class PubServiceAPI : APIBase
    {
        public JsonReturn SMSSend(SMSPassModel smsPassModel, SMSSendModel smsSendModel)
        {
            var apiUrl = GetAPIUrl("PubService", "SMSSend");
            string postData = $"{smsPassModel.GetParamData()}&{smsSendModel.GetParamData()}";
            return Post(apiUrl, postData);
        }

        public JsonReturn SMSBatchSend(SMSPassModel smsPassModel, List<SMSSendModel> smsSendList)
        {
            var apiUrl = GetAPIUrl("PubService", "SMSBatchSend");
            string postData = $"{smsPassModel.GetParamData()}&{smsSendList.GetParamData("smsSendList")}";
            return Post(apiUrl, postData);
        }

        public JsonReturn SMSAccountInfo(SMSPassModel smsPassModel, out SMSAccountInfoModel smsAccountInfo)
        {
            var apiUrl = GetAPIUrl("PubService", "SMSAccountInfo");
            var postData = smsPassModel.GetParamData();

            var jsonReturn = Post(apiUrl, postData);
            if (jsonReturn != null)
                smsAccountInfo = jsonReturn.GetValue<SMSAccountInfoModel>();
            else
                smsAccountInfo = null;
            return jsonReturn;
        }

        public JsonReturn SMSRecPeek(SMSPassModel smsPassModel, out SMSReceivesModel smsRecs)
        {
            var apiUrl = GetAPIUrl("PubService", "SMSRecPeek");
            var postData = smsPassModel.GetParamData();
            var jsonReturn = Post(apiUrl, postData);
            if (jsonReturn != null)
                smsRecs = JsonConvert.DeserializeObject<SMSReceivesModel>(jsonReturn.Value);
            else
                smsRecs = null;
            return jsonReturn;
        }

        public JsonReturn SMSRecMarkRead(SMSPassModel smsPassModel, List<int> smsRecIdList)
        {
            var apiUrl = GetAPIUrl("PubService", "SMSRecMarkRead");
            string postData = $"{smsPassModel.GetParamData()}&{smsRecIdList.GetParamData("smsRecIdList")}";
            return Post(apiUrl, postData);
        }
    }
}