using controller.usuario.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace incommerce.controller.usuario
{
    public class Startup
    {
        private IHostingEnvironment CurrentEnvironment { get; set; }
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            CurrentEnvironment = env;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
            services.AddCors();

            //services.AddDbContext<DBContext>(options =>
            //       options.UseMySql(
            //           Environment.GetEnvironmentVariable("DATABASE_CONNECTION")
            //       ));

            services.AddMvc();
            services.AddSwaggerGen(new SwaggerConfig().ConfigureServiceSwaggerGen());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(new SwaggerConfig().ConfigureSwaggerUI());
        }
    }
}
