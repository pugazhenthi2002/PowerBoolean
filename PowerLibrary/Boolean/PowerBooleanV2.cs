using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PowerLibrary.Boolean
{
    public class PowerBoolean<T> : IEquatable<PowerBoolean<T>>
    {
        private string message;
        private string trace;

        public PowerBoolean(string msg = "")
        {
            message = msg;
            Result = false;
            Value = default(T);
            trace = "";
            ExceptionInfo = null;
        }

        public PowerBoolean(bool result = true, string msg = "")
        {
            Result = result;
            message = msg;
            Value = default(T);
            trace = "";
            ExceptionInfo = null;
        }

        public PowerBoolean(T value, bool result = true, string msg = "")
        {
            Result = result;
            message = msg;
            Value = value;
            trace = "";
            ExceptionInfo = null;
        }

        public PowerBoolean(Exception e)
        {
            Result = false;
            message = e.Message;
            Value = default(T);
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
        public T Value { get; set; }

        [XmlAttribute]
        [DefaultValue("")]
        public string Trace
        {
            get => trace ?? "";
            set => trace = value;
        }

        public bool Equals(PowerBoolean<T> other) => string.Equals(message, other.message) && Result == other.Result && other.GetType() == GetType()
            && EqualityComparer<T>.Default.Equals(Value, other.Value);

        public override bool Equals(object obj) => obj != null && obj is PowerBoolean other && Equals(other);

        public override int GetHashCode()
        {
            string message = this.message;
            return (message != null ? message.GetHashCode() : 0) * 397 ^ this.Result.GetHashCode();
        }

        public static implicit operator bool(PowerBoolean<T> value) => value.Result;

        public static implicit operator string(PowerBoolean<T> value) => value.Message;

        public static implicit operator T(PowerBoolean<T> value) => value.Value;

        public static implicit operator PowerBoolean<T>(T value) => new PowerBoolean<T>(value);

        public static implicit operator PowerBoolean<T>(string message) => new PowerBoolean<T>(message);

        public static implicit operator PowerBoolean<T>(bool result) => new PowerBoolean<T>(result);

        public static implicit operator PowerBoolean(PowerBoolean<T> value) => new PowerBoolean(value.Result, value.Message);

        public static implicit operator PowerBoolean<T>(PowerBoolean value) => new PowerBoolean<T>(default(T), value.Result, value.Message);

        public static bool operator ==(PowerBoolean<T> x, PowerBoolean<T> y) => x.Result == y.Result;

        public static string operator +(PowerBoolean<T> x, PowerBoolean<T> y) => x.ToString() + y.ToString();

        public static bool operator !=(PowerBoolean<T> x, PowerBoolean<T> y) => x.Result != y.Result;

        public override string ToString() => this.Message;
    }
}
