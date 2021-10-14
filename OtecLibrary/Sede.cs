using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtecLibrary
{
    class Sede
    {
        private int id_Sede;
        private string Nombre;
        private Administrador Administrador;
        private List<Curso> cursos;
        public Sede()
        { 
        }
        public Sede(int id_Sede, string nombre, Administrador administrador, List<Curso> cursos)
        {
            this.Id_Sede = id_Sede;
            Nombre1 = nombre;
            Administrador1 = administrador;
            this.Cursos = cursos;
        }

        public int Id_Sede { get => id_Sede; set => id_Sede = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public List<Curso> Cursos { get => cursos; set => cursos = value; }
        internal Administrador Administrador1 { get => Administrador; set => Administrador = value; }
    }
}
