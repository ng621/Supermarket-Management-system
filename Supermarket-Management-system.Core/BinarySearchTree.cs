using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket_Management_system.Core
{
    public class BinarySearchTree
    {

        private TreeNode root;

        public void Insert(string name, Product value)
        {
            root = InsertHelper(root, name, value);
        }

        private TreeNode InsertHelper(TreeNode current, string name, Product value)
        {

            if (current == null)
            {
                TreeNode newNode = new TreeNode();

                newNode.Name = name;

                newNode.Value = value;
                return newNode;
            }

            int compare = string.Compare(name, current.Name);

            if (compare < 0)
            {
                current.Left = InsertHelper(current.Left, name, value);
            }
            else if (compare > 0)
            {
                current.Right = InsertHelper(current.Right, name, value);
            }

            return current;
        }
        public Product Search(string name)
        {
            return SearchHelper(root, name);
        }

        private Product SearchHelper(TreeNode current, string name)
        {
             if (current == null)
            {
                return null;
            }

            int compare = string.Compare(name, current.Name);

            if (compare == 0)
            {
                return current.Value;
            }
            else if (compare < 0)
            {
                return SearchHelper(current.Left, name);

            }
            else
            {
                return SearchHelper(current.Right, name);
            }
        }

        public List<Product> InOrder()
        {
            List<Product> results = new List<Product>();
            InOrderHelper(root, results);
            return results;
        }

        private void InOrderHelper(TreeNode current,List<Product> results)
        {
            if (current == null)
            {
                return;
            }
            InOrderHelper(current.Left, results);
            results.Add(current.Value);
            InOrderHelper(current.Right, results);
        }
    }
}
    
