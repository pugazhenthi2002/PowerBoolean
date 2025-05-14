using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerLibrary.Extensions
{
    public static class StringExtension
    {
        public static bool IsNullOrEmpty(this string value) => value == null || value.Length == 0;

        public static bool IsNotNullOrEmpty(this string value) => !IsNullOrEmpty(value);
    }
}
