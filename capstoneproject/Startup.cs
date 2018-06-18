using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(capstoneproject.Startup))]
namespace capstoneproject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
