using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket_Management_system.Core
{
    public class BinarySearchTree
    {

        private TreeNode root;

        public void Insert(string name, string value)
        {
            root = InsertHelper(root, name, value);
        }

        private TreeNode InsertHelper(TreeNode current, string name, string value)
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
        public string Search(string name)
        {
            return SearchHelper(root, name);
        }

        private string SearchHelper(TreeNode current, string name)
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
    }
}
    
