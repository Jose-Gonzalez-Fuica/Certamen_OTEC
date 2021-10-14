using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtecLibrary
{
    class Coordinador
    {
        private int Id_Coordinador;
        private string Nombre;
        private Sede sede;
        public Coordinador()
        {

        }
        public Coordinador(int id_Coordinador, string nombre, Sede sede)
        {
            Id_Coordinador1 = id_Coordinador;
            Nombre1 = nombre;
            this.Sede = sede;
        }

        public int Id_Coordinador1 { get => Id_Coordinador; set => Id_Coordinador = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        internal Sede Sede { get => sede; set => sede = value; }
    }
}
