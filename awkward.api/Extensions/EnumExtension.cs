using System;
using System.Collections.Generic;
using System.Linq;

namespace awkward.api.Extensions
{
    public static class EnumExtension
    {
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static object TryParseDefault<T>(this string valueToParse, bool ignoreCase = true)
        {
            object result = default(T);

            if (Enum.IsDefined(typeof(T), valueToParse))
            {
                result = Enum.Parse(typeof(T), valueToParse, ignoreCase);
            }

            return result;
        }

        public static object TryParseDefault<T>(this int valueToParse)
        {
            var result = Enum.GetName(typeof(T), valueToParse);

            return result.TryParseDefault<T>();
        }
    }
}
