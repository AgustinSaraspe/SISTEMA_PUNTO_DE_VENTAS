using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace SISTEMA_DE_VENTAS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void frm_closing(object sender, FormClosingEventArgs e) 
        {
            txtUsuario.Text = "";
            txtClave.Text = "";

            this.Show();
        }

        private void linkLCancelar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            Usuario objUsuario = new CN_Usuario().Listar().Where(u => u.NombreCompleto == txtUsuario.Text && u.Clave == txtClave.Text).FirstOrDefault(); 

            if (objUsuario != null)
            {
                Inicio form = new Inicio(objUsuario);
                form.Show();
                this.Hide();

                form.FormClosing += frm_closing;
            }
            else
            {
                MessageBox.Show("No se encontro el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                Usuario objUsuario = new CN_Usuario().Listar().Where(u => u.NombreCompleto == txtUsuario.Text && u.Clave == txtClave.Text).FirstOrDefault();

                if (objUsuario != null)
                {
                    Inicio form = new Inicio(objUsuario);
                    form.Show();
                    this.Hide();

                    form.FormClosing += frm_closing;
                }
                else
                {
                    MessageBox.Show("No se encontro el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
