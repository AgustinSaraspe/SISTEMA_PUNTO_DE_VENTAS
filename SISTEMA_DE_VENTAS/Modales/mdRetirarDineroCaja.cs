using CapaEntidad;
using CapaNegocio;
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
    public partial class mdRetirarDineroCaja : Form
    {
        private decimal monto;
        public decimal montoRetirar;
        public mdRetirarDineroCaja(decimal montoActual)
        {
            monto = montoActual;
            InitializeComponent();
        }

        private void mdRetirarDineroCaja_Load(object sender, EventArgs e)
        {
            if (txtMontoRetirar.Text == "")
            {
                txtMontoRetirar.Text = "0";
                txtMontoRetirar.Select();
                txtMontoRetirar.SelectAll();
            }
        }
        private void btnRetirar_Click(object sender, EventArgs e)
        {
            if (txtMontoRetirar.Text == "" || txtMontoRetirar.Text == "0")
            {
                MessageBox.Show("Debe ingresar un monto para poder retirarlo de la caja", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            montoRetirar = Convert.ToDecimal(txtMontoRetirar.Text);

            if (montoRetirar <= monto)
            {

                string horaDeRegistro = DateTime.Now.ToString("HH:mm:ss");
                string fechaDeHoy = DateTime.Now.ToString("dd/MM/yyyy");

                Cliente cliente = new Cliente()
                {
                    NombreCliente = "",
                    DocumentoCliente = "",
                    Deuda = 0,
                    SaldoFavor = 0,
                };

                int idCaja = new frmCaja().ObtenerIdCaja();

                Caja filaRetirar = new Caja()
                {
                    IdCaja = idCaja,
                    FechaRegistro = fechaDeHoy,
                    Hora = horaDeRegistro,
                    Tipo = "Salida",
                    Descripcion = "Salida de dinero",
                    Cliente = cliente.NombreCliente,
                    Deuda = cliente.Deuda,
                    FormaPago = "",
                    TotalFinal = montoRetirar,
                    SaldoFavor = cliente.SaldoFavor,
                    EstadoCaja = -1
                };

                bool respusetaC = new CN_Caja().resgistrar(filaRetirar, out string mensajeC);

                if (respusetaC)
                {
                    MessageBox.Show("Se retiro el dinero de la caja", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(mensajeC, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("No se dispone de esa cantidad en la caja", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtMontoRetirar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtMontoRetirar.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        private void txtMontoRetirar_TextChanged(object sender, EventArgs e)
        {

            if (txtMontoRetirar.Text == "")
            {
                txtMontoRetirar.Text = "0";
                txtMontoRetirar.SelectAll();
            }
        }

        private void txtMontoRetirar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                if (txtMontoRetirar.Text == "" || txtMontoRetirar.Text == "0")
                {
                    MessageBox.Show("Debe ingresar un monto para poder retirarlo de la caja", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                montoRetirar = Convert.ToDecimal(txtMontoRetirar.Text);

                if (montoRetirar <= monto)
                {

                    string horaDeRegistro = DateTime.Now.ToString("HH:mm:ss");
                    string fechaDeHoy = DateTime.Now.ToString("dd/MM/yyyy");

                    Cliente cliente = new Cliente()
                    {
                        NombreCliente = "",
                        DocumentoCliente = "",
                        Deuda = 0,
                        SaldoFavor = 0,
                    };

                    int idCaja = new frmCaja().ObtenerIdCaja();

                    Caja filaRetirar = new Caja()
                    {
                        IdCaja = idCaja,
                        FechaRegistro = fechaDeHoy,
                        Hora = horaDeRegistro,
                        Tipo = "Salida",
                        Descripcion = "Salida de dinero",
                        Cliente = cliente.NombreCliente,
                        Deuda = cliente.Deuda,
                        FormaPago = "",
                        TotalFinal = montoRetirar,
                        SaldoFavor = cliente.SaldoFavor,
                        EstadoCaja = -1
                    };

                    bool respusetaC = new CN_Caja().resgistrar(filaRetirar, out string mensajeC);

                    if (respusetaC)
                    {
                        MessageBox.Show("Se retiro el dinero de la caja", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(mensajeC, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("No se dispone de esa cantidad en la caja", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
