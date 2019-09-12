using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UBooks.Startup))]
namespace UBooks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
