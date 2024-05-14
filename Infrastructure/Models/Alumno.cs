using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class Alumno
    {
        public int CodigoAlumno { get; set; }
        public string? NombreAlumno { get; set; }
        public int? EdadAlumno { get; set; }
        public int? SemestreAlumno { get; set; }
        public string? GeneroAlumno { get; set; }
        public int? CodigoCarrera1 { get; set; }

        public virtual Carrera? CodigoCarrera1Navigation { get; set; }
    }
}
