using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(a4Aero.Startup))]
namespace a4Aero
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
