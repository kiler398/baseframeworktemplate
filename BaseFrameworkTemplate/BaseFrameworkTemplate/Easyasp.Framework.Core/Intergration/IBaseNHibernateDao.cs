using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;
using Easyasp.Framework.Core.Intergration.EventHandles;
using Easyasp.Framework.Core.Intergration.NHibernate;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Metadata;

namespace Easyasp.Framework.Core.Intergration
{
    public interface IBaseNHibernateDao<DomainType> : IGenericDao<DomainType>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        void SaveOrUpdateCopy(DomainType instance);


        /// <summary>
        /// 刷新对象
        /// </summary>
        /// <param name="instance"></param>
        void Refresh(DomainType instance);

        /// <summary>
        /// 从session中移除对象
        /// </summary>
        ///// <param name="instance"></param>
        void Evict(DomainType instance);

        void Lock(DomainType instance, LockMode lockMode);
        event DataChangedEventHandler DataChanged;
        event DataCreatedEventHandler DataCreated;
        event DataUpdatedEventHandler DataUpdated;
        event DataDeletedEventHandler DataDeleted;



        List<DomainType> FindAll(ICriterion[] criterias);
        List<DomainType> FindAll(ICriterion[] criterias, Order[] sortItems);
        List<DomainType> FindAll(ICriterion[] criterias, int firstRow, int maxRows, out int recordCount);

        List<DomainType> FindAll(ICriterion[] criterias, Order[] sortItems, int firstRow, int maxRows,
                                                 out int recordCount);

        List<DomainType> FindAll(ICriterion[] criterias, Order[] sortItems, int firstRow, int maxRows,
                                                 string filterName, string cacheRegionName, out int recordCount);

        List<DomainType> FindAllWithCustomQuery(string queryString);
        List<DomainType> FindAllWithCustomQuery(string queryString, int firstRow, int maxRows);

        List<DomainType> FindAllWithCustomQuery(string queryString,
                                                                NhibernateParameterCollection nhibernateQueryParams);

        List<DomainType> FindAllWithCustomQuery(string queryString,
                                                                NhibernateParameterCollection nhibernateQueryParams,
                                                                int firstRow, int maxRows);

        /// <summary>
        /// HQL标量查询
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        object FindScalarWithCustomQuery(string queryString);

        /// <summary>
        /// 带参数的HQL标量查询
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="nhibernateQueryParams"></param>
        /// <returns></returns>
        object FindScalarWithCustomQuery(string queryString,
                                                         NhibernateParameterCollection nhibernateQueryParams);

        void InitializeLazyProperties(DomainType instance);
        void InitializeLazyProperty(DomainType instance, string propertyName);
        List<DomainType> FindListByDetachedCriteriaQuery(DetachedCriteria detachedCriteria);

        List<DomainType> FindListByDetachedCriteriaQuery(DetachedCriteria detachedCriteria,
                                                                         DetachedCriteria detachedCriteriaCount,
                                                                         int firstRow, int maxRows, out int recordCount);

        IList ProjectionQuery(IProjection[] projections, ICriterion[] criterias, Order[] orders);

        object ProjectionSingleLineQuery(IProjection[] projections, ICriterion[] criterias,
                                                         Order[] orders);

        TypeScalar ProjectionScalarQuery<TypeScalar>(IProjection[] projections, ICriterion[] criterias,
                                                                     Order[] orders);

        void AfterPropertiesSet();

        IClassMetadata GetClassMetadata();

        string GetKeyFieldName();

        List<string> GetAllFieldNames();
    }
}
