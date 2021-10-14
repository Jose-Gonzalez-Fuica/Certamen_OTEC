using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OtecLibrary;

namespace Otec
{
    class Program
    {
        static void Main(string[] args)
        {
            Asignatura asignatura = new Asignatura(1, "Matematica", "Diego Sandoval");
            Asignatura asignatura1 = new Asignatura(1, "Computacion", "Sebastian");
            Asignatura asignatura2 = new Asignatura(1, "Lenguaje", "Diego Sandoval");
            Coordinador coordinador = new Coordinador(1, "Sebastian Quiroz");
            Administrador administrador = new Administrador(1, "Jose Gonzalez", "18.800.804-6", "Ruben Dario 551", "+56933723219", "jose.gonzalez@implementos.cl");
            List<Asignatura> lista = new List<Asignatura>();
            lista.Add(asignatura);
            lista.Add(asignatura1);
            lista.Add(asignatura2);
            Curso curso = new Curso(1, "Hackeo Etico I", coordinador, lista);
            List<Asignatura> lista2 = new List<Asignatura>(lista);
            lista2.Remove(asignatura2);
            Curso curso2 = new Curso(2, "Hackeo Etico II", coordinador, lista2);
            List<Curso> cursos = new List<Curso>();
            cursos.Add(curso);
            cursos.Add(curso2);
            Sede sede = new Sede(1, "Los Angeles", administrador, cursos);
            Console.WriteLine("Sede: "+sede.Nombre);
            Console.WriteLine("Datos del Administrador: ");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Administrador Nombre: " + sede.Administrador.Nombre);
            Console.WriteLine("Administrador rut: "+ sede.Administrador.Rut);
            Console.WriteLine("Administrador Direccion: "+ sede.Administrador.Direccion);
            Console.WriteLine("Administrador Numero: "+ sede.Administrador.Telefono);
            Console.WriteLine("Administrador Correo: "+ sede.Administrador.Correo);
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Cantidad de Cursos: "+ sede.Cursos.Count());
            string listaCursos="";
            foreach (var item in sede.Cursos)
            {
                listaCursos += "Nombre de curso: " + item.Nombre+"\n";
                listaCursos += "Coordinador de curso: " + item.Coordinador.Nombre+"\n";
                string listaAsignaturas="";
                foreach (var dato in item.Asignaturas)
                {
                    listaAsignaturas += "Asignatura de curso: " + dato.Nombre + "\n";
                    listaAsignaturas += "Profesor de la Asignatura: " + dato.Profesor + "\n";

                }
                listaCursos += "-----------------------------------------------------------------------------------------------------------------------\n";
                listaCursos += "Asignaturas del curso: \n" + listaAsignaturas;
                listaCursos += "-----------------------------------------------------------------------------------------------------------------------\n";

            }
            Console.WriteLine("Lista de cursos: ");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(listaCursos);
            Console.ReadKey();

        }
    }
}
