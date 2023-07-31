using ERCBelousova.DataBase;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ERCBelousova.Сonfiguration
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AuthDbContext>(options => options.UseSqlite("Data Sourse = Database\\app.db"));
            services.AddControllers();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app)
        {

        }

    }
}
