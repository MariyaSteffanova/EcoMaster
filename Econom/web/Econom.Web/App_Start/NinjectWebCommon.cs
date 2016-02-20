[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Econom.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Econom.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Econom.Web.App_Start
{
    using System;
    using System.Web;

    using Common;
    using Data;
    using Data.Contracts;
    using ItemMasterData.Data;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;
    using Ninject.Web.Mvc.FilterBindingSyntax;
    using Infrastructure.Filters;
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
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IRepository<,>)).To(typeof(GenericRepository<,>));

            kernel.Bind<IEconomDbContext>().To<EconomDbContext>().InRequestScope();
            kernel.Bind<IItemMasterDbContext>().To<ItemMasterDbContext>().InRequestScope();

            kernel.BindFilter<HomeStorageOwnerAttribute>(System.Web.Mvc.FilterScope.Action, 0)
                .WhenActionMethodHas<HomeStorageOwnerWrapperAttribute>();

            kernel.Bind(k => k
                .From(
                    GlobalConstants.DataServicesAssembly,
                    GlobalConstants.SearchersServicesAssembly,
                    GlobalConstants.LogicServicesAssembly)
               .SelectAllClasses()
               .BindDefaultInterface());
        }
    }
}
