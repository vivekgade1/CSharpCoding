using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CodePractice.Strings
{
    public class PStrings
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            string[] input = new[] {"a1 9 2 3 1","g1 act car","zo4 4 7","ab1 off key dog","a8 act zoo"};
            Console.WriteLine(PStrings.LogsCompare(input));
        }
        
        /// <summary>
        /// Compares two list of strings lexographically.
        /// </summary>
        /// <returns>list of strings.</returns>
        public static string[] LogsCompare(string[] logs)
        {
            Array.Sort(logs, (s1, s2) =>
            {
                string[] splitS1 = s1.Split(" ");
                string[] splitS2 = s2.Split(" ");
                bool s1FirstIsDigit = Char.IsDigit(splitS1[1][0]);
                bool s2FirstIsDigit = Char.IsDigit(splitS2[1][0]);
                if (!s1FirstIsDigit && !s2FirstIsDigit)
                {
                    int cmp = 0,i = 1;
                    int minLength = splitS1.Length <= splitS2.Length ? splitS1.Length : splitS2.Length;
                    while (cmp == 0 && i < minLength)
                    {
                        cmp = String.CompareOrdinal(splitS1[i], splitS2[i]);
                        if (cmp != 0) return cmp;
                        i++;
                    }

                    if (splitS1.Length < splitS2.Length)
                    {
                        return -1;
                    }

                    return String.CompareOrdinal(splitS1[0], splitS2[0]);;
                }
                return s1FirstIsDigit ? (s2FirstIsDigit ? 1 : 1) : -1;

            });
            return logs;
        }
    }
}