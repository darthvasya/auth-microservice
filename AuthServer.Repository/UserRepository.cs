using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthServer.DAL.Contracts;
using AuthServer.DAL.Implementations;
using AuthServer.Model;

namespace AuthServer.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private UserEntities dataContext;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public UserRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected UserEntities DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }
    }

    public interface IUserRepository : IRepository<User>
    { }
}
