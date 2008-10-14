using Easyasp.Framework.Core.Compress.Collections;

namespace Easyasp.Framework.Core.Compress.Collections
{
    public interface ITree
    {
        ITreeNode[] Find(object obj, TreeTraversal traversal);
        ITreeNode[] Traversal(TreeTraversal traversal);

        ITreeNode Root { get; }
    }
}