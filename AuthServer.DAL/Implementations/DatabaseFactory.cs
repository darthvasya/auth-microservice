using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthServer.DAL.Contracts;
using AuthServer.Model;

namespace AuthServer.DAL.Implementations
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private UserEntities dataContext;
        public UserEntities Get()
        {
            return dataContext ?? (dataContext = new UserEntities());
        }

        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
