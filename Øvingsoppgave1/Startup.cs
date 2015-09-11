using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Øvingsoppgave1.Startup))]
namespace Øvingsoppgave1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
