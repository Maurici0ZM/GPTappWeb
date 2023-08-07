using System;
using System.Collections.Generic;

namespace GPTapp.Models
{
    public partial class Proyecto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } 
        public string Descripcion { get; set; } 
        public DateTime FechaInicio { get; set; }
    }
}
