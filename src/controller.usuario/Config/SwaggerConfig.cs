using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
