using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Proyecto01.Startup))]

// Files related to ASP.NET Identity duplicate the Microsoft ASP.NET Identity file structure and contain initial Microsoft comments.

namespace Proyecto01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}