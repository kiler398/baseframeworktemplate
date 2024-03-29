﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Easyasp.Framework.Core.Intergration
{
    public interface IGenericDao<T>
    {
        //查询出所有数据
        List<T> FindAll();

        //分页查询出所有数据
        List<T> FindAll(int firstRow, int maxRows);

        //通过ID加载数据
        T Load(object id);

        //通过ID加载数据
        void Load(T instance, object id);

        //添加数据
        void Save(T instance);

        //添加数据
        void SaveOrUpdate(T instance);

        //局部更新数据
        void PartUpdate(T instance, object id, string[] updatePropertyNames);

        //更新数据
        void Update(T instance);

        //删除数据
        void Delete(T instance);

        //通过ID删除数据
        void DeleteByID(object id);

        //删除所有的数据
        void DeleteAll();

        /// <summary>
        /// 日志
        /// </summary>
        ILog Logger { get; set; }
    }
}
