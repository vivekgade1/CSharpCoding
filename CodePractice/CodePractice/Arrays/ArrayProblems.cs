namespace CodePractice.Arrays
{
    public class ArrayProblems
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="A">array of integers</param>
        /// <param name="K">integer in </param>
        /// <returns></returns>
        public int TwoSumLessThanK(int[] A, int K)
        {
            int result = -1;
            int sum = -1;
            for(int i = 0;i < A.Length ; i++) 
            {
                for (int j = i + 1; j < A.Length; j++)
                {
                    sum = A[i] + A[j];
                    if (sum > result &&  sum < K)
                    {
                        result = sum;
                    }
                }
            }
            return result;
        }        
    }
}