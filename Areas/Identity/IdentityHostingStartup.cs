using System;
using entrepreneur_tc_auth.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(entrepreneur_tc_auth.Areas.Identity.IdentityHostingStartup))]
namespace entrepreneur_tc_auth.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<entrepreneur_tc_authIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LiveDB")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<entrepreneur_tc_authIdentityDbContext>();
            });
        }
    }
}