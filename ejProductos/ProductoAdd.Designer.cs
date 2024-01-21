namespace ejProductos
{
    partial class ProductoAdd
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
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem("Ropa");
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem("Alimentación");
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem("Mueble");
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem("Libro");
            this.addInfo = new System.Windows.Forms.Label();
            this.addBotonAñadir = new System.Windows.Forms.Button();
            this.addBotonCancelar = new System.Windows.Forms.Button();
            this.addLabelNombre = new System.Windows.Forms.Label();
            this.addLabelCodigo = new System.Windows.Forms.Label();
            this.addLabelCantidad = new System.Windows.Forms.Label();
            this.addLabelPrecio = new System.Windows.Forms.Label();
            this.addLabelDescripcion = new System.Windows.Forms.Label();
            this.addLabelTipo = new System.Windows.Forms.Label();
            this.addNombre = new System.Windows.Forms.TextBox();
            this.addCodigo = new System.Windows.Forms.TextBox();
            this.addPrecio = new System.Windows.Forms.TextBox();
            this.addDescripcion = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.addTipo = new System.Windows.Forms.ComboBox();
            this.addCantidad = new System.Windows.Forms.TextBox();
            this.previewFoto = new System.Windows.Forms.PictureBox();
            this.addBotonFoto = new System.Windows.Forms.Button();
            this.addLabelFoto = new System.Windows.Forms.Label();
            this.addFoto = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.previewFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // addInfo
            // 
            this.addInfo.AutoSize = true;
            this.addInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.addInfo.Location = new System.Drawing.Point(22, 9);
            this.addInfo.Name = "addInfo";
            this.addInfo.Size = new System.Drawing.Size(580, 18);
            this.addInfo.TabIndex = 0;
            this.addInfo.Text = "Para añadir un nuevo producto, rellena todos los campos y haz click en el botón A" +
    "ñadir";
            // 
            // addBotonAñadir
            // 
            this.addBotonAñadir.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addBotonAñadir.Enabled = false;
            this.addBotonAñadir.Location = new System.Drawing.Point(437, 277);
            this.addBotonAñadir.Name = "addBotonAñadir";
            this.addBotonAñadir.Size = new System.Drawing.Size(75, 23);
            this.addBotonAñadir.TabIndex = 7;
            this.addBotonAñadir.Text = "Añadir";
            this.addBotonAñadir.UseVisualStyleBackColor = true;
            this.addBotonAñadir.Click += new System.EventHandler(this.addBotonAñadir_Click);
            // 
            // addBotonCancelar
            // 
            this.addBotonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.addBotonCancelar.Location = new System.Drawing.Point(527, 277);
            this.addBotonCancelar.Name = "addBotonCancelar";
            this.addBotonCancelar.Size = new System.Drawing.Size(75, 23);
            this.addBotonCancelar.TabIndex = 8;
            this.addBotonCancelar.Text = "Cancelar";
            this.addBotonCancelar.UseVisualStyleBackColor = true;
            // 
            // addLabelNombre
            // 
            this.addLabelNombre.AutoSize = true;
            this.addLabelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.addLabelNombre.Location = new System.Drawing.Point(22, 61);
            this.addLabelNombre.Name = "addLabelNombre";
            this.addLabelNombre.Size = new System.Drawing.Size(58, 17);
            this.addLabelNombre.TabIndex = 3;
            this.addLabelNombre.Text = "Nombre";
            // 
            // addLabelCodigo
            // 
            this.addLabelCodigo.AutoSize = true;
            this.addLabelCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.addLabelCodigo.Location = new System.Drawing.Point(22, 98);
            this.addLabelCodigo.Name = "addLabelCodigo";
            this.addLabelCodigo.Size = new System.Drawing.Size(52, 17);
            this.addLabelCodigo.TabIndex = 4;
            this.addLabelCodigo.Text = "Código";
            // 
            // addLabelCantidad
            // 
            this.addLabelCantidad.AutoSize = true;
            this.addLabelCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.addLabelCantidad.Location = new System.Drawing.Point(22, 135);
            this.addLabelCantidad.Name = "addLabelCantidad";
            this.addLabelCantidad.Size = new System.Drawing.Size(64, 17);
            this.addLabelCantidad.TabIndex = 5;
            this.addLabelCantidad.Text = "Cantidad";
            // 
            // addLabelPrecio
            // 
            this.addLabelPrecio.AutoSize = true;
            this.addLabelPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.addLabelPrecio.Location = new System.Drawing.Point(22, 172);
            this.addLabelPrecio.Name = "addLabelPrecio";
            this.addLabelPrecio.Size = new System.Drawing.Size(105, 17);
            this.addLabelPrecio.TabIndex = 6;
            this.addLabelPrecio.Text = "Precio (unidad)";
            // 
            // addLabelDescripcion
            // 
            this.addLabelDescripcion.AutoSize = true;
            this.addLabelDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.addLabelDescripcion.Location = new System.Drawing.Point(22, 260);
            this.addLabelDescripcion.Name = "addLabelDescripcion";
            this.addLabelDescripcion.Size = new System.Drawing.Size(82, 17);
            this.addLabelDescripcion.TabIndex = 7;
            this.addLabelDescripcion.Text = "Descripción";
            // 
            // addLabelTipo
            // 
            this.addLabelTipo.AutoSize = true;
            this.addLabelTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.addLabelTipo.Location = new System.Drawing.Point(22, 209);
            this.addLabelTipo.Name = "addLabelTipo";
            this.addLabelTipo.Size = new System.Drawing.Size(36, 17);
            this.addLabelTipo.TabIndex = 8;
            this.addLabelTipo.Text = "Tipo";
            // 
            // addNombre
            // 
            this.addNombre.Location = new System.Drawing.Point(86, 61);
            this.addNombre.Name = "addNombre";
            this.addNombre.Size = new System.Drawing.Size(195, 20);
            this.addNombre.TabIndex = 1;
            this.addNombre.TextChanged += new System.EventHandler(this.addComprobarCampos_TextChanged);
            // 
            // addCodigo
            // 
            this.addCodigo.Location = new System.Drawing.Point(80, 98);
            this.addCodigo.Name = "addCodigo";
            this.addCodigo.Size = new System.Drawing.Size(134, 20);
            this.addCodigo.TabIndex = 2;
            this.addCodigo.TextChanged += new System.EventHandler(this.addComprobarCampos_TextChanged);
            // 
            // addPrecio
            // 
            this.addPrecio.Location = new System.Drawing.Point(133, 172);
            this.addPrecio.Name = "addPrecio";
            this.addPrecio.Size = new System.Drawing.Size(100, 20);
            this.addPrecio.TabIndex = 4;
            this.addPrecio.TextChanged += new System.EventHandler(this.addComprobarCampos_TextChanged);
            // 
            // addDescripcion
            // 
            this.addDescripcion.Location = new System.Drawing.Point(110, 246);
            this.addDescripcion.Multiline = true;
            this.addDescripcion.Name = "addDescripcion";
            this.addDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.addDescripcion.Size = new System.Drawing.Size(309, 54);
            this.addDescripcion.TabIndex = 6;
            this.addDescripcion.TextChanged += new System.EventHandler(this.addComprobarCampos_TextChanged);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Items.AddRange(new object[] {
            "Ropa",
            "Alimentación",
            "Mueble",
            "Libro"});
            this.listBox1.Location = new System.Drawing.Point(210, 211);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 19);
            this.listBox1.TabIndex = 15;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            listViewItem13.Tag = "Ropa";
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16});
            this.listView1.Location = new System.Drawing.Point(239, 92);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(91, 100);
            this.listView1.TabIndex = 17;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // addTipo
            // 
            this.addTipo.FormattingEnabled = true;
            this.addTipo.Items.AddRange(new object[] {
            "Ropa",
            "Alimentación",
            "Mueble",
            "Electrodoméstico"});
            this.addTipo.Location = new System.Drawing.Point(64, 209);
            this.addTipo.Name = "addTipo";
            this.addTipo.Size = new System.Drawing.Size(121, 21);
            this.addTipo.TabIndex = 5;
            this.addTipo.TextChanged += new System.EventHandler(this.addComprobarCampos_TextChanged);
            // 
            // addCantidad
            // 
            this.addCantidad.Location = new System.Drawing.Point(92, 135);
            this.addCantidad.Name = "addCantidad";
            this.addCantidad.Size = new System.Drawing.Size(120, 20);
            this.addCantidad.TabIndex = 3;
            this.addCantidad.TextChanged += new System.EventHandler(this.addComprobarCampos_TextChanged);
            // 
            // previewFoto
            // 
            this.previewFoto.BackColor = System.Drawing.SystemColors.HighlightText;
            this.previewFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewFoto.Location = new System.Drawing.Point(437, 109);
            this.previewFoto.Name = "previewFoto";
            this.previewFoto.Size = new System.Drawing.Size(164, 137);
            this.previewFoto.TabIndex = 18;
            this.previewFoto.TabStop = false;
            this.previewFoto.UseWaitCursor = true;
            // 
            // addBotonFoto
            // 
            this.addBotonFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.addBotonFoto.Location = new System.Drawing.Point(476, 58);
            this.addBotonFoto.Name = "addBotonFoto";
            this.addBotonFoto.Size = new System.Drawing.Size(125, 23);
            this.addBotonFoto.TabIndex = 19;
            this.addBotonFoto.Text = "Seleccionar foto";
            this.addBotonFoto.UseVisualStyleBackColor = true;
            this.addBotonFoto.Click += new System.EventHandler(this.addBotonFoto_Click);
            // 
            // addLabelFoto
            // 
            this.addLabelFoto.AutoSize = true;
            this.addLabelFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.addLabelFoto.Location = new System.Drawing.Point(434, 61);
            this.addLabelFoto.Name = "addLabelFoto";
            this.addLabelFoto.Size = new System.Drawing.Size(36, 17);
            this.addLabelFoto.TabIndex = 20;
            this.addLabelFoto.Text = "Foto";
            // 
            // addFoto
            // 
            this.addFoto.BackColor = System.Drawing.SystemColors.Window;
            this.addFoto.Location = new System.Drawing.Point(437, 85);
            this.addFoto.Name = "addFoto";
            this.addFoto.ReadOnly = true;
            this.addFoto.Size = new System.Drawing.Size(164, 20);
            this.addFoto.TabIndex = 21;
            this.addFoto.TextChanged += new System.EventHandler(this.addComprobarCampos_TextChanged);
            // 
            // ProductoAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 319);
            this.Controls.Add(this.addFoto);
            this.Controls.Add(this.addLabelFoto);
            this.Controls.Add(this.addBotonFoto);
            this.Controls.Add(this.previewFoto);
            this.Controls.Add(this.addCantidad);
            this.Controls.Add(this.addTipo);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.addDescripcion);
            this.Controls.Add(this.addPrecio);
            this.Controls.Add(this.addCodigo);
            this.Controls.Add(this.addNombre);
            this.Controls.Add(this.addLabelTipo);
            this.Controls.Add(this.addLabelDescripcion);
            this.Controls.Add(this.addLabelPrecio);
            this.Controls.Add(this.addLabelCantidad);
            this.Controls.Add(this.addLabelCodigo);
            this.Controls.Add(this.addLabelNombre);
            this.Controls.Add(this.addBotonCancelar);
            this.Controls.Add(this.addBotonAñadir);
            this.Controls.Add(this.addInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductoAdd";
            this.Text = "ProductoAñadir";
            ((System.ComponentModel.ISupportInitialize)(this.previewFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label addInfo;
        private System.Windows.Forms.Button addBotonAñadir;
        private System.Windows.Forms.Button addBotonCancelar;
        private System.Windows.Forms.Label addLabelNombre;
        private System.Windows.Forms.Label addLabelCodigo;
        private System.Windows.Forms.Label addLabelCantidad;
        private System.Windows.Forms.Label addLabelPrecio;
        private System.Windows.Forms.Label addLabelDescripcion;
        private System.Windows.Forms.Label addLabelTipo;
        private System.Windows.Forms.TextBox addNombre;
        private System.Windows.Forms.TextBox addCodigo;
        private System.Windows.Forms.TextBox addPrecio;
        private System.Windows.Forms.TextBox addDescripcion;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ComboBox addTipo;
        private System.Windows.Forms.TextBox addCantidad;
        private System.Windows.Forms.PictureBox previewFoto;
        private System.Windows.Forms.Button addBotonFoto;
        private System.Windows.Forms.Label addLabelFoto;
        private System.Windows.Forms.TextBox addFoto;
    }
}