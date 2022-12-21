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
    public partial class mdVerTotalCaja : Form
    {
        private decimal totalMonto;

        public mdVerTotalCaja(decimal total)
        {
            totalMonto = total;

            InitializeComponent();
        }
        private void mdVerTotalCaja_Load(object sender, EventArgs e)
        {
            lblTotal.Text = totalMonto.ToString();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
