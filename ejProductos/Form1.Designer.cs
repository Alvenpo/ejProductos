
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.foto = new System.Windows.Forms.DataGridViewImageColumn();
            this.ruta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.botonImportar = new System.Windows.Forms.Button();
            this.botonExportar = new System.Windows.Forms.Button();
            this.menuFiltrar = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.tablaProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // menuAñadir
            // 
            this.menuAñadir.Location = new System.Drawing.Point(12, 12);
            this.menuAñadir.Name = "menuAñadir";
            this.menuAñadir.Size = new System.Drawing.Size(111, 23);
            this.menuAñadir.TabIndex = 6;
            this.menuAñadir.Text = "Añadir producto";
            this.menuAñadir.UseVisualStyleBackColor = true;
            this.menuAñadir.Click += new System.EventHandler(this.menuAñadir_Click);
            // 
            // menuEliminar
            // 
            this.menuEliminar.Location = new System.Drawing.Point(12, 50);
            this.menuEliminar.Name = "menuEliminar";
            this.menuEliminar.Size = new System.Drawing.Size(111, 23);
            this.menuEliminar.TabIndex = 7;
            this.menuEliminar.Text = "Borrar producto";
            this.menuEliminar.UseVisualStyleBackColor = true;
            this.menuEliminar.Click += new System.EventHandler(this.menuEliminar_Click);
            // 
            // menuModificar
            // 
            this.menuModificar.Location = new System.Drawing.Point(12, 88);
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
            this.descripcion,
            this.foto,
            this.ruta});
            this.tablaProductos.Location = new System.Drawing.Point(145, 12);
            this.tablaProductos.Name = "tablaProductos";
            this.tablaProductos.ReadOnly = true;
            this.tablaProductos.RowHeadersWidth = 4;
            this.tablaProductos.Size = new System.Drawing.Size(643, 426);
            this.tablaProductos.TabIndex = 9;
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Visible = false;
            // 
            // codigo
            // 
            this.codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codigo.HeaderText = "Código";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Visible = false;
            // 
            // cantidad
            // 
            this.cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Visible = false;
            // 
            // precio
            // 
            this.precio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.precio.HeaderText = "Precio (unidad)";
            this.precio.MinimumWidth = 101;
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            this.precio.Visible = false;
            // 
            // tipo
            // 
            this.tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Visible = false;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Visible = false;
            // 
            // foto
            // 
            this.foto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.foto.HeaderText = "Foto";
            this.foto.Image = ((System.Drawing.Image)(resources.GetObject("foto.Image")));
            this.foto.Name = "foto";
            this.foto.ReadOnly = true;
            this.foto.Visible = false;
            // 
            // ruta
            // 
            this.ruta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ruta.HeaderText = "Ruta";
            this.ruta.Name = "ruta";
            this.ruta.ReadOnly = true;
            this.ruta.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // botonImportar
            // 
            this.botonImportar.Location = new System.Drawing.Point(12, 126);
            this.botonImportar.Name = "botonImportar";
            this.botonImportar.Size = new System.Drawing.Size(75, 23);
            this.botonImportar.TabIndex = 12;
            this.botonImportar.Text = "Importar";
            this.botonImportar.UseVisualStyleBackColor = true;
            this.botonImportar.Click += new System.EventHandler(this.botonImportar_Click);
            // 
            // botonExportar
            // 
            this.botonExportar.Enabled = false;
            this.botonExportar.Location = new System.Drawing.Point(12, 164);
            this.botonExportar.Name = "botonExportar";
            this.botonExportar.Size = new System.Drawing.Size(75, 23);
            this.botonExportar.TabIndex = 13;
            this.botonExportar.Text = "Exportar";
            this.botonExportar.UseVisualStyleBackColor = true;
            this.botonExportar.Click += new System.EventHandler(this.botonExportar_Click);
            // 
            // menuFiltrar
            // 
            this.menuFiltrar.BackColor = System.Drawing.SystemColors.Control;
            this.menuFiltrar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.menuFiltrar.CheckOnClick = true;
            this.menuFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.menuFiltrar.FormattingEnabled = true;
            this.menuFiltrar.Items.AddRange(new object[] {
            "Nombre",
            "Código",
            "Cantidad",
            "Precio",
            "Tipo",
            "Descripción",
            "Foto",
            "Ruta"});
            this.menuFiltrar.Location = new System.Drawing.Point(12, 206);
            this.menuFiltrar.Name = "menuFiltrar";
            this.menuFiltrar.Size = new System.Drawing.Size(101, 144);
            this.menuFiltrar.TabIndex = 14;
            this.menuFiltrar.SelectedIndexChanged += new System.EventHandler(this.menuFiltrar_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuFiltrar);
            this.Controls.Add(this.botonExportar);
            this.Controls.Add(this.botonImportar);
            this.Controls.Add(this.tablaProductos);
            this.Controls.Add(this.menuModificar);
            this.Controls.Add(this.menuEliminar);
            this.Controls.Add(this.menuAñadir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button menuAñadir;
        private System.Windows.Forms.Button menuEliminar;
        private System.Windows.Forms.Button menuModificar;
        private System.Windows.Forms.DataGridView tablaProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn prueba;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button botonImportar;
        private System.Windows.Forms.Button botonExportar;
        private System.Windows.Forms.CheckedListBox menuFiltrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewImageColumn foto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ruta;

        //private System.Windows.Forms.DataGridViewButtonColumn;
    }
}

