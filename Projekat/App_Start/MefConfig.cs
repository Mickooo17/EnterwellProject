using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Web.Mvc;
using Projekat.Infrastructure;
using Projekat.Container;

namespace Projekat.App_Start
{
    /// <summary>
    ///     Responsible for configuring MEF for the application.
    /// </summary>
    public static class MefConfig
    {
        public static void RegisterMef()
        {
            var container = ConfigureContainer();

            ControllerBuilder.Current.SetControllerFactory(new MefControllerFactory(container));

            var resolver = new MefDependencyResolver(container);

            DependencyResolver.SetResolver(resolver);

            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        private static CompositionContainer ConfigureContainer()
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var businessRulesCatalog = new AssemblyCatalog(typeof(IVATRateMetaData).Assembly);
            var catalogs = new AggregateCatalog(assemblyCatalog, businessRulesCatalog);
            var container = new CompositionContainer(catalogs);

            return container;
        }
    }
}