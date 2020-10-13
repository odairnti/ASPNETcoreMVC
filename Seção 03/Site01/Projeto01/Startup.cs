using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.Sqlite;
using Site01.Database;

namespace Projeto01
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc(options => options.EnableEndpointRouting = false);
           // services.AddControllers(options => options.EnableEndpointRouting = false);
           // services.AddControllersWithViews(options => options.EnableEndpointRouting = false);
           // services.AddRazorPages().AddMvcOptions(options => options.EnableEndpointRouting = false);


            //ef = Entity Framework
            //para saber os acesso procurar no google por: provider ef
            services.AddDbContext<DatabaseContext>(options =>
            {
                //  options.UseSqlServer("Server=(localDB)\\MSSQLLocalDB;Database=Site01");
                options.UseSqlite("Data Source = Database\\BDados.db");
            });
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSession();

            app.UseRouting();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
