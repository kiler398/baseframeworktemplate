using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Common.Logging;
using Easyasp.Framework.Core.Intergration.EventHandles;
using Easyasp.Framework.Core.Intergration.NHibernate;
using Easyasp.Framework.Core.Utility;
using NHibernate;
using NHibernate.Collection;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using NHibernate.Metadata;
using NHibernate.Proxy;
using Spring.Data.NHibernate.Generic;
using Spring.Data.NHibernate.Generic.Support;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using IDictionary=System.Collections.IDictionary;

namespace Easyasp.Framework.Core.Intergration.Springs
{
    public class BaseSpringNHibernateDao<DomainType> : HibernateDaoSupport, IBaseNHibernateDao<DomainType>
    {
        private string keyFieldName;
        private List<string> allFieldNames;
        private IClassMetadata classMetadata;


        #region 基本操作

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="instance">持久化类</param>
        public virtual void Save(DomainType instance)
        {
            try
            {
                ISession session = CurrentSession;
                session.Save(instance);
                OnDataCreated(EventArgs.Empty);
                OnDataChanged(EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Logger.Error("Save Object Failed:", ex);
                throw new DataException("Could not perform Save for " + typeof(DomainType).Name, ex);
            }
        }

        ///// <summary>
        ///// 更新数据
        ///// </summary>
        ///// <param name="instance">持久化类</param>
        public virtual void Update(DomainType instance)
        {
            try
            {
                ISession session = CurrentSession;
                session.Update(instance);
                OnDataUpdated(EventArgs.Empty);
                OnDataChanged(EventArgs.Empty);
            }
            catch (Exception ex)
            {
                //Logger.Error("Update Object Failed:", ex);
                throw new DataException("Could not perform Update for " + typeof(DomainType).Name, ex);
            }
        }

        /// <summary>
        /// 保存或者更新数据
        /// </summary>
        /// <param name="instance">持久化类</param>
        public virtual void SaveOrUpdate(DomainType instance)
        {
            try
            {
                ISession session = CurrentSession;
                session.SaveOrUpdate(instance);
                OnDataChanged(EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Logger.Error("SaveOrUpdate Object Failed:", ex);
                throw new DataException("Could not perform SaveOrUpdate for " + typeof(DomainType).Name, ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public virtual void SaveOrUpdateCopy(DomainType instance)
        {
            try
            {
                ISession session = CurrentSession;
                session.SaveOrUpdateCopy(instance);
                OnDataChanged(EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Logger.Error("SaveOrUpdateCopy Object Failed:", ex);
                throw new DataException("Could not perform SaveOrUpdateCopy for " + typeof(DomainType).Name, ex);
            }
        }


        /// <summary>
        /// 部分更新
        /// </summary>
        /// <param name="instance">更新的值</param>
        /// <param name="id">id</param>
        /// <param name="updatePropertyNames">需要更新的属性名</param>
        public virtual void PartUpdate(DomainType instance, object id, string[] updatePropertyNames)
        {
            try
            {
                DomainType lastInstance = Load(id);
                Type t = typeof(DomainType);
                foreach (string propertyName in updatePropertyNames)
                {
                    PropertyInfo setPropertyInfo = t.GetProperty(propertyName);
                    setPropertyInfo.SetValue(lastInstance, setPropertyInfo.GetValue(instance, null), null);
                }
                Update(instance);
            }
            catch (Exception ex)
            {
                Logger.Error("PartUpdate Object Failed:", ex);
                throw new DataException("Could not perform PartUpdate for " + typeof(DomainType).Name, ex);
            }
        }


        ///// <summary>
        ///// 删除数据
        ///// </summary>
        ///// <param name="instance">需要删除的业务实体</param>
        public virtual void Delete(DomainType instance)
        {
            try
            {
                ISession session = CurrentSession;
                session.Delete(instance);
                OnDataDeleted(EventArgs.Empty);
                OnDataChanged(EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Logger.Error("Delete Object Failed:", ex);
                throw new DataException("Could not perform Delete for " + typeof(DomainType).Name, ex);
            }
        }

        ///// <summary>
        ///// 通过ID删除数据
        ///// </summary>
        ///// <param name="id"></param>
        public virtual void DeleteByID(object id)
        {
            DomainType obj = Load(id);
            if (obj != null)
                Delete(obj);
        }

        ///// <summary>
        ///// 删除所有的数据
        ///// </summary>
        public virtual void DeleteAll()
        {
            try
            {
                ISession session = CurrentSession;
                session.Delete(String.Format("from {0}", typeof(DomainType).Name));
                OnDataDeleted(EventArgs.Empty);
                OnDataChanged(EventArgs.Empty);
            }
            catch (Exception ex)
            {
                throw new DataException("Could not perform DeleteAll for " + typeof(DomainType).Name, ex);
            }
        }


        /// <summary>
        /// 加载对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual DomainType Load(object id)
        {
            try
            {
                ISession session = CurrentSession;
                return session.Load<DomainType>(id);
            }
            catch (Exception ex)
            {
                Logger.Error("Load Object Failed:", ex);
                throw new DataException("Could not perform Load for " + typeof(DomainType).Name, ex);
            }
        }


        /// <summary>
        /// 加载对象
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="id"></param>
        public virtual void Load(DomainType instance, object id)
        {
            try
            {
                ISession session = CurrentSession;
                session.Load(instance, id);
            }
            catch (Exception ex)
            {
                Logger.Error("Load Object Failed:", ex);
                throw new DataException("Could not perform Load for " + typeof(DomainType).Name, ex);
            }
        }

        /// <summary>
        /// 刷新对象
        /// </summary>
        /// <param name="instance"></param>
        public virtual void Refresh(DomainType instance)
        {
            try
            {
                ISession session = CurrentSession;
                session.Refresh(instance);
            }
            catch (Exception ex)
            {
                Logger.Error("Refresh Object Failed:", ex);
                throw new DataException("Could not perform Refresh for " + typeof(DomainType).Name, ex);
            }
        }


        /// <summary>
        /// 从session中移除对象
        /// </summary>
        ///// <param name="instance"></param>
        public virtual void Evict(DomainType instance)
        {
            try
            {
                ISession session = CurrentSession;
                session.Evict(instance);
            }
            catch (Exception ex)
            {
                Logger.Error("Evict Object Failed:", ex);
                throw new DataException("Could not perform Evict for " + typeof(DomainType).Name, ex);
            }
        }

        ///// <summary>
        ///// 锁定对象
        ///// </summary>
        ///// <param name="instance">需要锁定的对象</param>
        ///// <param name="lockMode"></param>
        public virtual void Lock(DomainType instance, LockMode lockMode)
        {
            try
            {
                ISession session = CurrentSession;
                session.Lock(instance, lockMode);
            }
            catch (Exception ex)
            {
                Logger.Error("Lock Object Failed:", ex);
                throw new DataException("Could not perform Lock for " + typeof(DomainType).Name, ex);
            }
        }

        #endregion

        #region 事件委托

        public event DataChangedEventHandler DataChanged;
        public event DataCreatedEventHandler DataCreated;
        public event DataUpdatedEventHandler DataUpdated;
        public event DataDeletedEventHandler DataDeleted;

        protected virtual void OnDataChanged(EventArgs e)
        {
            if (DataChanged != null)
            {
                DataChanged(this, e);
            }
        }

        protected virtual void OnDataCreated(EventArgs e)
        {
            if (DataCreated != null)
            {
                DataCreated(this, e);
            }
        }

        protected virtual void OnDataUpdated(EventArgs e)
        {
            if (DataUpdated != null)
            {
                DataUpdated(this, e);
            }
        }

        protected virtual void OnDataDeleted(EventArgs e)
        {
            if (DataDeleted != null)
            {
                DataDeleted(this, e);
            }
        }

        #endregion

        #region 日志对象

        private ILog logger = null;

        /// <summary>
        /// 日志
        /// </summary>
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

        #endregion

        #region 受保护的方法

        /// <summary>
        /// 将IList装换为类型化的List
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        protected virtual List<DomainType> ConvertToTypedList(IList<DomainType> list)
        {
            if (list == null) return null;
            List<DomainType> typedList = new List<DomainType>();
            foreach (DomainType o in list)
            {
                typedList.Add(o);
            }
            return typedList;
        }

        protected virtual ISession CurrentSession
        {
            get
            {
                return this.DoGetSession(false);
            }
        }

        #endregion

        #region 查找所有的数据

        public List<DomainType> FindAll()
        {
            return FindAll(int.MinValue, int.MinValue);
        }

        public List<DomainType> FindAll(int firstRow, int maxRows)
        {
            int recordCount = 0;
            return FindAll(null, null, firstRow, maxRows, out recordCount);
        }

        #endregion

        #region 面向对象的查询方式

        public virtual List<DomainType> FindAll(ICriterion[] criterias)
        {
            return FindAll(criterias, null);
        }

        public virtual List<DomainType> FindAll(ICriterion[] criterias, Order[] sortItems)
        {
            int recordCount = 0;
            return FindAll(criterias, sortItems, int.MinValue, int.MinValue, out recordCount);
        }

        public virtual List<DomainType> FindAll(ICriterion[] criterias, int firstRow, int maxRows, out int recordCount)
        {
            return FindAll(criterias, null, firstRow, maxRows, "", "", out recordCount);
        }

        public virtual List<DomainType> FindAll(ICriterion[] criterias, Order[] sortItems, int firstRow, int maxRows,
                                                out int recordCount)
        {
            return FindAll(criterias, sortItems, firstRow, maxRows, "", "", out recordCount);
        }

        public virtual List<DomainType> FindAll(ICriterion[] criterias, Order[] sortItems, int firstRow, int maxRows,
                                                string filterName, string cacheRegionName, out int recordCount)
        {
            try
            {
                int outRecordCount = 0;

                ISession session = CurrentSession;

                //如果有filter打开
                if (!string.IsNullOrEmpty(filterName))
                {
                    session.EnableFilter(filterName);
                }

                //查询l当前页记录的ICriteria
                ICriteria criteria = session.CreateCriteria(typeof(DomainType));
                //查询记录总数的ICriteria
                ICriteria criteriaCount = session.CreateCriteria(typeof(DomainType));


                //加载查询条件
                if (criterias != null)
                {
                    foreach (ICriterion cond in criterias)
                    {
                        criteria.Add(cond);
                        criteriaCount.Add(cond);
                    }
                }

                //加载排序条件
                if (sortItems != null)
                {
                    foreach (Order order in sortItems)
                    {
                        //查询记录总数的ICriteria不需要加载排序条件
                        criteria.AddOrder(order);
                    }
                }

                //打开缓存
                if (!string.IsNullOrEmpty(cacheRegionName))
                {
                    criteria.SetCacheable(true);
                    criteria.SetCacheRegion(cacheRegionName);
                }

                //投影查询获取记录总数
                criteriaCount.SetProjection(Projections.RowCount());
                outRecordCount = criteriaCount.SetMaxResults(1).UniqueResult<int>();

                //设置分页查询
                if (firstRow != int.MinValue) criteria.SetFirstResult(firstRow);
                if (maxRows != int.MinValue) criteria.SetMaxResults(maxRows);

                //获取当前页记录数
                IList<DomainType> result = criteria.List<DomainType>();

                if (result.Count > outRecordCount)
                {
                    throw new Exception("Query Count Error!");
                }

                //关闭缓存
                if (!string.IsNullOrEmpty(cacheRegionName))
                {
                    criteria.SetCacheable(false);
                }

                //如果有filter关闭
                if (!string.IsNullOrEmpty(filterName))
                {
                    session.DisableFilter(filterName);
                }

                recordCount = outRecordCount;

                return ConvertToTypedList(result);

            }
            catch (Exception ex)
            {
                this.Logger.Error(ex.Message);
                throw new DataException("Could not perform FindAll for " + typeof(DomainType).Name, ex);
            }
        }

        #endregion

        #region HQL集合查询

        public virtual List<DomainType> FindAllWithCustomQuery(string queryString)
        {
            return FindAllWithCustomQuery(queryString, null, int.MinValue, int.MinValue);
        }

        public virtual List<DomainType> FindAllWithCustomQuery(string queryString, int firstRow, int maxRows)
        {
            return FindAllWithCustomQuery(queryString, null, firstRow, maxRows);
        }

        public virtual List<DomainType> FindAllWithCustomQuery(string queryString,
                                                               NhibernateParameterCollection nhibernateQueryParams)
        {
            return FindAllWithCustomQuery(queryString, nhibernateQueryParams, int.MinValue, int.MinValue);
        }

        public virtual List<DomainType> FindAllWithCustomQuery(string queryString,
                                                               NhibernateParameterCollection nhibernateQueryParams,
                                                               int firstRow, int maxRows)
        {
            if (string.IsNullOrEmpty(queryString)) throw new ArgumentNullException("queryString");

            IList<DomainType> list = null;

            try
            {
                list = HibernateTemplate.ExecuteFind<DomainType>(
                    delegate(ISession session)
                    {
                        IQuery query = session.CreateQuery(queryString);

                        if (nhibernateQueryParams != null && nhibernateQueryParams.Count > 0)
                        {
                            foreach (NhibernateParameter param in nhibernateQueryParams)
                            {
                                query.SetParameter(param.ParameterName, param.Value, param.DbType);
                            }
                        }

                        if (firstRow != int.MinValue) query.SetFirstResult(firstRow);
                        if (maxRows != int.MinValue) query.SetMaxResults(maxRows);

                        return query.List<DomainType>();
                    });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw new DataException("Could not perform FindAllWithCustomQuery for " + typeof(DomainType).Name, ex);
            }

            return ConvertToTypedList(list);
        }

        #endregion

        #region HQL标量查询

        /// <summary>
        /// HQL标量查询
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public virtual object FindScalarWithCustomQuery(string queryString)
        {
            return FindScalarWithCustomQuery(queryString, null);
        }

        /// <summary>
        /// 带参数的HQL标量查询
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="nhibernateQueryParams"></param>
        /// <returns></returns>
        public virtual object FindScalarWithCustomQuery(string queryString,
                                                        NhibernateParameterCollection nhibernateQueryParams)
        {
            ISession session = CurrentSession;

            try
            {
                IQuery query = session.CreateQuery(queryString);

                if (nhibernateQueryParams != null && nhibernateQueryParams.Count > 0)
                {
                    foreach (NhibernateParameter param in nhibernateQueryParams)
                    {
                        query.SetParameter(param.ParameterName, param.Value, param.DbType);
                    }
                }

                return query.SetMaxResults(1).UniqueResult();
            }
            catch (Exception ex)
            {
                throw new DataException("Could not perform FindScalar for custom query : " + queryString, ex);
            }
        }

        #endregion

        #region 初始化实体

        public virtual void InitializeLazyProperties(DomainType instance)
        {
            if (instance == null) throw new ArgumentNullException("instance");

            ISession session = CurrentSession;


            foreach (object val in ReflectionUtil.GetPropertiesDictionary(instance).Values)
            {
                if (val is INHibernateProxy || val is IPersistentCollection)
                {
                    if (!NHibernateUtil.IsInitialized(val))
                    {
                        session.Lock(instance, LockMode.None);
                        NHibernateUtil.Initialize(val);
                    }
                }
            }
        }

        public virtual void InitializeLazyProperty(DomainType instance, string propertyName)
        {
            if (instance == null) throw new ArgumentNullException("instance");
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentNullException("collectionPropertyName");

            IDictionary properties = ReflectionUtil.GetPropertiesDictionary(instance);
            if (!properties.Contains(propertyName))
                throw new ArgumentOutOfRangeException("collectionPropertyName", "Property "
                                                                                + propertyName +
                                                                                " doest not exist for type "
                                                                                + instance.GetType().ToString() + ".");

            ISession session = CurrentSession;

            object val = properties[propertyName];

            if (val is INHibernateProxy || val is IPersistentCollection)
            {
                if (!NHibernateUtil.IsInitialized(val))
                {
                    session.Lock(instance, LockMode.None);
                    NHibernateUtil.Initialize(val);
                }
            }
        }

        #endregion

        #region 游离条件查询

        public virtual List<DomainType> FindListByDetachedCriteriaQuery(DetachedCriteria detachedCriteria)
        {
            if (detachedCriteria == null) throw new ArgumentNullException("detachedCriteria");
            ISession session = CurrentSession;

            try
            {
                IList<DomainType> result = detachedCriteria.GetExecutableCriteria(session).List<DomainType>();
                return ConvertToTypedList(result);
            }
            catch (Exception ex)
            {
                Logger.Error("Could not perform Find List By DetachedCriteriaQuery : " + ex.Message);
                throw new DataException("Could not perform Find List By DetachedCriteriaQuery : ", ex);
            }
        }

        public virtual List<DomainType> FindListByDetachedCriteriaQuery(DetachedCriteria detachedCriteria,
                                                                        DetachedCriteria detachedCriteriaCount,
                                                                        int firstRow, int maxRows, out int recordCount)
        {
            if (detachedCriteria == null) throw new ArgumentNullException("detachedCriteria");

            ISession session = CurrentSession;

            try
            {
                //查询l当前页记录的ICriteria
                ICriteria criteria = detachedCriteria.GetExecutableCriteria(session);
                //查询记录总数的ICriteria
                ICriteria criteriaCount = detachedCriteriaCount.GetExecutableCriteria(session);
                //投影查询获取记录总数
                criteriaCount.SetProjection(Projections.RowCount());
                recordCount = criteriaCount.SetMaxResults(1).UniqueResult<int>();

                //设置分页查询
                if (firstRow != int.MinValue) criteria.SetFirstResult(firstRow);
                if (maxRows != int.MinValue) criteria.SetMaxResults(maxRows);

                //获取当前页记录数
                IList<DomainType> result = criteria.List<DomainType>();

                if (result.Count > recordCount)
                {
                    throw new Exception("Query Count Error!");
                }
                return ConvertToTypedList(result);
            }
            catch (Exception ex)
            {
                Logger.Error("Could not perform Find List By DetachedCriteriaQuery : " + ex.Message);
                throw new DataException("Could not perform Find List By DetachedCriteriaQuery : ", ex);
            }
        }

        #endregion

        #region 投影查询

        public virtual System.Collections.IList ProjectionQuery(IProjection[] projections, ICriterion[] criterias, Order[] orders)
        {
            ISession session = CurrentSession;

            try
            {
                ICriteria criteria = session.CreateCriteria(typeof(DomainType));

                if (criterias != null)
                {
                    foreach (ICriterion cond in criterias)
                    {
                        criteria.Add(cond);
                    }
                }

                if (orders != null)
                {
                    foreach (Order order in orders)
                    {
                        criteria.AddOrder(order);
                    }
                }

                if (projections != null)
                {
                    foreach (IProjection projection in projections)
                    {
                        criteria.SetProjection(projection);
                    }
                }

                return criteria.List();
            }
            catch (Exception ex)
            {
                throw new DataException("Could not perform ProjectionQuery for " + typeof(DomainType).Name, ex);
            }
        }

        public virtual object ProjectionSingleLineQuery(IProjection[] projections, ICriterion[] criterias,
                                                        Order[] orders)
        {
            ISession session = CurrentSession;
            try
            {
                ICriteria criteria = session.CreateCriteria(typeof(DomainType));

                if (criterias != null)
                {
                    foreach (ICriterion cond in criterias)
                    {
                        criteria.Add(cond);
                    }
                }

                criteria.SetMaxResults(1);

                if (orders != null)
                {
                    foreach (Order order in orders)
                    {
                        criteria.AddOrder(order);
                    }
                }

                if (projections != null)
                {
                    foreach (IProjection projection in projections)
                    {
                        criteria.SetProjection(projection);
                    }
                }

                IList result = criteria.List();

                if (result == null)
                    return null;
                else
                    return result[0];
            }
            catch (Exception ex)
            {
                throw new DataException("Could not perform ProjectionSingleLineQuery for " + typeof(DomainType).Name,
                                        ex);
            }
        }

        public virtual TypeScalar ProjectionScalarQuery<TypeScalar>(IProjection[] projections, ICriterion[] criterias,
                                                                    Order[] orders)
        {
            object result = ProjectionSingleLineQuery(projections, criterias, orders);

            if (result == null)
                return default(TypeScalar);
            else
                return (TypeScalar)result;
        }

        #endregion

        public virtual IClassMetadata GetClassMetadata()
        {
            if(this.classMetadata == null)
            {
                this.classMetadata = this.HibernateTemplate.SessionFactory.GetClassMetadata(typeof (DomainType));
            }
            return classMetadata;
        }

        public virtual string GetKeyFieldName()
        {
            if(string.IsNullOrEmpty(this.keyFieldName) && GetClassMetadata().HasIdentifierProperty)
            {
                this.keyFieldName = GetClassMetadata().IdentifierPropertyName;
            }
            return this.keyFieldName;
        }

        public virtual List<string> GetAllFieldNames()
        {
            if (this.allFieldNames == null)
            {
                this.allFieldNames = new List<string>();
                this.allFieldNames.AddRange(GetClassMetadata().PropertyNames);
            }
            return this.allFieldNames;
        }


    }
}
