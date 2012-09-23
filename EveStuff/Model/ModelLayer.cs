using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using NHibernate;
using NHibernate.Criterion;

namespace EveStuff.Model
{
    static class SessionFactory
    {
        private static ISessionFactory sessionFactory = null;
        private static void BuildSessionFactory()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(EveType).Assembly);
            sessionFactory = cfg.BuildSessionFactory();
       }

        public static ISession GetSession() 
        {
            if (sessionFactory == null)
                BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }



    class ModelLayer
    {
        private ISession session;
        public ModelLayer()
        {
            session = SessionFactory.GetSession();
        }


        public void Commit()
        {
            session.Flush();
            session.Close();
        }

        public EveType GetEveType(int id)
        {
            return session.Get<EveType>(id);
        }

        private IList<EveType> listQuery( ICriterion crit, Order[] orders)
        {    
            var criteria = session.CreateCriteria<EveType>().Add(crit);
            foreach (var order in orders)
                criteria = criteria.AddOrder(order);
            return criteria.List<EveType>();        
        }


        internal IList<EveType> GetTypesFromGroup(int _groupID)
        {
            return listQuery(Expression.Eq("GroupID", _groupID),
                new[] { new Order("Name", true) });
        }
    }
}
