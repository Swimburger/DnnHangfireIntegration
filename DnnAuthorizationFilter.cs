using Hangfire.Dashboard;
using Microsoft.Owin;
using DotNetNuke.Entities.Users;

namespace DnnHangfireIntegration
{
    public class DnnAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            var owinContext = new OwinContext(context.GetOwinEnvironment());
            if (!owinContext.Authentication.User.Identity.IsAuthenticated)
            {
                return false;
            }

            var userInfo = UserController.GetUserByName(owinContext.Authentication.User.Identity.Name);
            return userInfo.IsSuperUser;
        }
    }
}