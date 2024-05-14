using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class Profesor
    {
        public int CodigoProfesor { get; set; }
        public string? NombreProfesor { get; set; }
        public string? DireccionProfesor { get; set; }
        public long? TelefonoProfesor { get; set; }
        public DateTime? HorarioProfesor { get; set; }
    }
}
