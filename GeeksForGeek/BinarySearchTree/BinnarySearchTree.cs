using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeek.BinarySearchTree
{
    class BinarySearchTree
    {
        public Node Root { get; set; }
        public BinarySearchTree()
        {

        }

        public void Add(int data)
        {
            if (Root == null)
            {
                Root = new Node(data);
                return;
            }
            var node = Root;
            while (node != null)
            {
                if (node.Data < data)
                {
                    if(node.Right == null)
                    {
                        node.Right = new Node(data);
                        return;
                    }
                    else
                    {
                        node = node.Right;
                    }                    
                }
                else if (node.Data > data)
                {
                    if (node.Left == null)
                    {
                        node.Left = new Node(data);
                        return;
                    }
                    else
                    {
                        node = node.Left;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        public bool IsLeafNode(Node node)
        {
            return node.Right == null && node.Left==null;
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
            public static implicit operator bool(Node node)
            {
                return node != null;
            }
            public static implicit operator int(Node node)
            {
                if (node)
                {
                    return node.Data;
                }
                return 0;
            }
            public bool isLeafNode()
            {
                return !Right && !Left;
            }
        }
    }
}
