using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeek.Array
{
    class MaxOfMinEveryWindow
    {
        public static void Main()
        {
            var arr = new int[] { 10, 20, 30, 50, 25, 70, 30 };
            int[] tempArr = new int[arr.Length];
            
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                var n = GetNumCount(i, arr);
                if (tempArr[n] < arr[i])
                {
                    tempArr[n] = arr[i];
                }
            }
        }
        public static int GetNumCount(int index, int[] arr)
        {
            int current = arr[index];
            int i = index-1;
            int j = index+1;
            int cnt = 0;
            while (i >= 0)
            {
                var prev = arr[i];
                if (prev < current)
                {
                    break;
                }
                i--;
                cnt++;
            }
            while (j < arr.Length)
            {
                var next = arr[j];
                if (next < current)
                {
                    break;
                }
                j++;
                cnt++;
            }
            return cnt;
        }
    }
}
