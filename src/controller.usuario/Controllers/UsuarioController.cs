using controller.usuario.Controllers;
using controller.usuario.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace incommerce.controller.usuario
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : BaseController
    {
        private readonly DBContext db;

        /// <summary>
        /// Construtor para api/usuario
        /// </summary>
        /// <param name="db">Contexto do banco de dados</param>
        public UsuarioController(DBContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Validação de usuario e senha.
        /// </summary>
        /// <param name="username">Login</param>
        /// <param name="password">Senha</param>
        /// <returns>Objeto usuário.</returns>
        /// <response code="404">Retorna nulo se o usuário é null.</response>
        [HttpPost("logged")]
        [ProducesResponseType(404)]
        public ActionResult<Usuarios> Logged(string username, string password)
        {
            var usuario = db.Usuarios.Where(
                    o =>
                        o.IndAtivo == 1 &&
                        o.Login == username &&
                        o.Senha == password)
                    //.Include(o => o.Perfis)
                    .FirstOrDefault();

            if (usuario == null) return NotFound();
            return usuario;
        }

        /// <summary>
        /// Busca o usuário pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto usuário.</returns>
        /// <response code="404">Retorna nulo se o usuário é null.</response>
        [HttpGet("get/{id}")]
        [ProducesResponseType(404)]
        public ActionResult<Usuarios> Get(int id)
        {
            var usuario = (from c in db.Usuarios
                           where c.Idusuario == id
                           select c)
                           //.Include(o => o.Perfis)
                           .FirstOrDefault();

            if (usuario.Equals(null)) return NotFound();
            return usuario;
        }

        /// <summary>
        /// Busca o usuário pelo seu login de acesso.
        /// </summary>
        /// <param name="username">Login</param>
        /// <returns>Objeto usuário.</returns>
        /// <response code="404">Retorna nulo se o usuário é null.</response>
        [HttpGet("getByUsername/{username}")]
        [ProducesResponseType(404)]
        public ActionResult<Usuarios> GetByUsername(string username)
        {
            var usuario = (from c in db.Usuarios
                           where c.Login.Equals(username)
                           select c)
                           //.Include(o => o.Perfis)
                           .FirstOrDefault();

            if (usuario.Equals(null)) return NotFound();
            return usuario;
        }

        /// <summary>
        /// Busca lista de usuários pelo seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único</param>
        /// <returns>Lista de objetos usuários.</returns>
        /// <response code="404">Retorna nulo se a lista é vazia.</response>
        [HttpGet("getList/{id}")]
        [ProducesResponseType(404)]
        public ActionResult<List<Usuarios>> GetList(int id)
        {
            var usuarios = (from c in db.Usuarios
                            where c.Idusuario.Equals(id)
                            select c)
                            //.Include(o => o.Perfis)
                            .ToList();

            if (usuarios.Equals(null) || usuarios.Count <= 0) return NotFound();
            return usuarios;
        }

        /// <summary>
        /// Busca lista de usuários ativos no sistema.
        /// </summary>
        /// <returns>Lista de objetos usuários.</returns>
        /// <response code="404">Retorna nulo se a lista é vazia.</response>
        [HttpGet("getAllAtivo")]
        [ProducesResponseType(404)]
        public ActionResult<List<Usuarios>> GetAllAtivos()
        {
            var usuarios = db.Usuarios
                .Where(o => o.IndAtivo == 1)
                    //.Include(o => o.Perfis)
                    .OrderBy(o => o.Login)
                    .ToList();

            if (usuarios.Equals(null) || usuarios.Count <= 0) return NotFound();
            return usuarios;
        }

        /// <summary>
        /// Busca todos os usuários do sistema.
        /// </summary>
        /// <returns>Lista de objetos usuários.</returns>
        /// <response code="404">Retorna nulo nulo se a lista é vazia.</response>
        [HttpGet("getAll")]
        [ProducesResponseType(404)]
        public ActionResult<List<Usuarios>> GetAll()
        {
            var usuarios = db.Usuarios
                //.Include(o => o.Perfis)
                .OrderBy(o => o.Login)
                .ToList();

            if (usuarios.Equals(null) || usuarios.Count <= 0) return NotFound();
            return usuarios;
        }

        /// <summary>
        /// Atualização do usuário.
        /// </summary>
        /// <param name="id">Identificador único do usuário</param>
        /// <param name="usuario">Objeto usuário contendo os novos dados</param>
        /// <returns>Objeto usuário atualizado.</returns>
        [HttpPut("update/{id}")]
        public ActionResult<Usuarios> Update(int id, [FromBody]Usuarios usuario)
        {
            var data = this.Get(id);

            if (data.Equals(null)) return NotFound();

            data.Value.Email = usuario.Email;
            data.Value.Login = usuario.Login;
            data.Value.Senha = usuario.Senha;
            data.Value.Cpf = usuario.Cpf;
            data.Value.IndAtivo = usuario.IndAtivo;
            data.Value.Idrevendedora = usuario.Idrevendedora;
            data.Value.Idperfil = usuario.Idperfil;

            db.Usuarios.Update(data.Value);
            db.SaveChanges();

            return data.Value;
        }

        /// <summary>
        /// Cria novo usuário no sistema.
        /// </summary>
        /// <param name="usuario">Objeto usuário</param>
        /// <returns>Objeto usuário criado.</returns>
        [HttpPost("insert")]
        public Usuarios Insert([FromBody]Usuarios usuario)
        {
            var _new = new Usuarios();
            _new.Email = usuario.Email;
            _new.Login = usuario.Login;
            _new.Senha = usuario.Senha;
            _new.Cpf = usuario.Cpf;
            _new.IndAtivo = usuario.IndAtivo;
            _new.Idrevendedora = usuario.Idrevendedora;
            _new.Idperfil = usuario.Idperfil;

            db.Usuarios.Add(_new);
            db.SaveChanges();

            return _new;
        }

        /// <summary>
        /// Exclui um usuário do sistema.
        /// </summary>
        /// <param name="id">Identificador único</param>
        /// <returns>True|False</returns>
        [HttpGet("delete/{id}")]
        public bool Delete(int id)
        {
            try
            {
                this.Desvincular(id);

                var usuario = this.Get(id);
                db.Usuarios.Remove(usuario.Value);

                db.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// TODO: Verificar como desvincular no .NET Core
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool Desvincular(int id)
        {
            try
            {
                /// Desabilita RequireAttribute
                // db.Configuration.ValidateOnSaveEnabled = false;

                /// Remove todas as relacoes com as marcas desse usuário.
                //db.UsuarioMarcas.Where(o => o.IDUsuario.Equals(id)).ToList()
                //    .ForEach(o => db.UsuarioMarcas.Remove(o));
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
