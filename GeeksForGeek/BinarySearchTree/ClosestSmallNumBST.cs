using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeek.BinarySearchTree
{
    class ClosestSmallNumBST
    {
        static void Main1(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();
            bst.Add(10);
            bst.Add(16);
            bst.Add(13);
            bst.Add(6);
            bst.Add(8);
            bst.Add(9);
            bst.Add(1);
            BinarySearchTree.Node lastSmall = new BinarySearchTree.Node(int.MinValue);
            FindClosest(18, bst.Root, ref lastSmall);
        }
        public static void FindClosest(int num,BinarySearchTree.Node node, ref BinarySearchTree.Node lastSmallNode)
        {
            if (node != null)
            {
                if (node.Data == num)
                {
                    lastSmallNode = node;
                }
                if (node.Data > num)
                {
                    FindClosest(num, node.Left, ref lastSmallNode);
                }
                else
                {
                    if (lastSmallNode.Data < node.Data)
                    {
                        lastSmallNode = node;
                    }
                    FindClosest(num, node.Right, ref lastSmallNode);
                }
            }
        }
    }


}
