using OtecLibrary;
using OtecLibraryRepos;
using OtecWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OtecWebApi.Controllers
{
    public class AdministradorController : ApiController
    {
        respuesta resp = new respuesta();
        AdministradorRepo adminEntity = new AdministradorRepo();
        [HttpGet]
        [Route("api/v1/getAdministradores")]
        public respuesta listar()
        {
           
            try
            {
                List<Administrador> listaAdmin = adminEntity.listadoAdministradores();
                resp.error = false;
                resp.mensaje = "ok";
                if (listaAdmin.Count > 0)
                    resp.data = listaAdmin;
                else
                    resp.data = "No se encontraron Administradores";
                return resp;
            }
            catch (Exception e)
            {

                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;
            }
        }
        [HttpPost]
        [Route("api/v1/postAdministrador")]
        public respuesta postAdmin(Administrador admin)
        {
            try
            {
                int valido = adminEntity.postAdmin(admin);
                if(valido==1)
                {
                    resp.error = false;
                    resp.mensaje = "Administrador Ingresado";
                    resp.data = admin;
                    return resp;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "Error al ingresar";
                    resp.data = null;
                    return resp;
                }
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;
            }
        }
        [HttpPut]
        [Route("api/v1/putAdministrador")]
        public respuesta putAdmin(Administrador admin)
        {
            try
            {
                int valido = adminEntity.putAdmin(admin);
                if (valido == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Administrador actualizado";
                    resp.data = admin;
                    return resp;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "Error al actualizar";
                    resp.data = null;
                    return resp;
                }
            }
            catch (Exception e)
            {

                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;
            }
        }
        [HttpDelete]
        [Route("api/v1/deleteAdministrador")]
        public respuesta deleteAdmin(int id_administrador)
        {
            try
            {
                int valido = adminEntity.deleteAdmin(id_administrador);
                if (valido >= 1)
                {
                    resp.error = false;
                    resp.mensaje = "Administradores borrados : "+valido;
                    resp.data = null;
                    return resp;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "Error al borrar";
                    resp.data = null;
                    return resp;
                }
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;
            }
        }
    }
   
}
