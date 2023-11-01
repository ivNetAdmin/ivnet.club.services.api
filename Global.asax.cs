
//5K0l02&64
using Autofac;
using Autofac.Integration.WebApi;
using ivnet.club.services.api.Services;
using ivnet.club.services.api.Services.Interfaces;
using ivnet.club.services.api.Startup;
using System;
using System.Reflection;
using System.Web.Http;

namespace ivnet.club.services.api
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var containerbuilder = new ContainerBuilder();

            containerbuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            containerbuilder.RegisterType<RinkBookingDataService>().AsSelf();
            containerbuilder.RegisterType<ClubCodeDataService>().AsSelf();
            containerbuilder.RegisterType<UserDataService>().AsSelf();
            
            var container = containerbuilder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}