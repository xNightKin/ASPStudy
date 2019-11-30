using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MusicStore1.Startup))]
namespace MusicStore1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
