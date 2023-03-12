using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PARKING.Windows
{
    public partial class frmInicio : Form
    {
        private IconMenuItem menuActivo = null;
        private Form formularioActivo = null;
        public frmInicio()
        {
            InitializeComponent();
        }

        private void BarraMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmInicio_Load(object sender, EventArgs e)
        {

        }

        private void ClientesMenu_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmClientes());
        }
        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (menuActivo != null)
            {
                menuActivo.BackColor = Color.White;
            }

            menu.BackColor = Color.Silver;
            menuActivo = menu;

            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            formularioActivo = formulario;

            contenedorPanel.Controls.Add(formulario);

            formulario.Show();

        }

        private void UsuariosMenu_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmIngresos());
        }

        private void iconMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmEgresos());
        }

        private void ProductosMenu_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmPlantas());
        }
    }
}
