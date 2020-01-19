using System;
using System.Collections.Generic;
using System.Text;

namespace CodePractice.Google
{
    public class Problems
    {
        /* **************
         * Compare Strings by Frequency of the Smallest Character
         ****************/
        public int[] NumSmallerByFrequency(string[] queries, string[] words)
        {
            int[] result = new int[queries.Length];
            int queriesWordCount = 0;
            int wordsWordCount = 0;
            for (int i = 0; i < queries.Length; i++)
            {
                queriesWordCount = this.GetHighestFrequency(queries[i]);
                wordsWordCount = this.GetHighestFrequency(words[i]);
                result[i] = queriesWordCount < wordsWordCount ? queriesWordCount : wordsWordCount;
            }

            return result;
        }

        public int GetHighestFrequency(string word)
        {
            int result = 0;
            Dictionary<char, int> alphaMap = new Dictionary<char, int>();
            string alphabets = "abcdefghijklmnopqrstuvwxyz";
            for (int indx = 0; indx <alphabets.Length; indx++)
            {
                alphaMap.Add(alphabets[indx], 0);
            }

            for (int pos = 0; pos < word.Length; pos++)
            {
                if (alphaMap.ContainsKey(word[pos]))
                {
                    alphaMap[word[pos]]++;
                    if (result < alphaMap[word[pos]])
                    {
                        result = alphaMap[word[pos]];
                    }
                }
            }

            return result;
        }
        /*
         *
         * 
         */
        public string LicenseKeyFormatting(string inputStr, int noOfGrp)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder filteredStr = new StringBuilder();
            for (int i = 0; i < inputStr.Length; i++)
            {
                if (!inputStr[i].Equals('-'))
                {
                    filteredStr.Append(inputStr[i]);
                }
            }
            
            int crrtSize = filteredStr.Length;
            int firstGroupSize = crrtSize % noOfGrp != 0 ? crrtSize % noOfGrp : noOfGrp;
            result.Append(filteredStr.ToString().Substring(0,firstGroupSize));
            result.Append('-');
            
            for (int i = firstGroupSize ; i < filteredStr.Length; i++)
            {
                if ( ((i - firstGroupSize  - 1) % noOfGrp) == 0)
                {
                    result.Append('-');
                }
                else
                {
                    if (Char.IsLower(filteredStr[i]))
                    {
                        result.Append(Char.ToUpper(filteredStr[i]));
                    }
                    else
                    {
                        result.Append(filteredStr[i]);
                    }
                }
                
                
            }

            return result.ToString();
        }
    }
}