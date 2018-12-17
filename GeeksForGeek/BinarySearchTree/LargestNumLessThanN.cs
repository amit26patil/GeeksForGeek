using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeek.BinarySearchTree
{
    /// <summary>
    /// Largest number less than or equal to N 
    /// </summary>
    class LargestNumLessThanN
    {
        static void Main1(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();
            bst.Add(5);
            bst.Add(12);
            bst.Add(21);
            bst.Add(25);
            bst.Add(16);
            bst.Add(19);
            bst.Add(9);
            bst.Add(2);
            bst.Add(3);
            bst.Add(1);
            int minNum = int.MinValue;
            GetLargest(bst.Root, 17, ref minNum);
        }
        static void GetLargest(BinarySearchTree.Node node, int n, ref int minNum)
        {
            if (node)
            {
                if (node <= n)
                {
                    if (minNum < node)
                    {
                        minNum = node;
                    }
                    GetLargest(node.Right, n, ref minNum);
                }
                else if(node > n)
                {
                    GetLargest(node.Left, n, ref minNum);
                }
            }
            return;
        }
    }
}
