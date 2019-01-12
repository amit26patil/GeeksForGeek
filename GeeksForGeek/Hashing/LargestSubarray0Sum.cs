using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeek.Hashing
{
    /// <summary>
    /// Find the length of largest subarray with 0 sum
    /// Input: arr[] = {15, -2, 2, -8, 1, 7, 10, 23};
    /// Output: 5
    /// The largest subarray with 0 sum is -2, 2, -8, 1, 7
    /// </summary>
    class LargestSubarray0Sum
    {
        public static void Main()
        {
            var arr = new int[] { 15, -2, 2, -8, 1, 7, 10, 23 };
            var len = MaxLen(arr);
        }
        public static int MaxLen(int[] arr)
        {
            Dictionary<int, int> hash = new Dictionary<int, int>();
            int sum = 0;
            int maxLen = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                if(arr[i] == 0 && maxLen == 0)
                {
                    maxLen = 1;
                }
                if (sum == 0)
                {
                    maxLen = Math.Max(maxLen, i + 1);
                }
                if (hash.ContainsKey(sum))
                {
                    maxLen = Math.Max(maxLen, i - hash[sum]);
                }
                else
                {
                    hash.Add(sum, i);
                }
            }
            return maxLen;
        }
    }
}
