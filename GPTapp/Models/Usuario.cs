using System;
using System.Collections.Generic;

namespace GPTapp.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string? NombreUsuario { get; set; }
        public string? ContraseñaUsuario { get; set; }
        public int? RolUsuario { get; set; }
        public int? Activo { get; set; }
    }
}
