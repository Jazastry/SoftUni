using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTree
{
    internal class BinarySearchTree<T> : IEnumerable<TreeNode<T>>
    {
        private TreeNode<T> CurrentNode { get; set; }

        private List<TreeNode<T>> nodesList { get; set; }

        public BinarySearchTree()
        {
        }

        public void Add(TreeNode<T> nodeToAdd)
        {
            this.nodesList.Add(nodeToAdd);
        }

        public void Remove(TreeNode<T> nodeToRemove)
        {
            
        }

        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            foreach (TreeNode<T> node in nodesList)
            {
                yield return node;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool Search(TreeNode<T> treeNodeToSearchFor)
        {
            TreeNode<T> currentNode = new TreeNode<T>();
            while ()
            {
                
            }
        }
    }
}