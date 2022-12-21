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


namespace SISTEMA_DE_VENTAS.Modales
{
    public partial class mdEditarDeuda : Form
    {
        private decimal DeudaNueva;
        private decimal deudaActual;
        private int idCliente;
        public mdEditarDeuda(int id)
        {
            idCliente = id;
            InitializeComponent();
        }

        private void mdEditarDeuda_Load(object sender, EventArgs e)
        {
            if (txtDeuda.Text == "")
            {
                txtDeuda.Text = "0";
                txtDeuda.Select();
                txtDeuda.SelectAll();
            }

            List<Cliente> cliente = new CN_Cliente().ObtenerClienteId(idCliente);
            foreach (Cliente item in cliente)
            {
                deudaActual = item.Deuda;
            }

            lblDeudaActual.Text = deudaActual.ToString();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            var resultado = MessageBox.Show("¿Estas seguro que deseas editar la deuda del cliente a $" + (txtDeuda.Text) + "?", "Mensaje", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resultado == DialogResult.OK)
            {
                string mensaje = string.Empty;
                DeudaNueva = Convert.ToDecimal(txtDeuda.Text);
                var result = new CN_Cliente().editarDueda(idCliente, DeudaNueva, out mensaje);
                if (!result)
                {
                    MessageBox.Show("No se pudo editar la deuda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Se modifico correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
                
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDeuda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtDeuda.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtDeuda_TextChanged(object sender, EventArgs e)
        {
            if (txtDeuda.Text == "")
            {
                txtDeuda.Text = "0";
                txtDeuda.Select();
                txtDeuda.SelectAll();
            }
        }

        private void txtDeuda_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                var resultado = MessageBox.Show("¿Estas seguro que deseas editar la deuda del cliente a $" + (txtDeuda.Text) + "?", "Mensaje", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resultado == DialogResult.OK)
                {
                    string mensaje = string.Empty;
                    DeudaNueva = Convert.ToDecimal(txtDeuda.Text);
                    var result = new CN_Cliente().editarDueda(idCliente, DeudaNueva, out mensaje);
                    if (!result)
                    {
                        MessageBox.Show("No se pudo editar la deuda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Se modifico correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }
    }
}
