using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerLibrary.Extensions
{
    public static class CollectionExtension
    {
        public static bool IsNullOrEmpty<T>(this ICollection<T> value) =>  value == null || value.Count == 0;

        public static bool IsNotNullOrEmpty<T>(this ICollection<T> value) =>  !IsNullOrEmpty(value);
    }
}
