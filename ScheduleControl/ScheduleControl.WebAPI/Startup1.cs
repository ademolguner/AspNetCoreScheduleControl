using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace ScheduleControl.WebAPI
{
    [assembly:OwinStartup(typeof(ScheduleControl.WebAPI.Startup))]
    public class Startup1
    {
        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }
    }
}
