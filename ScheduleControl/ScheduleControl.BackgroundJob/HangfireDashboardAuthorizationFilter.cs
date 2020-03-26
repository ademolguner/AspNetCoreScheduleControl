﻿using Hangfire.Annotations;
using Hangfire.Dashboard;
using ScheduleControl.Core.Consts;
using System.Security.Claims;

namespace ScheduleControl.BackgroundJob
{
    public class HangfireDashboardAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull]DashboardContext context)
        {
            var httpContext = context.GetHttpContext();
            var useRole = "Admin";// httpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            return useRole == AppRoles.RoleEnums.Admin.ToString();
        }
    }
}