using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;
using Spring.Data.Generic;

namespace Easyasp.Framework.Core.Intergration.Springs
{
    public class BaseSpringAdoDao<DomainType> : AdoDaoSupport, IGenericDao<DomainType>
    {
        public List<DomainType> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public List<DomainType> FindAll(int firstRow, int maxRows)
        {
            throw new System.NotImplementedException();
        }

        public DomainType Load(object id)
        {
            throw new System.NotImplementedException();
        }

        public void Load(DomainType instance, object id)
        {
            throw new System.NotImplementedException();
        }

        public void Save(DomainType instance)
        {
            throw new System.NotImplementedException();
        }

        public void SaveOrUpdate(DomainType instance)
        {
            throw new System.NotImplementedException();
        }

        public void PartUpdate(DomainType instance, object id, string[] updatePropertyNames)
        {
            throw new System.NotImplementedException();
        }

        public void Update(DomainType instance)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(DomainType instance)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteByID(object id)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new System.NotImplementedException();
        }

        public ILog Logger
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }
    }
}
