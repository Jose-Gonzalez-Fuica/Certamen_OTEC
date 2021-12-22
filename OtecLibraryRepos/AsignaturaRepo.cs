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
    public class AsignaturaRepo
    {
        Datos data = new Datos();
        public List<Asignatura> listadoAsignaturas()
        {
            DataSet respuesta = data.listado("Select * from sq_jg_asignatura");
            List<Asignatura> listadoAsignatura = new List<Asignatura>();
            foreach (DataRow item in respuesta.Tables[0].Rows)
            {
                Asignatura asignatura = new Asignatura();
                asignatura.Id_asignatura = int.Parse(item.ItemArray[0].ToString());
                asignatura.Nombre = item.ItemArray[1].ToString();
                asignatura.Profesor = item.ItemArray[2].ToString();
                listadoAsignatura.Add(asignatura);
            }

            return listadoAsignatura;
        }
        public int postAsignatura(Asignatura asignatura)
        {
            string query = "insert into sq_jg_asignatura values ('" + asignatura.Nombre + "','" + asignatura.Profesor + "')";
            int resp = data.ejecutar(query);
            return resp;
        }
        public int putAsignatura(Asignatura asignatura)
        {
            string query = "update sq_jg_asignatura set nombre='" + asignatura.Nombre + "',profesor='" + asignatura.Profesor + "' where id_asignatura=" + asignatura.Id_asignatura;
            int resp = data.ejecutar(query);
            return resp;
        }
        public int deleteAsignatura(int id_asignatura)
        {
            string query = "delete from sq_jg_asignatura where id_asignatura=" + id_asignatura;
            int resp = data.ejecutar(query);
            return resp;
        }
        public AsignaturaRepo()
        {

        }
    }
}
