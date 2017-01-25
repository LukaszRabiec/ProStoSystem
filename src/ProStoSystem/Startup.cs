using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProStoSystem.Startup))]
namespace ProStoSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
