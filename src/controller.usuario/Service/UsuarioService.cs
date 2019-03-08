using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Usuarios.Dto;
using Usuarios.Repository;
using Usuarios.Repository.Model;
using Usuarios.Utils;

namespace Usuarios.Service
{
    public class UsuarioService
    {
        private UsuarioRepository usuarioRepository = new UsuarioRepository();

        public UsuarioDTO validarUsuario(string username, string password)
        {
            return JsonHelper.toObject<UsuarioDTO>(usuarioRepository.validarUsuario(username, password));
        }
    }
}
