namespace PARKING.Windows
{
    partial class frmInicio
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ProductosMenu = new FontAwesome.Sharp.IconMenuItem();
            this.UsuariosMenu = new FontAwesome.Sharp.IconMenuItem();
            this.iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            this.contenedorPanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.YellowGreen;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProductosMenu,
            this.UsuariosMenu,
            this.iconMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 73);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ProductosMenu
            // 
            this.ProductosMenu.AutoSize = false;
            this.ProductosMenu.IconChar = FontAwesome.Sharp.IconChar.ProductHunt;
            this.ProductosMenu.IconColor = System.Drawing.Color.Black;
            this.ProductosMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ProductosMenu.IconSize = 50;
            this.ProductosMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ProductosMenu.Name = "ProductosMenu";
            this.ProductosMenu.Size = new System.Drawing.Size(122, 69);
            this.ProductosMenu.Text = "Plantas";
            this.ProductosMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ProductosMenu.Click += new System.EventHandler(this.ProductosMenu_Click);
            // 
            // UsuariosMenu
            // 
            this.UsuariosMenu.AutoSize = false;
            this.UsuariosMenu.IconChar = FontAwesome.Sharp.IconChar.IceCream;
            this.UsuariosMenu.IconColor = System.Drawing.Color.Black;
            this.UsuariosMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.UsuariosMenu.IconSize = 50;
            this.UsuariosMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.UsuariosMenu.Name = "UsuariosMenu";
            this.UsuariosMenu.Size = new System.Drawing.Size(122, 69);
            this.UsuariosMenu.Text = "Ingresos";
            this.UsuariosMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.UsuariosMenu.Click += new System.EventHandler(this.UsuariosMenu_Click);
            // 
            // iconMenuItem1
            // 
            this.iconMenuItem1.AutoSize = false;
            this.iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.Exchange;
            this.iconMenuItem1.IconColor = System.Drawing.Color.Black;
            this.iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem1.IconSize = 50;
            this.iconMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.iconMenuItem1.Name = "iconMenuItem1";
            this.iconMenuItem1.Size = new System.Drawing.Size(122, 69);
            this.iconMenuItem1.Text = "Egresos";
            this.iconMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconMenuItem1.Click += new System.EventHandler(this.iconMenuItem1_Click);
            // 
            // contenedorPanel
            // 
            this.contenedorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedorPanel.Location = new System.Drawing.Point(0, 73);
            this.contenedorPanel.Name = "contenedorPanel";
            this.contenedorPanel.Size = new System.Drawing.Size(800, 377);
            this.contenedorPanel.TabIndex = 4;
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.contenedorPanel);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmInicio";
            this.Text = "PARKING";
            this.Load += new System.EventHandler(this.frmInicio_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem ProductosMenu;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private FontAwesome.Sharp.IconMenuItem UsuariosMenu;
        private System.Windows.Forms.Panel contenedorPanel;
    }
}