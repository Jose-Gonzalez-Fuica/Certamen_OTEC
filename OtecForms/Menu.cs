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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void asignaturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Asignatura form = new Asignatura();
            form.Show();
        }

        private void coordinadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Coordinador form = new Coordinador();
            form.Show();
        }
    }
}
