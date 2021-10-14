using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtecLibrary
{
    public class Curso
    {
        private int id_Curso;
        private string nombre;
        private Coordinador coordinador;
        private List<Asignatura> asignaturas;

        public Curso()
        {

        }

        public Curso(int id_Curso, string nombre, Coordinador coordinador, List<Asignatura> asignaturas)
        {
            this.Id_Curso = id_Curso;
            this.Nombre = nombre;
            this.Coordinador = coordinador;
            this.Asignaturas = asignaturas;
        }

        public int Id_Curso { get => id_Curso; set => id_Curso = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public Coordinador Coordinador { get => coordinador; set => coordinador = value; }
        public List<Asignatura> Asignaturas { get => asignaturas; set => asignaturas = value; }
    }
}
