using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using Spring.Data.NHibernate;
using Spring.Data.NHibernate.Generic;

namespace Easyasp.Framework.Core.BaseManage
{
    public class NhibernateDeployHelper
    {

        public IDictionary HibernateProperties { get; set; }
        private static Configuration cfg = new Configuration();
        private bool isInit = false;
        //private static ISessionFactory sessionFactory;

        public NhibernateDeployHelper()
        {
        }

        private void initObject()
        {
            IDictionary<string, string> pors = new Dictionary<string, string>();
            foreach (DictionaryEntry entry in HibernateProperties)
            {
                pors.Add(new KeyValuePair<string, string>(entry.Key.ToString(), entry.Value.ToString()));
            }
            cfg.AddProperties(pors);
            cfg.AddAssembly(typeof(NhibernateDeployHelper).Assembly);
            isInit = true;
        }

        public   string GenerateDropSchemaScript(Dialect dialect)
        {
            if (!isInit)
                initObject();
            return string.Join(";\n", cfg.GenerateDropSchemaScript(dialect));
        }

        public string GenerateSchemaCreationScript(Dialect dialect)
        {
            if (!isInit)
                initObject();
            return string.Join(";\n", cfg.GenerateSchemaCreationScript(dialect));
        }

    }
}
