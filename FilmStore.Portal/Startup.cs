using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FilmStore.Portal.Startup))]
namespace FilmStore.Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
