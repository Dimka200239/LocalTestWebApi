using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LinqToDB.Configuration;
using LinqToDB.Data;
using LinqToDB.AspNet;
using Norbit.Sap.Georgiev.CSharpLastTask.Api.DB.DBDataProvider.Linq2DB;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.AspNetCore.Authentication.Negotiate;

namespace Norbit.Sap.Georgiev.CSharpLastTask.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddLinqToDbContext<Linq2DBMainBase>((provider, options) =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
            services.AddScoped<DataConnection, Linq2DBMainBase>();
            services.AddScoped<Linq2DBDataProvider, Linq2DBDataProvider>();
            services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();
            services.AddAuthorization(options => { options.FallbackPolicy = options.DefaultPolicy; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseAuthentication();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
