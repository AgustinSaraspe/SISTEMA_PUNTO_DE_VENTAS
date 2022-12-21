
namespace SISTEMA_DE_VENTAS.Modales
{
    partial class mdDescuento
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
            this.btnAgregarDescuento = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMontoDescuento = new System.Windows.Forms.Label();
            this.txtMontoPorcentaje = new System.Windows.Forms.TextBox();
            this.cbSinPorcentaje = new System.Windows.Forms.CheckBox();
            this.cbConPorcentaje = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAgregarDescuento
            // 
            this.btnAgregarDescuento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnAgregarDescuento.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnAgregarDescuento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarDescuento.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarDescuento.ForeColor = System.Drawing.Color.White;
            this.btnAgregarDescuento.Location = new System.Drawing.Point(216, 292);
            this.btnAgregarDescuento.Name = "btnAgregarDescuento";
            this.btnAgregarDescuento.Size = new System.Drawing.Size(164, 35);
            this.btnAgregarDescuento.TabIndex = 0;
            this.btnAgregarDescuento.Text = "Aceptar";
            this.btnAgregarDescuento.UseVisualStyleBackColor = false;
            this.btnAgregarDescuento.Click += new System.EventHandler(this.btnAgregarDescuento_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Agrega el descuento";
            // 
            // txtDescuento
            // 
            this.txtDescuento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.txtDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.ForeColor = System.Drawing.Color.White;
            this.txtDescuento.Location = new System.Drawing.Point(211, 148);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(169, 29);
            this.txtDescuento.TabIndex = 2;
            this.txtDescuento.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            this.txtDescuento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescuento_KeyDown);
            this.txtDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescuento_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(397, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Monto sin descuento:";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.lblMonto.Location = new System.Drawing.Point(455, 95);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(124, 13);
            this.lblMonto.TabIndex = 4;
            this.lblMonto.Text = "Agrega el descuento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Monto con descuento:";
            // 
            // lblMontoDescuento
            // 
            this.lblMontoDescuento.AutoSize = true;
            this.lblMontoDescuento.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoDescuento.ForeColor = System.Drawing.Color.White;
            this.lblMontoDescuento.Location = new System.Drawing.Point(208, 249);
            this.lblMontoDescuento.Name = "lblMontoDescuento";
            this.lblMontoDescuento.Size = new System.Drawing.Size(124, 13);
            this.lblMontoDescuento.TabIndex = 6;
            this.lblMontoDescuento.Text = "Agrega el descuento";
            // 
            // txtMontoPorcentaje
            // 
            this.txtMontoPorcentaje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.txtMontoPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoPorcentaje.ForeColor = System.Drawing.Color.White;
            this.txtMontoPorcentaje.Location = new System.Drawing.Point(211, 198);
            this.txtMontoPorcentaje.Name = "txtMontoPorcentaje";
            this.txtMontoPorcentaje.Size = new System.Drawing.Size(169, 29);
            this.txtMontoPorcentaje.TabIndex = 7;
            this.txtMontoPorcentaje.TextChanged += new System.EventHandler(this.txtMontoPorcentaje_TextChanged);
            this.txtMontoPorcentaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoPorcentaje_KeyPress);
            // 
            // cbSinPorcentaje
            // 
            this.cbSinPorcentaje.AutoSize = true;
            this.cbSinPorcentaje.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSinPorcentaje.ForeColor = System.Drawing.Color.White;
            this.cbSinPorcentaje.Location = new System.Drawing.Point(12, 92);
            this.cbSinPorcentaje.Name = "cbSinPorcentaje";
            this.cbSinPorcentaje.Size = new System.Drawing.Size(68, 20);
            this.cbSinPorcentaje.TabIndex = 8;
            this.cbSinPorcentaje.Text = "Monto";
            this.cbSinPorcentaje.UseVisualStyleBackColor = true;
            // 
            // cbConPorcentaje
            // 
            this.cbConPorcentaje.AutoSize = true;
            this.cbConPorcentaje.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbConPorcentaje.ForeColor = System.Drawing.Color.White;
            this.cbConPorcentaje.Location = new System.Drawing.Point(114, 92);
            this.cbConPorcentaje.Name = "cbConPorcentaje";
            this.cbConPorcentaje.Size = new System.Drawing.Size(98, 20);
            this.cbConPorcentaje.TabIndex = 9;
            this.cbConPorcentaje.Text = "Porcentaje";
            this.cbConPorcentaje.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(9, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Agrega el descuento";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(601, 58);
            this.label5.TabIndex = 11;
            this.label5.Text = "Descuento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(7, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(205, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tipo de descuento";
            // 
            // mdDescuento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(601, 356);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbConPorcentaje);
            this.Controls.Add(this.cbSinPorcentaje);
            this.Controls.Add(this.txtMontoPorcentaje);
            this.Controls.Add(this.lblMontoDescuento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAgregarDescuento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "mdDescuento";
            this.Load += new System.EventHandler(this.mdDescuento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarDescuento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMontoDescuento;
        private System.Windows.Forms.TextBox txtMontoPorcentaje;
        private System.Windows.Forms.CheckBox cbSinPorcentaje;
        private System.Windows.Forms.CheckBox cbConPorcentaje;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}