using System;
using System.Collections.Generic;

namespace Usuarios.Repository.Model
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public sbyte? IndAtivo { get; set; }
    }
}
