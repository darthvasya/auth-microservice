using AuthServer.DAL.Contracts;
using AuthServer.DAL.Implementations;
using AuthServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Repository
{
    public class UserPasswordRepository : Repository<UserPassword>, IUserPasswordRepository
    {
        private UserEntities dataContext;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public UserPasswordRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected UserEntities DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }
    }

    public interface IUserPasswordRepository : IRepository<UserPassword>
    { }

}
