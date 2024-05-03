using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NotificationExample.Startup))]
namespace NotificationExample
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
