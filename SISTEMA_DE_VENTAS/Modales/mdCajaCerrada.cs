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
    public partial class mdCajaCerrada : Form
    {

        public bool estadoDeCaja = true;
        private decimal montoCierre;
        private decimal montoEfectivo = 0;

        public mdCajaCerrada(decimal monto)
        {
            montoCierre = monto;
            InitializeComponent();
        }

        

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {

            string horaDeRegistro = DateTime.Now.ToString("HH:mm:ss");
            string fechaDeHoy = DateTime.Now.ToString("dd/MM/yyyy");

                Cliente cliente = new Cliente()
                {
                  NombreCliente = "",
                  DocumentoCliente = "",
                  Deuda = 0,
                  SaldoFavor = 0,
                };

                int idCaja = new frmCaja().ObtenerIdCaja();
  
                Caja  filaCierre = new Caja()
                {
                    IdCaja = idCaja,
                    FechaRegistro = fechaDeHoy,
                    Hora = horaDeRegistro,
                    Tipo = "Caja",
                    Descripcion = "Cierre de caja",
                    Cliente = cliente.NombreCliente,
                    Deuda = cliente.Deuda,
                    FormaPago = "",
                    TotalFinal = montoCierre,
                    SaldoFavor = cliente.SaldoFavor,
                    EstadoCaja = 0
                };
           
                bool respusetaC = new CN_Caja().resgistrar(filaCierre, out string mensajeC);

                if (respusetaC)
                {
                    MessageBox.Show("Se cerro la caja", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
                else
                {
                    MessageBox.Show(mensajeC, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
          
        }

        private void mdCajaCerrada_Load(object sender, EventArgs e)
        {

            string horaDeRegistro = DateTime.Now.ToString("HH:mm:ss");
            string fechaDeHoy = DateTime.Now.ToString("dd/MM/yyyy");

            Cliente cliente = new Cliente()
            {
                NombreCliente = "",
                DocumentoCliente = "",
                Deuda = 0,
                SaldoFavor = 0,
               
            };

           Caja filaCierreM = new Caja()
           {
                FechaRegistro = fechaDeHoy,
                Hora = horaDeRegistro,
                Tipo = "Caja",
                Descripcion = "Cierre de caja",
                Cliente = cliente.NombreCliente,
                Deuda = cliente.Deuda,
                FormaPago = "",
                TotalFinal = montoCierre,
                SaldoFavor = cliente.SaldoFavor,
                EstadoCaja = 0
           };

            //------------------------------------------------------------------------

            lblMontoTotal.Text = montoCierre.ToString();

            frmCaja caja = new frmCaja();
            int id = caja.obtenerIdCajaActual();
            List<Caja> objCaja = new CN_Caja().ObtenerCajaId(id);

            objCaja.Add(filaCierreM);

            if (objCaja.Count != 0)
            {
                foreach (Caja item in objCaja)
                {
                    dgvData.Rows.Add(new object[] {item.FechaRegistro, item.Hora, item.Tipo, item.Descripcion, item.Cliente,
                            item.Deuda,
                            item.FormaPago,
                            item.TotalFinal,
                            item.SaldoFavor,
                    });
                }
            }

            decimal aux = 0;

            foreach (Caja item in objCaja)
            {
                if (item.FormaPago == "Tarjeta" || item.FormaPago == "Debito")
                {
                    aux = aux + item.TotalFinal;
                 
                }

                montoEfectivo = montoCierre - aux;
            }

            lblMonto.Text = montoEfectivo.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
