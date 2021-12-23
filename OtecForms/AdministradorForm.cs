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
    public partial class AdministradorForm : Form
    {
        AdministradorRepo administradorEntity = new AdministradorRepo();
        public AdministradorForm()
        {
            InitializeComponent();
        }
        public string NombrePrevio = "";
        public string RUTPrevio = "";
        public string DireccionPrevio = "";
        public string TelefonoPrevio = "";
        public string CorreoPrevio = "";

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string advertencia = "";
            string NombreValidar = txtNombre.Text;
            string RUTValidar = txtRUT.Text;
            string DireccionValidar = txtDireccion.Text;
            string TelefonoValidar = txtTelefono.Text;
            string CorreoValidar = txtCorreo.Text;
            if (string.IsNullOrEmpty(NombreValidar) || NombreValidar.Trim() == string.Empty)
            {
                advertencia += "\nNombre";
            }
            if (string.IsNullOrEmpty(RUTValidar) || RUTValidar.Trim() == string.Empty)
            {
                advertencia += "\nRUT";
            }
            if (string.IsNullOrEmpty(DireccionValidar) || DireccionValidar.Trim() == string.Empty)
            {
                advertencia += "\nDireccion";
            }
            if (string.IsNullOrEmpty(TelefonoValidar) || TelefonoValidar.Trim() == string.Empty)
            {
                advertencia += "\nTelefono";
            }
            if (string.IsNullOrEmpty(CorreoValidar) || CorreoValidar.Trim() == string.Empty)
            {
                advertencia += "\nCorreo";
            }

            if (string.IsNullOrEmpty(advertencia))
            {
                Administrador administrador = new Administrador(0, NombreValidar, RUTValidar, DireccionValidar, TelefonoValidar,CorreoValidar);
                int ingreso = administradorEntity.postAdmin(administrador);
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

        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtRUT.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCorreo.Text = string.Empty;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Esta seguro que quiere eliminar este administrador?", "Advertencia", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                int id = (int)dgvAdministrador.CurrentRow.Cells[0].Value;
                int delete = administradorEntity.deleteAdmin(id);
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
        }

        private void AdministradorForm_Load(object sender, EventArgs e)
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
            List<Administrador> listaAdministrador = administradorEntity.listadoAdministradores();
            dgvAdministrador.DataSource = listaAdministrador;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dgvAdministrador_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            NombrePrevio = (string)dgvAdministrador.CurrentRow.Cells[1].Value;
            RUTPrevio = (string)dgvAdministrador.CurrentRow.Cells[2].Value;
            DireccionPrevio = (string)dgvAdministrador.CurrentRow.Cells[3].Value;
            TelefonoPrevio = (string)dgvAdministrador.CurrentRow.Cells[4].Value;
            CorreoPrevio = (string)dgvAdministrador.CurrentRow.Cells[5].Value;
        }

        private void dgvAdministrador_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var resultado = MessageBox.Show("Esta seguro que quiere modificar este campo?", "Advertencia", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                int id = (int)dgvAdministrador.CurrentRow.Cells[0].Value;
                string nombre = (string)dgvAdministrador.CurrentRow.Cells[1].Value;
                string RUT = (string)dgvAdministrador.CurrentRow.Cells[2].Value;
                string direccion = (string)dgvAdministrador.CurrentRow.Cells[3].Value;
                string telefono = (string)dgvAdministrador.CurrentRow.Cells[4].Value;
                string correo = (string)dgvAdministrador.CurrentRow.Cells[5].Value;
                string advertencia = "";

                if (string.IsNullOrEmpty(nombre) || nombre.Trim() == string.Empty)
                {
                    advertencia += "\nNombre";
                }
                if (string.IsNullOrEmpty(RUT) || RUT.Trim() == string.Empty)
                {
                    advertencia += "\nRUT";
                }
                if (string.IsNullOrEmpty(direccion) || direccion.Trim() == string.Empty)
                {
                    advertencia += "\nDireccion";
                }
                if (string.IsNullOrEmpty(telefono) || telefono.Trim() == string.Empty)
                {
                    advertencia += "\nTelefono";
                }
                if (string.IsNullOrEmpty(correo) || correo.Trim() == string.Empty)
                {
                    advertencia += "\nCorreo";
                }


                if (string.IsNullOrEmpty(advertencia))
                {
                    Administrador administrador = new Administrador(id, nombre, RUT, direccion, telefono, correo);
                    int put = administradorEntity.putAdmin(administrador);
                    MessageBox.Show("Los datos han sido modificados correctamente");
                }
                else
                {
                    MessageBox.Show("El siguiente campo no pudo ser modificado" + advertencia);
                    dgvAdministrador.CurrentRow.Cells[1].Value = NombrePrevio;
                    dgvAdministrador.CurrentRow.Cells[2].Value = RUTPrevio;
                    dgvAdministrador.CurrentRow.Cells[3].Value = DireccionPrevio;
                    dgvAdministrador.CurrentRow.Cells[4].Value = TelefonoPrevio;
                    dgvAdministrador.CurrentRow.Cells[5].Value = CorreoPrevio;
                }

            }
        }
    }
}
