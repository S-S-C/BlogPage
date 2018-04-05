using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogPage.Startup))]
namespace BlogPage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
