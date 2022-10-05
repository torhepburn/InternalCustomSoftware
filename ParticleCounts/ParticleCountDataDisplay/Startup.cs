using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ParticleCountDataDisplay.Startup))]
namespace ParticleCountDataDisplay
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
