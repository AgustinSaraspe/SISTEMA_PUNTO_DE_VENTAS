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
    public partial class mdCajaAbierta : Form
    {

        public decimal montoInicial;
        

        public mdCajaAbierta()
        {
            InitializeComponent();
        }

        private void mdCaja_Load(object sender, EventArgs e)
        {          
            if(txtMontoInicial.Text == "")
            {
                txtMontoInicial.Text = "0";
                txtMontoInicial.Select();
                txtMontoInicial.SelectAll();
            }
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            if (txtMontoInicial.Text == "" || txtMontoInicial.Text == "0")
            {
                MessageBox.Show("Debe ingresar un monto inicial para poder abrir la caja", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            { 
                    montoInicial = Convert.ToDecimal(txtMontoInicial.Text);

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

                    Caja filaApertura = new Caja()
                    {
                        IdCaja = idCaja,
                        FechaRegistro = fechaDeHoy,
                        Hora = horaDeRegistro,
                        Tipo = "Caja",
                        Descripcion = "Apertura de caja",
                        Cliente = cliente.NombreCliente,
                        Deuda = cliente.Deuda,
                        FormaPago = "",
                        TotalFinal = montoInicial,
                        SaldoFavor = cliente.SaldoFavor,
                        EstadoCaja = 1
                    };

                    bool respusetaC = new CN_Caja().resgistrar(filaApertura, out string mensajeC);

                    if (respusetaC)
                    {
                        MessageBox.Show("Se abrio una nueva caja", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(mensajeC, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                    }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtMontoInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtMontoInicial.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        private void txtMontoInicial_TextChanged(object sender, EventArgs e)
        {
            if (txtMontoInicial.Text == "")
            {
                txtMontoInicial.Text = "0";
                txtMontoInicial.SelectAll();
            }
        }

        private void txtMontoInicial_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {

                if (txtMontoInicial.Text == "" || txtMontoInicial.Text == "0")
                {
                    MessageBox.Show("Debe ingresar un monto inicial para poder abrir la caja", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    montoInicial = Convert.ToDecimal(txtMontoInicial.Text);

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

                    Caja  filaApertura = new Caja()
                    {
                        IdCaja = idCaja,
                        FechaRegistro = fechaDeHoy,
                        Hora = horaDeRegistro,
                        Tipo = "Caja",
                        Descripcion = "Apertura de caja",
                        Cliente = cliente.NombreCliente,
                        Deuda = cliente.Deuda,
                        FormaPago = "",
                        TotalFinal = montoInicial,
                        SaldoFavor = cliente.SaldoFavor,
                        EstadoCaja = 1
                    };

                    bool respusetaC = new CN_Caja().resgistrar(filaApertura, out string mensajeC);

                    if (respusetaC)
                    {
                        MessageBox.Show("Se abrió la caja", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(mensajeC, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                    }
                }
            }
        }
    }
    
}
