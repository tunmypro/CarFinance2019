using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewAPI.Startup))]
namespace NewAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
