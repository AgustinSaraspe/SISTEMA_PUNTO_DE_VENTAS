using CapaEntidad;
using SISTEMA_DE_VENTAS.ComboBox;
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


namespace SISTEMA_DE_VENTAS.Modales
{
    public partial class mdVenta : Form
    {

        public Cliente clienteExiste;

        private decimal deudaAcutal;
        public decimal deuda = 0;

        public decimal saldoFavorActual;
        public decimal saldoFavor = 0;

        public decimal totalActual;
        public decimal totalActualConDescuento;

        public decimal DCambio;
        public string DFormaPago;
        public decimal montoPago;
        public decimal montoDescuento;

        public mdVenta(decimal total, Cliente cliente)
        {
            clienteExiste = cliente;
            totalActual = total;


            InitializeComponent();
        }

        private void mdVenta_Load(object sender, EventArgs e)
        {
            cboFormaPago.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Contado" });
            cboFormaPago.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Debito" });
            cboFormaPago.Items.Add(new OpcionCombo() { Valor = 2, Texto = "Tarjeta" });
            cboFormaPago.DisplayMember = "Texto";
            cboFormaPago.ValueMember = "Valor";
            cboFormaPago.SelectedIndex = 0;


            labelTotal.Text = totalActual.ToString();

            if (txtPagaCon.Text.Trim() == "")
            {
                txtPagaCon.Text = "0";
                txtPagaCon.SelectAll();
            }

            if (clienteExiste.EstadoCliente == 1)
            {
               
                int id = clienteExiste.IdCliente;
                List<Cliente> obj = new CN_Cliente().ObtenerClienteId(id);
                foreach (Cliente item in obj)
                {
                    saldoFavorActual = item.SaldoFavor;

                    if (saldoFavorActual > 0)
                    {
                        cbPagarConSaldoFavor.Visible = true;
                        lblsaldo.Text = saldoFavorActual.ToString();
                    }
                }
            }
            else
            {
                cbPagarConSaldoFavor.Visible = false;
                lblsaldo.Text = "";
            }          
        }

        private void txtPagaCon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)          
            {
                calcularCambio();

                DFormaPago = ((OpcionCombo)cboFormaPago.SelectedItem).Texto;

                if (cbAgregarDeuda.Checked == true)
                {
                    if (clienteExiste.EstadoCliente == 0)
                    {
                        var result = MessageBox.Show("No se a seleccionado un cliente, presiona aceptar para hacerlo", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.OK)
                        {
                            mdClienteVenta _cliente = new mdClienteVenta();
                            var resultado = _cliente.ShowDialog();
                            if (resultado == DialogResult.OK)
                            {
                                clienteExiste = new Cliente()
                                {
                                    IdCliente = _cliente._Cliente.IdCliente,
                                    NombreCliente = _cliente._Cliente.NombreCliente,
                                    DocumentoCliente = _cliente._Cliente.DocumentoCliente,
                                    Telefono = _cliente._Cliente.Telefono,
                                    Direccion = _cliente._Cliente.Direccion,
                                    Correo = _cliente._Cliente.Correo,
                                    Deuda = _cliente._Cliente.Deuda,
                                    SaldoFavor = _cliente._Cliente.SaldoFavor,
                                    EstadoCliente = _cliente._Cliente.EstadoCliente
                                };                               
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        List<Cliente> obj = new CN_Cliente().ObtenerClienteId(clienteExiste.IdCliente);
                        foreach (Cliente item in obj)
                        {
                            deudaAcutal = item.Deuda;
                        }

                        deuda = deuda + deudaAcutal;


                        var respuesta = new CN_Cliente().editarDueda(clienteExiste.IdCliente, deuda, out string Mensaje);
                        if (respuesta)
                        {

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo modificar la deuda del cliente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Close();
                        }
                    }                    
                }
                else if (cbAgregarSaldoFavor.Checked == true)
                {
                    if (clienteExiste.EstadoCliente == 0)
                    {
                        var result = MessageBox.Show("No se a seleccionado un cliente, presiona aceptar para hacerlo", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.OK)
                        {
                            mdClienteVenta _cliente = new mdClienteVenta();
                            var resultado = _cliente.ShowDialog();
                            if (resultado == DialogResult.OK)
                            {
                                clienteExiste = new Cliente()
                                {
                                    IdCliente = _cliente._Cliente.IdCliente,
                                    NombreCliente = _cliente._Cliente.NombreCliente,
                                    DocumentoCliente = _cliente._Cliente.DocumentoCliente,
                                    Telefono = _cliente._Cliente.Telefono,
                                    Direccion = _cliente._Cliente.Direccion,
                                    Correo = _cliente._Cliente.Correo,
                                    Deuda = _cliente._Cliente.Deuda,
                                    SaldoFavor = _cliente._Cliente.SaldoFavor,
                                    EstadoCliente = _cliente._Cliente.EstadoCliente
                                };
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        int id = clienteExiste.IdCliente;
                        List<Cliente> obj = new CN_Cliente().ObtenerClienteId(id);
                        foreach (Cliente item in obj)
                        {
                            saldoFavorActual = item.SaldoFavor;
                        }

                        saldoFavor = saldoFavorActual + saldoFavor;

                        var respuesta = new CN_Cliente().editarSaldoFavor(id, saldoFavor, out string Mensaje);
                        if (respuesta)
                        {
                            DCambio = 0;
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo modificar el saldo a favor del cliente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Close();
                        }
                    }
                }
                else if (cbPagarConSaldoFavor.Checked == true)
                {

                    if (clienteExiste.EstadoCliente == 1)
                    {
                        List<Cliente> obj = new CN_Cliente().ObtenerClienteId(clienteExiste.IdCliente);
                        foreach (Cliente item in obj)
                        {
                            saldoFavor = item.SaldoFavor;
                        }
                        if (saldoFavor >= totalActual)
                        {

                            saldoFavor = saldoFavor - totalActual;
                            totalActual = 0;

                            var respuesta = new CN_Cliente().editarSaldoFavor(clienteExiste.IdCliente, saldoFavor, out string Mensaje);
                            if (!respuesta)
                            {
                                MessageBox.Show("No se pudo modificar el saldo a favor del cliente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                DCambio = 0;
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }


                        }
                        else if (saldoFavor <= totalActual)
                        {
                            totalActual = totalActual - saldoFavor;
                            saldoFavor = 0;

                            var respuesta = new CN_Cliente().editarSaldoFavor(clienteExiste.IdCliente, saldoFavor, out string Mensaje);
                            if (!respuesta)
                            {
                                MessageBox.Show("No se pudo modificar el saldo a favor del cliente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            if (totalActual > 0)
                            {
                                labelTotal.Text = totalActual.ToString();
                                cbPagarConSaldoFavor.Visible = false;
                                cbPagarConSaldoFavor.Checked = false;
                                lblsaldo.Text = "";
                                labelTotal.Text = totalActual.ToString();
                            }
                        }
                    }
                }
                else
                {               
                    if(montoPago < totalActual || montoPago < totalActualConDescuento)
                    {
                        MessageBox.Show("Falta dinero por abonar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }                    
                }
                            
            }
            if(e.KeyData == Keys.F4)
            {
                mdDescuento modal = new mdDescuento(totalActual);
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    montoDescuento = modal.DescuentoMonto;
                    totalActualConDescuento = modal.monto;

                    if (montoDescuento == 0)
                    {
                        return;
                    }
                    if (montoDescuento > 0)
                    {
                        lblMontoDescuento.Text = totalActualConDescuento.ToString();
                        lblDescuento.Text = montoDescuento.ToString();
                        lblDescuento.ForeColor = Color.Red;
                        calcularCambio();
                    }
                }
            }
        }

        public void calcularCambio()
        {

            decimal pagaCon;
            decimal total;

            if (montoDescuento != 0)
            {
                 total = totalActualConDescuento;

            }
            else
            {
                 total = totalActual;
            }


            if (total == 0 && montoDescuento == 0)
            {
                MessageBox.Show("No existen productos en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtPagaCon.Text.Trim() == "")
            {
                txtPagaCon.Text = "0";
                txtPagaCon.SelectAll();

            }

            if (decimal.TryParse(txtPagaCon.Text.Trim(), out pagaCon))
            {
                if (pagaCon < total)
                {
                    cbAgregarDeuda.Visible = true;
                    deuda = total - pagaCon;
                    lblDeuda.Visible = true;
                    lblDeuda.Text = "Falta " + deuda + " pagar";
                    cbAgregarDeuda.Text = "Dejar a cliente deuda";
                    montoPago = pagaCon;
                    //-------------------------------------------

                    cbAgregarSaldoFavor.Visible = false;
                    lblSaldoFavor.Visible = false;
                    DCambio = 0;
                    labelCambio.Text = "0.00";

                }
                if (pagaCon > total)
                {
                    cbAgregarSaldoFavor.Visible = true;
                    saldoFavor = pagaCon - total;
                    lblSaldoFavor.Visible = true;
                    lblSaldoFavor.Text = "Dejar saldo " + saldoFavor + " a favor";
                    cbAgregarSaldoFavor.Text = "Dejar saldo a favor";
                    //---------------------------------

                    cbAgregarDeuda.Visible = false;
                    lblDeuda.Visible = false;

                    //---------------------cambio

                    montoPago = pagaCon;
                    DCambio = pagaCon - total;
                    labelCambio.Text = DCambio.ToString("0.00");                 
                }
                if(pagaCon == total)
                {
                    montoPago = pagaCon;
                    DCambio = pagaCon - total;
                    labelCambio.Text = DCambio.ToString("0.00");

                    //----------------------------------------

                    cbAgregarSaldoFavor.Visible = false;
                    cbAgregarDeuda.Visible = false;
                    lblSaldoFavor.Visible = false;
                    lblDeuda.Visible = false;
                }

            }
        }
        private void btnDescuento_Click(object sender, EventArgs e)
        {
            mdDescuento modal = new mdDescuento(totalActual);
            var result = modal.ShowDialog();
            if(result == DialogResult.OK)
            {
                montoDescuento = modal.DescuentoMonto;
                totalActualConDescuento = modal.monto;

                if (montoDescuento == 0)
                {
                    return;
                }
                if(montoDescuento > 0)
                {  
                    lblMontoDescuento.Text = totalActualConDescuento.ToString();
                    lblDescuento.Text = montoDescuento.ToString();
                    lblDescuento.ForeColor = Color.Red;
                    calcularCambio();
                }
            }
        }
        
        private void txtPagaCon_KeyUp(object sender, KeyEventArgs e)
        {
            calcularCambio();
        }

        private void txtPagaCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPagaCon.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        private void btnRealizarVenta_Click(object sender, EventArgs e)
        {
            calcularCambio();

            DFormaPago = ((OpcionCombo)cboFormaPago.SelectedItem).Texto;

            if (cbAgregarDeuda.Checked == true)
            {
                if (clienteExiste.EstadoCliente == 0)
                {
                    var result = MessageBox.Show("No se a seleccionado un cliente, presiona aceptar para hacerlo", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        mdClienteVenta _cliente = new mdClienteVenta();
                        var resultado = _cliente.ShowDialog();
                        if (resultado == DialogResult.OK)
                        {
                            clienteExiste = new Cliente()
                            {
                                IdCliente = _cliente._Cliente.IdCliente,
                                NombreCliente = _cliente._Cliente.NombreCliente,
                                DocumentoCliente = _cliente._Cliente.DocumentoCliente,
                                Telefono = _cliente._Cliente.Telefono,
                                Direccion = _cliente._Cliente.Direccion,
                                Correo = _cliente._Cliente.Correo,
                                Deuda = _cliente._Cliente.Deuda,
                                SaldoFavor = _cliente._Cliente.SaldoFavor,
                                EstadoCliente = _cliente._Cliente.EstadoCliente
                            };
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    List<Cliente> obj = new CN_Cliente().ObtenerClienteId(clienteExiste.IdCliente);
                    foreach (Cliente item in obj)
                    {
                        deudaAcutal = item.Deuda;
                    }

                    deuda = deuda + deudaAcutal;


                    var respuesta = new CN_Cliente().editarDueda(clienteExiste.IdCliente, deuda, out string Mensaje);
                    if (respuesta)
                    {

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo modificar la deuda del cliente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                }
            }
            else if (cbAgregarSaldoFavor.Checked == true)
            {
                if (clienteExiste.EstadoCliente == 0)
                {
                    var result = MessageBox.Show("No se a seleccionado un cliente, presiona aceptar para hacerlo", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        mdClienteVenta _cliente = new mdClienteVenta();
                        var resultado = _cliente.ShowDialog();
                        if (resultado == DialogResult.OK)
                        {
                            clienteExiste = new Cliente()
                            {
                                IdCliente = _cliente._Cliente.IdCliente,
                                NombreCliente = _cliente._Cliente.NombreCliente,
                                DocumentoCliente = _cliente._Cliente.DocumentoCliente,
                                Telefono = _cliente._Cliente.Telefono,
                                Direccion = _cliente._Cliente.Direccion,
                                Correo = _cliente._Cliente.Correo,
                                Deuda = _cliente._Cliente.Deuda,
                                SaldoFavor = _cliente._Cliente.SaldoFavor,
                                EstadoCliente = _cliente._Cliente.EstadoCliente
                            };
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    int id = clienteExiste.IdCliente;
                    List<Cliente> obj = new CN_Cliente().ObtenerClienteId(id);
                    foreach (Cliente item in obj)
                    {
                        saldoFavorActual = item.SaldoFavor;
                    }

                    saldoFavor = saldoFavorActual + saldoFavor;

                    var respuesta = new CN_Cliente().editarSaldoFavor(id, saldoFavor, out string Mensaje);
                    if (respuesta)
                    {
                        DCambio = 0;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo modificar el saldo a favor del cliente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                }
            }
            else if (cbPagarConSaldoFavor.Checked == true)
            {

                if (clienteExiste.EstadoCliente == 1)
                {
                    List<Cliente> obj = new CN_Cliente().ObtenerClienteId(clienteExiste.IdCliente);
                    foreach (Cliente item in obj)
                    {
                        saldoFavor = item.SaldoFavor;
                    }
                    if (saldoFavor >= totalActual)
                    {

                        saldoFavor = saldoFavor - totalActual;
                        totalActual = 0;

                        var respuesta = new CN_Cliente().editarSaldoFavor(clienteExiste.IdCliente, saldoFavor, out string Mensaje);
                        if (!respuesta)
                        {
                            MessageBox.Show("No se pudo modificar el saldo a favor del cliente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            DCambio = 0;
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }


                    }
                    else if (saldoFavor <= totalActual)
                    {
                        totalActual = totalActual - saldoFavor;
                        saldoFavor = 0;

                        var respuesta = new CN_Cliente().editarSaldoFavor(clienteExiste.IdCliente, saldoFavor, out string Mensaje);
                        if (!respuesta)
                        {
                            MessageBox.Show("No se pudo modificar el saldo a favor del cliente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        if (totalActual > 0)
                        {
                            labelTotal.Text = totalActual.ToString();
                            cbPagarConSaldoFavor.Visible = false;
                            cbPagarConSaldoFavor.Checked = false;
                            lblsaldo.Text = "";
                            labelTotal.Text = totalActual.ToString();
                        }
                    }
                }
            }
            else
            {
                if (montoPago < totalActual || montoPago < totalActualConDescuento)
                {
                    MessageBox.Show("Falta dinero por abonar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
