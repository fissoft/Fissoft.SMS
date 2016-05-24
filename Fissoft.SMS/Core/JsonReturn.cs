using Newtonsoft.Json;

namespace Fissoft.SMS.Core
{
    public class JsonReturn
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public string Value { get; set; } 
        
        public JsonReturn()
        {
        }
        public JsonReturn(int code, string msg)
        {
            this.Code = code;
            this.Msg = msg;
        }
        public JsonReturn(int code, string msg, object value)
        {
            SetCodeMsg(code, msg, value);
        }
        public void SetCodeMsg(int code, string msg, object value)
        {
            this.Code = code;
            this.Msg = msg;
            this.Value = JsonConvert.SerializeObject(value);
        }
        public void SetCodeMsg(int code, string msg, string value)
        {
            this.Code = code;
            this.Msg = msg;
            this.Value =value;
        }
        public void SetCodeMsg(int code, string msg)
        {
            this.Code = code;
            this.Msg = msg;
        }

        public T GetValue<T>() where T:class,new()
        {
            if (string.IsNullOrEmpty(Value))
                return null;
            else
            {
                return JsonConvert.DeserializeObject<T>(Value);
            }
        }
        public override string ToString()
        {
            return string.Format("Code:{0},Msg:{1},Value:{2}", Code, Msg,Value);
        }
    }
}