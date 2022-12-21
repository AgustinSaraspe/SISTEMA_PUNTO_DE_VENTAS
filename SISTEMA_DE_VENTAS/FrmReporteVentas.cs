using CapaEntidad;
using CapaNegocio;
using ClosedXML.Excel;
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

namespace SISTEMA_DE_VENTAS
{
    public partial class FrmReporteVentas : Form
    {
        public FrmReporteVentas()
        {
            InitializeComponent();
        }

        private void FrmReporteVentas_Load(object sender, EventArgs e)
        {
            foreach(DataGridViewColumn columna in dgvData.Columns)
            {
                cboBusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
            }
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<ReporteVenta> lista = new CN_Reporte().Venta(dtpFechaInicio.Value.Date.ToString(), dtpFechaFin.Value.ToString());

            dgvData.Rows.Clear();

            foreach (ReporteVenta rv in lista)
            {
                dgvData.Rows.Add(new object[] {
                     rv.FechaRegistro,
                     rv.TipoDocumento,
                     rv.NumeroDocumento,
                     rv.MontoTotal,
                     rv.UsuarioRegistro,
                     rv.CodigoProducto,
                     rv.NombreProducto,
                     rv.Categoria,
                     rv.PrecioVenta,
                     rv.Cantidad,
                     rv.SubTotal,
                     rv.FormaPago
                });
            }
        }

        private void btnBuscarFiltro_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cboBusqueda.SelectedItem).Valor.ToString();

            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()))
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

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count < 1)
            {
                MessageBox.Show("No hay registros para exportar", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();

                foreach (DataGridViewColumn colum in dgvData.Columns)
                {
                    if (colum.HeaderText != "" && colum.Visible)
                    {
                        dt.Columns.Add(colum.HeaderText, typeof(string));
                    }
                }

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Visible)
                    {
                        dt.Rows.Add(new object[] {
                           row.Cells[0].Value.ToString(),
                           row.Cells[1].Value.ToString(),
                           row.Cells[2].Value.ToString(),
                           row.Cells[3].Value.ToString(),
                           row.Cells[4].Value.ToString(),
                           row.Cells[5].Value.ToString(),
                           row.Cells[6].Value.ToString(),
                           row.Cells[7].Value.ToString(),
                           row.Cells[8].Value.ToString(),
                           row.Cells[9].Value.ToString(),
                           row.Cells[10].Value.ToString(),
                           row.Cells[11].Value.ToString(),
                        });
                    }
                }

                SaveFileDialog save = new SaveFileDialog();
                save.FileName = string.Format("ReporteVentas_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                save.Filter = "Excel Files | *.xlsx";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(save.FileName);
                        MessageBox.Show("Reporte generado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error al generar el reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
    }
}
