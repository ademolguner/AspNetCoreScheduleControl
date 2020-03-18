using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Hangfire.Annotations;
using Hangfire.Dashboard;
using ScheduleControl.Core.Consts;

namespace ScheduleControl.BackgroundJob
{
   public  class HangfireDashboardAuthorizationFilter: IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull]DashboardContext context)
        {
            var httpContext = context.GetHttpContext();
            var useRole = "WebMaster";//httpContext.User.FindFirst(ClaimTypes.Role)?.Value;//"WebMaster";//
            return useRole == AppRoles.RoleEnums.WebMaster.ToString();
        }
    }
}
