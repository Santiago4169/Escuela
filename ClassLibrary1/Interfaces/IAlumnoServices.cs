using Core.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IAlumnoServices
    {
        List<AlumnoView> ConsultarServicies();
        AlumnoView ConsultarPorCodigo(int codigoAlumno);

        void Agregar(AlumnoView AlumnoNuevo);

        void Editar(int CodigoAlumno, AlumnoView AlumnoEditar);

        void Eliminar(int CodigoAlumno);
    }
}
