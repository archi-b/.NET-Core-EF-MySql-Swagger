using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Usuarios.Repository.Model;

namespace Usuarios.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>
    {
        public Usuario validarUsuario(string username, string password) {

            return this.Select()
                    .Where((c) => c.Login.Equals(username) && c.Senha.Equals(password))
                    .FirstOrDefault();
        }
    }
}
