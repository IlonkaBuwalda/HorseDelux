using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HorseDelux.Startup))]
namespace HorseDelux
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
