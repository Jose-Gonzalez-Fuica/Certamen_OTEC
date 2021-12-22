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
    public class AdministradorRepo
    {
        Datos data = new Datos();
        public List<Administrador> listadoAdministradores()
        {
            DataSet respuesta = data.listado("Select * from sq_jg_administrador");
            List<Administrador> listadoAdmin = new List<Administrador>();
            foreach(DataRow item in respuesta.Tables[0].Rows)
            {
                Administrador admin = new Administrador();
                admin.Id_administrador = int.Parse(item.ItemArray[0].ToString());
                admin.Nombre = item.ItemArray[1].ToString();
                admin.Rut = item.ItemArray[2].ToString();
                admin.Direccion= item.ItemArray[3].ToString();
                admin.Telefono= item.ItemArray[4].ToString();
                admin.Correo= item.ItemArray[5].ToString();
                listadoAdmin.Add(admin);
            }

            return listadoAdmin;
        }
        public int postAdmin(Administrador admin)
        {
            string query = "insert into sq_jg_administrador values ('"+admin.Nombre+"','"+admin.Rut+"','"+admin.Direccion+"','"+admin.Telefono+"','"+admin.Correo+"')";
            int resp=data.ejecutar(query);
            return resp;
        }
        public int putAdmin(Administrador admin)
        {
            string query = "update sq_jg_administrador set nombre='" + admin.Nombre + "',rut='" + admin.Rut + "',direccion='" + admin.Direccion + "',telefono='" + admin.Telefono + "',correo='" + admin.Correo + "' where id_administrador="+admin.Id_administrador;
            int resp = data.ejecutar(query);
            return resp;
        }
        public int deleteAdmin(int id_administrador)
        {
            string query = "delete from sq_jg_administrador where id_administrador="+id_administrador;
            int resp = data.ejecutar(query);
            return resp;
        }
        public AdministradorRepo()
        {

        }
    }
}
