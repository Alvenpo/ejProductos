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
            //IMPORTANTE: Precio no muestra bien los decimales (no pone coma)
            Precio = /*((float) Convert.ToDouble(addPrecio.Text)).ToString()*/float.Parse(addPrecio.Text, CultureInfo.InvariantCulture.NumberFormat) + "€"; //Comprobar que es un número y después añadir el € //La forma comentada no funcionaba: era como un Convert.ToInt()
            Tipo = addTipo.Text;
            Descripcion = addDescripcion.Text;
            Foto = Image.FromFile(addFoto.Text);
            Ruta = addFoto.Text;
            /*String[] Tipos = new String[addTipo.Items.Count]; //IMPORTANTE: Descomentar más tarde. Se puede usar para comprobar si el tipo es válido
            int i = 0;
            foreach(String x in addTipo.Items)
            {
                Tipos[i] = x;
                i++;
            }*/
        }

        private void addBotonFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Archivos .png (*.png)|*.png|Archivos .jpg (*.jpg)|*.jpg|Archivos .gif (*.gif)|*.gif"/*"|Todos los archivos (*.*)|*.*"*/ };
            ofd.InitialDirectory = @"Imágenes"; //La arroba es opcional
            //ofd.RestoreDirectory = true; //No es necesario ya que cada vez que pulsamos el botón se crea un nuevo OpenFileDialog
            //ofd.Title = "Selecciona una imagen";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                addFoto.Text = ofd.FileName;
                previewFoto.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void addComprobarCampos_TextChanged(object sender, EventArgs e)
        {
            //addComprobarCampos.Text = $"{addNombre.Text}, {addCodigo.Text}, {addCantidad.Text}, {addPrecio.Text}, {addTipo.Text}, {addDescripcion.Text}, {addFoto.Text}";
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
