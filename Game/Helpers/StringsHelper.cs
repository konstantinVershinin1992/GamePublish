using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text.RegularExpressions;

namespace TestProData.Helpers
{
    public static class StringsHelper
    {
        public static String F(this String format, params Object[] args)
        {
            return String.Format(format, args);
        }

        public static String RemoveHtmlTags(string text)
        {
            var reg = new Regex("<(.|\n)*?>", RegexOptions.IgnoreCase);
            var str = reg.Replace(text, "");
            return str.Replace("&nbsp;", " ");
        }

        public static String GetSymbols(String text, Int32 length)
        {
            if (text.Length > length)
            {
                text = text.Substring(0, length) + "...";
            }
            return text;
        }

        public static string GetYoutubeId(string frame)
        {
            var str = @"www.youtube.com/embed/";
            var firstIndex = frame.IndexOf(str);
            
            if (firstIndex > 0)
            {
                var strRes = frame.Substring(str.Length + firstIndex);
                var lastIndex = strRes.IndexOf('"');
                var finalRes = strRes.Substring(0,lastIndex);
                return finalRes;
            }
            return "";
        }


        public static string SetTagBr(string source , int num)
        {
            
            if (!string.IsNullOrEmpty(source))
            {

                var str = source.Split(' ').ToList();
                str.Add(" ");
                var curStr = "";
                for (var i = 0; i < str.Count() - 1; i++)
                {
                    curStr += str[i] + " ";
                    var curRow = curStr.LastIndexOf("<br/>");
                    if (curRow > 0)
                    {
                        if ((curStr.Substring(curRow) + str[i + 1]).Length > num)
                            curStr += "<br/>";
                    }
                    else
                    {
                        if ((curStr + str[i + 1]).Length > num)
                            curStr += "<br/>";
                    }
                }


                return curStr;
            }
            return null;
        }



       /* public static string GetWord (string Key,IEnumerable<Word> words )
        {
            var firstOrDefault = words.FirstOrDefault(w => w.Key.Equals(Key, StringComparison.InvariantCultureIgnoreCase));
            if (firstOrDefault != null)
            {
                var word = firstOrDefault.Value;
                return word;
            }
            return "Not Found The Word";
        }*/
    }
}