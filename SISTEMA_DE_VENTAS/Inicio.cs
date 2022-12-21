using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using FontAwesome.Sharp;
using CapaNegocio;
using SISTEMA_DE_VENTAS.Modales;

namespace SISTEMA_DE_VENTAS
{
    public partial class Inicio : Form
    {  
        private static Usuario usuarioActual;
        private static IconMenuItem menuActual = null;
        private static Form formularioActual = null;

        public Inicio(Usuario objusuario)
        {
            usuarioActual = objusuario; 
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            frmCaja estadoC = new frmCaja();           
            bool resultadoCaja = estadoC.estadoCaja();

            if(resultadoCaja == true)
            {             
                var result = MessageBox.Show(" Se cerro el programa y la caja no \n ¿Desea cerrar la caja?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (result == DialogResult.Yes)
                {
                    estadoC.cerrarCaja();
                }

            }
           
            List<Permiso> listaPermisos = new CN_Permiso().Listar(usuarioActual.IdUsuario);

            foreach (IconMenuItem iconMenu in menu.Items)
            {
                bool busqueda = listaPermisos.Any(m => m.NombreMenu == iconMenu.Name);

                if (busqueda == false)
                {
                    iconMenu.Visible = false;
                }

            }

            lblUsuario.Text = usuarioActual.NombreCompleto;
        }

        private void abrirFormulario(IconMenuItem menu, Form formulario)
        {
            lblFecha.Visible = false;
            lblHora.Visible = false;

            if (menuActual != null)
            {
                menuActual.BackColor = Color.FromArgb(30, 30, 40);
                menuActual.IconColor = Color.White;
                menuActual.ForeColor = Color.White;
            }

            menu.BackColor = Color.FromArgb(80, 134, 150);
            menu.IconColor = Color.Black;
            menu.ForeColor = Color.Black;
            menuActual = menu;

            if (formularioActual != null)
            {
                formularioActual.Close();
            }

            formularioActual = formulario;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.TopLevel = false;
            formulario.Dock = DockStyle.Fill;
            contenedor.Controls.Add(formulario);
            formulario.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (menu.Width == 200)
            {
                menu.Width = 100;
            }
            else
            {
                menu.Width = 200;
            }
        }

        private void menuU_Click(object sender, EventArgs e)
        {
            abrirFormulario((IconMenuItem)sender, new FrmUsuario());          
        }

        private void submenuCA_Click(object sender, EventArgs e)
        {
            abrirFormulario(menuM, new FrmCategoria());         
        }

        private void submenuP_Click(object sender, EventArgs e)
        {
            abrirFormulario(menuM, new FrmProducto());
        }

        private void submenuR_Click(object sender, EventArgs e)
        {
            abrirFormulario(menuV, new FrmVentas(usuarioActual));
        }

        private void submenuD_Click(object sender, EventArgs e)
        {
            abrirFormulario(menuV, new FrmDetalleVenta());
        }

        private void menuCl_Click(object sender, EventArgs e)
        {
            abrirFormulario((IconMenuItem)sender, new frmClientes());
        }

        private void menuC_Click(object sender, EventArgs e)
        {
            abrirFormulario((IconMenuItem)sender, new frmCaja());
        }

        private void subMenuV_Click(object sender, EventArgs e)
        {
            abrirFormulario(menuR, new FrmReporteVentas());
        }

        private void subMenuc_Click(object sender, EventArgs e)
        {
            abrirFormulario(menuR, new FrmReporteCaja());           
        }

        private void menuR_MouseHover(object sender, EventArgs e)
        {          
            menuR.ForeColor = Color.Black;
            menuR.IconColor = Color.Black;      
        }

        private void menuR_MouseLeave(object sender, EventArgs e)
        {
            menuR.ForeColor = Color.White;
            menuR.IconColor = Color.White;

        }

        private void menuV_MouseHover(object sender, EventArgs e)
        {
            menuV.ForeColor = Color.Black;
            menuV.IconColor = Color.Black;
        }

        private void menuV_MouseLeave(object sender, EventArgs e)
        {
            menuV.ForeColor = Color.White;
            menuV.IconColor = Color.White;
        }

        private void menuM_MouseHover(object sender, EventArgs e)
        {
            menuM.ForeColor = Color.Black;
            menuM.IconColor = Color.Black;
        }

        private void menuM_MouseLeave(object sender, EventArgs e)
        {
            menuM.ForeColor = Color.White;
            menuM.IconColor = Color.White;
        }

        private void fechaHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            contenedor.Controls.Remove(formularioActual);
            lblFecha.Visible = true;
            lblHora.Visible = true;
        }

        private void lblCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
