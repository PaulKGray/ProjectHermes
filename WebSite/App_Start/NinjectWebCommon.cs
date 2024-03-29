[assembly: WebActivator.PreApplicationStartMethod(typeof(ProjectHermes.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(ProjectHermes.App_Start.NinjectWebCommon), "Stop")]

namespace ProjectHermes.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;


    using Ninject.Web.Mvc;
    using Ninject.Web.Mvc.FilterBindingSyntax;

    using ProjectHermes.Services;
    using ProjectHermes.Services.Interfaces;
    using ProjectHermes.Controllers.Actionfilters;
    using Ninject.Web.Common;
    using Ninject;
    using System.Web.Mvc;
	


    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static Ninject.IKernel CreateKernel()
        {
            var kernel = new StandardKernel(new Services.Registrations.NHibernateModule());
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            kernel.BindFilter<TransactionAttribute>(FilterScope.Action, 0).WhenActionMethodHas<TransactionAttribute>();

						System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {

            Services.Registrations.Services.RegisterServices(kernel);


       
        
        }        
    }
}
