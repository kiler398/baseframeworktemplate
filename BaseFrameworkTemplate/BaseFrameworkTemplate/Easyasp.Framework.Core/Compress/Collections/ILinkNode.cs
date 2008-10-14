namespace Easyasp.Framework.Core.Compress.Collections
{
    public interface ILinkNode
    {
        ILinkNode Next { get; set; }

        object Value { get; set; }
    }
}