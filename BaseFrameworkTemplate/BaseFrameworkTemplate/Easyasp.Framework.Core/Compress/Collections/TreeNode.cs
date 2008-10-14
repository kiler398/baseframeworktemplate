using System;

namespace Easyasp.Framework.Core.Compress.Collections
{
    public class TreeNode : TreeNodeBase
    {
        public TreeNode() : this(null)
        {
        }

        public TreeNode(object obj)
        {
            base.pvalue = obj;
        }

        public void Add(TreeNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }
            base.AddNode(node);
        }

        public virtual TreeNode Add(object obj)
        {
            TreeNode node = new TreeNode(obj);
            this.Add(node);
            return node;
        }

        public virtual void Remove(TreeNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }
            base.RemoveNode(node);
        }
    }
}