using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Faculity_System.Startup))]
namespace Faculity_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
