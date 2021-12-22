using OtecLibrary;
using OtecLibraryConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OtecLibraryRepos
{
    class CoordinadorRepo
    {
        Datos data = new Datos();
        public List<Coordinador> listadoCoordinador()
        {
            DataSet respuesta = data.listado("Select * from sq_jg_coordinador");
            List<Coordinador> listadoCoordinador = new List<Coordinador>();
            foreach (DataRow item in respuesta.Tables[0].Rows)
            {
                Coordinador coordinador = new Coordinador();
                coordinador.Id_Coordinador = int.Parse(item.ItemArray[0].ToString());
                coordinador.Nombre = item.ItemArray[1].ToString();
                listadoCoordinador.Add(coordinador);
            }

            return listadoCoordinador;
        }
        public int postCoordinador(Coordinador coordinador)
        {
            string query = "insert into sq_jg_coordinador values ('" + coordinador.Nombre + "')";
            int resp = data.ejecutar(query);
            return resp;
        }
        public int putCoordinador(Coordinador coordinador)
        {
            string query = "update sq_jg_coordinador set nombre='" + coordinador.Nombre + "' where id_asignatura=" + coordinador.Id_Coordinador;
            int resp = data.ejecutar(query);
            return resp;
        }
        public int deleteCoordinador(int id_coordinador)
        {
            string query = "delete from sq_jg_coordinador where id_coordinador=" + id_coordinador;
            int resp = data.ejecutar(query);
            return resp;
        }
        public CoordinadorRepo()
        {

        }
    }
}
