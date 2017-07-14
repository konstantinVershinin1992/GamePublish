using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Game.Startup))]
namespace Game
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
