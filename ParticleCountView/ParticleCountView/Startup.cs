using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ParticleCountView.Startup))]
namespace ParticleCountView
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
