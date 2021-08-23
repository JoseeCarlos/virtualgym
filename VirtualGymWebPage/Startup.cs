using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VirtualGymWebPage.Startup))]
namespace VirtualGymWebPage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {            
            app.MapSignalR();
        }
    }
}
