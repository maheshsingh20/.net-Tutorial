using System;

namespace DataStructures.CustomDS
{
    public class TreeNode<T> where T : IComparable<T>
    {
        public T Data { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
        
        public TreeNode(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }
    
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;
        
        public BinarySearchTree()
        {
            root = null;
        }
        
        public void Insert(T data)
        {
            root = InsertRec(root, data);
        }
        
        private TreeNode<T> InsertRec(TreeNode<T> node, T data)
        {
            if (node == null)
            {
                return new TreeNode<T>(data);
            }
            
            if (data.CompareTo(node.Data) < 0)
            {
                node.Left = InsertRec(node.Left, data);
            }
            else if (data.CompareTo(node.Data) > 0)
            {
                node.Right = InsertRec(node.Right, data);
            }
            
            return node;
        }
        
        public bool Search(T data)
        {
            return SearchRec(root, data);
        }
        
        private bool SearchRec(TreeNode<T> node, T data)
        {
            if (node == null) return false;
            
            if (data.CompareTo(node.Data) == 0) return true;
            
            if (data.CompareTo(node.Data) < 0)
                return SearchRec(node.Left, data);
            else
                return SearchRec(node.Right, data);
        }
        
        public void InOrder()
        {
            Console.Write("InOrder: ");
            InOrderRec(root);
            Console.WriteLine();
        }
        
        private void InOrderRec(TreeNode<T> node)
        {
            if (node != null)
            {
                InOrderRec(node.Left);
                Console.Write(node.Data + " ");
                InOrderRec(node.Right);
            }
        }
        
        public void PreOrder()
        {
            Console.Write("PreOrder: ");
            PreOrderRec(root);
            Console.WriteLine();
        }
        
        private void PreOrderRec(TreeNode<T> node)
        {
            if (node != null)
            {
                Console.Write(node.Data + " ");
                PreOrderRec(node.Left);
                PreOrderRec(node.Right);
            }
        }
        
        public void PostOrder()
        {
            Console.Write("PostOrder: ");
            PostOrderRec(root);
            Console.WriteLine();
        }
        
        private void PostOrderRec(TreeNode<T> node)
        {
            if (node != null)
            {
                PostOrderRec(node.Left);
                PostOrderRec(node.Right);
                Console.Write(node.Data + " ");
            }
        }
        
        public static void Demo()
        {
            Console.WriteLine("\n=== Binary Search Tree Demo ===");
            
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            
            bst.Insert(50);
            bst.Insert(30);
            bst.Insert(70);
            bst.Insert(20);
            bst.Insert(40);
            bst.Insert(60);
            bst.Insert(80);
            
            bst.InOrder();
            bst.PreOrder();
            bst.PostOrder();
            
            Console.WriteLine($"\nSearch 40: {bst.Search(40)}");
            Console.WriteLine($"Search 100: {bst.Search(100)}");
        }
    }
}
