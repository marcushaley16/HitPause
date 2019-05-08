using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DiscussionApp.WebMVC.Startup))]
namespace DiscussionApp.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
