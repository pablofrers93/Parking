namespace PARKING.Windows
{
    partial class frmEgresos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ToolBarPanel = new System.Windows.Forms.Panel();
            this.ClienteBuscarTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UltimoIconButton = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.EditarIconButton = new FontAwesome.Sharp.IconButton();
            this.NuevoIconButton = new FontAwesome.Sharp.IconButton();
            this.DatosDataGridView = new System.Windows.Forms.DataGridView();
            this.colPatente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAbonoVigente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlanta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLugar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImporteAbonado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DatosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolBarPanel
            // 
            this.ToolBarPanel.BackColor = System.Drawing.Color.YellowGreen;
            this.ToolBarPanel.Controls.Add(this.ClienteBuscarTextBox);
            this.ToolBarPanel.Controls.Add(this.label1);
            this.ToolBarPanel.Controls.Add(this.UltimoIconButton);
            this.ToolBarPanel.Controls.Add(this.iconButton1);
            this.ToolBarPanel.Controls.Add(this.EditarIconButton);
            this.ToolBarPanel.Controls.Add(this.NuevoIconButton);
            this.ToolBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolBarPanel.Location = new System.Drawing.Point(0, 0);
            this.ToolBarPanel.Name = "ToolBarPanel";
            this.ToolBarPanel.Size = new System.Drawing.Size(863, 100);
            this.ToolBarPanel.TabIndex = 5;
            // 
            // ClienteBuscarTextBox
            // 
            this.ClienteBuscarTextBox.Enabled = false;
            this.ClienteBuscarTextBox.Location = new System.Drawing.Point(451, 40);
            this.ClienteBuscarTextBox.Name = "ClienteBuscarTextBox";
            this.ClienteBuscarTextBox.Size = new System.Drawing.Size(245, 20);
            this.ClienteBuscarTextBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(403, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cliente:";
            // 
            // UltimoIconButton
            // 
            this.UltimoIconButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UltimoIconButton.IconChar = FontAwesome.Sharp.IconChar.ForwardFast;
            this.UltimoIconButton.IconColor = System.Drawing.Color.Goldenrod;
            this.UltimoIconButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.UltimoIconButton.Location = new System.Drawing.Point(966, 19);
            this.UltimoIconButton.Name = "UltimoIconButton";
            this.UltimoIconButton.Size = new System.Drawing.Size(62, 63);
            this.UltimoIconButton.TabIndex = 2;
            this.UltimoIconButton.Text = "Último";
            this.UltimoIconButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.UltimoIconButton.UseVisualStyleBackColor = true;
            // 
            // iconButton1
            // 
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(241, 19);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(62, 63);
            this.iconButton1.TabIndex = 2;
            this.iconButton1.Text = "Buscar";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton1.UseVisualStyleBackColor = true;
            // 
            // EditarIconButton
            // 
            this.EditarIconButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditarIconButton.IconChar = FontAwesome.Sharp.IconChar.Pen;
            this.EditarIconButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.EditarIconButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.EditarIconButton.Location = new System.Drawing.Point(81, 19);
            this.EditarIconButton.Name = "EditarIconButton";
            this.EditarIconButton.Size = new System.Drawing.Size(62, 63);
            this.EditarIconButton.TabIndex = 3;
            this.EditarIconButton.Text = "Editar";
            this.EditarIconButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.EditarIconButton.UseVisualStyleBackColor = true;
            // 
            // NuevoIconButton
            // 
            this.NuevoIconButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NuevoIconButton.IconChar = FontAwesome.Sharp.IconChar.File;
            this.NuevoIconButton.IconColor = System.Drawing.Color.LimeGreen;
            this.NuevoIconButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.NuevoIconButton.Location = new System.Drawing.Point(13, 19);
            this.NuevoIconButton.Name = "NuevoIconButton";
            this.NuevoIconButton.Size = new System.Drawing.Size(62, 63);
            this.NuevoIconButton.TabIndex = 5;
            this.NuevoIconButton.Text = "Nuevo";
            this.NuevoIconButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.NuevoIconButton.UseVisualStyleBackColor = true;
            this.NuevoIconButton.Click += new System.EventHandler(this.NuevoIconButton_Click);
            // 
            // DatosDataGridView
            // 
            this.DatosDataGridView.AllowUserToAddRows = false;
            this.DatosDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DatosDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DatosDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DatosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DatosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPatente,
            this.colFechaIngreso,
            this.colAbonoVigente,
            this.colPlanta,
            this.colLugar,
            this.colImporteAbonado});
            this.DatosDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatosDataGridView.Location = new System.Drawing.Point(0, 100);
            this.DatosDataGridView.MultiSelect = false;
            this.DatosDataGridView.Name = "DatosDataGridView";
            this.DatosDataGridView.ReadOnly = true;
            this.DatosDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatosDataGridView.RowTemplate.Height = 28;
            this.DatosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DatosDataGridView.Size = new System.Drawing.Size(863, 350);
            this.DatosDataGridView.TabIndex = 6;
            // 
            // colPatente
            // 
            this.colPatente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPatente.FillWeight = 50F;
            this.colPatente.HeaderText = "Patente";
            this.colPatente.MinimumWidth = 50;
            this.colPatente.Name = "colPatente";
            this.colPatente.ReadOnly = true;
            // 
            // colFechaIngreso
            // 
            this.colFechaIngreso.HeaderText = "Fecha Ingreso";
            this.colFechaIngreso.Name = "colFechaIngreso";
            this.colFechaIngreso.ReadOnly = true;
            this.colFechaIngreso.Width = 150;
            // 
            // colAbonoVigente
            // 
            this.colAbonoVigente.HeaderText = "Fecha Egreso";
            this.colAbonoVigente.Name = "colAbonoVigente";
            this.colAbonoVigente.ReadOnly = true;
            this.colAbonoVigente.Width = 150;
            // 
            // colPlanta
            // 
            this.colPlanta.HeaderText = "Planta";
            this.colPlanta.Name = "colPlanta";
            this.colPlanta.ReadOnly = true;
            this.colPlanta.Width = 120;
            // 
            // colLugar
            // 
            this.colLugar.HeaderText = "Numero Lugar";
            this.colLugar.Name = "colLugar";
            this.colLugar.ReadOnly = true;
            // 
            // colImporteAbonado
            // 
            this.colImporteAbonado.HeaderText = "Importe Abonado";
            this.colImporteAbonado.Name = "colImporteAbonado";
            this.colImporteAbonado.ReadOnly = true;
            // 
            // frmEgresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 450);
            this.Controls.Add(this.DatosDataGridView);
            this.Controls.Add(this.ToolBarPanel);
            this.Name = "frmEgresos";
            this.Text = "  ";
            this.Load += new System.EventHandler(this.frmEgresos_Load);
            this.ToolBarPanel.ResumeLayout(false);
            this.ToolBarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DatosDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ToolBarPanel;
        private System.Windows.Forms.TextBox ClienteBuscarTextBox;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton UltimoIconButton;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton EditarIconButton;
        private FontAwesome.Sharp.IconButton NuevoIconButton;
        private System.Windows.Forms.DataGridView DatosDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAbonoVigente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlanta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLugar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImporteAbonado;
    }
}