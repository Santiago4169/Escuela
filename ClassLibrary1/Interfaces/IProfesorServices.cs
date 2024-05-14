using Core.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IProfesorServices
    {
        List<ProfesorView> ConsultarServicies();

        ProfesorView ConsultarPorCodigo(int codigoProfesor);

        void Agregar(ProfesorView ProfesorNuevo);

        void Editar(int CodigoProfesoro, ProfesorView ProfesorEditar);

        void Eliminar(int CodigoProfesor);
    }
}
