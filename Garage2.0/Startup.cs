using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Garage2._0.Startup))]
namespace Garage2._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
