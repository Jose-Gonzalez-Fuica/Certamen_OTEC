using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtecLibrary
{
    public class Asignatura
    {
        private int id_asignatura;
        private string nombre;
        private string profesor;

        public Asignatura()
        {
        }

        public Asignatura(int id_asignatura, string nombre, string profesor)
        {
            this.Id_asignatura = id_asignatura;
            this.Nombre = nombre;
            this.Profesor = profesor;
        }

        public int Id_asignatura { get => id_asignatura; set => id_asignatura = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Profesor { get => profesor; set => profesor = value; }
    }
}
