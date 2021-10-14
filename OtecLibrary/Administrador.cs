using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtecLibrary
{
    public class Administrador
    {
        private int id_administrador;
        private string nombre;
        private string rut;
        private string direccion;
        private string telefono;
        private string correo;
        public Administrador()
        {

        }
        public Administrador(int id_administrador, string nombre, string rut, string direccion, string telefono, string correo)
        {
            this.Id_administrador = id_administrador;
            this.Nombre = nombre;
            this.Rut = rut;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Correo = correo;
        }

        public int Id_administrador { get => id_administrador; set => id_administrador = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Rut { get => rut; set => rut = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
    }
}
