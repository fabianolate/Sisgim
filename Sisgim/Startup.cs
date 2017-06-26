using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sisgim.Startup))]
namespace Sisgim
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
