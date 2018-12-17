using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeek.Heap
{
    class KthLargestNumInArray
    {
        public static void Main1()
        {
            var array = new int[] { 10, 15, 18, 5, 6, 9, 20 };
            var tempArray = new int[array.Length];
            Array.Copy(array, tempArray, array.Length);

            var maxHeap = new MaxHeap();
            var max = maxHeap.GetMax(array, 3);
        }
    }
    public class MaxHeap
    {
        public int GetMax(int[] arr, int n)
        {
            for (int j = 0; j < n; j++)
            {
                for (int i = (arr.Length / 2)-1; i >= 0; i--)
                {
                    Heapify(arr, i);
                }
                if (j != n - 1)
                {
                    arr[0] = int.MinValue;
                }
            }
            
            return arr[0];
        }
        private void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        public void Heapify(int[] arr, int i)
        {
            var left = 2 * i + 1;
            var right = left + 1;
            var maxNumIndex = i;
            if(left<arr.Length && arr[left] > arr[maxNumIndex])
            {
                maxNumIndex = left;
            }
            if (right < arr.Length && arr[right] > arr[maxNumIndex])
            {
                maxNumIndex = right;
            }
            if (maxNumIndex != i)
            {
                Swap(arr, maxNumIndex, i);
            }
        }
    }
}
