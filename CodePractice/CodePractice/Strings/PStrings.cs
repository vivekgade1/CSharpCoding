using System;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;

namespace CodePractice.Strings
{
    public class PStrings
    {
        /*/// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            string[] input = new[] {"baaba"};
            Console.WriteLine(new PStrings().LongestPalindrome("baaba"));
        }*/

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
                    int cmp = 0, i = 1;
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

                    return String.CompareOrdinal(splitS1[0], splitS2[0]);
                    ;
                }

                return s1FirstIsDigit ? (s2FirstIsDigit ? 1 : 1) : -1;

            });
            return logs;
        }

        /// <summary>
        /// Longest palindrome string.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public string LongestPalindrome(string inputString)
        {
            int size = inputString.Length;
            int start = 0, end = 0, maxLen = 0;
            for (int i = 0; i < size; i++)
            {
                int evenLen= this.CheckPalindrome(inputString, i,i+1); 
                int oddLen = this.CheckPalindrome(inputString, i, i);

                if (oddLen > evenLen && maxLen < oddLen)
                {
                    start = i - (oddLen / 2);;
                    end = i + (oddLen / 2);
                    maxLen = oddLen;
                }
                else if(oddLen < evenLen && maxLen < evenLen)
                {
                    start = i - ((evenLen / 2) - 1);
                    end = i + (evenLen / 2);
                    maxLen = oddLen;
                }
            }

            return inputString.Substring(start, end);
        }

        private int CheckPalindrome(string input, int start, int end)
        {
            while (start >0 && end< input.Length && input[start].Equals(input[end]))
            {
                start--;
                end++;
            }
            return end - start + 1 ;
        }
    }
}