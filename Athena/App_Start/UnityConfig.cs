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
            // Repo register
            container.RegisterType<IOrganizationRepository, OrganizationRepository>();
            container.RegisterType<ISubjectRepository, SubjectRepository>();

            // Service Register
            container.RegisterType<IOrganizationService, OrganizationService>();
            container.RegisterType<ISubjectService, SubjectService>();
            container.RegisterType<ICustomExceptionValidationService, CustomExceptionValidationService>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}