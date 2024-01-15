using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public ProductoAdd()
        {
            InitializeComponent();
        }

        private void addBotonAñadir_Click(object sender, EventArgs e)
        {
            Nombre = addNombre.Text;
            Codigo = addCodigo.Text;
            Cantidad = Convert.ToInt32(addCantidad.Text);
            //IMPORTANTE: Precio no muestra bien los decimales (no pone coma)
            Precio = ((float) Convert.ToDouble(addPrecio.Text)).ToString() + "€"; //Comprobar que es un número y después añadir el €
            Tipo = addTipo.Text;
            Descripcion = addDescripcion.Text;
            /*String[] Tipos = new String[addTipo.Items.Count]; //IMPORTANTE: Descomentar más tarde. Se puede usar para comprobar si el tipo es válido
            int i = 0;
            foreach(String x in addTipo.Items)
            {
                Tipos[i] = x;
                i++;
            }*/
        }
    }
}
