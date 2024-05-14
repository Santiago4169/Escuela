using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ModelsView
{
    public class AlumnoView
    {
        public int CodigoAlumno { get; set; }
        public string? NombreAlumno { get; set; }
        public int? EdadAlumno { get; set; }
        public int? SemestreAlumno { get; set; }
        public string? GeneroAlumno { get; set; }
        public int? CodigoCarrera1 { get; set; }
    }
}
