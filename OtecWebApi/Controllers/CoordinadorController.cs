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
    public class CoordinadorController : ApiController
    {
        respuesta resp = new respuesta();
        CoordinadorRepo coordinadorEntity = new CoordinadorRepo();
        [HttpGet]
        [Route("api/v1/getCoordinadores")]
        public respuesta listar()
        {

            try
            {
                List<Coordinador> listaCoordinador = coordinadorEntity.listadoCoordinador();
                resp.error = false;
                resp.mensaje = "ok";
                if (listaCoordinador.Count > 0)
                    resp.data = listaCoordinador;
                else
                    resp.data = "No se encontraron Coordinadores";
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
        [Route("api/v1/postCoordinador")]
        public respuesta postAdmin(Coordinador coordinador)
        {
            try
            {
                int valido = coordinadorEntity.postCoordinador(coordinador);
                if (valido == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Coordinador Ingresado";
                    resp.data = coordinador;
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
        [Route("api/v1/putCoordinador")]
        public respuesta putAdmin(Coordinador coordinador)
        {
            try
            {
                int valido = coordinadorEntity.putCoordinador(coordinador);
                if (valido == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Coordinador actualizado";
                    resp.data = coordinador;
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
        [Route("api/v1/deleteCoordinador")]
        public respuesta deleteAdmin(int id_coordinador)
        {
            try
            {
                int valido = coordinadorEntity.deleteCoordinador(id_coordinador);
                if (valido >= 1)
                {
                    resp.error = false;
                    resp.mensaje = "Coordinadores borrados : " + valido;
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
