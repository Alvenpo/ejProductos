namespace ejProductos
{
    partial class ProductoMod
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
            this.modBotonSalir = new System.Windows.Forms.Button();
            this.modTablaProductos = new System.Windows.Forms.DataGridView();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.foto = new System.Windows.Forms.DataGridViewImageColumn();
            this.ruta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modInfo = new System.Windows.Forms.Label();
            this.modBotonModificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.modTablaProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // modBotonSalir
            // 
            this.modBotonSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.modBotonSalir.Location = new System.Drawing.Point(713, 415);
            this.modBotonSalir.Name = "modBotonSalir";
            this.modBotonSalir.Size = new System.Drawing.Size(75, 23);
            this.modBotonSalir.TabIndex = 16;
            this.modBotonSalir.Text = "Salir";
            this.modBotonSalir.UseVisualStyleBackColor = true;
            this.modBotonSalir.Click += new System.EventHandler(this.modBotonSalir_Click);
            // 
            // modTablaProductos
            // 
            this.modTablaProductos.AllowUserToAddRows = false;
            this.modTablaProductos.AllowUserToDeleteRows = false;
            this.modTablaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.modTablaProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre,
            this.codigo,
            this.cantidad,
            this.precio,
            this.tipo,
            this.descripcion,
            this.foto,
            this.ruta});
            this.modTablaProductos.Location = new System.Drawing.Point(12, 30);
            this.modTablaProductos.Name = "modTablaProductos";
            this.modTablaProductos.RowHeadersWidth = 4;
            this.modTablaProductos.Size = new System.Drawing.Size(695, 408);
            this.modTablaProductos.TabIndex = 15;
            this.modTablaProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.modTablaProductos_CellContentClick);
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
            this.tipo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            // modInfo
            // 
            this.modInfo.AutoSize = true;
            this.modInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.modInfo.Location = new System.Drawing.Point(12, 4);
            this.modInfo.Name = "modInfo";
            this.modInfo.Size = new System.Drawing.Size(559, 18);
            this.modInfo.TabIndex = 13;
            this.modInfo.Text = "Para modificar un producto haz click en el botón Modificar de la fila correspondi" +
    "ente";
            // 
            // modBotonModificar
            // 
            this.modBotonModificar.Location = new System.Drawing.Point(713, 386);
            this.modBotonModificar.Name = "modBotonModificar";
            this.modBotonModificar.Size = new System.Drawing.Size(75, 23);
            this.modBotonModificar.TabIndex = 17;
            this.modBotonModificar.Text = "Modificar";
            this.modBotonModificar.UseVisualStyleBackColor = true;
            this.modBotonModificar.Click += new System.EventHandler(this.modBotonModificar_Click);
            // 
            // ProductoMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.modBotonModificar);
            this.Controls.Add(this.modBotonSalir);
            this.Controls.Add(this.modTablaProductos);
            this.Controls.Add(this.modInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductoMod";
            this.Text = "ProductoMod";
            this.Load += new System.EventHandler(this.ProductoMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.modTablaProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button modBotonSalir;
        private System.Windows.Forms.DataGridView modTablaProductos;
        private System.Windows.Forms.Label modInfo;
        private System.Windows.Forms.Button modBotonModificar;
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