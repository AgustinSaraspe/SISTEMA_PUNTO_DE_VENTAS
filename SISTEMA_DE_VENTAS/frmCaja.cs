using CapaEntidad;
using CapaNegocio;
using SISTEMA_DE_VENTAS.Modales;
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
    public partial class frmCaja : Form
    { 
        public decimal montoInicial;
        public decimal acumuladorMonto;
        public int IdCajaActual;
        static bool caja1;
        public frmCaja()
        {
            InitializeComponent();
        }

        private void frmCaja_Load(object sender, EventArgs e)
        {
            caja1 = estadoCaja();

            if (caja1 == true)
            {
                obtenerIdCajaActual();
                List<Caja> objCajaActual = new CN_Caja().ObtenerCajaId(IdCajaActual);
                if (objCajaActual.Count != 0)
                {
                    foreach (Caja item in objCajaActual)
                    {
                        dgvData.Rows.Add(new object[] {item.FechaRegistro, item.Hora, item.Tipo, item.Descripcion, item.Cliente,
                            item.Deuda,
                            item.FormaPago,
                            item.TotalFinal,
                            item.SaldoFavor
                        });
                    }
                }
            }
        }

        public void cerrarCaja()
        {
            controlMonto();

            string horaDeRegistro = DateTime.Now.ToString("HH:mm:ss");
            string fechaDeHoy = DateTime.Now.ToString("dd/MM/yyyy");

            Cliente cliente = new Cliente()
            {
                NombreCliente = "",
                DocumentoCliente = "",
                Deuda = 0,
                SaldoFavor = 0
            };

            int idCaja = new frmCaja().ObtenerIdCaja();

            Caja filaCierre = new Caja()
            {
                IdCaja = idCaja,
                FechaRegistro = fechaDeHoy,
                Hora = horaDeRegistro,
                Tipo = "Caja",
                Descripcion = "Cierre de caja",
                Cliente = cliente.NombreCliente,
                Deuda = cliente.Deuda,
                FormaPago = "",
                TotalFinal = acumuladorMonto,
                SaldoFavor = cliente.SaldoFavor,
                EstadoCaja = 0
            };

            bool respusetaC = new CN_Caja().resgistrar(filaCierre, out string mensajeC);

            if (respusetaC)
            {
                MessageBox.Show("Se cerro la caja", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show(mensajeC, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
         
        public void controlMonto()
        {
            obtenerIdCajaActual();
            List<Caja> objCajaActual = new CN_Caja().ObtenerCajaId(IdCajaActual);
            acumuladorMonto = 0;

            foreach (Caja item in objCajaActual)
            {
                if (item.EstadoCaja == -1)
                {
                    decimal resta = acumuladorMonto - item.TotalFinal;

                    acumuladorMonto = resta;

                }
                else
                {
                    acumuladorMonto = acumuladorMonto + item.TotalFinal;
                }
            }
        }

        public bool estadoCaja()
        {
            bool estado = false;
            List<Caja> objCaja = new CN_Caja().obtnerUltimaFila();

            if (objCaja.Count > 0)
            {
                Caja last = objCaja[objCaja.Count - 1];
                int estadoCaja = last.EstadoCaja;

                if (estadoCaja == 0)
                {
                    estado = false;
                    return estado;
                }
                else
                {
                    estado = true;
                    return estado;                   
                }
            }
            return estado;
        }  

        public int ObtenerIdCaja()
        {
            int id = obtenerIdCajaActual();
            List<Caja> objCaja1 = new CN_Caja().ObtenerCajaId(id);

            if(objCaja1.Count == 0)
            {
                return IdCajaActual = 1;
            }

            Caja last = objCaja1[objCaja1.Count - 1];
            int estadoCaja = last.EstadoCaja;

            if (estadoCaja == 0)
            {             
                return IdCajaActual + 1;
            }
            else
            {
                return IdCajaActual;
            }         
        }   
       
        public int obtenerIdCajaActual()
        {
            List<Caja> objCaja = new CN_Caja().obtnerUltimaFila();

            foreach (Caja item in objCaja)
            {
                IdCajaActual = item.IdCaja;
            }

            return IdCajaActual;
        }

        private void actualizarDgv()
        {
            dgvData.Rows.Clear();
            obtenerIdCajaActual();
            List<Caja> objCajaActual = new CN_Caja().ObtenerCajaId(IdCajaActual);
            if (objCajaActual.Count != 0)
            {
                foreach (Caja item in objCajaActual)
                {
                    dgvData.Rows.Add(new object[] {item.FechaRegistro, item.Hora, item.Tipo, item.Descripcion, item.Cliente,
                            item.Deuda,
                            item.FormaPago,
                            item.TotalFinal,
                            item.SaldoFavor
                    });
                }
            }
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            bool estado = estadoCaja();

            if (estado == false)
            {
                mdCajaAbierta aperturaCaja = new mdCajaAbierta();
                var result = aperturaCaja.ShowDialog();
                if (result == DialogResult.OK)
                {
                    montoInicial = aperturaCaja.montoInicial;
                    actualizarDgv();
                }
                else
                {
                    MessageBox.Show("La caja no se abrió", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("La caja se encuentra abierta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            bool estado = estadoCaja();
            if (estado == true)
            {
                controlMonto();
                mdCajaCerrada cierreCaja = new mdCajaCerrada(acumuladorMonto);
                var result = cierreCaja.ShowDialog();
                if (result == DialogResult.OK)
                {
                    MessageBox.Show("La caja se cerro con éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    actualizarDgv();
                }
                else
                {
                    MessageBox.Show("La caja no se cerró", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("La caja se encuentra cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvData.Columns[e.ColumnIndex].Name == "Tipo")
            {
                if (Convert.ToString(e.Value) == "Salida")
                {
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.BackColor = Color.IndianRed;
                }
                if (Convert.ToString(e.Value) == "Entrada")
                {
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.BackColor = Color.DarkSeaGreen;
                }
                if(Convert.ToString(e.Value) == "Caja")
                {
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.BackColor = Color.DarkGray;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool estado = estadoCaja();
            if (estado == true)
            {
                mdAgregarDineroCaja caja = new mdAgregarDineroCaja();
                var result = caja.ShowDialog();
                if (result == DialogResult.OK)
                {
                    MessageBox.Show("Se agregó el dinero a la caja", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    actualizarDgv();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el dinero", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("La caja se encuentra cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            bool estado = estadoCaja();
            if (estado == true)
            {

                controlMonto();
                mdRetirarDineroCaja caja = new mdRetirarDineroCaja(acumuladorMonto);
                var result = caja.ShowDialog();
                if (result == DialogResult.OK)
                {
                    MessageBox.Show("Se retiro el dinero de la caja", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    actualizarDgv();
                }
                else
                {
                    MessageBox.Show("No se pudo retirar el dinero", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("La caja se encuentra cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnVerTotal_Click(object sender, EventArgs e)
        {
            bool estado = estadoCaja();
            if (estado == true)
            {
                controlMonto();
                mdVerTotalCaja caja = new mdVerTotalCaja(acumuladorMonto);
                caja.ShowDialog();             
            }
            else
            {
                MessageBox.Show("La caja se encuentra cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
