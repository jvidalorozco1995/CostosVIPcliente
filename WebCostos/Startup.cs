using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebCostos.Startup))]
namespace WebCostos
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
