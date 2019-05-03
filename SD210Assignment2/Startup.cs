using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SD210Assignment2.Startup))]
namespace SD210Assignment2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
