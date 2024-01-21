namespace ejProductos
{
    partial class modTipoDespegable
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
            this.checkboxTipo = new System.Windows.Forms.CheckedListBox();
            this.labelTipo = new System.Windows.Forms.Label();
            this.checkBotonAceptar = new System.Windows.Forms.Button();
            this.rbRopa = new System.Windows.Forms.RadioButton();
            this.rbAlimentacion = new System.Windows.Forms.RadioButton();
            this.rbMueble = new System.Windows.Forms.RadioButton();
            this.rbElectrodomestico = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // checkboxTipo
            // 
            this.checkboxTipo.BackColor = System.Drawing.SystemColors.Control;
            this.checkboxTipo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkboxTipo.CheckOnClick = true;
            this.checkboxTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.checkboxTipo.FormattingEnabled = true;
            this.checkboxTipo.Items.AddRange(new object[] {
            "Ropa",
            "Alimentación",
            "Mueble",
            "Electrodoméstico"});
            this.checkboxTipo.Location = new System.Drawing.Point(223, 32);
            this.checkboxTipo.Name = "checkboxTipo";
            this.checkboxTipo.Size = new System.Drawing.Size(192, 120);
            this.checkboxTipo.TabIndex = 15;
            // 
            // labelTipo
            // 
            this.labelTipo.AutoSize = true;
            this.labelTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labelTipo.Location = new System.Drawing.Point(8, 9);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(300, 20);
            this.labelTipo.TabIndex = 16;
            this.labelTipo.Text = "Selecciona uno de los siguientes tipos:";
            // 
            // checkBotonAceptar
            // 
            this.checkBotonAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.checkBotonAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.checkBotonAceptar.Location = new System.Drawing.Point(223, 118);
            this.checkBotonAceptar.Name = "checkBotonAceptar";
            this.checkBotonAceptar.Size = new System.Drawing.Size(75, 34);
            this.checkBotonAceptar.TabIndex = 17;
            this.checkBotonAceptar.Text = "Aceptar";
            this.checkBotonAceptar.UseVisualStyleBackColor = true;
            this.checkBotonAceptar.Click += new System.EventHandler(this.checkBotonAceptar_Click);
            // 
            // rbRopa
            // 
            this.rbRopa.AutoSize = true;
            this.rbRopa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.rbRopa.Location = new System.Drawing.Point(12, 40);
            this.rbRopa.Name = "rbRopa";
            this.rbRopa.Size = new System.Drawing.Size(62, 22);
            this.rbRopa.TabIndex = 18;
            this.rbRopa.TabStop = true;
            this.rbRopa.Text = "Ropa";
            this.rbRopa.UseVisualStyleBackColor = true;
            this.rbRopa.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbAlimentacion
            // 
            this.rbAlimentacion.AutoSize = true;
            this.rbAlimentacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.rbAlimentacion.Location = new System.Drawing.Point(12, 68);
            this.rbAlimentacion.Name = "rbAlimentacion";
            this.rbAlimentacion.Size = new System.Drawing.Size(110, 22);
            this.rbAlimentacion.TabIndex = 19;
            this.rbAlimentacion.TabStop = true;
            this.rbAlimentacion.Text = "Alimentación";
            this.rbAlimentacion.UseVisualStyleBackColor = true;
            this.rbAlimentacion.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbMueble
            // 
            this.rbMueble.AutoSize = true;
            this.rbMueble.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.rbMueble.Location = new System.Drawing.Point(12, 96);
            this.rbMueble.Name = "rbMueble";
            this.rbMueble.Size = new System.Drawing.Size(74, 22);
            this.rbMueble.TabIndex = 20;
            this.rbMueble.TabStop = true;
            this.rbMueble.Text = "Mueble";
            this.rbMueble.UseVisualStyleBackColor = true;
            this.rbMueble.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbElectrodomestico
            // 
            this.rbElectrodomestico.AutoSize = true;
            this.rbElectrodomestico.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.rbElectrodomestico.Location = new System.Drawing.Point(12, 124);
            this.rbElectrodomestico.Name = "rbElectrodomestico";
            this.rbElectrodomestico.Size = new System.Drawing.Size(143, 22);
            this.rbElectrodomestico.TabIndex = 21;
            this.rbElectrodomestico.TabStop = true;
            this.rbElectrodomestico.Text = "Electrodoméstico";
            this.rbElectrodomestico.UseVisualStyleBackColor = true;
            this.rbElectrodomestico.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // modTipoDespegable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 160);
            this.Controls.Add(this.rbElectrodomestico);
            this.Controls.Add(this.rbMueble);
            this.Controls.Add(this.rbAlimentacion);
            this.Controls.Add(this.rbRopa);
            this.Controls.Add(this.checkBotonAceptar);
            this.Controls.Add(this.labelTipo);
            this.Controls.Add(this.checkboxTipo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "modTipoDespegable";
            this.Text = "modTipoDespegable";
            this.Load += new System.EventHandler(this.modTipoDespegable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkboxTipo;
        private System.Windows.Forms.Label labelTipo;
        private System.Windows.Forms.Button checkBotonAceptar;
        private System.Windows.Forms.RadioButton rbRopa;
        private System.Windows.Forms.RadioButton rbAlimentacion;
        private System.Windows.Forms.RadioButton rbMueble;
        private System.Windows.Forms.RadioButton rbElectrodomestico;
    }
}