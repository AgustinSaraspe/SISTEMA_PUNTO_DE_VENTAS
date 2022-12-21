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
    public partial class mdEditarSaldoCliente : Form
    {
        private decimal saldoNuevo;
        private decimal saldoActual;
        private int idCliente;
        public mdEditarSaldoCliente(int id)
        {
            idCliente = id;
            InitializeComponent();
        }

        private void mdEditarSaldoCliente_Load(object sender, EventArgs e)
        {
            if (txtSaldo.Text == "")
            {
                txtSaldo.Text = "0";
                txtSaldo.Select();
                txtSaldo.SelectAll();
            }

            List<Cliente> cliente = new CN_Cliente().ObtenerClienteId(idCliente);
            foreach(Cliente item in cliente)
            {
                saldoActual = item.SaldoFavor;
            }

            lblSaldoActual.Text = saldoActual.ToString();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Estas seguro que deseas editar el saldo a favor del cliente a $"+(txtSaldo.Text)+"?","Mensaje", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resultado == DialogResult.OK)
            {
                string mensaje = string.Empty;
                saldoNuevo = Convert.ToDecimal(txtSaldo.Text);
                var result = new CN_Cliente().editarSaldoFavor(idCliente, saldoNuevo, out mensaje);
                if (!result)
                {
                    MessageBox.Show("No se pudo editar el saldo a favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtSaldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtSaldo.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        private void txtSaldo_TextChanged(object sender, EventArgs e)
        {
            if (txtSaldo.Text == "")
            {
                txtSaldo.Text = "0";
                txtSaldo.Select();
                txtSaldo.SelectAll();
            }
        }

        private void txtSaldo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                var resultado = MessageBox.Show("¿Estas seguro que deseas editar el saldo a favor del cliente a $" + (txtSaldo.Text) + "?", "Mensaje", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resultado == DialogResult.OK)
                {
                    string mensaje = string.Empty;
                    saldoNuevo = Convert.ToDecimal(txtSaldo.Text);
                    var result = new CN_Cliente().editarSaldoFavor(idCliente, saldoNuevo, out mensaje);
                    if (!result)
                    {
                        MessageBox.Show("No se pudo editar el saldo a favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
