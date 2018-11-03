using controller.usuario.Config;
using controller.usuario.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

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

            services.AddDbContext<DBContext>(options =>
                   options.UseMySql(
                       Environment.GetEnvironmentVariable("MYSQL_CONNECTION")
                   ));

            services.AddMvc();

            //// Configurando o serviço de documentação do Swagger
            SwaggerConfig swagger = new SwaggerConfig();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(swagger.Version,
                    new Info
                    {
                        Title = swagger.Title,
                        Version = swagger.Version,
                        Description = swagger.Description,
                        Contact = new Contact
                        {
                            Name = swagger.Contact,
                            Url = swagger.Url
                        }
                    });

                string caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao =
                    PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            // Ativando middlewares para uso do Swagger
            SwaggerConfig swagger = new SwaggerConfig();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{swagger.Version}/swagger.json", swagger.Title);
            });
        }
    }
}
