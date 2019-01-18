using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeek.Tree.ConnectNodesSameLevel
{
    class ConnectNodesSameLevel
    {
        public static void Main1()
        {
            var tree = new BinaryTree(10);
            tree.Root.Left = new BinaryTree.Node(3);
            tree.Root.Right = new BinaryTree.Node(5);
            tree.Root.Left.Right = new BinaryTree.Node(1);
            tree.Root.Left.Left = new BinaryTree.Node(4);
            var node = tree.Root.Right.Right = new BinaryTree.Node(2);
            Connect(tree);
        }
        public static void Connect(BinaryTree tree)
        {
            //var left = tree.Root.Left;
            //var right = tree.Root.Right;
            //if (left != null)
            //{
            //    left.NextRight = right;
            //}
            var right = Connect(tree.Root, true);
            var nodes = new List<BinaryTree.Node>() { tree.Root };
            var childNodes = GetChildren(nodes);
            while (childNodes.Count > 0)
            {
                if (childNodes.Count > 1)
                {
                    for (int i = 1; i < childNodes.Count; i++)
                    {
                        childNodes[i - 1].NextRight = childNodes[i];
                    }
                }
                childNodes = GetChildren(childNodes);
            }

        }
        public static List<BinaryTree.Node> GetChildren(List<BinaryTree.Node> nodes)
        {
            List<BinaryTree.Node> childNodes = new List<BinaryTree.Node>();
            foreach (var node in nodes)
            {
                if (node.Left != null)
                {
                    childNodes.Add(node.Left);
                }
                if (node.Right != null)
                {
                    childNodes.Add(node.Right);
                }
            }
            return childNodes;
        }
        public static BinaryTree.Node Connect(BinaryTree.Node node, bool fromLeft = false)
        {
            if (node == null)
                return node;
            BinaryTree.Node tempNode = null;
            if (fromLeft)
            {
                tempNode = node.Left;
                if (node.Right != null)
                {
                    tempNode = node.Right;
                }
            }
            else
            {
                tempNode = node.Right;
                if (node.Left != null)
                {
                    tempNode = node.Left;
                }
            }
            if (node.Left != null)
            {
                node.Left.NextRight = node.Right;
            }
            var childRightNode = Connect(node.Left, true);
            if (childRightNode != null)
            {
                var childLeftNode = Connect(node.Right);
                childRightNode.NextRight = childLeftNode;
            }
            return tempNode;
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
            public Node NextRight { get; set; }
            public override string ToString()
            {
                return Data.ToString();
            }
        }
        public Node Root { get; set; }
    }
}
