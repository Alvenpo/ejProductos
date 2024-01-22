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

        private void addBotonAñadir_Click(object sender, EventArgs e) //Al pulsar el botón añadir se añaden todos los campos al listado de productos
        {
            Nombre = addNombre.Text;
            Codigo = addCodigo.Text;
            Cantidad = Convert.ToInt32(addCantidad.Text);
            Precio = float.Parse(addPrecio.Text, CultureInfo.InvariantCulture.NumberFormat) + "€"; //Comprobar que es un número y después añadir el € 
            Tipo = addTipo.Text;
            Descripcion = addDescripcion.Text;
            Foto = Image.FromFile(addFoto.Text);
            Ruta = addFoto.Text;
            if (((Form1)padre).addAccedido == false) //Si el formulario no había sido accedido antes, ahora queda constancia de que sí (para que no vuelva a aparecer la info de la blank screen)
            {
                ((Form1)padre).addAccedido = true;
            }
        }

        private void addBotonFoto_Click(object sender, EventArgs e) //Botón para seleccionar una foto
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Archivos .png (*.png)|*.png|Archivos .jpg (*.jpg)|*.jpg|Archivos .gif (*.gif)|*.gif" }; //Ventana de selección de imagen. Adicionalmente se filtran archivos que se pueden seleccionar
            ofd.InitialDirectory = @"Imágenes"; //Esto es para que cada vez que pulsemos el botón, nos situemos directamente en la carpeta de Imágenes, pero parece ser que no funciona bien
            if (ofd.ShowDialog() == DialogResult.OK) //Si seleccionamos una foto añadimos la foto y su ruta
            {
                addFoto.Text = ofd.FileName;
                previewFoto.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void addComprobarCampos_TextChanged(object sender, EventArgs e) //Comprobar que los campos tienen valores adecuados
        {
            if (((Form1)padre).Productos != null) //Si no hay ningún producto en el listado no es necesario comparar el código, ya que no coincidirá 
            {
                pkRepetida = false;
                for (int i = 0; i < ((Form1)padre).Productos.RowCount; i++)
                {
                    if (addCodigo.Text == ((Form1)padre).Productos.Rows[i].Cells["codigo"].Value.ToString()) //Si el código seleccionado ya está asociado a un producto del listado
                    {
                        pkRepetida = true;
                        MessageBox.Show("El valor introducido para el código del producto ya está asociado a otro producto", "Atención: Código repetido");
                    }
                }
            }
            //Si ningún campo es nulo, el tipo seleccionado existe y el código no está repetido, se comprueba que los campos Cantidad y Precio tienen valores numéricos
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
            else //Si hay al menos 1 valor incorrecto, no se podrá añadir el producto
            {
                addBotonAñadir.Enabled = false;
            }
        }

        private void ProductoAdd_Load(object sender, EventArgs e) //Esto sólo se utiliza para saber si este formulario ya ha sido accedido y no volver a mostrar la información blank screen
        {
            if (((Form1) padre).addAccedido == true)
            {
                addInfo.Visible = false;
            }
        }
    }
}
