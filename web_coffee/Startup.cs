using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(web_coffee.Startup))]
namespace web_coffee
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
