using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtecLibrary
{
    public class Coordinador
    {
        private int id_Coordinador;
        private string nombre;
        public Coordinador()
        {

        }
        public Coordinador(int id_Coordinador, string nombre)
        {
            Id_Coordinador = id_Coordinador;
            Nombre = nombre;
        }

        public int Id_Coordinador { get => id_Coordinador; set => id_Coordinador = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
