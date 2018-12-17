using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeek.BinarySearchTree
{
    /// <summary>
    /// Root to leaf path sum equal to a given number in BST
    /// </summary>
    class RootToLeafPathSum
    {
        static void Main1(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();
            bst.Add(45);
            bst.Add(50);
            bst.Add(38);
            bst.Add(52);
            bst.Add(55);
            bst.Add(51);
            bst.Add(47);
            bst.Add(48);
            bst.Add(46);
            bst.Add(41);
            bst.Add(44);
            bst.Add(40);
            bst.Add(33);
            bst.Add(35);
            bst.Add(31);
            var isEx = isPathExists(bst.Root, 195);
        }
        static bool isPathExists(BinarySearchTree.Node node, int sum)
        {
            if (node)
            {
                var isLeaf = isLeafNode(node);
                if (isLeaf && sum - node == 0)
                {
                    return true;
                }
                else if(isLeaf && sum - node != 0)
                {
                    return false;
                }
                var isEx = isPathExists(node.Right, sum - node);
                if (!isEx)
                {
                    return isPathExists(node.Left, sum - node);
                }
                else
                {
                    return true;
                }
                //if (node.Right && node.Right <= sum - node)
                //{
                //    return isPathExists(node.Right, sum - node);
                //}
                //else if (node.Left && node.Left <= sum - node)
                //{
                //    return isPathExists(node.Left, sum - node);
                //}
            }
            return false;
        }
        static bool isLeafNode(BinarySearchTree.Node node)
        {
            return !node.Right && !node.Left;
        }
    }
}
