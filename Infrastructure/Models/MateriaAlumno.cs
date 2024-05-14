using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class MateriaAlumno
    {
        public int? CodigoMateria1 { get; set; }
        public int? CodigoAlumno2 { get; set; }

        public virtual Alumno? CodigoAlumno2Navigation { get; set; }
        public virtual Materium? CodigoMateria1Navigation { get; set; }
    }
}
