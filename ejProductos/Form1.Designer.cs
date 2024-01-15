
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
            this.ColumnaBorrar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.añadirFila = new System.Windows.Forms.Button();
            this.añadirFilaSeguido = new System.Windows.Forms.Button();
            this.comprobarVacio = new System.Windows.Forms.Label();
            this.añadirColumna = new System.Windows.Forms.Button();
            this.cuentaFilasColumnas = new System.Windows.Forms.Button();
            this.menuAñadir = new System.Windows.Forms.Button();
            this.menuEliminar = new System.Windows.Forms.Button();
            this.menuModificar = new System.Windows.Forms.Button();
            this.tablaProductos = new System.Windows.Forms.DataGridView();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textoPrueba = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnaBorrar});
            this.dataGridView1.Location = new System.Drawing.Point(33, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ColumnaBorrar
            // 
            this.ColumnaBorrar.HeaderText = "delete";
            this.ColumnaBorrar.Name = "ColumnaBorrar";
            // 
            // añadirFila
            // 
            this.añadirFila.Location = new System.Drawing.Point(168, 309);
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
            this.añadirFilaSeguido.Location = new System.Drawing.Point(168, 376);
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
            this.comprobarVacio.Location = new System.Drawing.Point(30, 243);
            this.comprobarVacio.Name = "comprobarVacio";
            this.comprobarVacio.Size = new System.Drawing.Size(245, 13);
            this.comprobarVacio.TabIndex = 3;
            this.comprobarVacio.Text = "Aquí se puede comprobar si DataGridView es nulo";
            // 
            // añadirColumna
            // 
            this.añadirColumna.Location = new System.Drawing.Point(17, 309);
            this.añadirColumna.Name = "añadirColumna";
            this.añadirColumna.Size = new System.Drawing.Size(115, 36);
            this.añadirColumna.TabIndex = 4;
            this.añadirColumna.Text = "Añadir nueva columna";
            this.añadirColumna.UseVisualStyleBackColor = true;
            this.añadirColumna.Click += new System.EventHandler(this.añadirColumna_Click);
            // 
            // cuentaFilasColumnas
            // 
            this.cuentaFilasColumnas.Location = new System.Drawing.Point(17, 376);
            this.cuentaFilasColumnas.Name = "cuentaFilasColumnas";
            this.cuentaFilasColumnas.Size = new System.Drawing.Size(115, 55);
            this.cuentaFilasColumnas.TabIndex = 5;
            this.cuentaFilasColumnas.Text = "Contar filas y columnas del DataGridView\r\n";
            this.cuentaFilasColumnas.UseVisualStyleBackColor = true;
            this.cuentaFilasColumnas.Click += new System.EventHandler(this.cuentaFilasColumnas_Click);
            // 
            // menuAñadir
            // 
            this.menuAñadir.Location = new System.Drawing.Point(645, 309);
            this.menuAñadir.Name = "menuAñadir";
            this.menuAñadir.Size = new System.Drawing.Size(111, 23);
            this.menuAñadir.TabIndex = 6;
            this.menuAñadir.Text = "Añadir producto";
            this.menuAñadir.UseVisualStyleBackColor = true;
            this.menuAñadir.Click += new System.EventHandler(this.menuAñadir_Click);
            // 
            // menuEliminar
            // 
            this.menuEliminar.Location = new System.Drawing.Point(645, 347);
            this.menuEliminar.Name = "menuEliminar";
            this.menuEliminar.Size = new System.Drawing.Size(111, 23);
            this.menuEliminar.TabIndex = 7;
            this.menuEliminar.Text = "Borrar producto";
            this.menuEliminar.UseVisualStyleBackColor = true;
            this.menuEliminar.Click += new System.EventHandler(this.menuEliminar_Click);
            // 
            // menuModificar
            // 
            this.menuModificar.Location = new System.Drawing.Point(645, 385);
            this.menuModificar.Name = "menuModificar";
            this.menuModificar.Size = new System.Drawing.Size(111, 23);
            this.menuModificar.TabIndex = 8;
            this.menuModificar.Text = "Modificar producto";
            this.menuModificar.UseVisualStyleBackColor = true;
            this.menuModificar.Click += new System.EventHandler(this.menuModificar_Click);
            // 
            // tablaProductos
            // 
            this.tablaProductos.AllowUserToAddRows = false;
            this.tablaProductos.AllowUserToDeleteRows = false;
            this.tablaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre,
            this.codigo,
            this.cantidad,
            this.precio,
            this.tipo,
            this.descripcion});
            this.tablaProductos.Location = new System.Drawing.Point(385, 12);
            this.tablaProductos.Name = "tablaProductos";
            this.tablaProductos.ReadOnly = true;
            this.tablaProductos.Size = new System.Drawing.Size(371, 272);
            this.tablaProductos.TabIndex = 9;
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 69;
            // 
            // codigo
            // 
            this.codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codigo.HeaderText = "Código";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Width = 65;
            // 
            // cantidad
            // 
            this.cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Width = 74;
            // 
            // precio
            // 
            this.precio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.precio.HeaderText = "Precio (unidad)";
            this.precio.MinimumWidth = 101;
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            this.precio.Width = 101;
            // 
            // tipo
            // 
            this.tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Width = 53;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 88;
            // 
            // textoPrueba
            // 
            this.textoPrueba.AutoSize = true;
            this.textoPrueba.Location = new System.Drawing.Point(456, 314);
            this.textoPrueba.Name = "textoPrueba";
            this.textoPrueba.Size = new System.Drawing.Size(183, 13);
            this.textoPrueba.TabIndex = 10;
            this.textoPrueba.Text = "Prueba DataGridView Borrar despues";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(408, 407);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textoPrueba);
            this.Controls.Add(this.tablaProductos);
            this.Controls.Add(this.menuModificar);
            this.Controls.Add(this.menuEliminar);
            this.Controls.Add(this.menuAñadir);
            this.Controls.Add(this.cuentaFilasColumnas);
            this.Controls.Add(this.añadirColumna);
            this.Controls.Add(this.comprobarVacio);
            this.Controls.Add(this.añadirFilaSeguido);
            this.Controls.Add(this.añadirFila);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaProductos)).EndInit();
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
        private System.Windows.Forms.DataGridViewButtonColumn ColumnaBorrar;
        private System.Windows.Forms.Button menuAñadir;
        private System.Windows.Forms.Button menuEliminar;
        private System.Windows.Forms.Button menuModificar;
        private System.Windows.Forms.DataGridView tablaProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn prueba;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.Label textoPrueba;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;

        //private System.Windows.Forms.DataGridViewButtonColumn;
    }
}

