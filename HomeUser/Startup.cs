using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeUser.Startup))]
namespace HomeUser
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
