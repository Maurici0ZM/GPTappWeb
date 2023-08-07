using System;
using System.Collections.Generic;

namespace GPTapp.Models
{
    public partial class AsignacionTarea
    {
        public int Id { get; set; }
        public int? TareaId { get; set; }
        public int? UsuarioId { get; set; }
        public int? EstadoProyecto { get; set; }
        public DateTime? FechaAsignacion { get; set; }
        public DateTime? FechaLimite { get; set; }
    }
}
