using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CraftsWebsite.Startup))]
namespace CraftsWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
