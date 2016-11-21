using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthServer.Model;

namespace AuthServer.DAL.Contracts
{
    public interface IDatabaseFactory : IDisposable
    {
        UserEntities Get();
    }
}
