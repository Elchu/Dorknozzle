using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dorknozzle.Startup))]
namespace dorknozzle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
