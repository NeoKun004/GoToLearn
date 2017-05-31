using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoToLearn.Startup))]
namespace GoToLearn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
