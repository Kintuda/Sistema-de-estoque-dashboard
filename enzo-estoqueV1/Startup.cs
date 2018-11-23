using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(enzo_estoqueV1.Startup))]
namespace enzo_estoqueV1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
