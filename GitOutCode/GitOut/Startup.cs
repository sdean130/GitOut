using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GitOut.Startup))]
namespace GitOut
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
