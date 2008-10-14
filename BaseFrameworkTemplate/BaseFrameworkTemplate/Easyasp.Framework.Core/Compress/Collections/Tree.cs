namespace Easyasp.Framework.Core.Compress.Collections
{
    public class Tree : TreeBase
    {
        public Tree() : this(null)
        {
        }

        public Tree(object root) : base(new TreeNode(root))
        {
        }
    }
}