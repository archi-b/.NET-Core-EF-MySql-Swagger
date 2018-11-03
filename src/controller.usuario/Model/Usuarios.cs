using System;
using System.Collections.Generic;

namespace controller.usuario.Model
{
    public partial class Usuarios
    {
        public Usuarios()
        {
        }

        public int Idusuario { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public byte? IndAtivo { get; set; }
        public int? Idrevendedora { get; set; }
        public int? Idperfil { get; set; }
        
    }
}
