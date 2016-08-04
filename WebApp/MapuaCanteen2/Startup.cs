using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MapuaCanteen2.Startup))]
namespace MapuaCanteen2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
