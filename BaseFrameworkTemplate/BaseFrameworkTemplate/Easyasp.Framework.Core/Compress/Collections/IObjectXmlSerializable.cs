using System;
using System.Xml.Serialization;

namespace Easyasp.Framework.Core.Compress.Collections
{
    public interface IObjectXmlSerializable : IXmlSerializable
    {
        Type GetObjectType();
        object UnWrap();
        void Wrap(object obj);
    }
}