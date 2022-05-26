using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PTPM_NET105_ValidateFrom.Areas.Identity.Data;
using PTPM_NET105_ValidateFrom.Data;

[assembly: HostingStartup(typeof(PTPM_NET105_ValidateFrom.Areas.Identity.IdentityHostingStartup))]
namespace PTPM_NET105_ValidateFrom.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ValidateFormContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ValidateFormContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options =>
                    {
                        options.SignIn.RequireConfirmedAccount = false;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireUppercase = false;
                    })
                    .AddEntityFrameworkStores<ValidateFormContext>();
            });
        }
    }
}