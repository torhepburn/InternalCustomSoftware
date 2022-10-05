using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSiteMasterTest.Startup))]
namespace WebSiteMasterTest
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
