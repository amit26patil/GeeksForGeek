using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeek.Tree
{
    /// <summary>
    /// 
    /// </summary>
    class PrintTopViewTree
    {
        private class TreeNode
        {
            public TreeNode(BinaryTree.Node node, int breadth)
            {
                this.Node = node;
                this.BreadthLevel = breadth;
            }
            public BinaryTree.Node Node { get; set; }
            public int BreadthLevel { get; set; }
        }
        public static void Main()
        {
            BinaryTree tree = new BinaryTree(1);
            tree.Root.Left = new BinaryTree.Node(2);
            tree.Root.Right = new BinaryTree.Node(3);
            tree.Root.Left.Right = new BinaryTree.Node(4);
            tree.Root.Left.Right.Right = new BinaryTree.Node(5);
            tree.Root.Left.Right.Right.Right = new BinaryTree.Node(6);
            PrintTopView(tree);
        }
        public static void PrintTopView(BinaryTree tree)
        {
            Dictionary<int, TreeNode> hashMap = new Dictionary<int, TreeNode>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(new TreeNode(tree.Root, 0));
            while (queue.Count > 0)
            {
                var tempNode = queue.Dequeue();

                if (!hashMap.ContainsKey(tempNode.BreadthLevel))
                {
                    hashMap.Add(tempNode.BreadthLevel, tempNode);
                }
                if (tempNode.Node.Left != null)
                {
                    queue.Enqueue(new TreeNode(tempNode.Node.Left, tempNode.BreadthLevel + 1));
                }
                if (tempNode.Node.Right != null)
                {
                    queue.Enqueue(new TreeNode(tempNode.Node.Right, tempNode.BreadthLevel - 1));
                }
            }
            foreach (var hash in hashMap)
            {
                Console.WriteLine($"{hash.Value.Node.Data}=>");
            }

        }
    }
}
