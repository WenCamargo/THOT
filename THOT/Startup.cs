using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(THOT.Startup))]
namespace THOT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
