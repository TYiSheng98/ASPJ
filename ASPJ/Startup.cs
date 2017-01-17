using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPJ.Startup))]
namespace ASPJ
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
