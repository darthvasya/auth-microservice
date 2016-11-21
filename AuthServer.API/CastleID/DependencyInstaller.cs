using AuthServer.DAL.Contracts;
using AuthServer.DAL.Implementations;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;

namespace AuthServer.API.CastleID
{
    public class DependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                        //Component.For<ILogService>()
                        //    .ImplementedBy<LogService>()
                        //    .LifeStyle.PerWebRequest,

                        Component.For<IDatabaseFactory>()
                            .ImplementedBy<DatabaseFactory>()
                            .LifeStyle.PerWebRequest,

                        Component.For<IUnitOfWork>()
                            .ImplementedBy<UnitOfWork>()
                            .LifeStyle.PerWebRequest,

                        AllTypes.FromThisAssembly().BasedOn<IHttpController>().LifestyleTransient(),

                        AllTypes.FromAssemblyNamed("AuthServer.Service")
                            .Where(type => type.Name.EndsWith("Service")).WithServiceAllInterfaces().LifestylePerWebRequest(),

                        AllTypes.FromAssemblyNamed("AuthServer.Repository")
                            .Where(type => type.Name.EndsWith("Repository")).WithServiceAllInterfaces().LifestylePerWebRequest()
                        );
        }
    }
}