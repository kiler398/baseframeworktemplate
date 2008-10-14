using System.Collections;

namespace Easyasp.Framework.Core.Compress.Collections
{
    public interface ILink : IList, ICollection, IEnumerable
    {
        void AddRange(ICollection collection);
    }
}