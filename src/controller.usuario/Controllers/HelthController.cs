
using Microsoft.AspNetCore.Mvc;

namespace incommerce.controller.usuario
{
    [Route("api/[controller]")]
    public class HelthController : Controller
    {
        /// <summary>
        /// Construtor para api/usuario
        /// </summary>
        public HelthController() { }

        /// <summary>
        /// Fornece a saúde do microserviço.
        /// </summary>
        /// <returns>Texto simples informando o status.</returns>
        [HttpGet("Helth")]
        public string Helth()
        {
            return "{ microservice = 'controller.usuario', status = 'success' }";
        }
    }
}
