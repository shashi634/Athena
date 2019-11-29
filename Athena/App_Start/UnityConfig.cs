using Athena.Repository;
using Athena.Service;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Athena
{
    /// <summary>
    /// 
    /// </summary>
    public static class UnityConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IOrganizationRepository, OrganizationRepository>();
            container.RegisterType<IOrganizationService, OrganizationService>();
            container.RegisterType<ICustomExceptionValidationService, CustomExceptionValidationService>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}