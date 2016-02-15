using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NinjectStore.Startup))]
namespace NinjectStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
