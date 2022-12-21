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
using SISTEMA_DE_VENTAS.Modales;

namespace SISTEMA_DE_VENTAS
{
    public partial class frmClientes : Form
    {

        private int idCliente;

        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
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
                dgvData.Rows.Add(new object[] {"",item.IdCliente, item.NombreCliente, item.DocumentoCliente, item.Telefono, item.Direccion, item.Correo,item.EstadoCliente == 1 ? "Activo" : "No Activo",item.EstadoCliente == 1 ? 1 : 0,
                    item.Deuda, item.SaldoFavor, item.FechaRegistro
                });
            }
        }
        private void limpiar()
        {
            txtIndice.Text = "-1";
            txtId.Text = "0";
            txtNombre.Text = "";
            txtDocumento.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";  
            cboEstado.SelectedIndex = 0;
            txtNombre.Select();
        }

        private void actualizarDgv()
        {
            dgvData.Rows.Clear();
            List<Cliente> listaCliente = new CN_Cliente().Listar();

            foreach (Cliente item in listaCliente) 
            {
                dgvData.Rows.Add(new object[] {"",item.IdCliente, item.NombreCliente, item.DocumentoCliente, item.Telefono, item.Direccion, item.Correo,item.EstadoCliente == 1 ? "Activo" : "No Activo",item.EstadoCliente == 1 ? 1 : 0,
                    item.Deuda, item.SaldoFavor, item.FechaRegistro
                });
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
                    dgvData.Rows.Add(new object[] {"", idGenerado, txtDocumento.Text, txtNombre.Text, txtTelefono.Text,txtDireccion.Text, txtCorreo.Text,
                    ((OpcionCombo)cboEstado.SelectedItem).Texto.ToString(),
                    ((OpcionCombo)cboEstado.SelectedItem).Valor.ToString(),
                    objCliente.Deuda, objCliente.SaldoFavor, objCliente.FechaRegistro
                });

                    limpiar();
                }
                else
                {
                    MessageBox.Show(Mensaje);
                }
            }
            else
            {
                bool resultado = new CN_Cliente().Editar(objCliente, out string Mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];

                    row.Cells["Id"].Value = txtId.Text;
                    row.Cells["DocumentoCliente"].Value = txtDocumento.Text;
                    row.Cells["NombreCliente"].Value = txtNombre.Text;
                    row.Cells["Correo"].Value = txtCorreo.Text;
                    row.Cells["Telefono"].Value = txtTelefono.Text;
                    row.Cells["Direccion"].Value = txtDireccion.Text;
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboEstado.SelectedItem).Valor.ToString();
                    row.Cells["EstadoCliente"].Value = ((OpcionCombo)cboEstado.SelectedItem).Texto.ToString();

                    limpiar();
                }
                else
                {
                    MessageBox.Show(Mensaje); 
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar el cliente?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cliente obj = new Cliente() 
                    {
                        IdCliente = Convert.ToInt32(txtId.Text),
                    };

                    bool respuesta = new CN_Cliente().Eliminar(obj, out string Mensaje);

                    if (respuesta)
                    {
                        dgvData.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show(Mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = ((OpcionCombo)cboBusqueda.SelectedItem).Valor.ToString();

            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {

                    if (row.Cells[filtro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnEditarSaldo_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) > 0)
            {
                idCliente = Convert.ToInt32(txtId.Text);
                mdEditarSaldoCliente editarSaldo = new mdEditarSaldoCliente(idCliente);
                var resultado = editarSaldo.ShowDialog();

                if (resultado != DialogResult.OK)
                {
                    MessageBox.Show("No se modificó el saldo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    actualizarDgv();
                }
            }
            else
            {
                MessageBox.Show("No se a seleccionado a un cliente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEditarDeuda_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) > 0)
            {
                idCliente = Convert.ToInt32(txtId.Text);
                mdEditarDeuda editarDeuda = new mdEditarDeuda(idCliente);
                var resultado = editarDeuda.ShowDialog();

                if (resultado != DialogResult.OK)
                {
                    MessageBox.Show("No se modificó la deuda", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    actualizarDgv();
                }
            }
            else
            {
                MessageBox.Show("No se a seleccionado a un cliente", "Atwncion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (dgvData.Columns[e.ColumnIndex].Name == "btn") 
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {

                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvData.Rows[indice].Cells["Id"].Value.ToString();
                    txtNombre.Text = dgvData.Rows[indice].Cells["NombreCliente"].Value.ToString();
                    txtDocumento.Text = dgvData.Rows[indice].Cells["DocumentoCliente"].Value.ToString();
                    txtTelefono.Text = dgvData.Rows[indice].Cells["Telefono"].Value.ToString();
                    txtCorreo.Text = dgvData.Rows[indice].Cells["Correo"].Value.ToString();
                    txtDireccion.Text = dgvData.Rows[indice].Cells["Direccion"].Value.ToString();

                    foreach (OpcionCombo op in cboEstado.Items)
                    {
                        if (Convert.ToInt32(op.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indiceCombo = cboEstado.Items.IndexOf(op);
                            cboEstado.SelectedIndex = indiceCombo;
                            break;
                        }
                    }
                }
            }
        }
    }
}
