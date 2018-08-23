using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestEmailSendingFunctionality.Startup))]
namespace TestEmailSendingFunctionality
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
