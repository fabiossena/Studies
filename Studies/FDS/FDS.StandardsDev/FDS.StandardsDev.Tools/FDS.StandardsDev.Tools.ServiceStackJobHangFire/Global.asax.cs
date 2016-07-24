using Hangfire;
using Microsoft.Owin;
using Owin;
using ServiceStack;
using System;

[assembly: OwinStartup(typeof(FDS.StandardsDev.Tools.ServiceStackJobHangFire.Startup))]
namespace FDS.StandardsDev.Tools.ServiceStackJobHangFire
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("Data Source=DESKTOP-OPKJQQJ;Initial Catalog=FDSJob;Integrated Security=True");

            app.UseHangfireDashboard();
            app.UseHangfireServer();

            RecurringJob.AddOrUpdate(() => test(), Cron.Minutely);
        }

        public void test()
        {
            Console.WriteLine("Daily Job");
        }
    }

 

    public class Global : System.Web.HttpApplication
    {
        public class AppHost : AppHostBase
        {
            //Tell ServiceStack the name of your application and where to find your services
            public AppHost() : base("ServiceStack Test Web Services", typeof(ServiceStackTestService).Assembly) { }

            public override void Configure(Funq.Container container)
            {
                //register any dependencies your services use, e.g:
                //container.Register<ICacheClient>(new MemoryCacheClient());
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            new AppHost().Init();
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