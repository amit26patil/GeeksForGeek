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

        }
    }
    public class MINHeap
    {

    }
    public class MAXHeap
    {
        private List<int> array;
        public void AddNum()
        {

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
            if(parent>=0 && array[i] < array[parent])
            {
                Swap(i, parent);
                Heapify(parent);
            }
        }
    }
}
