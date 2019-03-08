using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Usuarios.Repository;
using Usuarios.Repository.Model;

namespace Usuarios.Service
{
    public class UsuarioService
    {
        private UsuarioRepository usuarioRepository = new UsuarioRepository();

        public Usuario validarUsuario(string username, string password)
        {
            return usuarioRepository.Select()
                .Where((c) => c.Login.Equals(username) && c.Senha.Equals(password))
                .FirstOrDefault();
        }
    }
}
