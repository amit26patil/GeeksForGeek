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

            leftHeap.AddNum(5);
            leftHeap.AddNum(10);
            leftHeap.AddNum(3);
            var top = leftHeap.GetTop();

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
        public int GetTop()
        {
            if (array.Count > 0)
            {
                return array[0];
            }
            return -1;
        }
        public void AddNum(int num)
        {
            array.Add(num);
            Heapify(array.Count-1);
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
