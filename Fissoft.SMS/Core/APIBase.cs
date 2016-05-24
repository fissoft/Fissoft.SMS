using System;
using System.Configuration;
using System.Text;
using Newtonsoft.Json;

namespace Fissoft.SMS.Core
{
    public abstract class APIBase
    {
        public static readonly string apiBaseUrl;
        /// <summary>
        /// 服务基础地址
        /// sys:APIBaseUrl
        /// </summary>
        public virtual string APIBaseUrl => apiBaseUrl;

        static APIBase()
        {
            apiBaseUrl = ConfigurationManager.AppSettings["sys:APIBaseUrl"];
            if (string.IsNullOrWhiteSpace(apiBaseUrl))
                throw new InvalidOperationException("请先设置 appSetting 'sys:APIBaseUrl'");
        }

        /// <summary>
        /// 获取服务地址
        /// </summary>
        /// <param name="apiRoute">"/PubService/SMSSend"</param>
        /// <returns>服务全地址</returns>
        public string GetAPIUrl(string apiRoute)
        {
            if (apiRoute.StartsWith("http://"))
                return apiRoute;
            string url = APIBaseUrl.Trim().TrimEnd('/');
            apiRoute = apiRoute.Trim().TrimStart('/');

            return $"{url}/{apiRoute}";
        }

        /// <summary>
        /// 获取服务地址
        /// </summary>
        /// <param name="controller">controller</param>
        /// <param name="actionName">actionName</param>
        /// <returns>服务全地址</returns>
        public string GetAPIUrl(string controller, string actionName)
        {
            string url = APIBaseUrl.Trim().TrimEnd('/');
            return $"{url}/{controller}/{actionName}";
        }

        public JsonReturn Post(string apiUrl, string postData)
        {
            Encoding encoding = Encoding.UTF8;
            return Post(apiUrl, postData, encoding);
        }
       
        public JsonReturn Post(string apiUrl, string postData, Encoding encoding, int tryNum=1)
        {
            string responseMsg = WebRequestHelper.Post(apiUrl, postData, encoding, tryNum);
            if (responseMsg == null)
                return null;
            else
                return JsonConvert.DeserializeObject<JsonReturn>(responseMsg);
        }
    }
}
