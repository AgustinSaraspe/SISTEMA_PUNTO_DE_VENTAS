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
    public partial class mdCliente : Form
    {

        public Cliente _Cliente;
        public mdCliente()
        {
            InitializeComponent();
        }

        private void mdCliente_Load(object sender, EventArgs e)
        {

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

            List<Cliente> listaClientes = new CN_Cliente().Listar();

            foreach (Cliente item in listaClientes) 
            {
                if (item.EstadoCliente == 1)
                {
                  dgvData.Rows.Add(new object[] {
                    item.IdCliente,
                    item.NombreCliente,
                    item.DocumentoCliente,
                    item.Telefono,
                    item.Direccion,
                    item.Correo,
                    item.EstadoCliente,
                    item.Deuda,
                    item.SaldoFavor,
                    item.FechaRegistro
                  });
                }
            }
        }

        private void bntBuscar_Click(object sender, EventArgs e)
        {
            string Filtro = ((OpcionCombo)cboBusqueda.SelectedItem).Valor.ToString();

            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Cells[Filtro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()))
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

        private void bntLimpiar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Visible = true;
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
                    EstadoCliente = Convert.ToInt32(dgvData.Rows[iRow].Cells["EstadoCliente"].Value),
                    Deuda = Convert.ToDecimal(dgvData.Rows[iRow].Cells["Deuda"].Value),
                    SaldoFavor = Convert.ToDecimal(dgvData.Rows[iRow].Cells["SaldoFavor"].Value),
                    FechaRegistro = dgvData.Rows[iRow].Cells["FechaRegistro"].Value.ToString()

                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}

