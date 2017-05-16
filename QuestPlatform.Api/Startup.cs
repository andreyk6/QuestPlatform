using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using QuestPlatform.Services.Configurations;

[assembly: OwinStartup(typeof(QuestPlatform.Api.Startup))]

namespace QuestPlatform.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AutoMapperConfig.Initialize();
            ConfigureAuth(app);
        }
    }
}
