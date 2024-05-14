using Business.Interfaces;
using Core.ModelsView;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class ProfesorServices : IProfesorServices
    {
        private readonly EscuelaContext _dbcontext;

        public ProfesorServices() { }

        public ProfesorServices(EscuelaContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<ProfesorView> ConsultarServicies()
        {
            List<ProfesorView> ListaprofesorViews = new List<ProfesorView>();
            var ListServicies = _dbcontext.Profesors.ToList();

            if(ListServicies != null)
            {
                foreach(var item in ListServicies)
                {
                    ProfesorView profesorView = new ProfesorView()
                    {
                        CodigoProfesor = item.CodigoProfesor,
                        NombreProfesor = item.NombreProfesor,
                        DireccionProfesor = item.DireccionProfesor,
                        TelefonoProfesor = item.TelefonoProfesor,
                        HorarioProfesor = item.HorarioProfesor,
                    };
                    ListaprofesorViews.Add(profesorView);
                }
            }
            return ListaprofesorViews;
        }

        public ProfesorView ConsultarPorCodigo(int codigoProfesor)
        {
            var Profesor = _dbcontext.Profesors.FirstOrDefault(a => a.CodigoProfesor == codigoProfesor);
            if (Profesor != null)
            {
                var profesorView = new ProfesorView
                {
                    CodigoProfesor = Profesor.CodigoProfesor,
                    NombreProfesor = Profesor.NombreProfesor,
                    DireccionProfesor = Profesor.DireccionProfesor,
                    TelefonoProfesor = Profesor.TelefonoProfesor,
                    HorarioProfesor = Profesor.HorarioProfesor
                };

                return profesorView;
            }
            else
            {
                throw new Exception("El profesor no existe en la base de datos.");
            }

        }

        public void Agregar(ProfesorView ProfesorNuevo)
        {
            var existeProfesor = _dbcontext.Profesors.Any(a => a.CodigoProfesor == ProfesorNuevo.CodigoProfesor);

            if (existeProfesor)
            {
                throw new Exception("El profesor ya existe en la base de datos.");
            }
            var Profesor = new Profesor
            {
                CodigoProfesor = ProfesorNuevo.CodigoProfesor,
                NombreProfesor = ProfesorNuevo.NombreProfesor,
                DireccionProfesor = ProfesorNuevo.DireccionProfesor,
                TelefonoProfesor = ProfesorNuevo.TelefonoProfesor,
                HorarioProfesor = ProfesorNuevo.HorarioProfesor
            };
            _dbcontext.Profesors.Add(Profesor);
            _dbcontext.SaveChanges();
        }

        public void Editar(int CodigoProfesor, ProfesorView ProfesorEditar)
        {
            var profesor = _dbcontext.Profesors.FirstOrDefault(a => a.CodigoProfesor == CodigoProfesor);
            if (profesor != null)
            {
                profesor.CodigoProfesor = ProfesorEditar.CodigoProfesor;
                profesor.NombreProfesor = ProfesorEditar.NombreProfesor;
                profesor.DireccionProfesor = ProfesorEditar.DireccionProfesor;
                profesor.TelefonoProfesor = ProfesorEditar.TelefonoProfesor;
                profesor.HorarioProfesor = ProfesorEditar.HorarioProfesor;
                _dbcontext.SaveChanges();
            }
            else
            {
                throw new Exception("El profesor no existe en la base de datos.");
            }
        }

        public void Eliminar(int CodigoProfesor)
        {
            var ProfesorAEliminar = _dbcontext.Profesors.FirstOrDefault(a => a.CodigoProfesor == CodigoProfesor);

            if (ProfesorAEliminar != null)
            {
                _dbcontext.Profesors.Remove(ProfesorAEliminar);
                _dbcontext.SaveChanges();
            }
            else
            {
                throw new Exception("El Profesor no existe en la base de datos.");
            }
        }


    }
}
