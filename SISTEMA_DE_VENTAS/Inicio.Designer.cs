
namespace SISTEMA_DE_VENTAS
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.barraSuperior = new System.Windows.Forms.Label();
            this.fechaHora = new System.Windows.Forms.Timer(this.components);
            this.contenedor = new System.Windows.Forms.Panel();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuU = new FontAwesome.Sharp.IconMenuItem();
            this.menuM = new FontAwesome.Sharp.IconMenuItem();
            this.submenuCA = new FontAwesome.Sharp.IconMenuItem();
            this.submenuP = new FontAwesome.Sharp.IconMenuItem();
            this.menuV = new FontAwesome.Sharp.IconMenuItem();
            this.submenuR = new FontAwesome.Sharp.IconMenuItem();
            this.submenuD = new FontAwesome.Sharp.IconMenuItem();
            this.menuR = new FontAwesome.Sharp.IconMenuItem();
            this.subMenuV = new FontAwesome.Sharp.IconMenuItem();
            this.subMenuc = new FontAwesome.Sharp.IconMenuItem();
            this.menuC = new FontAwesome.Sharp.IconMenuItem();
            this.menuCl = new FontAwesome.Sharp.IconMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCerrarSesion = new System.Windows.Forms.Label();
            this.contenedor.SuspendLayout();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Verdana", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.lblFecha.Location = new System.Drawing.Point(630, 482);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(136, 48);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Verdana", 90F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblHora.Location = new System.Drawing.Point(598, 307);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(451, 145);
            this.lblHora.TabIndex = 0;
            this.lblHora.Text = "HORA";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.lblUsuario.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(1669, 42);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(62, 16);
            this.lblUsuario.TabIndex = 15;
            this.lblUsuario.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1601, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Usuario:";
            // 
            // barraSuperior
            // 
            this.barraSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.barraSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraSuperior.Location = new System.Drawing.Point(0, 0);
            this.barraSuperior.Name = "barraSuperior";
            this.barraSuperior.Size = new System.Drawing.Size(1924, 99);
            this.barraSuperior.TabIndex = 16;
            // 
            // fechaHora
            // 
            this.fechaHora.Enabled = true;
            this.fechaHora.Tick += new System.EventHandler(this.fechaHora_Tick);
            // 
            // contenedor
            // 
            this.contenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.contenedor.Controls.Add(this.lblFecha);
            this.contenedor.Controls.Add(this.lblHora);
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(200, 99);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1724, 874);
            this.contenedor.TabIndex = 13;
            // 
            // menu
            // 
            this.menu.AutoSize = false;
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuU,
            this.menuM,
            this.menuV,
            this.menuR,
            this.menuC,
            this.menuCl});
            this.menu.Location = new System.Drawing.Point(0, 99);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(200, 874);
            this.menu.TabIndex = 12;
            this.menu.Text = "menuStrip1";
            // 
            // menuU
            // 
            this.menuU.AutoSize = false;
            this.menuU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.menuU.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuU.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuU.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.menuU.IconColor = System.Drawing.Color.White;
            this.menuU.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuU.IconSize = 50;
            this.menuU.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuU.Name = "menuU";
            this.menuU.Padding = new System.Windows.Forms.Padding(6, 0, 4, 0);
            this.menuU.Size = new System.Drawing.Size(200, 80);
            this.menuU.Text = "Usuario";
            this.menuU.Click += new System.EventHandler(this.menuU_Click);
            // 
            // menuM
            // 
            this.menuM.AutoSize = false;
            this.menuM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.menuM.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuCA,
            this.submenuP});
            this.menuM.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuM.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuM.IconChar = FontAwesome.Sharp.IconChar.Tools;
            this.menuM.IconColor = System.Drawing.Color.White;
            this.menuM.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuM.IconSize = 50;
            this.menuM.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuM.Name = "menuM";
            this.menuM.Padding = new System.Windows.Forms.Padding(6, 0, 4, 0);
            this.menuM.Size = new System.Drawing.Size(200, 80);
            this.menuM.Text = "Mantenedor ";
            this.menuM.MouseLeave += new System.EventHandler(this.menuM_MouseLeave);
            this.menuM.MouseHover += new System.EventHandler(this.menuM_MouseHover);
            // 
            // submenuCA
            // 
            this.submenuCA.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuCA.IconColor = System.Drawing.Color.Black;
            this.submenuCA.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuCA.Name = "submenuCA";
            this.submenuCA.Size = new System.Drawing.Size(166, 30);
            this.submenuCA.Text = "Categoria";
            this.submenuCA.Click += new System.EventHandler(this.submenuCA_Click);
            // 
            // submenuP
            // 
            this.submenuP.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuP.IconColor = System.Drawing.Color.Black;
            this.submenuP.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuP.Name = "submenuP";
            this.submenuP.Size = new System.Drawing.Size(166, 30);
            this.submenuP.Text = "Producto";
            this.submenuP.Click += new System.EventHandler(this.submenuP_Click);
            // 
            // menuV
            // 
            this.menuV.AutoSize = false;
            this.menuV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.menuV.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuR,
            this.submenuD});
            this.menuV.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuV.IconChar = FontAwesome.Sharp.IconChar.Tag;
            this.menuV.IconColor = System.Drawing.Color.White;
            this.menuV.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuV.IconSize = 50;
            this.menuV.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuV.Name = "menuV";
            this.menuV.Padding = new System.Windows.Forms.Padding(6, 0, 4, 0);
            this.menuV.Size = new System.Drawing.Size(200, 80);
            this.menuV.Text = "Ventas";
            this.menuV.MouseLeave += new System.EventHandler(this.menuV_MouseLeave);
            this.menuV.MouseHover += new System.EventHandler(this.menuV_MouseHover);
            // 
            // submenuR
            // 
            this.submenuR.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuR.IconColor = System.Drawing.Color.Black;
            this.submenuR.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuR.Name = "submenuR";
            this.submenuR.Size = new System.Drawing.Size(220, 30);
            this.submenuR.Text = "Registrar venta ";
            this.submenuR.Click += new System.EventHandler(this.submenuR_Click);
            // 
            // submenuD
            // 
            this.submenuD.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuD.IconColor = System.Drawing.Color.Black;
            this.submenuD.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuD.Name = "submenuD";
            this.submenuD.Size = new System.Drawing.Size(220, 30);
            this.submenuD.Text = "Detalle de venta";
            this.submenuD.Click += new System.EventHandler(this.submenuD_Click);
            // 
            // menuR
            // 
            this.menuR.AutoSize = false;
            this.menuR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.menuR.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuV,
            this.subMenuc});
            this.menuR.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuR.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuR.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.menuR.IconColor = System.Drawing.Color.White;
            this.menuR.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuR.IconSize = 50;
            this.menuR.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuR.Name = "menuR";
            this.menuR.Padding = new System.Windows.Forms.Padding(6, 0, 4, 0);
            this.menuR.Size = new System.Drawing.Size(200, 80);
            this.menuR.Text = "Reportes";
            this.menuR.MouseLeave += new System.EventHandler(this.menuR_MouseLeave);
            this.menuR.MouseHover += new System.EventHandler(this.menuR_MouseHover);
            // 
            // subMenuV
            // 
            this.subMenuV.IconChar = FontAwesome.Sharp.IconChar.None;
            this.subMenuV.IconColor = System.Drawing.Color.Black;
            this.subMenuV.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subMenuV.Name = "subMenuV";
            this.subMenuV.Size = new System.Drawing.Size(202, 30);
            this.subMenuV.Text = "Reporte Venta";
            this.subMenuV.Click += new System.EventHandler(this.subMenuV_Click);
            // 
            // subMenuc
            // 
            this.subMenuc.IconChar = FontAwesome.Sharp.IconChar.None;
            this.subMenuc.IconColor = System.Drawing.Color.Black;
            this.subMenuc.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subMenuc.Name = "subMenuc";
            this.subMenuc.Size = new System.Drawing.Size(202, 30);
            this.subMenuc.Text = "Reporte Caja";
            this.subMenuc.Click += new System.EventHandler(this.subMenuc_Click);
            // 
            // menuC
            // 
            this.menuC.AutoSize = false;
            this.menuC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.menuC.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuC.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuC.IconChar = FontAwesome.Sharp.IconChar.MoneyCheckAlt;
            this.menuC.IconColor = System.Drawing.Color.White;
            this.menuC.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuC.IconSize = 50;
            this.menuC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuC.Name = "menuC";
            this.menuC.Padding = new System.Windows.Forms.Padding(6, 0, 4, 0);
            this.menuC.Size = new System.Drawing.Size(200, 80);
            this.menuC.Text = "Caja";
            this.menuC.Click += new System.EventHandler(this.menuC_Click);
            // 
            // menuCl
            // 
            this.menuCl.AutoSize = false;
            this.menuCl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.menuCl.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuCl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuCl.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.menuCl.IconColor = System.Drawing.Color.White;
            this.menuCl.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuCl.IconSize = 50;
            this.menuCl.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuCl.Name = "menuCl";
            this.menuCl.Size = new System.Drawing.Size(200, 80);
            this.menuCl.Text = "Clientes";
            this.menuCl.Click += new System.EventHandler(this.menuCl_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 93);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblCerrarSesion
            // 
            this.lblCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(140)))));
            this.lblCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCerrarSesion.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.lblCerrarSesion.Location = new System.Drawing.Point(1809, 37);
            this.lblCerrarSesion.Name = "lblCerrarSesion";
            this.lblCerrarSesion.Size = new System.Drawing.Size(103, 26);
            this.lblCerrarSesion.TabIndex = 22;
            this.lblCerrarSesion.Text = "Cerrar Sesion";
            this.lblCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCerrarSesion.Click += new System.EventHandler(this.lblCerrarSesion_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1924, 973);
            this.Controls.Add(this.lblCerrarSesion);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.barraSuperior);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Ventas ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.contenedor.ResumeLayout(false);
            this.contenedor.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label barraSuperior;
        private System.Windows.Forms.Timer fechaHora;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.MenuStrip menu;
        private FontAwesome.Sharp.IconMenuItem menuU;
        private FontAwesome.Sharp.IconMenuItem menuM;
        private FontAwesome.Sharp.IconMenuItem submenuCA;
        private FontAwesome.Sharp.IconMenuItem submenuP;
        private FontAwesome.Sharp.IconMenuItem menuV;
        private FontAwesome.Sharp.IconMenuItem submenuR;
        private FontAwesome.Sharp.IconMenuItem submenuD;
        private FontAwesome.Sharp.IconMenuItem menuR;
        private FontAwesome.Sharp.IconMenuItem menuC;
        private FontAwesome.Sharp.IconMenuItem menuCl;
        private FontAwesome.Sharp.IconMenuItem subMenuV;
        private FontAwesome.Sharp.IconMenuItem subMenuc;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCerrarSesion;
    }
}

