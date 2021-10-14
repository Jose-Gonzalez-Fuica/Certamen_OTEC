using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtecLibrary
{
    class Curso
    {
        private int id_Curso;
        private string nombre;
        private Coordinador coordinador;
        private List<Asignatura> asignatura;

        public Curso()
        {

        }

        public Curso(int id_Curso, string nombre, Coordinador coordinador, List<Asignatura> asignatura)
        {
            this.id_Curso = id_Curso;
            this.nombre = nombre;
            this.coordinador = coordinador;
            this.asignatura = asignatura;
        }
    }
}
