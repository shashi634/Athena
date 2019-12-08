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
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IQuestionRepository, QuestionRepository>();
            // Service Register
            container.RegisterType<IOrganizationService, OrganizationService>();
            container.RegisterType<ISubjectService, SubjectService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IQuestionService, QuestionService>();
            container.RegisterType<ICustomExceptionValidationService, CustomExceptionValidationService>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}