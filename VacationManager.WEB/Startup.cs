﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VacationManager.WEB.Startup))]
namespace VacationManager.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
