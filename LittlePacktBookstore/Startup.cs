using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using LittlePacktBookstore.Data;
using LittlePacktBookstore.Models;
using LittlePacktBookstore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace LittlePacktBookstore
{
    public class Startup
    {
		private IConfiguration _configuration;

		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1); ;
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "LittlePacktBookStore API", Version = "v1" });
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				c.IncludeXmlComments(xmlPath);
			});

			services.AddDbContext<LittlePacktBookStoreDbContex>(dbContextOptionBuilder =>
			dbContextOptionBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
			services.AddScoped<IRepository<Book>, SqlBooksRepository>();
			services.AddScoped<IRepository<Carousel>, SqlCarouselsRepository>();
			services.AddScoped<IRepository<Order>, SqlOrdersRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "LittlePacktBookStore API");
			});
			app.UseMvc(ConfigureRoutes);
			app.UseStaticFiles();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }

		private static void ConfigureRoutes(IRouteBuilder routes)
		{
			routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
		}

	}
}
