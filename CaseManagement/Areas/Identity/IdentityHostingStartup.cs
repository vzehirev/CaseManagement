using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(CaseManagement.Areas.Identity.IdentityHostingStartup))]
namespace CaseManagement.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}