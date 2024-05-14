using System;
using System.Collections.Generic;

namespace Escuela.Models
{
    public partial class Carrera
    {
        public Carrera()
        {
            Alumnos = new HashSet<Alumno>();
        }

        public int CodigoCarrera { get; set; }
        public string? NombreCarrera { get; set; }
        public double? DuracionCarrera { get; set; }

        public virtual ICollection<Alumno> Alumnos { get; set; }
    }
}
