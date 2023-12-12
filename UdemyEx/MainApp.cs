using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Console;

namespace UdemyEx
{
    internal class MainApp
    {
        static void Main(string[] args)
        {
            var result = charCount("Hello, World!");

            foreach (var v in result)
            {
                Console.WriteLine("{0}: {1} ", v.Key,v.Value);
            }
        }

        private static Dictionary<char, int> charCount(string s)
        {
            String sl = s.ToLower();
            Regex reg = new Regex(@"[^a-zA-Z0-9가-힣]");

            //\s 는 공백을 의미 함
            //String rs = Regex.Replace(sl, @"[^a-zA-Z0-9가-힣\s]", "");
            //String rs = Regex.Replace(sl, @"[^a-zA-Z0-9가-힣]", "");

            //rs = String.Concat(rs.OrderBy(ch => ch));

            sl = sl.Sort();

            var result = new Dictionary<char,int>();

            //for (var i = 0; i < rs.Length; i++)
            for(var i = 0; i < sl.Length; i++)
            {
                //var ch = rs[i];
                var ch = sl[i];

                //if(reg.IsMatch(ch.ToString()) == false)
                if(isAlphaNumeric(ch.ToString()))
                {
                    if (result.ContainsKey(ch))
                    {
                        result[ch]++;
                    }
                    else
                    {
                        result.Add(ch, 1);
                    }
                }    
/*
                if(result.ContainsKey(ch))
                {
                    result[ch]++;
                }
                else
                {
                    result.Add(ch, 1);
                }
*/
            }

            return result;
        }

        public static bool isAlphaNumeric(string s)
        {
            for(var i = 0; i < s.Length; i++)
            {
                var code = (int)s[i];

                if(!(code > 47 && code < 58) && // numeric(0-9)
                   !(code > 64 && code < 91) && // upper alpha (A-Z)
                   !(code > 96 && code < 123))  // lower alpha (a-z)
                {
                    return false;
                }
            }

            return true;
        }
    }

    public static class StringExtensions
    {
        public static String Sort(this String input)
        {
            char[] chars = input.ToCharArray();
            Array.Sort(chars);
            return new String(chars);
        }
    }


}