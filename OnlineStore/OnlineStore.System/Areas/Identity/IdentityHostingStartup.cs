using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.System.Areas.Identity.Data;
using OnlineStore.System.Data;

[assembly: HostingStartup(typeof(OnlineStore.System.Areas.Identity.IdentityHostingStartup))]
namespace OnlineStore.System.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<OnlineStoreDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("OnlineStoreDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    })
                    .AddEntityFrameworkStores<OnlineStoreDbContext>();
            });
        }
    }
}