using CapaEntidad;
using CapaNegocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_DE_VENTAS
{
    
    public partial class FrmDetalleVenta : Form
    {
        public FrmDetalleVenta()
        {
            InitializeComponent();
        }
        public string localDatee;
       

        private void FrmDetalleVenta_Load(object sender, EventArgs e)
        { 
           txtNumeroDocumento.Focus();  
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            Venta objVenta = new CN_Venta().obtenerVenta(txtNumeroDocumento.Text);

            if (objVenta.IdVenta != 0)
            {
                txtNumeroDocumento.Text = objVenta.NumeroDocumento;
                txtDocumento.Text = objVenta.TipoDocumento;
                txtFecha.Text = objVenta.FechaRegistro;
                txtUsuario.Text = objVenta.objUsuario.NombreCompleto;

                dgvData.Rows.Clear();
                foreach (Detalle_Venta dv in objVenta.objDetalle_Venta)
                {
                    dgvData.Rows.Add(new object[] { dv.objProducto.Nombre, dv.PrecioVenta, dv.Cantidad, dv.SubTotal, dv.FormaPago });
                }

                lbMontoTotal.Text = objVenta.MontoTotal.ToString("0.00");
                lbMontoPago.Text = objVenta.MontoPago.ToString("0.00");
                lbMontoCambio.Text = objVenta.MontoCambio.ToString("0.00");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFecha.Text = "";
            txtNumeroDocumento.Text = "";
            txtDocumento.Text = "";
            txtUsuario.Text = "";
            dgvData.Rows.Clear();
            lbMontoTotal.Text = "$0.00";
            lbMontoPago.Text = "$0.00";
            lbMontoCambio.Text = "$0.00";
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            if (txtNumeroDocumento.Text == "")
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string Texto_Html = Properties.Resources.PlantillaVenta.ToString();            

            Texto_Html = Texto_Html.Replace("@tipodocumento", txtDocumento.Text);
            Texto_Html = Texto_Html.Replace("@numerodocumento", txtNumeroDocumento.Text);

            Texto_Html = Texto_Html.Replace("@fecharegistro", txtFecha.Text);
            Texto_Html = Texto_Html.Replace("@usuarioregistro", txtUsuario.Text);

            string filas = string.Empty;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Precio"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["SubTotal"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["FormaPago"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            Texto_Html = Texto_Html.Replace("@filas", filas);
            Texto_Html = Texto_Html.Replace("@montototal", lbMontoTotal.Text);
            Texto_Html = Texto_Html.Replace("@pagocon", lbMontoPago.Text);
            Texto_Html = Texto_Html.Replace("@cambio", lbMontoCambio.Text);

            SaveFileDialog save = new SaveFileDialog();
            save.FileName = string.Format("Venta_{0}.pdf", txtNumeroDocumento.Text);
            save.Filter = "Pdf Files (*.pdf)|*.pdf";

            if (save.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(save.FileName, FileMode.Create))
                {
                    Document pdf = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdf, stream);
                    pdf.Open();

                    using (StringReader sr = new StringReader(Texto_Html))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdf, sr);
                    }
                    pdf.Close();
                    stream.Close();
                    MessageBox.Show("Documento Generado  ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtNumeroDocumento.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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
    }
}
