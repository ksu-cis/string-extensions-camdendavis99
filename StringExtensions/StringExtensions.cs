using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods
{
    public static class StringExtensions
    {
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static string Capitalize(this String str)
        {
            if (str.Length > 0 && str[0] >= 'a' && str[0] <= 'z')
            {
                string first = str[0].ToString().ToUpper();
                return first + str.Substring(1);
            }
            return str;
        }

        // shit don't work
        public static void Decapitalize(this String str)
        {
            if (str.Length > 0 && str[0] >= 'A' && str[0] <= 'Z')
            {
                string first = str[0].ToString().ToLower();
                str = first + str.Substring(1);
            }
        }

        public static String Titleize(this String title)
        {
            if (title.WordCount() > 0)
            {
                List<string> articles = new List<string>()
                {
                    "a",
                    "an",
                    "the"
                };
                List<string> parts = new List<string>(title.Split(' '));
                string first = parts[0];
                if (articles.Contains(parts[0].ToLower()))
                {
                    parts.RemoveAt(0);
                    parts.Add(", " + first);
                    first = parts[0];
                    while (articles.Contains(first.ToLower()))
                    {
                        parts.RemoveAt(0);
                        parts.Add(first);
                        first = parts[0];
                    }
                }
                string result = "";
                foreach (string s in parts)
                {
                    result += s + " ";
                }
                return result;
            }
            return title;
        }
    }
}
