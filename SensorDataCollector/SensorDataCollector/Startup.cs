using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SensorDataCollector.Startup))]
namespace SensorDataCollector
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
