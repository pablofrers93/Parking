namespace PARKING.Windows
{
    partial class frmPlantas
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
            this.UltimoIconButton = new FontAwesome.Sharp.IconButton();
            this.DatosDataGridView = new System.Windows.Forms.DataGridView();
            this.colPlantas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidadLugares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidadDisponible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DatosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolBarPanel
            // 
            this.ToolBarPanel.BackColor = System.Drawing.Color.YellowGreen;
            this.ToolBarPanel.Controls.Add(this.UltimoIconButton);
            this.ToolBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolBarPanel.Location = new System.Drawing.Point(0, 0);
            this.ToolBarPanel.Name = "ToolBarPanel";
            this.ToolBarPanel.Size = new System.Drawing.Size(800, 100);
            this.ToolBarPanel.TabIndex = 5;
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
            this.colPlantas,
            this.colCantidadLugares,
            this.colCantidadDisponible});
            this.DatosDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatosDataGridView.Location = new System.Drawing.Point(0, 100);
            this.DatosDataGridView.MultiSelect = false;
            this.DatosDataGridView.Name = "DatosDataGridView";
            this.DatosDataGridView.ReadOnly = true;
            this.DatosDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatosDataGridView.RowTemplate.Height = 28;
            this.DatosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DatosDataGridView.Size = new System.Drawing.Size(800, 350);
            this.DatosDataGridView.TabIndex = 6;
            // 
            // colPlantas
            // 
            this.colPlantas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPlantas.HeaderText = "Nombre de Planta";
            this.colPlantas.MinimumWidth = 50;
            this.colPlantas.Name = "colPlantas";
            this.colPlantas.ReadOnly = true;
            // 
            // colCantidadLugares
            // 
            this.colCantidadLugares.HeaderText = "Total Lugares";
            this.colCantidadLugares.Name = "colCantidadLugares";
            this.colCantidadLugares.ReadOnly = true;
            // 
            // colCantidadDisponible
            // 
            this.colCantidadDisponible.HeaderText = "Lugares Disponibles";
            this.colCantidadDisponible.Name = "colCantidadDisponible";
            this.colCantidadDisponible.ReadOnly = true;
            // 
            // frmPlantas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DatosDataGridView);
            this.Controls.Add(this.ToolBarPanel);
            this.Name = "frmPlantas";
            this.Text = "frmPlantas";
            this.Load += new System.EventHandler(this.frmPlantas_Load);
            this.ToolBarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DatosDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ToolBarPanel;
        private FontAwesome.Sharp.IconButton UltimoIconButton;
        private System.Windows.Forms.DataGridView DatosDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlantas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidadLugares;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidadDisponible;
    }
}