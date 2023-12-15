
namespace ejProductos
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.añadirFila = new System.Windows.Forms.Button();
            this.añadirFilaSeguido = new System.Windows.Forms.Button();
            this.comprobarVacio = new System.Windows.Forms.Label();
            this.añadirColumna = new System.Windows.Forms.Button();
            this.cuentaFilasColumnas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(150, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // añadirFila
            // 
            this.añadirFila.Location = new System.Drawing.Point(615, 262);
            this.añadirFila.Name = "añadirFila";
            this.añadirFila.Size = new System.Drawing.Size(115, 36);
            this.añadirFila.TabIndex = 1;
            this.añadirFila.Text = "Añadir nueva fila";
            this.añadirFila.UseVisualStyleBackColor = true;
            this.añadirFila.Visible = false;
            this.añadirFila.Click += new System.EventHandler(this.añadirFila_Click);
            // 
            // añadirFilaSeguido
            // 
            this.añadirFilaSeguido.Location = new System.Drawing.Point(615, 329);
            this.añadirFilaSeguido.Name = "añadirFilaSeguido";
            this.añadirFilaSeguido.Size = new System.Drawing.Size(115, 55);
            this.añadirFilaSeguido.TabIndex = 2;
            this.añadirFilaSeguido.Text = "Añadir nueva fila con todos los valores de golpe";
            this.añadirFilaSeguido.UseVisualStyleBackColor = true;
            this.añadirFilaSeguido.Visible = false;
            this.añadirFilaSeguido.Click += new System.EventHandler(this.añadirFilaSeguido_Click);
            // 
            // comprobarVacio
            // 
            this.comprobarVacio.AutoSize = true;
            this.comprobarVacio.Location = new System.Drawing.Point(147, 250);
            this.comprobarVacio.Name = "comprobarVacio";
            this.comprobarVacio.Size = new System.Drawing.Size(245, 13);
            this.comprobarVacio.TabIndex = 3;
            this.comprobarVacio.Text = "Aquí se puede comprobar si DataGridView es nulo";
            // 
            // añadirColumna
            // 
            this.añadirColumna.Location = new System.Drawing.Point(464, 262);
            this.añadirColumna.Name = "añadirColumna";
            this.añadirColumna.Size = new System.Drawing.Size(115, 36);
            this.añadirColumna.TabIndex = 4;
            this.añadirColumna.Text = "Añadir nueva columna";
            this.añadirColumna.UseVisualStyleBackColor = true;
            this.añadirColumna.Click += new System.EventHandler(this.añadirColumna_Click);
            // 
            // cuentaFilasColumnas
            // 
            this.cuentaFilasColumnas.Location = new System.Drawing.Point(464, 329);
            this.cuentaFilasColumnas.Name = "cuentaFilasColumnas";
            this.cuentaFilasColumnas.Size = new System.Drawing.Size(115, 55);
            this.cuentaFilasColumnas.TabIndex = 5;
            this.cuentaFilasColumnas.Text = "Contar filas y columnas del DataGridView\r\n";
            this.cuentaFilasColumnas.UseVisualStyleBackColor = true;
            this.cuentaFilasColumnas.Click += new System.EventHandler(this.cuentaFilasColumnas_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cuentaFilasColumnas);
            this.Controls.Add(this.añadirColumna);
            this.Controls.Add(this.comprobarVacio);
            this.Controls.Add(this.añadirFilaSeguido);
            this.Controls.Add(this.añadirFila);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button añadirFila;
        private System.Windows.Forms.Button añadirFilaSeguido;
        private System.Windows.Forms.Label comprobarVacio;
        private System.Windows.Forms.Button añadirColumna;
        private System.Windows.Forms.Button cuentaFilasColumnas;
    }
}

