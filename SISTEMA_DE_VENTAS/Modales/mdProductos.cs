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
using CapaNegocio;
using SISTEMA_DE_VENTAS.ComboBox;


namespace SISTEMA_DE_VENTAS.Modales
{
    public partial class mdProductos : Form
    {

        public Producto _Producto { get; set; }
        public mdProductos()
        {
            InitializeComponent();
        }
        private void mdProductos_Load(object sender, EventArgs e)
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

            List<Producto> listaProductos = new CN_Producto().Listar();

            foreach (Producto item in listaProductos) 
            {

                if(item.Estado == true)
                {
                    dgvData.Rows.Add(new object[] {
                       item.IdProducto,
                       item.Codigo,
                       item.Nombre,
                       item.objCategoria.Descripcion,
                       item.Stock,
                       item.PrecioVenta,
                    });
                }
                else
                {
                    return;
                }
            }
        }

        private void bntBuscar_Click(object sender, EventArgs e)
        {
            string Filtro = ((OpcionCombo)cboBusqueda.SelectedItem).Valor.ToString();

            if(dgvData.Rows.Count > 0)
            {
                foreach(DataGridViewRow row in dgvData.Rows)
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
            foreach(DataGridViewRow row in dgvData.Rows)
            {
                row.Visible = true;
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;

            if (iRow >= 0 && iColum > 0)
            {
                _Producto = new Producto()
                {
                    IdProducto = Convert.ToInt32(dgvData.Rows[iRow].Cells["Id"].Value.ToString()),
                    Codigo = dgvData.Rows[iRow].Cells["Codigo"].Value.ToString(),
                    Nombre = dgvData.Rows[iRow].Cells["Nombre"].Value.ToString(),
                    Stock = Convert.ToInt32(dgvData.Rows[iRow].Cells["Stock"].Value.ToString()),
                    PrecioVenta = Convert.ToDecimal(dgvData.Rows[iRow].Cells["PrecioVenta"].Value.ToString()),
                    Descripcion = dgvData.Rows[iRow].Cells["Categoria"].Value.ToString(),

                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

       
    }
}
