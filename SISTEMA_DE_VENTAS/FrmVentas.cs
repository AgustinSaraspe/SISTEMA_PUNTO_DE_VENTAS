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
using SISTEMA_DE_VENTAS.ComboBox;
using SISTEMA_DE_VENTAS.Modales;
using CapaNegocio;

namespace SISTEMA_DE_VENTAS
{
    public partial class FrmVentas : Form
    {
    
        public decimal totalmonto;
        static bool caja;
        private Usuario _Usuario;
        public Cliente _Cliente;

        public FrmVentas(Usuario objUsuario)
        {
            _Usuario = objUsuario;
            InitializeComponent();
            autoCompletarTxt();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            frmCaja estado = new frmCaja();
            caja = estado.estadoCaja();

            if (caja == true)
            {
                cboTipoDocumento.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
                cboTipoDocumento.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });
                cboTipoDocumento.DisplayMember = "Texto";
                cboTipoDocumento.ValueMember = "Valor";
                cboTipoDocumento.SelectedIndex = 0;

                txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtId.Text = "0";
                labelTotal.Text = "$0.00";
                txtBuscarProducto.Enabled = true;
                btnBuscar.Enabled = true;
                btnAgregar.Enabled = true;
                txtBuscarProducto.Select();
            }
            else if (caja == false)
            {

                MessageBox.Show("Debe abrir caja para poder realizar una venta", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtBuscarProducto.Enabled = false;
                btnBuscar.Enabled = false;
                btnAgregar.Enabled = false;
                return;
               
            }

            _Cliente = new Cliente()
            {
                IdCliente = 0,
                NombreCliente = "",
                DocumentoCliente = "",
                Telefono ="",
                Direccion = "",
                Correo  ="",
                Deuda = 0,
                SaldoFavor = 0,
                EstadoCliente = 0
            };         
        }

        private void calcularTotal()
        {
            decimal total = 0;

            if(dgvData.Rows.Count > 0)
            {
                foreach(DataGridViewRow row in dgvData.Rows)
                {
                    total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString());
                }

                totalmonto = total;
                labelTotal.Text = "$" + totalmonto.ToString("0.00");
            }
            else
            {
                labelTotal.Text = "$0.00";
            }
        }
         
        private void limpiarProducto()
        {
            txtId.Text = "0";
            txtBuscarProducto.Text = "";
            lblProducto.Text = "";
            lblPrecio.Text = "$0.00";
            txtStock.Text = "0";
            nudCantidad.Value = 0;
            txtBuscarProducto.Select();
        }

        private void AgregarProducto()
        {
            bool producto_existe = false;

            if (int.Parse(txtId.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if(lblProducto.Text == "")
            {
                MessageBox.Show("El producto debe contener un nombre", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(lblPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Precio / Formato de moneda incorrecta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtStock.Text == "")
            {
                MessageBox.Show("Se necesita ingresar stock para realizar la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToInt32(txtStock.Text) < Convert.ToInt32(nudCantidad.Value.ToString()))
            {
                MessageBox.Show("No se dispone de esa cantidad en stock", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!producto_existe)
            {
                bool respuesta = new CN_Venta().RestarStock(Convert.ToInt32(txtId.Text), Convert.ToInt32(nudCantidad.Value.ToString()));

                if (respuesta)
                {

                    dgvData.Rows.Add(new object[] {
                        txtId.Text,
                        lblProducto.Text,
                        precio.ToString("0.00"),
                        nudCantidad.Value.ToString(),
                        (nudCantidad.Value * precio).ToString("0.00"),
                    });

                    calcularTotal();
                    limpiarProducto();
                    txtBuscarProducto.Select();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void RealizarVenta()
        {
            if (dgvData.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar productos en la venta", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            mdVenta datos = new mdVenta(totalmonto, _Cliente);
            var dialogResult = datos.ShowDialog();

             if (dialogResult == DialogResult.OK)
             {
                if(datos.clienteExiste.EstadoCliente != 0)
                {
                    _Cliente = new Cliente()
                    {
                        IdCliente = datos.clienteExiste.IdCliente,
                        NombreCliente = datos.clienteExiste.NombreCliente,
                        DocumentoCliente = datos.clienteExiste.DocumentoCliente,
                        Telefono = datos.clienteExiste.Telefono,
                        Direccion = datos.clienteExiste.Direccion,
                        Correo = datos.clienteExiste.Correo,
                        Deuda = datos.clienteExiste.Deuda,
                        SaldoFavor = datos.clienteExiste.SaldoFavor,
                    };
                }

                //-------------------------------------------------REGISTRO DE VENTA-----------------------------------------------------

                DataTable detalle_venta = new DataTable();
                detalle_venta.Columns.Add("IdProducto", typeof(int));
                detalle_venta.Columns.Add("PrecioVenta", typeof(decimal));
                detalle_venta.Columns.Add("Cantidad", typeof(int));
                detalle_venta.Columns.Add("SubTotal", typeof(decimal));

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                  detalle_venta.Rows.Add(new object[]
                  {
                    row.Cells["IdProducto"].Value.ToString(),
                    row.Cells["Precio"].Value.ToString(),
                    row.Cells["Cantidad"].Value.ToString(),
                    row.Cells["SubTotal"].Value.ToString()
                  });
                }

                int idcorrelativo = new CN_Venta().obtenerCorrelativo();
                string numeroDocumento = string.Format("{0:00000}", idcorrelativo);

                Venta objVenta = new Venta()
                {
                    objUsuario = new Usuario() { IdUsuario = _Usuario.IdUsuario },
                    TipoDocumento = ((OpcionCombo)cboTipoDocumento.SelectedItem).Texto,
                    NumeroDocumento = numeroDocumento,
                    MontoPago = datos.montoPago,
                    MontoCambio = datos.DCambio,
                    MontoTotal = datos.totalActual,
                    FormaPago = datos.DFormaPago,
                    DocumentoCliente = _Cliente.DocumentoCliente,
                    NombreCliente = _Cliente.NombreCliente
                };

                bool respuesta = new CN_Venta().registrar(objVenta, detalle_venta, out string mensaje);

                if (respuesta)
                {
                 
                    MessageBox.Show("La venta se realizo con éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvData.Rows.Clear();                  
                }
                else
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                //-------------------------------------------------REGISTRO DE CAJA-----------------------------------------------------
             
                string horaDeRegistro = DateTime.Now.ToString("HH:mm:ss");
                string fechaDeHoy = DateTime.Now.ToString("dd/MM/yyyy");

                int idCaja = new frmCaja().ObtenerIdCaja();
       
                Caja Registro = new Caja()
                {
                    IdCaja = idCaja,
                    FechaRegistro = fechaDeHoy,
                    Hora = horaDeRegistro,
                    Tipo = "Entrada",
                    Descripcion = "Venta",
                    Cliente = _Cliente.NombreCliente,
                    Deuda = _Cliente.Deuda,
                    FormaPago = datos.DFormaPago,
                    TotalFinal = datos.totalActual,
                    SaldoFavor = _Cliente.SaldoFavor,
                    EstadoCaja = 1
                };
                 
                var resultado = new CN_Caja().resgistrar(Registro, out string mensajeC);
                
                if (resultado)
                {
                    MessageBox.Show("Se realizo el registro en la caja", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //-----------RESTAURAR CLIENTE------

                    lblCliente.Visible = false;
                    lblClienteNombre.Visible = false;

                    _Cliente = new Cliente()
                    {
                        IdCliente = 0,
                        NombreCliente = "",
                        DocumentoCliente = "",
                        Telefono = "",
                        Direccion = "",
                        Correo = "",
                        Deuda = 0,
                        SaldoFavor = 0,
                        EstadoCliente = 0
                    };

                    //-----------RESTAURAR PRODUCTO------

      
                    labelTotal.Text = "$0.00";
                    limpiarProducto();

                }
                else
                {
                    MessageBox.Show(mensajeC, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
             }
            else
            {
                MessageBox.Show("No se realizó la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }                
        }
 
        private void autoCompletarTxt()
        {
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
            List<Producto> listaProducto = new CN_Producto().Listar();

            foreach(Producto producto in listaProducto)
            {
                lista.Add(producto.Nombre);
            }

            txtBuscarProducto.AutoCompleteCustomSource = lista;
        }

        private void btnRealizarVenta_Click(object sender, EventArgs e)
        {
            RealizarVenta();
        }

        private void txtBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                if (txtBuscarProducto.Text != "")
                {
                    Producto objProducto = new CN_Producto().Listar().Where(p => (p.Nombre.ToUpper().Contains(txtBuscarProducto.Text.ToUpper()) || p.Codigo.ToUpper().Contains(txtBuscarProducto.Text.ToUpper())) && p.Estado == true).FirstOrDefault();

                    if (objProducto != null)
                    {

                        txtId.Text = objProducto.IdProducto.ToString();
                        txtBuscarProducto.BackColor = Color.Honeydew;
                        txtBuscarProducto.ForeColor = Color.Black;
                        txtBuscarProducto.Text = objProducto.Codigo;                   
                        lblProducto.Text = objProducto.Nombre;
                        lblPrecio.Text = objProducto.PrecioVenta.ToString();
                        txtStock.Text = objProducto.Stock.ToString();
                        nudCantidad.Value = 1;
                        nudCantidad.Focus();
                       
                    }
                    else
                    {
                        MessageBox.Show("Se genero un error al cargar el producto, intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        txtBuscarProducto.BackColor = Color.MistyRose;
                        lblProducto.Text = "";
                        lblPrecio.Text = "$0.00";
                        txtStock.Text = "0";
                        txtBuscarProducto.Focus();
                        txtBuscarProducto.Text = "Ingrese nuevamente nombre o codigo";
                        txtBuscarProducto.ForeColor = Color.Red;
                        txtBuscarProducto.SelectAll();

                    }
                }
                else if (txtBuscarProducto.Text == "")
                {
                    RealizarVenta();
                }
            }
            if (e.KeyData == Keys.F3)
            {
                mdCliente mdcliente = new mdCliente();
                var resultado = mdcliente.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    txtIdCliente.Text = mdcliente._Cliente.IdCliente.ToString();

                    _Cliente = new Cliente()
                    {
                        IdCliente = mdcliente._Cliente.IdCliente,
                        NombreCliente = mdcliente._Cliente.NombreCliente,
                        DocumentoCliente = mdcliente._Cliente.DocumentoCliente,
                        Telefono = mdcliente._Cliente.Telefono,
                        Direccion = mdcliente._Cliente.Direccion,
                        Correo = mdcliente._Cliente.Correo,
                        Deuda = mdcliente._Cliente.Deuda,
                        SaldoFavor = mdcliente._Cliente.SaldoFavor,
                        FechaRegistro = mdcliente._Cliente.FechaRegistro,
                        EstadoCliente = mdcliente._Cliente.EstadoCliente
                    };
                }
            }
            if (e.KeyData == Keys.F2)
            {
                RealizarVenta();
            }
        }
        private void btnCliente_Click(object sender, EventArgs e)
        {
            mdCliente mdcliente = new mdCliente();
            var resultado = mdcliente.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                txtIdCliente.Text = mdcliente._Cliente.IdCliente.ToString();
                lblCliente.Visible = true;
                lblClienteNombre.Visible = true;
                lblClienteNombre.Text = mdcliente._Cliente.NombreCliente;

                _Cliente = new Cliente()
                {
                    IdCliente = mdcliente._Cliente.IdCliente,
                    NombreCliente = mdcliente._Cliente.NombreCliente,
                    DocumentoCliente = mdcliente._Cliente.DocumentoCliente,
                    Telefono = mdcliente._Cliente.Telefono,
                    Direccion = mdcliente._Cliente.Direccion,
                    Correo = mdcliente._Cliente.Correo,
                    Deuda = mdcliente._Cliente.Deuda,
                    SaldoFavor = mdcliente._Cliente.SaldoFavor,
                    FechaRegistro = mdcliente._Cliente.FechaRegistro,
                    EstadoCliente = mdcliente._Cliente.EstadoCliente
                };
            }
        }

        private void nudCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                AgregarProducto();
            }
            if (e.KeyData == Keys.F2)
            {
                AgregarProducto();
                RealizarVenta();
            }
            if (e.KeyData == Keys.Back)
            {
                txtId.Text = "0";
                txtStock.Text = "0";
                lblProducto.Text = "";
                lblPrecio.Text = "$0.00";
                txtBuscarProducto.Text = "";
                txtBuscarProducto.BackColor = Color.Honeydew;
                txtBuscarProducto.Focus();
                nudCantidad.Value = 1;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtStock.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProductos())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtId.Text = modal._Producto.IdProducto.ToString();
                    txtBuscarProducto.Text = modal._Producto.Codigo.ToString();
                    lblProducto.Text = modal._Producto.Nombre;
                    lblPrecio.Text = modal._Producto.PrecioVenta.ToString("0.00");
                    txtStock.Text = modal._Producto.Stock.ToString();
                    nudCantidad.Value = 1;
                    nudCantidad.Focus();
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarProducto();
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "btn")
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    bool respuesta = new CN_Venta().SumarStock(Convert.ToInt32(dgvData.Rows[index].Cells["IdProducto"].Value.ToString()), Convert.ToInt32(dgvData.Rows[index].Cells["Cantidad"].Value.ToString()));

                    if (respuesta)
                    {
                        dgvData.Rows.RemoveAt(index);
                        calcularTotal();
                        txtBuscarProducto.Select();
                    }
                }
            }
        }
    }
}
