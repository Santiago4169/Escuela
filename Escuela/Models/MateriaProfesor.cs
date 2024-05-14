using System;
using System.Collections.Generic;

namespace Escuela.Models
{
    public partial class MateriaProfesor
    {
        public int? CodigoMateria2 { get; set; }
        public int? CodigoProfesor2 { get; set; }

        public virtual Materium? CodigoMateria2Navigation { get; set; }
        public virtual Profesor? CodigoProfesor2Navigation { get; set; }
    }
}
