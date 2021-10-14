using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtecLibrary
{
    public class Sede
    {
        private int id_Sede;
        private string nombre;
        private Administrador administrador;
        private List<Curso> cursos;
        public Sede()
        { 
        }
        public Sede(int id_Sede, string nombre, Administrador administrador, List<Curso> cursos)
        {
            this.Id_Sede = id_Sede;
            this.Nombre = nombre;
            this.Administrador = administrador;
            this.Cursos = cursos;
        }

        public int Id_Sede { get => id_Sede; set => id_Sede = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public Administrador Administrador { get => administrador; set => administrador = value; }
        public List<Curso> Cursos { get => cursos; set => cursos = value; }
    }
}
