using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeek.Tree
{
    /// <summary>
    /// Print Left View Of Tree
    /// </summary>
    class PrintLeftViewTree
    {
        static int maxLevel = 0;
        static void Main1(string[] args)
        {
            var tree = new BinaryTree(1);
            tree.Root.Left = new BinaryTree.Node(2);
            tree.Root.Right = new BinaryTree.Node(3);
            tree.Root.Left.Right = new BinaryTree.Node(4);
            var node = tree.Root.Right.Right = new BinaryTree.Node(5);
            node.Right = new BinaryTree.Node(6);
            PrintLeftView(tree.Root, 1);
        }

        private static void PrintLeftView(BinaryTree.Node node, int level)
        {
            if (node != null)
            {
                if (maxLevel < level)
                {
                    Console.Write($"{node.Data}=>");
                    maxLevel = level;
                }
                PrintLeftView(node.Left, level + 1);
                PrintLeftView(node.Right, level + 1);
            }
        }
    }
    public class BinaryTree
    {
        public BinaryTree(int num)
        {
            Root = new Node(num);
        }
        public class Node
        {
            public Node(int data)
            {
                Data = data;
            }
            public int Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public override string ToString()
            {
                return Data.ToString();
            }
        }
        public Node Root { get; set; }
    }
}
