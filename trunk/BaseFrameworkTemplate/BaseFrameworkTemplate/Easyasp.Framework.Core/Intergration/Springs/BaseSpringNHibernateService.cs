using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;
using NHibernate.Criterion;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Easyasp.Framework.Core.Intergration.Springs
{
    public class BaseSpringNHibernateService<DomainType>
    {
        protected IBaseNHibernateDao<DomainType> selfDao;

        private ILog logger = null;

        public ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(this.GetType());
                return logger;
            }
            set { logger = value; }
        }

        public BaseSpringNHibernateService(IBaseNHibernateDao<DomainType> selfDao)
        {
            this.selfDao = selfDao;
        }

        protected BaseSpringNHibernateService()
        {
        }

        public virtual DomainType GetNewDomainInstance()
        {
            return Activator.CreateInstance<DomainType>();
        }

        [Transaction(TransactionPropagation.Required, ReadOnly = false)]
        public virtual void Create(DomainType obj)
        {
            selfDao.Save(obj);
        }


        [Transaction(TransactionPropagation.Required, ReadOnly = false)]
        public virtual void Update(DomainType obj)
        {
            selfDao.Update(obj);
        }

        [Transaction(TransactionPropagation.Required, ReadOnly = false)]
        public virtual void SaveOrUpdate(DomainType obj)
        {
            selfDao.SaveOrUpdate(obj);
        }

        [Transaction(TransactionPropagation.Required, ReadOnly = false)]
        public virtual void DeleteAll()
        {
            selfDao.DeleteAll();
        }

        [Transaction(TransactionPropagation.Required, ReadOnly = false)]
        public virtual void DeleteByID(object id)
        {
            selfDao.DeleteByID(id);
        }

        [Transaction(TransactionPropagation.Required, ReadOnly = false)]
        public virtual void PatchDeleteByIDs(object[] ids)
        {
            foreach (var id in ids)
            {
                selfDao.DeleteByID(id);                
            }
        }

        [Transaction(TransactionPropagation.Required, ReadOnly = false)]
        public virtual void PatchDeleteByTypedIDs<IDType>(IDType[] ids)
        {
            foreach (var id in ids)
            {
                selfDao.DeleteByID(id);
            }
        }

        [Transaction(TransactionPropagation.Required, ReadOnly = false)]
        public virtual void PatchDeleteByTypedIntIDs(int[] ids)
        {
            foreach (int id in ids)
            {
                selfDao.DeleteByID(id);
            }
        }

        [Transaction(TransactionPropagation.Required, ReadOnly = false)]
        public virtual void Delete(DomainType instance)
        {
            selfDao.Delete(instance);
        }

        [Transaction(TransactionPropagation.Required, ReadOnly = false)]
        public virtual void Refresh(DomainType instance)
        {
            selfDao.Refresh(instance);
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual DomainType FindById(object id)
        {
            return selfDao.Load(id);
        }
        [Transaction(TransactionPropagation.Required)]
        public virtual List<DomainType> FindAll()
        {
            return selfDao.FindAll();
        }
        [Transaction(TransactionPropagation.Required)]
        protected virtual List<DomainType> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            return selfDao.FindAll(null, null, firstRow, maxRows, out recordCount);
        }
        [Transaction(TransactionPropagation.Required)]
        protected virtual List<DomainType> FindAll(Order[] sortItems, int firstRow, int maxRows, out int recordCount)
        {
            return selfDao.FindAll(null, null, firstRow, maxRows, out recordCount);
        }
        [Transaction(TransactionPropagation.Required)]
        protected virtual void InitializeLazyProperties(DomainType instance)
        {
            selfDao.InitializeLazyProperties(instance);
        }
        [Transaction(TransactionPropagation.Required)]
        protected virtual void InitializeLazyProperty(DomainType instance, string propertyName)
        {
            selfDao.InitializeLazyProperty(instance, propertyName);
        }
        [Transaction(TransactionPropagation.Required)]
        protected virtual List<DomainType> FindAll(ICriterion[] criterias, Order[] sortItems)
        {
            return selfDao.FindAll(criterias, sortItems);
        }
        [Transaction(TransactionPropagation.Required)]
        protected virtual List<DomainType> FindAll(ICriterion[] criterias, Order[] sortItems, int firstRow, int maxRows, out int recordCount)
        {
            return selfDao.FindAll(criterias, sortItems, firstRow, maxRows, out recordCount);
        }
        //[Transaction(TransactionPropagation.Required)]
        //public List<DomainType> GetAll(string orderFieldName, bool isAsc, int firstRow, int maxRows, out int recordCount)
        //{
        //    List<Order> orders = new List<Order>();
        //    if (!string.IsNullOrEmpty(orderFieldName))
        //        orders.Add(new Order(orderFieldName, isAsc));
        //    List<ICriterion> criterions = new List<ICriterion>();
        //    return this.FindAll(criterions.ToArray(), orders.ToArray(), firstRow, maxRows, out recordCount);
        //}

        public List<DomainType> GetQueryPageList(int firstRow, int maxRows, Hashtable queryCondition,
                                                 string defaultOrderByField, bool defaultOrderFieldIsDesc,
                                                 out int recordCount)
        {
            if(queryCondition==null)
                throw new ArgumentNullException("queryCondition");



            List<ICriterion> criterions = new List<ICriterion>();
            foreach (DictionaryEntry entry in queryCondition)
            {
                string[] split = entry.Key.ToString().Split('$');
                if(split.Length!=2)
                {
                    throw new ArgumentException(string.Format("Argument \"queryCondition\" has error , Item \"{0}\" has split error.", entry.Key.ToString()), "queryCondition");
                }
                string fieldName = split[0];
                string operationType = split[1].ToUpper();
                if (this.selfDao.GetAllFieldNames().Contains(fieldName))
                {
                    switch (operationType)
                    {
                        case "EQ":
                            criterions.Add(Property.ForName(fieldName).Eq(entry.Value.ToString()));
                            break;
                        case "GE":
                            criterions.Add(Property.ForName(fieldName).Ge(entry.Value.ToString()));
                            break;
                        case "LE":
                            criterions.Add(Property.ForName(fieldName).Le(entry.Value.ToString()));
                            break;
                        case "GT":
                            criterions.Add(Property.ForName(fieldName).Gt(entry.Value.ToString()));
                            break;
                        case "LT":
                            criterions.Add(Property.ForName(fieldName).Lt(entry.Value.ToString()));
                            break;
                        case "LIKEANY":
                            criterions.Add(Property.ForName(fieldName).Like(entry.Value.ToString(),MatchMode.Anywhere));
                            break;
                        case "LIKESTART":
                            criterions.Add(Property.ForName(fieldName).Like(entry.Value.ToString(), MatchMode.Start));
                            break;
                        case "LIKEEND":
                            criterions.Add(Property.ForName(fieldName).Like(entry.Value.ToString(), MatchMode.End));
                            break;
                        case "ISNULL":
                            criterions.Add(Property.ForName(fieldName).IsNull());
                            break;
                        case "ISNOTNULL":
                            criterions.Add(Property.ForName(fieldName).IsNotNull());
                            break;
                        case "ISEMPTY":
                            criterions.Add(Property.ForName(fieldName).IsEmpty());
                            break;
                        case "ISNOTEMPTY":
                            criterions.Add(Property.ForName(fieldName).IsNotEmpty());
                            break;
                        default:
                            throw new ArgumentException(string.Format("Argument \"queryCondition\" has error , Item \"{0}\" has unknow operation.", entry.Key.ToString()), "queryCondition");
                            break;
                    }
                }
            }
            List<Order> orders = new List<Order>();
            if (!string.IsNullOrEmpty(defaultOrderByField))
                orders.Add(new Order(this.selfDao.GetKeyFieldName(), defaultOrderFieldIsDesc));
            return this.FindAll(criterions.ToArray(), orders.ToArray(), firstRow, maxRows, out recordCount);
        }
    }
}
