using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeek.ArrayProblems
{
    /// <summary>
    /// Duplicates in an array in O(n) and by using O(1) extra space | Set-2
    /// https://www.geeksforgeeks.org/duplicates-array-using-o1-extra-space-set-2/
    /// </summary>
    class DuplicatesInOofN
    {
        public static void Main1()
        {
            var array = new int[] { 1, 6, 3, 1, 6, 4, 5};
            var n = array.Length;
            for (int i = 0; i < n; i++)
            {
                var index = array[i] % n;
                array[index] += n; 
            }
            for (int i = 0; i < n; i++)
            {
                if (array[i] / n > 1)
                {
                    Console.Write(i+" ");
                }
            }
        }
    }
}
