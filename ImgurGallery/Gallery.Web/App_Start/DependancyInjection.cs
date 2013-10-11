using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Castle.Components.DictionaryAdapter;
using Gallery.Core;
using Autofac.Integration.Mvc;

namespace Gallery.Web.App_Start
{
    public class DependancyInjection
    {
        public static void Setup()
        {
            var builder = new ContainerBuilder();
            
            // Register Controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // Register all Services
            builder.RegisterType<Client>().As<IClient>();

            // Register the Castle Dictionary Adaptor Factory
            builder.RegisterType<DictionaryAdapterFactory>().As<IDictionaryAdapterFactory>().SingleInstance();

            // Resolve ISettings by resolving the DictionaryAdapterFactory and 
            // initialising it with AppSettings from App.config
            builder.Register(x => x.Resolve<IDictionaryAdapterFactory>()
                .GetAdapter<ISettings>(ConfigurationManager.AppSettings))
                .As<ISettings>().SingleInstance();

            // Resolve the specified settings by resolving ISettings then just taking the appropriate property
            builder.Register(x => x.Resolve<ISettings>().Client).As<IClientSettings>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}