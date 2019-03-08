using Microsoft.AspNetCore.Mvc;
using Usuarios.Dto;
using Usuarios.Service;

namespace Usuarios.Controllers
{
    [Route("api/v1/cadastro/usuarios")]
    [ApiController]
    public class UsuarioController : BaseController
    {
        private UsuarioService usuarioService = new UsuarioService();

        /// <summary>
        /// Validação de usuario e senha.
        /// </summary>
        /// <param name="username">Login</param>
        /// <param name="password">Senha</param>
        /// <returns>Objeto usuário.</returns>
        /// <response code="404">Retorna nulo se o usuário é null.</response>
        [HttpPost("validar")]
        [ProducesResponseType(404)]
        public ActionResult<UsuarioDTO> ValidarUsuario(string username, string password)
        {
            var usuario = this.usuarioService.validarUsuario(username, password);

            if (usuario == null) return NotFound();
            return usuario;
        }

        ///// <summary>
        ///// Busca o usuário pelo seu identificador.
        ///// </summary>
        ///// <param name="id">Identificador</param>
        ///// <returns>Objeto usuário.</returns>
        ///// <response code="404">Retorna nulo se o usuário é null.</response>
        //[HttpGet("{id}")]
        //[ProducesResponseType(404)]
        //public ActionResult<Usuarios> Get(int id)
        //{
        //    var usuario = (from c in db.Usuarios
        //                   where c.Idusuario == id
        //                   select c)
        //                   //.Include(o => o.Perfis)
        //                   .FirstOrDefault();

        //    if (usuario.Equals(null)) return NotFound();
        //    return usuario;
        //}

        ///// <summary>
        ///// Busca o usuário pelo seu login de acesso.
        ///// </summary>
        ///// <param name="username">Login</param>
        ///// <returns>Objeto usuário.</returns>
        ///// <response code="404">Retorna nulo se o usuário é null.</response>
        //[HttpGet("{username}/login")]
        //[ProducesResponseType(404)]
        //public ActionResult<Usuarios> GetByUsername(string username)
        //{
        //    var usuario = (from c in db.Usuarios
        //                   where c.Login.Equals(username)
        //                   select c)
        //                   //.Include(o => o.Perfis)
        //                   .FirstOrDefault();

        //    if (usuario.Equals(null)) return NotFound();
        //    return usuario;
        //}

        ///// <summary>
        ///// Busca lista de usuários ativos no sistema.
        ///// </summary>
        ///// <returns>Lista de objetos usuários.</returns>
        ///// <response code="404">Retorna nulo se a lista é vazia.</response>
        //[HttpGet("ativos")]
        //[ProducesResponseType(404)]
        //public ActionResult<List<Usuarios>> GetAllAtivos()
        //{
        //    var usuarios = db.Usuarios
        //        .Where(o => o.IndAtivo == 1)
        //            //.Include(o => o.Perfis)
        //            .OrderBy(o => o.Login)
        //            .ToList();

        //    if (usuarios.Equals(null) || usuarios.Count() <= 0) return NotFound();
        //    return usuarios;
        //}

        ///// <summary>
        ///// Busca todos os usuários do sistema.
        ///// </summary>
        ///// <returns>Lista de objetos usuários.</returns>
        ///// <response code="404">Retorna nulo nulo se a lista é vazia.</response>
        //[HttpGet("")]
        //[ProducesResponseType(404)]
        //public ActionResult<List<Usuarios>> GetAll()
        //{
        //    var usuarios = db.Usuarios
        //        //.Include(o => o.Perfis)
        //        .OrderBy(o => o.Login)
        //        .ToList();

        //    if (usuarios.Equals(null) || usuarios.Count() <= 0) return NotFound();
        //    return usuarios;
        //}

        ///// <summary>
        ///// Atualização do usuário.
        ///// </summary>
        ///// <param name="id">Identificador único do usuário</param>
        ///// <param name="usuario">Objeto usuário contendo os novos dados</param>
        ///// <returns>Objeto usuário atualizado.</returns>
        //[HttpPut("{id}/atualizar")]
        //public ActionResult<Usuarios> Update(int id, [FromBody]Usuarios usuario)
        //{
        //    var data = this.Get(id);

        //    if (data.Equals(null)) return NotFound();

        //    data.Value.Email = usuario.Email;
        //    data.Value.Login = usuario.Login;
        //    data.Value.Senha = usuario.Senha;
        //    data.Value.Cpf = usuario.Cpf;

        //    db.Usuarios.Update(data.Value);
        //    db.SaveChanges();

        //    return data.Value;
        //}

        ///// <summary>
        ///// Cria novo usuário no sistema.
        ///// </summary>
        ///// <param name="usuario">Objeto usuário</param>
        ///// <returns>Objeto usuário criado.</returns>
        //[HttpPost("inserir")]
        //public Usuarios Insert([FromBody]Usuarios usuario)
        //{
        //    var _new = new Usuarios();
        //    _new.Email = usuario.Email;
        //    _new.Login = usuario.Login;
        //    _new.Senha = usuario.Senha;
        //    _new.Cpf = usuario.Cpf;

        //    db.Usuarios.Add(_new);
        //    db.SaveChanges();

        //    return _new;
        //}

        ///// <summary>
        ///// Exclui um usuário do sistema.
        ///// </summary>
        ///// <param name="id">Identificador único</param>
        ///// <returns>True|False</returns>
        //[HttpGet("{id}/deletar")]
        //public bool Delete(int id)
        //{
        //    try
        //    {
        //        this.Desvincular(id);

        //        var usuario = this.Get(id);
        //        db.Usuarios.Remove(usuario.Value);

        //        db.SaveChanges();
        //    }
        //    catch
        //    {
        //        return false;
        //    }

        //    return true;
        //}

        ///// <summary>
        ///// TODO: Verificar como desvincular no .NET Core
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //private bool Desvincular(int id)
        //{
        //    try
        //    {
        //        /// TODO: Verificar se precisa.
        //        /// Desabilita RequireAttribute
        //        //db.Configuration.ValidateOnSaveEnabled = false;

        //        /// TODO: Verificar se essa relacao funcionara no .NET Core
        //        /// Remove todas as relacoes com as marcas desse usuário.
        //        //db.UsuarioMarcas.Where(o => o.Idusuario.Equals(id)).ToList()
        //        //    .ForEach(o => db.UsuarioMarcas.Remove(o));
        //    }
        //    catch
        //    {
        //        return false;
        //    }

        //    return true;
        //}
    }
}
