using Hangfire;
using Hangfire.Dashboard;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DnnHangfireIntegration.Startup))]

namespace DnnHangfireIntegration
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("HangfireConnection");
            app.UseHangfireServer();
            app.UseHangfireDashboard("/desktopmodules/hangfire", new DashboardOptions
            {
                Authorization = new[] { new DnnAuthorizationFilter() }
            });
        }
    }
}