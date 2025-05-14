using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PowerLibrary.Boolean
{
    public class PowerBoolean
    {
        private string message;
        private string trace;

        public PowerBoolean(string msg = "")
        {
            message = msg;
            Result = false;
            trace = "";
            ExceptionInfo = null;
        }

        public PowerBoolean(bool result = true, string msg = "")
        {
            Result = result;
            message = msg;
            trace = "";
            ExceptionInfo = null;
        }

        public PowerBoolean(Exception e)
        {
            Result = false;
            message = e.Message;
            trace = e.StackTrace;
            ExceptionInfo = e;
        }

        [XmlIgnore]
        public Exception ExceptionInfo { get; set; }

        [XmlAttribute]
        [DefaultValue("")]
        public string Message
        {
            get => message ?? "";
            set => message = value;
        }

        [XmlAttribute]
        public bool Result { get; set; }

        [XmlAttribute]
        [DefaultValue("")]
        public string Trace
        {
            get => trace ?? "";
            set => trace = value;
        }

        public bool Equals(PowerBoolean other)
        {
            return string.Equals(message, other.message) && Result == other.Result;
        }

        public override bool Equals(object obj)
        {
            return obj != null && obj is PowerBoolean other && Equals(other);
        }

        public override int GetHashCode()
        {
            string message = this.message;
            return (message != null ? message.GetHashCode() : 0) * 397 ^ Result.GetHashCode();
        }

        public static implicit operator bool(PowerBoolean value) => value.Result;

        public static implicit operator PowerBoolean(string value) => new PowerBoolean(value);

        public static implicit operator PowerBoolean(bool value) => new PowerBoolean(value);

        public static implicit operator string(PowerBoolean value) => value.Message;

        public static bool operator ==(PowerBoolean x, PowerBoolean y) => x.Result == y.Result;

        public static string operator +(PowerBoolean x, PowerBoolean y) => x.ToString() + y.ToString();

        public static bool operator !=(PowerBoolean x, PowerBoolean y) => x.Result != y.Result;

        public PowerBoolean OnFailure(Action<PowerBoolean> resultMethod)
        {
            if (!Result)
                resultMethod(this);
            return this;
        }

        public PowerBoolean OnSuccess(Action<PowerBoolean> resultMethod)
        {
            if (Result)
                resultMethod(this);
            return this;
        }
    }
}
