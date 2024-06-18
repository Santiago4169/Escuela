using Business.Interfaces;
using Core.ModelsView;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class AlumnoServices : IAlumnoServices
    {
        private readonly EscuelaContext _dbcontext;

        public AlumnoServices() { }

        public AlumnoServices(EscuelaContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<AlumnoView> ConsultarServicies()
        {
            List<AlumnoView> ListaAlumnoViews = new List<AlumnoView>();
            var ListServicies = _dbcontext.Alumnos.ToList();

            if (ListServicies != null)
            {
                foreach (var item in ListServicies)
                {
                    AlumnoView AlumnoView = new AlumnoView()
                    {
                        CodigoAlumno = item.CodigoAlumno,
                        NombreAlumno = item.NombreAlumno,
                        EdadAlumno = item.EdadAlumno,
                        SemestreAlumno = item.SemestreAlumno,
                        GeneroAlumno = item.GeneroAlumno,
                        CodigoCarrera1 = item.CodigoCarrera1,
                    };
                    ListaAlumnoViews.Add(AlumnoView);
                }
            }
            return ListaAlumnoViews;
        }
        public AlumnoView ConsultarPorCodigo(int codigoAlumno)
        {
            var alumno = _dbcontext.Alumnos.FirstOrDefault(a => a.CodigoAlumno == codigoAlumno);
            if (alumno != null)
            {
                var alumnoView = new AlumnoView
                {
                    CodigoAlumno = alumno.CodigoAlumno,
                    NombreAlumno = alumno.NombreAlumno,
                    EdadAlumno = alumno.EdadAlumno,
                    SemestreAlumno = alumno.SemestreAlumno,
                    GeneroAlumno = alumno.GeneroAlumno,
                    CodigoCarrera1 = alumno.CodigoCarrera1,
                };

                return alumnoView;
            }
            else
            {
                throw new Exception("El alumno no existe en la base de datos.");
            }

        }

        public void Agregar(AlumnoView AlumnoNuevo)
        {
            var existeAlumno = _dbcontext.Alumnos.Any(a => a.CodigoAlumno == AlumnoNuevo.CodigoAlumno);
            var existeCarrera = _dbcontext.Alumnos.Any(a => a.CodigoCarrera1 == AlumnoNuevo.CodigoCarrera1);

            if (existeAlumno)
            {
                throw new Exception("El alumno ya existe en la base de datos.");

            }
            if (!existeCarrera)
            {
                throw new Exception("El código de carrera no existe.");
            }
            var Alumno = new Alumno
            {
                CodigoAlumno = AlumnoNuevo.CodigoAlumno,
                NombreAlumno = AlumnoNuevo.NombreAlumno,
                EdadAlumno = AlumnoNuevo.EdadAlumno,
                SemestreAlumno = AlumnoNuevo.SemestreAlumno,
                GeneroAlumno = AlumnoNuevo.GeneroAlumno,
                CodigoCarrera1 = AlumnoNuevo.CodigoCarrera1,
            };
            _dbcontext.Alumnos.Add(Alumno);
            _dbcontext.SaveChanges();
        }

        public void Editar(int CodigoAlumno, AlumnoView AlumnoEditar)
        {
            var alumno = _dbcontext.Alumnos.FirstOrDefault(a => a.CodigoAlumno == CodigoAlumno);
            var existeCarrera = _dbcontext.Alumnos.Any(a => a.CodigoCarrera1 == AlumnoEditar.CodigoCarrera1);
            
            if (!existeCarrera)
            {
                throw new Exception("El código de carrera no existe.");
            }
            if (alumno != null)
            {
                alumno.CodigoAlumno = AlumnoEditar.CodigoAlumno;
                alumno.NombreAlumno = AlumnoEditar.NombreAlumno;
                alumno.EdadAlumno = AlumnoEditar.EdadAlumno;
                alumno.SemestreAlumno = AlumnoEditar.SemestreAlumno;
                alumno.GeneroAlumno = AlumnoEditar.GeneroAlumno;
                alumno.CodigoCarrera1 = AlumnoEditar.CodigoCarrera1;
                _dbcontext.SaveChanges();
            }
            else
            {
                throw new Exception("El alumno no existe en la base de datos.");
            }
        }

        public void Eliminar(int codigoAlumno)
        {
            var AlumnoAEliminar = _dbcontext.Alumnos.FirstOrDefault(a => a.CodigoAlumno == codigoAlumno);

            if (AlumnoAEliminar != null)
            {
                _dbcontext.Alumnos.Remove(AlumnoAEliminar);
                _dbcontext.SaveChanges();
            }
            else
            {
                throw new Exception("El alumno no existe en la base de datos.");
            }
        }
    }
}
