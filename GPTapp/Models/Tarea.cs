using System;
using System.Collections.Generic;

namespace GPTapp.Models
{
    public partial class Tarea
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string Descripcion { get; set; } = null!;
        public int? NivelDificultad { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? ProyectoId { get; set; }
        public string? UsuarioId { get; set; }
    }
}
