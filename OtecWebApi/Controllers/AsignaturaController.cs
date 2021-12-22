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
    public class AsignaturaController : ApiController
    {
        respuesta resp = new respuesta();
        AsignaturaRepo asignaturaEntity = new AsignaturaRepo();
        [HttpGet]
        [Route("api/v1/getAsignaturas")]
        public respuesta listar()
        {

            try
            {
                List<Asignatura> listaAsignatura = asignaturaEntity.listadoAsignaturas();
                resp.error = false;
                resp.mensaje = "ok";
                if (listaAsignatura.Count > 0)
                    resp.data = listaAsignatura;
                else
                    resp.data = "No se encontraron Asignaturas";
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
        [Route("api/v1/postAsignatura")]
        public respuesta postAsignatura(Asignatura asignatura)
        {
            try
            {
                int valido = asignaturaEntity.postAsignatura(asignatura);
                if (valido == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Asignatura Ingresada";
                    resp.data = asignatura;
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
        [Route("api/v1/putAsignatura")]
        public respuesta putAdmin(Asignatura asignatura)
        {
            try
            {
                int valido = asignaturaEntity.putAsignatura(asignatura);
                if (valido == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Asignatura actualizada";
                    resp.data = asignatura;
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
        [Route("api/v1/deleteAsignatura")]
        public respuesta deleteAsignatura(int id_asignatura)
        {
            try
            {
                int valido = asignaturaEntity.deleteAsignatura(id_asignatura);
                if (valido >= 1)
                {
                    resp.error = false;
                    resp.mensaje = "Asignaturas borradas : " + valido;
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
