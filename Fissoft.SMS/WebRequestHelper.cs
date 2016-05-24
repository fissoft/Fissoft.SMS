using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace Fissoft.SMS
{
    internal static class WebRequestHelper
    {
        public static string GetRequestHtml(string urlString, Encoding encoding, int tryNum = 3)
        {
            return WebRequestHelper.GetRequestHtml(urlString, encoding, string.Empty, tryNum);
        }

        public static string GetRequestHtml(string urlString, Encoding encoding, string referer, int tryNum = 3)
        {
            bool flag = false;
            int num = 0;
            HttpWebRequest httpWebRequest = (HttpWebRequest)null;
            string str = "";
            while (num < tryNum && !flag)
            {
                try
                {
                    httpWebRequest = WebRequest.Create(urlString) as HttpWebRequest;
                    httpWebRequest.Timeout = 10000;
                    httpWebRequest.Method = "GET";
                    httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";
                    if (!string.IsNullOrEmpty(referer))
                        httpWebRequest.Referer = referer;
                    str = new StreamReader(httpWebRequest.GetResponse().GetResponseStream(), encoding).ReadToEnd();
                    flag = true;
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ExceptionExcensions.GetMessages(ex) + urlString);
                    Thread.Sleep(num * 200);
                    flag = false;
                }
                finally
                {
                    ++num;
                    if (httpWebRequest != null)
                        httpWebRequest.Abort();
                }
            }
            return str;
        }

        public static string Post(string urlString, string postData, Encoding encoding, int tryNum = 3)
        {
            return WebRequestHelper.Post(urlString, postData, encoding, string.Empty, tryNum);
        }

        public static string Post(string urlString, string postData, Encoding encoding, string referer, int tryNum = 3)
        {
            byte[] bytes = encoding.GetBytes(postData);
            bool flag = false;
            int num = 0;
            HttpWebRequest httpWebRequest = (HttpWebRequest)null;
            string str = "";
            while (num < tryNum && !flag)
            {
                try
                {
                    ServicePointManager.Expect100Continue = false;
                    httpWebRequest = WebRequest.Create(urlString) as HttpWebRequest;
                    httpWebRequest.CookieContainer = new CookieContainer();
                    httpWebRequest.AllowAutoRedirect = true;
                    httpWebRequest.ProtocolVersion = HttpVersion.Version10;
                    httpWebRequest.Method = "POST";
                    httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                    httpWebRequest.ContentLength = (long)bytes.Length;
                    httpWebRequest.Timeout = 10000;
                    if (!string.IsNullOrEmpty(referer))
                        httpWebRequest.Referer = referer;
                    httpWebRequest.ReadWriteTimeout = 10000;
                    try
                    {
                        using (Stream requestStream = ((WebRequest)httpWebRequest).GetRequestStream())
                        {
                            requestStream.Write(bytes, 0, bytes.Length);
                            requestStream.Close();
                        }
                    }
                    catch
                    {
                        using (Stream requestStream = ((WebRequest)httpWebRequest).GetRequestStream())
                        {
                            requestStream.Write(bytes, 0, bytes.Length);
                            requestStream.Close();
                        }
                    }
                    StreamReader streamReader;
                    using (streamReader = new StreamReader((httpWebRequest.GetResponse() as HttpWebResponse).GetResponseStream(), encoding))
                    {
                        str = streamReader.ReadToEnd();
                        streamReader.Close();
                    }
                    flag = true;
                }
                catch (Exception ex)
                {
                   //Console.WriteLine(ExceptionExcensions.GetMessages(ex) + urlString);
                    Thread.Sleep(num * 200);
                    flag = false;
                }
                finally
                {
                    ++num;
                    if (httpWebRequest != null)
                        httpWebRequest.Abort();
                }
            }
            return str;
        }
        public static Stream GetFileStream(string urlString)
        {
            try
            {
                return WebRequest.Create(urlString).GetResponse().GetResponseStream();
            }
            catch
            {
                return (Stream)null;
            }
        }

        public static string Head(string urlString, Encoding encoding, int tryNum = 3)
        {
            return WebRequestHelper.Head(urlString, encoding, string.Empty, tryNum);
        }

        public static string Head(string urlString, Encoding encoding, string referer, int tryNum = 3)
        {
            bool flag = false;
            int num = 0;
            HttpWebRequest httpWebRequest = (HttpWebRequest)null;
            string str = "";
            while (num < tryNum && !flag)
            {
                try
                {
                    httpWebRequest = WebRequest.Create(urlString) as HttpWebRequest;
                    httpWebRequest.Timeout = 10000;
                    httpWebRequest.Method = "Head";
                    httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";
                    if (!string.IsNullOrEmpty(referer))
                        httpWebRequest.Referer = referer;
                    str = new StreamReader(httpWebRequest.GetResponse().GetResponseStream(), encoding).ReadToEnd();
                    flag = true;
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ExceptionExcensions.GetMessages(ex) + urlString);
                    Thread.Sleep(num * 200);
                    flag = false;
                }
                finally
                {
                    ++num;
                    if (httpWebRequest != null)
                        httpWebRequest.Abort();
                }
            }
            return str;
        }
    }
}