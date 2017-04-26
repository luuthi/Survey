using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SurveyWebApp.Startup))]
namespace SurveyWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
