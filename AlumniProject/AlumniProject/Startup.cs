using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlumniProject.Startup))]
namespace AlumniProject
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
