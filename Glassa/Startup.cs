using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Glassa.Startup))]
namespace Glassa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
