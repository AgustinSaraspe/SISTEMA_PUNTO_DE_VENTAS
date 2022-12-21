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
    public partial class mdAgregarDineroCaja : Form
    {

        public decimal montoAgregar;
        public mdAgregarDineroCaja()
        {
            InitializeComponent();
        }


        private void mdAgregarDineroCaja_Load(object sender, EventArgs e)
        {
            if (txtMontoAgregar.Text == "")
            {
                txtMontoAgregar.Text = "0";
                txtMontoAgregar.Select();
                txtMontoAgregar.SelectAll();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtMontoAgregar.Text == "" || txtMontoAgregar.Text == "0")
            {
                MessageBox.Show("Debe ingresar un monto para poder agregarlo en la caja", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                montoAgregar = Convert.ToDecimal(txtMontoAgregar.Text);

                string horaDeRegistro = DateTime.Now.ToString("HH:mm:ss");
                string fechaDeHoy = DateTime.Now.ToString("dd/MM/yyyy");

                Cliente cliente = new Cliente()
                {
                    NombreCliente = "",
                    DocumentoCliente = "",
                    Deuda = 0,
                    SaldoFavor = 0
                };

                int idCaja = new frmCaja().ObtenerIdCaja();

                Caja  filaAgregar = new Caja()
                {
                    IdCaja = idCaja,
                    FechaRegistro = fechaDeHoy,
                    Hora = horaDeRegistro,
                    Tipo = "Entrada",
                    Descripcion = "Entrada de dinero",
                    Cliente = cliente.NombreCliente,
                    Deuda = cliente.Deuda,
                    FormaPago = "",
                    TotalFinal = montoAgregar,
                    SaldoFavor = cliente.SaldoFavor,
                    EstadoCaja = 1
                };

                bool respusetaC = new CN_Caja().resgistrar(filaAgregar, out string mensajeC);

                if (respusetaC)
                {
                    MessageBox.Show("Se agrego el dinero a la caja", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(mensajeC, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void txtMontoAgregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtMontoAgregar.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        private void txtMontoAgregar_TextChanged(object sender, EventArgs e)
        {
            if (txtMontoAgregar.Text == "")
            {
                txtMontoAgregar.Text = "0";
                txtMontoAgregar.SelectAll();
            }
        }

        private void txtMontoAgregar_KeyDown(object sender, KeyEventArgs e)
        {
             if(e.KeyData == Keys.Enter)
             {
                if (txtMontoAgregar.Text == "" || txtMontoAgregar.Text == "0")
                {
                    MessageBox.Show("Debe ingresar un monto para poder agregarlo en la caja", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    montoAgregar = Convert.ToDecimal(txtMontoAgregar.Text);

                    string horaDeRegistro = DateTime.Now.ToString("HH:mm:ss");
                    string fechaDeHoy = DateTime.Now.ToString("dd/MM/yyyy");

                    Cliente cliente = new Cliente()
                    {
                        NombreCliente = "",
                        DocumentoCliente = "",
                        Deuda = 0,
                        SaldoFavor = 0
                    };

                    int idCaja = new frmCaja().ObtenerIdCaja();

                    Caja filaAgregar = new Caja()
                    {
                        IdCaja = idCaja,
                        FechaRegistro = fechaDeHoy,
                        Hora = horaDeRegistro,
                        Tipo = "Entrada",
                        Descripcion = "Entrada de dinero",
                        Cliente = cliente.NombreCliente,
                        Deuda = cliente.Deuda,
                        FormaPago = "",
                        TotalFinal = montoAgregar,
                        SaldoFavor = cliente.SaldoFavor,
                        EstadoCaja = 1
                    };

                    bool respusetaC = new CN_Caja().resgistrar(filaAgregar, out string mensajeC);

                    if (respusetaC)
                    {
                        MessageBox.Show("Se agrego el dinero a la caja", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(mensajeC, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
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
