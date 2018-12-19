using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeek.Heap
{
    class MedianInStream
    {
        public static void Main()
        {
            var leftHeap = new Heap(Heap.Type.Max);
            var rightHeap = new Heap(Heap.Type.Min);
            var top = leftHeap.GetTop();
            var array = new int[] { 2, 8, 3, 5, 16, 11, 15 };
            leftHeap.AddNum(array[0]);
            double median = array[0];
            Console.WriteLine(median);
            for (int i = 1; i < array.Length; i++)
            {
                var leftLength = leftHeap.Count;
                var rightLength = rightHeap.Count;
                var num = array[i];
                if (num < median)
                {
                    //Push To left
                    if (leftLength > rightLength)
                    {
                        //extract from left and push to right
                        var topNum = leftHeap.ExtractTop();
                        rightHeap.AddNum(topNum);
                        //then push num to left
                        leftHeap.AddNum(num);
                    }
                    else
                    {
                        //push num to left
                        leftHeap.AddNum(num);
                    }
                }
                else
                {
                    //push to left
                    if (leftLength < rightLength)
                    {
                        var topNum = rightHeap.ExtractTop();
                        leftHeap.AddNum(topNum);
                        rightHeap.AddNum(num);
                    }
                    else
                    {
                        rightHeap.AddNum(num);
                    }
                }
                median = GetMedian(leftHeap, rightHeap);
                Console.WriteLine(median);
            }

        }

        private static double GetMedian(Heap leftHeap, Heap rightHeap)
        {
            if (leftHeap.Count == rightHeap.Count)
                return (double)(leftHeap.GetTop() + rightHeap.GetTop()) / 2;
            else if (leftHeap.Count > rightHeap.Count)
                return leftHeap.GetTop();
            else
                return rightHeap.GetTop();
        }
    }
    public class Heap
    {

        private List<int> array;
        private Type type;
        public Heap(Type type)
        {
            this.type = type;
            array = new List<int>();
        }
        public enum Type
        {
            Min,
            Max
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetTop()
        {
            if (array.Count > 0)
            {
                return array[0];
            }
            return -1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        public void AddNum(int num)
        {
            array.Add(num);
            Heapify(array.Count-1);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ExtractTop()
        {
            Swap(0, array.Count-1);
            var temp = array[array.Count - 1];
            array.RemoveAt(array.Count - 1);
            Heapify(array.Count - 1);
            return temp;
        }
        public int Count
        {
            get
            {
                return array.Count;
            }
        }
        public void Swap(int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        public void Heapify(int i)
        {
            if (i <= 0)
            {
                return;
            }
            var parent = (i - 1) / 2;
            var comp = parent >= 0 && type == Type.Min ? array[i] < array[parent] : array[i] > array[parent];
            if (comp)
            {
                Swap(i, parent);
                Heapify(parent);
            }
        }
    }
}
