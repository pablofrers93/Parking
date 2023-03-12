namespace PARKING.Windows
{
    partial class frmIngresosAE
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PatenteTextBox = new System.Windows.Forms.TextBox();
            this.TipoVehiculoComboBox = new System.Windows.Forms.ComboBox();
            this.CheckBox = new System.Windows.Forms.CheckBox();
            this.PlantaComboBox = new System.Windows.Forms.ComboBox();
            this.NumeroLugarComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.DateTimePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Patente: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tipo Vehiculo: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Abono Vigente: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Planta: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Numero Lugar: ";
            // 
            // PatenteTextBox
            // 
            this.PatenteTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.PatenteTextBox.Location = new System.Drawing.Point(109, 20);
            this.PatenteTextBox.Name = "PatenteTextBox";
            this.PatenteTextBox.Size = new System.Drawing.Size(121, 20);
            this.PatenteTextBox.TabIndex = 0;
            // 
            // TipoVehiculoComboBox
            // 
            this.TipoVehiculoComboBox.FormattingEnabled = true;
            this.TipoVehiculoComboBox.Location = new System.Drawing.Point(367, 20);
            this.TipoVehiculoComboBox.Name = "TipoVehiculoComboBox";
            this.TipoVehiculoComboBox.Size = new System.Drawing.Size(142, 21);
            this.TipoVehiculoComboBox.TabIndex = 1;
            // 
            // CheckBox
            // 
            this.CheckBox.AutoSize = true;
            this.CheckBox.Location = new System.Drawing.Point(338, 66);
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Size = new System.Drawing.Size(15, 14);
            this.CheckBox.TabIndex = 3;
            this.CheckBox.UseVisualStyleBackColor = true;
            // 
            // PlantaComboBox
            // 
            this.PlantaComboBox.FormattingEnabled = true;
            this.PlantaComboBox.Location = new System.Drawing.Point(109, 63);
            this.PlantaComboBox.Name = "PlantaComboBox";
            this.PlantaComboBox.Size = new System.Drawing.Size(121, 21);
            this.PlantaComboBox.TabIndex = 2;
            this.PlantaComboBox.SelectedIndexChanged += new System.EventHandler(this.PlantaComboBox_SelectedIndexChanged);
            // 
            // NumeroLugarComboBox
            // 
            this.NumeroLugarComboBox.FormattingEnabled = true;
            this.NumeroLugarComboBox.Location = new System.Drawing.Point(109, 103);
            this.NumeroLugarComboBox.Name = "NumeroLugarComboBox";
            this.NumeroLugarComboBox.Size = new System.Drawing.Size(121, 21);
            this.NumeroLugarComboBox.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 51);
            this.button1.TabIndex = 6;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(258, 163);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 51);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Fecha de Entrada: ";
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.CustomFormat = "\"dd/MM/yyyy HH:mm\"";
            this.DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker.Location = new System.Drawing.Point(367, 104);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.Size = new System.Drawing.Size(142, 20);
            this.DateTimePicker.TabIndex = 5;
            // 
            // frmIngresosAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 249);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DateTimePicker);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NumeroLugarComboBox);
            this.Controls.Add(this.PlantaComboBox);
            this.Controls.Add(this.CheckBox);
            this.Controls.Add(this.TipoVehiculoComboBox);
            this.Controls.Add(this.PatenteTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmIngresosAE";
            this.Text = "REGISTRO NUEVO INGRESO";
            this.Load += new System.EventHandler(this.frmIngresosAE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PatenteTextBox;
        private System.Windows.Forms.ComboBox TipoVehiculoComboBox;
        private System.Windows.Forms.CheckBox CheckBox;
        private System.Windows.Forms.ComboBox PlantaComboBox;
        private System.Windows.Forms.ComboBox NumeroLugarComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DateTimePicker;
    }
}