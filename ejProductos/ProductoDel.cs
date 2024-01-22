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
    public partial class ProductoDel : Form
    {
        Form padre;
        public DataGridView DelDGV {  get; set; }
        public ProductoDel(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        private void ProductoDel_Load(object sender, EventArgs e)
        {
            if (((Form1)padre).delAccedido == true) //Esto se utiliza para saber si este formulario ya ha sido accedido y no volver a mostrar la información blank screen
            {
                delInfo.Visible = false;
            }
            DataGridView dgv = ((Form1)padre).Productos;
            DataGridView guardaDGV = ((Form1)padre).ProductosNuevo; 
            if (guardaDGV != dgv) //Optimización: para que no se actualice la lista cada vez que abramos el form (si esta no ha cambiado desde la ultima vez)
            {   //Por alguna razón no funciona la optimización
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    delTablaProductos.RowTemplate.Height = dgv.Rows[i].Height; //Coge la misma amplitud de la fila que en el listado de productos
                    delTablaProductos.Rows.Add("Borrar"); //Añade nueva fila con botón de borrado en la primera columna
                    for (int j = 0; j < dgv.Columns.Count; j++) //Se modifican los valores en blanco de la fila recién añadida
                    {
                        if (j == 6) //Para la columna Foto
                        {
                            delTablaProductos.Rows[i].Cells[j + 1].Value = dgv.Rows[i].Cells[j].Value;
                        }
                        else
                        {
                            delTablaProductos.Rows[i].Cells[j + 1].Value = dgv.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    if (Image.FromFile(dgv.Rows[i].Cells["ruta"].Value.ToString()).Width > delTablaProductos.Columns["foto"].MinimumWidth) //La fila con la foto más ancha definirá la anchura de la columna Foto
                    {
                        delTablaProductos.Columns["foto"].MinimumWidth = Image.FromFile(dgv.Rows[i].Cells["ruta"].Value.ToString()).Width;
                    }
                }
                ((Form1)padre).ProductosNuevo = delTablaProductos;
            }
            DelDGV = delTablaProductos;
        }

        private void delBotonSalir_Click(object sender, EventArgs e)
        {
            if (((Form1)padre).delAccedido == false) //Si el formulario no había sido accedido antes, ahora queda constancia de que sí (para que no vuelva a aparecer la info de la blank screen)
            {
                ((Form1)padre).delAccedido = true;
            }
            if (DelDGV != delTablaProductos)
            {
                DelDGV = delTablaProductos;
            }
        }

        private void delTablaProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Cuando se pulsa el botón de borrar fila
            if (e.ColumnIndex == delTablaProductos.Columns[0].Index) //Como el nombre de la columna está vacío da error si se pone "", hay que poner el indice de la columna
            {
                delTablaProductos.Rows.RemoveAt(e.RowIndex);
                delTablaProductos.Columns["foto"].MinimumWidth = 2; //Se establece el valor mínimo para la columna Foto. Esto es para reevaluar la amplitud de la columna //Si le pongo de anchoMínimo < 2 salta una excepción
                for (int i = 0; i < delTablaProductos.Rows.Count; i++) //Se reevalúa cuál de las filas restantes tiene la foto más ancha para definir la amplitud de la columna Foto
                {
                    if (Image.FromFile(delTablaProductos.Rows[i].Cells["ruta"].Value.ToString()).Width > delTablaProductos.Columns["foto"].MinimumWidth)
                    {
                        delTablaProductos.Columns["foto"].MinimumWidth = Image.FromFile(delTablaProductos.Rows[i].Cells["ruta"].Value.ToString()).Width;
                    }
                }
                if (delBotonSalir.DialogResult == DialogResult.Cancel) //Optimización: con esto nos aseguramos de que solo tengamos que volver a crear un DataGridView en Form1 tras pulsar el botón Salir cuando se haya borrado al menos 1 fila 
                {
                    delBotonSalir.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
