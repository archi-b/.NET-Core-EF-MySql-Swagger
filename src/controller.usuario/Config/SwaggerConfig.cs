using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;

namespace controller.usuario.Config
{
    public class SwaggerConfig
    {
        public string Version { get; } = "v1";
        public string Title { get; } = "Microservice controller.usuario";
        public string Description { get; } = "API REST criada com o ASP.NET Core";
        public string Contact { get; } = "jeisonmp";
        public string Url { get; } = "https://github.com/archi-b";

        /// <summary>
        /// Construtor da classe
        /// </summary>
        public SwaggerConfig() { }

        /// <summary>
        /// Cria SwaggerGenOptions para injeção de dependencia do serviço Swagger na ICollectionServices.
        /// IServiceCollection services.AddSwaggerGen(this.ConfigureServiceSwagger)
        /// </summary>
        /// <returns>Configuração do SwaggerGenOptions na IServiceCollection</returns>
        public Action<SwaggerGenOptions> ConfigureServiceSwaggerGen()
        {
            string caminhoAplicacao =
                PlatformServices.Default.Application.ApplicationBasePath;
            string nomeAplicacao =
                PlatformServices.Default.Application.ApplicationName;
            string caminhoXmlDoc =
                Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

            Action<SwaggerGenOptions> action = new Action<SwaggerGenOptions>(c =>
            {
                c.SwaggerDoc(this.Version,
                    new Info
                    {
                        Title = this.Title,
                        Version = this.Version,
                        Description = this.Description,
                        Contact = new Contact
                        {
                            Name = this.Contact,
                            Url = this.Url
                        }
                    });

                c.IncludeXmlComments(caminhoXmlDoc);
            });
            return action;
        }

        /// <summary>
        /// Cria SwaggerUI para compilação na IApplicationBuilder.
        /// </summary>
        /// <returns>Configuração do SwaggerUIOptions na IApplicationBuilde.</returns>
        public Action<SwaggerUIOptions> ConfigureSwaggerUI()
        {
            String caminhoSwaggerJson = $"/swagger/{this.Version}/swagger.json";

            Action<SwaggerUIOptions> action = new Action<SwaggerUIOptions>(c =>
            {
                c.SwaggerEndpoint(caminhoSwaggerJson, this.Title);
            });

            return action;
        }

    }
}
