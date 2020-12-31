using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DebateBoard.Startup))]
namespace DebateBoard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
