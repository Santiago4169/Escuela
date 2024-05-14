using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class AlumnoProfesor
    {
        public int? CodigoAlumno1 { get; set; }
        public int? CodigoProfesor1 { get; set; }

        public virtual Alumno? CodigoAlumno1Navigation { get; set; }
        public virtual Profesor? CodigoProfesor1Navigation { get; set; }
    }
}
