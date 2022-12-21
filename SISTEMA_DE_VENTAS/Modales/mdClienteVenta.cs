using CapaEntidad;
using CapaNegocio;
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

namespace SISTEMA_DE_VENTAS.Modales
{
    public partial class mdClienteVenta : Form
    {
        public Cliente _Cliente;
        public mdClienteVenta()
        {
            InitializeComponent();
        }

        private void mdClienteVenta_Load(object sender, EventArgs e)
        {
            cboEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;


            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                if (columna.Visible == true && columna.Name != "btn")
                {
                    cboBusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;



            List<Cliente> listaCliente = new CN_Cliente().Listar();

            foreach (Cliente item in listaCliente)
            {
                if (item.EstadoCliente == 1)
                {
                    dgvData.Rows.Add(new object[] {"",item.IdCliente, item.NombreCliente, item.DocumentoCliente, item.Telefono, item.Direccion, item.Correo,

                      item.EstadoCliente == 1 ? "Activo" : "No Activo",
                      item.EstadoCliente == 1 ? 1 : 0,
                      item.SaldoFavor,
                      item.Deuda

                    });
                }
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            string fechaDeHoy = localDate.Date.ToString("dd/MM/yyyy");

            Cliente objCliente = new Cliente()
            {
                IdCliente = Convert.ToInt32(txtId.Text),
                NombreCliente = txtNombre.Text,
                DocumentoCliente = txtDocumento.Text,
                Correo = txtCorreo.Text,
                Telefono = txtTelefono.Text,
                Direccion = txtDireccion.Text,
                EstadoCliente = Convert.ToInt32(((OpcionCombo)cboEstado.SelectedItem).Valor) == 1 ? 1 : 0,
                Deuda = 0,
                SaldoFavor = 0,
                FechaRegistro = fechaDeHoy
                
            };

            if (objCliente.IdCliente == 0)
            {
                int idGenerado = new CN_Cliente().Registrar(objCliente, out string Mensaje);

                if (idGenerado != 0)
                {
            
                    _Cliente = new Cliente()
                    {
                        IdCliente = idGenerado,
                        NombreCliente = txtNombre.Text,
                        DocumentoCliente = txtDocumento.Text,
                        Telefono = txtTelefono.Text,
                        Direccion = txtDireccion.Text,
                        Correo = txtCorreo.Text,
                        Deuda = 0,
                        SaldoFavor = 0,
                        EstadoCliente = Convert.ToInt32(((OpcionCombo)cboEstado.SelectedItem).Valor.ToString()),
                      
                    };

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(Mensaje);
                }
            }
            else
            {
                MessageBox.Show("No se puede editar a un cliente desde este formulario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtDocumento.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtTelefono.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;

            if (iRow >= 0 && iColum > 0)
            {
                _Cliente = new Cliente()
                {
                    IdCliente = Convert.ToInt32(dgvData.Rows[iRow].Cells["IdCliente"].Value.ToString()),
                    NombreCliente = dgvData.Rows[iRow].Cells["NombreCliente"].Value.ToString(),
                    DocumentoCliente = dgvData.Rows[iRow].Cells["DocumentoCliente"].Value.ToString(),
                    Telefono = dgvData.Rows[iRow].Cells["Telefono"].Value.ToString(),
                    Direccion = dgvData.Rows[iRow].Cells["Direccion"].Value.ToString(),
                    Correo = dgvData.Rows[iRow].Cells["Correo"].Value.ToString(),
                    EstadoCliente = Convert.ToInt32(dgvData.Rows[iRow].Cells["EstadoValor"].Value),
                    SaldoFavor = Convert.ToDecimal(dgvData.Rows[iRow].Cells["Saldo"].Value),
                    Deuda = Convert.ToDecimal(dgvData.Rows[iRow].Cells["Deuda"].Value)
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
    
    
}
