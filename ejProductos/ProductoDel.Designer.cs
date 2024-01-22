namespace ejProductos
{
    partial class ProductoDel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductoDel));
            this.delInfo = new System.Windows.Forms.Label();
            this.delTablaProductos = new System.Windows.Forms.DataGridView();
            this.botonBorrar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.foto = new System.Windows.Forms.DataGridViewImageColumn();
            this.ruta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delBotonSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.delTablaProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // delInfo
            // 
            this.delInfo.AutoSize = true;
            this.delInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.delInfo.Location = new System.Drawing.Point(12, 4);
            this.delInfo.Name = "delInfo";
            this.delInfo.Size = new System.Drawing.Size(530, 18);
            this.delInfo.TabIndex = 1;
            this.delInfo.Text = "Para eliminar un producto haz click en el botón Borrar de la fila correspondiente" +
    "";
            // 
            // delTablaProductos
            // 
            this.delTablaProductos.AllowUserToAddRows = false;
            this.delTablaProductos.AllowUserToDeleteRows = false;
            this.delTablaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.delTablaProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.botonBorrar,
            this.nombre,
            this.codigo,
            this.cantidad,
            this.precio,
            this.tipo,
            this.descripcion,
            this.foto,
            this.ruta});
            this.delTablaProductos.Location = new System.Drawing.Point(12, 30);
            this.delTablaProductos.Name = "delTablaProductos";
            this.delTablaProductos.ReadOnly = true;
            this.delTablaProductos.RowHeadersWidth = 4;
            this.delTablaProductos.Size = new System.Drawing.Size(695, 408);
            this.delTablaProductos.TabIndex = 10;
            this.delTablaProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.delTablaProductos_CellClick);
            // 
            // botonBorrar
            // 
            this.botonBorrar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.botonBorrar.HeaderText = "";
            this.botonBorrar.Name = "botonBorrar";
            this.botonBorrar.ReadOnly = true;
            this.botonBorrar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.botonBorrar.Width = 5;
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
            // foto
            // 
            this.foto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.foto.HeaderText = "Foto";
            this.foto.Image = ((System.Drawing.Image)(resources.GetObject("foto.Image")));
            this.foto.Name = "foto";
            this.foto.ReadOnly = true;
            // 
            // ruta
            // 
            this.ruta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ruta.HeaderText = "Ruta";
            this.ruta.Name = "ruta";
            this.ruta.ReadOnly = true;
            this.ruta.Width = 55;
            // 
            // delBotonSalir
            // 
            this.delBotonSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.delBotonSalir.Location = new System.Drawing.Point(713, 415);
            this.delBotonSalir.Name = "delBotonSalir";
            this.delBotonSalir.Size = new System.Drawing.Size(75, 23);
            this.delBotonSalir.TabIndex = 12;
            this.delBotonSalir.Text = "Salir";
            this.delBotonSalir.UseVisualStyleBackColor = true;
            this.delBotonSalir.Click += new System.EventHandler(this.delBotonSalir_Click);
            // 
            // ProductoDel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.delBotonSalir);
            this.Controls.Add(this.delTablaProductos);
            this.Controls.Add(this.delInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductoDel";
            this.Text = "ProductoEliminar";
            this.Load += new System.EventHandler(this.ProductoDel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.delTablaProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label delInfo;
        private System.Windows.Forms.DataGridView delTablaProductos;
        private System.Windows.Forms.Button delBotonSalir;
        private System.Windows.Forms.DataGridViewButtonColumn botonBorrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewImageColumn foto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ruta;
    }
}