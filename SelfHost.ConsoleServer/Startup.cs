﻿using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHost.ConsoleServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AuthConfig(app);
        }

    }
}
