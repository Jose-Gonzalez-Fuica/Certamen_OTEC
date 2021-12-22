using OtecLibrary;
using OtecLibraryRepos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtecForms
{
    public partial class AsignaturaForm : Form
    {
        AsignaturaRepo asignaturaEntity = new AsignaturaRepo();
        public AsignaturaForm()
        {
            InitializeComponent();
        }
        public string NombrePrevio = "";
        public string ProfesorPrevio = "";
        private void button1_Click(object sender, EventArgs e)
        {
            int id = (int)dgvAsignatura.CurrentRow.Cells[0].Value;
            int delete = asignaturaEntity.deleteAsignatura(id);
            if (delete == 1)
            {
                MessageBox.Show("Los datos han sido eliminados correctamente");
                actualizarTabla();
            }
            else
            {
                MessageBox.Show("Los datos no pudieron ser eliminados");
            }

        }

        private void AsignaturaForm_Load(object sender, EventArgs e)
        {
            try
            {
                actualizarTabla();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void actualizarTabla()
        {
            List<Asignatura> listaAsignatura = asignaturaEntity.listadoAsignaturas();
            dgvAsignatura.DataSource = listaAsignatura;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string NombreValidar = txtNombre.Text;
            string ProfesorValidar = TxtProfesor.Text;
            string advertencia = "";
            if(string.IsNullOrEmpty(NombreValidar) || NombreValidar.Trim()==string.Empty)
            {
                advertencia = "\nNombre";
            }
            if(string.IsNullOrEmpty(ProfesorValidar) || NombreValidar.Trim() == string.Empty)
            {
                advertencia += "\nProfesor";
            }

            if (string.IsNullOrEmpty(advertencia))
            {
                Asignatura asignatura = new Asignatura(0,NombreValidar,ProfesorValidar);
                int ingreso = asignaturaEntity.postAsignatura(asignatura);
                if (ingreso == 1)
                {
                    MessageBox.Show("Los datos han sido ingresados correctamente");
                    actualizarTabla();
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Los datos no han podido ser ingresados");
                }
            }
            else
            {
                MessageBox.Show("Los siguientes campos estan vacios" + advertencia);
            }
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
            TxtProfesor.Text = string.Empty;
        }

        private void dgvAsignatura_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var resultado= MessageBox.Show("Esta seguro que quiere modificar este campo?", "Advertencia", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                int id = (int)dgvAsignatura.CurrentRow.Cells[0].Value;
                string nombre = (string)dgvAsignatura.CurrentRow.Cells[1].Value;
                string profesor = (string)dgvAsignatura.CurrentRow.Cells[2].Value;
                string advertencia = "";

                if (string.IsNullOrEmpty(nombre) || nombre.Trim() == string.Empty)
                {
                    advertencia = "\nNombre";
                }
                if (string.IsNullOrEmpty(profesor) || profesor.Trim() == string.Empty)
                {
                    advertencia += "\nProfesor";
                }

                
                if(string.IsNullOrEmpty(advertencia))
                {
                    Asignatura asignatura = new Asignatura(id, nombre, profesor);
                    int put = asignaturaEntity.putAsignatura(asignatura);
                    MessageBox.Show("Los datos han sido modificados correctamente");
                }
                else
                {
                    MessageBox.Show("El siguiente campo no pudo ser modificado" + advertencia);
                    dgvAsignatura.CurrentRow.Cells[1].Value = NombrePrevio;
                    dgvAsignatura.CurrentRow.Cells[2].Value = ProfesorPrevio;
                }

            }
        }

        private void dgvAsignatura_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            NombrePrevio = (string)dgvAsignatura.CurrentRow.Cells[1].Value;
            ProfesorPrevio = (string)dgvAsignatura.CurrentRow.Cells[2].Value;
        }
    }
}
