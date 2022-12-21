using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_DE_VENTAS.Modales
{
    public partial class mdDescuento : Form
    {

        public decimal total;
        public decimal monto;
        public int DescuentoMonto;
        public mdDescuento(decimal totalActual)
        {
            total = totalActual;

            InitializeComponent();
        }

        private void mdDescuento_Load(object sender, EventArgs e)
        {

            if (txtDescuento.Text == "")
            {
                txtDescuento.Text = "0";
                txtDescuento.Select();
                txtDescuento.SelectAll();
            }

            if (txtMontoPorcentaje.Text == "")
            {
                txtMontoPorcentaje.Text = "0";
                txtMontoPorcentaje.SelectAll();
            }

            lblMonto.Text = total.ToString();
        }

        private void btnAgregarDescuento_Click(object sender, EventArgs e)
        {
            
            if(cbConPorcentaje.Checked == true)
            {
                DescuentoMonto = Convert.ToInt32(txtMontoPorcentaje.Text);
                decimal resultado = DescuentoMonto / 100;
                monto = resultado * total;
                cbSinPorcentaje.Checked = false;
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
            if(cbSinPorcentaje.Checked == true)
            {

                DescuentoMonto = Convert.ToInt32(txtDescuento.Text);
                monto = total - DescuentoMonto;
                cbConPorcentaje.Checked = false;
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningun tipo de descuento","Atencion",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtDescuento.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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


        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {

            if (txtDescuento.Text == "")
            {
                txtDescuento.Text = "0";
                txtDescuento.Select();
                txtDescuento.SelectAll();
            }
            else
            {
                monto = Convert.ToDecimal(txtDescuento.Text);

                lblMontoDescuento.Text = (total - monto).ToString();
            }
        }

        private void txtDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void txtMontoPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtMontoPorcentaje.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        private void txtMontoPorcentaje_TextChanged(object sender, EventArgs e)
        {
            if (txtDescuento.Text == "")
            {
                txtDescuento.Text = "0";
                txtDescuento.Select();
                txtDescuento.SelectAll();
            }
            else
            {
                monto = Convert.ToDecimal(txtDescuento.Text);

                lblMontoDescuento.Text = (total - monto).ToString();
            }
        }
    }
}
