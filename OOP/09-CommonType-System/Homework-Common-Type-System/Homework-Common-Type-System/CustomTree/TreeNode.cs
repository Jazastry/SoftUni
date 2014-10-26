using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTree
{
    class TreeNode<T>
    {
        public T Node { get; private set; }
    
        public TreeNode(T node)
        {
            this.Node = node;
        }

        public TreeNode()
        {
            
        } 
    }
}
