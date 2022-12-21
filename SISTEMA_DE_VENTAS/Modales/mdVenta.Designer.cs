
namespace SISTEMA_DE_VENTAS.Modales
{
    partial class mdVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelCambio = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPagaCon = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.cboFormaPago = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRealizarVenta = new FontAwesome.Sharp.IconButton();
            this.btnDescuento = new System.Windows.Forms.Button();
            this.lblMontoDescuento = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.cbAgregarDeuda = new System.Windows.Forms.CheckBox();
            this.lblDeuda = new System.Windows.Forms.Label();
            this.cbAgregarSaldoFavor = new System.Windows.Forms.CheckBox();
            this.lblSaldoFavor = new System.Windows.Forms.Label();
            this.cbPagarConSaldoFavor = new System.Windows.Forms.CheckBox();
            this.lblsaldo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(799, 638);
            this.label1.TabIndex = 0;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(799, 60);
            this.label2.TabIndex = 1;
            this.label2.Text = "Realizar Venta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.label4.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(7, 430);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cambio:";
            // 
            // labelCambio
            // 
            this.labelCambio.AutoSize = true;
            this.labelCambio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.labelCambio.Font = new System.Drawing.Font("Verdana", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCambio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.labelCambio.Location = new System.Drawing.Point(121, 428);
            this.labelCambio.Name = "labelCambio";
            this.labelCambio.Size = new System.Drawing.Size(108, 28);
            this.labelCambio.TabIndex = 4;
            this.labelCambio.Text = "Cambio:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.label6.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(7, 369);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Paga: ";
            // 
            // txtPagaCon
            // 
            this.txtPagaCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPagaCon.Location = new System.Drawing.Point(98, 371);
            this.txtPagaCon.Name = "txtPagaCon";
            this.txtPagaCon.Size = new System.Drawing.Size(265, 26);
            this.txtPagaCon.TabIndex = 6;
            this.txtPagaCon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPagaCon_KeyDown);
            this.txtPagaCon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPagaCon_KeyPress);
            this.txtPagaCon.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPagaCon_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.label7.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(255, 25);
            this.label7.TabIndex = 7;
            this.label7.Text = "Total con descuento:";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.labelTotal.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.labelTotal.Location = new System.Drawing.Point(92, 308);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(123, 32);
            this.labelTotal.TabIndex = 8;
            this.labelTotal.Text = "Total 00";
            // 
            // cboFormaPago
            // 
            this.cboFormaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFormaPago.ForeColor = System.Drawing.Color.SeaGreen;
            this.cboFormaPago.FormattingEnabled = true;
            this.cboFormaPago.Location = new System.Drawing.Point(207, 141);
            this.cboFormaPago.Name = "cboFormaPago";
            this.cboFormaPago.Size = new System.Drawing.Size(285, 28);
            this.cboFormaPago.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.label9.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(7, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(195, 25);
            this.label9.TabIndex = 10;
            this.label9.Text = "Forma de pago:";
            // 
            // btnRealizarVenta
            // 
            this.btnRealizarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnRealizarVenta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnRealizarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRealizarVenta.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRealizarVenta.ForeColor = System.Drawing.Color.White;
            this.btnRealizarVenta.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnRealizarVenta.IconColor = System.Drawing.Color.Black;
            this.btnRealizarVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRealizarVenta.Location = new System.Drawing.Point(12, 493);
            this.btnRealizarVenta.Name = "btnRealizarVenta";
            this.btnRealizarVenta.Size = new System.Drawing.Size(202, 41);
            this.btnRealizarVenta.TabIndex = 11;
            this.btnRealizarVenta.Text = "Realizar venta";
            this.btnRealizarVenta.UseVisualStyleBackColor = false;
            this.btnRealizarVenta.Click += new System.EventHandler(this.btnRealizarVenta_Click);
            // 
            // btnDescuento
            // 
            this.btnDescuento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnDescuento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescuento.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescuento.ForeColor = System.Drawing.Color.White;
            this.btnDescuento.Location = new System.Drawing.Point(12, 72);
            this.btnDescuento.Name = "btnDescuento";
            this.btnDescuento.Size = new System.Drawing.Size(117, 29);
            this.btnDescuento.TabIndex = 12;
            this.btnDescuento.Text = "Descuento% (F4)";
            this.btnDescuento.UseVisualStyleBackColor = false;
            this.btnDescuento.Click += new System.EventHandler(this.btnDescuento_Click);
            // 
            // lblMontoDescuento
            // 
            this.lblMontoDescuento.AutoSize = true;
            this.lblMontoDescuento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.lblMontoDescuento.Font = new System.Drawing.Font("Verdana", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoDescuento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblMontoDescuento.Location = new System.Drawing.Point(218, 199);
            this.lblMontoDescuento.Name = "lblMontoDescuento";
            this.lblMontoDescuento.Size = new System.Drawing.Size(42, 28);
            this.lblMontoDescuento.TabIndex = 13;
            this.lblMontoDescuento.Text = "00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.label5.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(7, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Total:";
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.lblDescuento.Font = new System.Drawing.Font("Verdana", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblDescuento.Location = new System.Drawing.Point(266, 227);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(27, 28);
            this.lblDescuento.TabIndex = 15;
            this.lblDescuento.Text = "0";
            // 
            // cbAgregarDeuda
            // 
            this.cbAgregarDeuda.AutoSize = true;
            this.cbAgregarDeuda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.cbAgregarDeuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cbAgregarDeuda.ForeColor = System.Drawing.Color.White;
            this.cbAgregarDeuda.Location = new System.Drawing.Point(607, 333);
            this.cbAgregarDeuda.Name = "cbAgregarDeuda";
            this.cbAgregarDeuda.Size = new System.Drawing.Size(141, 17);
            this.cbAgregarDeuda.TabIndex = 17;
            this.cbAgregarDeuda.Text = "Agregar deuda al cliente";
            this.cbAgregarDeuda.UseVisualStyleBackColor = false;
            this.cbAgregarDeuda.Visible = false;
            // 
            // lblDeuda
            // 
            this.lblDeuda.AutoSize = true;
            this.lblDeuda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.lblDeuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeuda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblDeuda.Location = new System.Drawing.Point(583, 349);
            this.lblDeuda.Name = "lblDeuda";
            this.lblDeuda.Size = new System.Drawing.Size(18, 20);
            this.lblDeuda.TabIndex = 18;
            this.lblDeuda.Text = "0";
            // 
            // cbAgregarSaldoFavor
            // 
            this.cbAgregarSaldoFavor.AutoSize = true;
            this.cbAgregarSaldoFavor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.cbAgregarSaldoFavor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cbAgregarSaldoFavor.ForeColor = System.Drawing.Color.White;
            this.cbAgregarSaldoFavor.Location = new System.Drawing.Point(611, 227);
            this.cbAgregarSaldoFavor.Name = "cbAgregarSaldoFavor";
            this.cbAgregarSaldoFavor.Size = new System.Drawing.Size(172, 17);
            this.cbAgregarSaldoFavor.TabIndex = 19;
            this.cbAgregarSaldoFavor.Text = "Agregar saldo a favor al cliente";
            this.cbAgregarSaldoFavor.UseVisualStyleBackColor = false;
            this.cbAgregarSaldoFavor.Visible = false;
            // 
            // lblSaldoFavor
            // 
            this.lblSaldoFavor.AutoSize = true;
            this.lblSaldoFavor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.lblSaldoFavor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoFavor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblSaldoFavor.Location = new System.Drawing.Point(583, 248);
            this.lblSaldoFavor.Name = "lblSaldoFavor";
            this.lblSaldoFavor.Size = new System.Drawing.Size(18, 20);
            this.lblSaldoFavor.TabIndex = 20;
            this.lblSaldoFavor.Text = "0";
            // 
            // cbPagarConSaldoFavor
            // 
            this.cbPagarConSaldoFavor.AutoSize = true;
            this.cbPagarConSaldoFavor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.cbPagarConSaldoFavor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cbPagarConSaldoFavor.ForeColor = System.Drawing.Color.White;
            this.cbPagarConSaldoFavor.Location = new System.Drawing.Point(612, 137);
            this.cbPagarConSaldoFavor.Name = "cbPagarConSaldoFavor";
            this.cbPagarConSaldoFavor.Size = new System.Drawing.Size(139, 17);
            this.cbPagarConSaldoFavor.TabIndex = 21;
            this.cbPagarConSaldoFavor.Text = "Pagar con saldo a favor";
            this.cbPagarConSaldoFavor.UseVisualStyleBackColor = false;
            this.cbPagarConSaldoFavor.Visible = false;
            // 
            // lblsaldo
            // 
            this.lblsaldo.AutoSize = true;
            this.lblsaldo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.lblsaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsaldo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblsaldo.Location = new System.Drawing.Point(583, 158);
            this.lblsaldo.Name = "lblsaldo";
            this.lblsaldo.Size = new System.Drawing.Size(18, 20);
            this.lblsaldo.TabIndex = 22;
            this.lblsaldo.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.label8.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(5, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(207, 25);
            this.label8.TabIndex = 23;
            this.label8.Text = "Total descuento:";
            // 
            // mdVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 638);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblsaldo);
            this.Controls.Add(this.cbPagarConSaldoFavor);
            this.Controls.Add(this.lblSaldoFavor);
            this.Controls.Add(this.cbAgregarSaldoFavor);
            this.Controls.Add(this.lblDeuda);
            this.Controls.Add(this.cbAgregarDeuda);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblMontoDescuento);
            this.Controls.Add(this.btnDescuento);
            this.Controls.Add(this.btnRealizarVenta);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboFormaPago);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPagaCon);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelCambio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "mdVenta";
            this.Load += new System.EventHandler(this.mdVenta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelCambio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPagaCon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.ComboBox cboFormaPago;
        private System.Windows.Forms.Label label9;
        private FontAwesome.Sharp.IconButton btnRealizarVenta;
        private System.Windows.Forms.Button btnDescuento;
        private System.Windows.Forms.Label lblMontoDescuento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDescuento;
        public System.Windows.Forms.CheckBox cbAgregarDeuda;
        private System.Windows.Forms.Label lblDeuda;
        public System.Windows.Forms.CheckBox cbAgregarSaldoFavor;
        private System.Windows.Forms.Label lblSaldoFavor;
        public System.Windows.Forms.CheckBox cbPagarConSaldoFavor;
        private System.Windows.Forms.Label lblsaldo;
        private System.Windows.Forms.Label label8;
    }
}