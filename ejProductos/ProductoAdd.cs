using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejProductos
{
   
    public partial class ProductoAdd : Form
    {
        public String Nombre { get; set; }
        public String Codigo { get; set; }
        public int Cantidad { get; set; }
        public String Precio { get; set; }
        public String Tipo { get; set; }
        public String Descripcion { get; set; }
        public Image Foto { get; set; }
        public String Ruta { get; set; }
        private bool pkRepetida = false;
        Form padre;
        public ProductoAdd(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        private void addBotonAñadir_Click(object sender, EventArgs e)
        {
            Nombre = addNombre.Text;
            Codigo = addCodigo.Text;
            Cantidad = Convert.ToInt32(addCantidad.Text);
            Precio = float.Parse(addPrecio.Text, CultureInfo.InvariantCulture.NumberFormat) + "€"; //Comprobar que es un número y después añadir el € 
            Tipo = addTipo.Text;
            Descripcion = addDescripcion.Text;
            Foto = Image.FromFile(addFoto.Text);
            Ruta = addFoto.Text;
        }

        private void addBotonFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Archivos .png (*.png)|*.png|Archivos .jpg (*.jpg)|*.jpg|Archivos .gif (*.gif)|*.gif" };
            ofd.InitialDirectory = @"Imágenes";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                addFoto.Text = ofd.FileName;
                previewFoto.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void addComprobarCampos_TextChanged(object sender, EventArgs e)
        {
            if (((Form1)padre).Productos != null) 
            {
                pkRepetida = false;
                for (int i = 0; i < ((Form1)padre).Productos.RowCount; i++)
                {
                    if (addCodigo.Text == ((Form1)padre).Productos.Rows[i].Cells["codigo"].Value.ToString())
                    {
                        pkRepetida = true;
                        MessageBox.Show("El valor introducido para el código del producto ya está asociado a otro producto", "Atención: Código repetido");
                    }
                }
            }
            if ((addNombre.Text != "") && (addCodigo.Text != "") && (pkRepetida == false) && (addCantidad.Text != "") && (addPrecio.Text != "") && (addTipo.Items.Contains(addTipo.Text)) && (addDescripcion.Text != "") && (addFoto.Text != "")) //Si reemplazamos "" por null no funciona bien
            {
                try //Comprobar que los campos Cantidad y Precio sólo tienen valores numéricos
                {
                    Convert.ToInt32(addCantidad.Text);
                    Convert.ToDouble(addPrecio.Text);
                    addBotonAñadir.Enabled = true;
                } 
                catch (FormatException fe)
                {
                    MessageBox.Show("Los campos Cantidad y Precio sólo pueden contener valores numéricos", "Atención: Formato incorrecto");
                }
            }
            else
            {
                addBotonAñadir.Enabled = false;
            }
        }
    }
}
