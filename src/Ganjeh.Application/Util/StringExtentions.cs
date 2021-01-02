using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Ganjeh.Application.Util
{
    public static class StringExtentions
    {
        public static string ToJsonString<T>(this T obj)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj, settings);
        }
        public static string SafeReplace(this string input, string find, string replace, bool matchWholeWord = true)
        {
            string textToFind = matchWholeWord ? string.Format(@"\b{0}\b", find) : find;
            return Regex.Replace(input, textToFind, replace);
        }
        public static string EscapeSQLInjection(this string input)
        {
            return input
                .Replace("'", "''")
                ;
        }
        public static string FixPersianNumbers(this string input)
        {
            return (input ?? string.Empty)
                .Replace("۰", "0")
                .Replace("۱", "1")
                .Replace("۲", "2")
                .Replace("۳", "3")
                .Replace("۴", "4")
                .Replace("۵", "5")
                .Replace("۶", "6")
                .Replace("۷", "7")
                .Replace("۸", "8")
                .Replace("۹", "9")
                ;
        }
    }
}