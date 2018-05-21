using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Booooooooooooooooooook.Startup))]
namespace Booooooooooooooooooook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
