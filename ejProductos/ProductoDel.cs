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
        private int anchoMax = 0;
        public DataGridView DelDGV {  get; set; }
        public ProductoDel(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        private void ProductoDel_Load(object sender, EventArgs e)
        {
            DataGridView dgv = ((Form1)padre).Productos;
            DataGridView guardaDGV = ((Form1)padre).ProductosNuevo; 
            if (guardaDGV != dgv) //Optimización: para que no se actualice la lista cada vez que abramos el form (si esta no ha cambiado desde la ultima vez)
            {   //Por alguna razón no funciona la optimización
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    delTablaProductos.RowTemplate.Height = dgv.Rows[i].Height;
                    delTablaProductos.Rows.Add("Borrar");
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (j == 6)
                        {
                            delTablaProductos.Rows[i].Cells[j + 1].Value = dgv.Rows[i].Cells[j].Value;
                        }
                        else
                        {
                            delTablaProductos.Rows[i].Cells[j + 1].Value = dgv.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    if (Image.FromFile(dgv.Rows[i].Cells["ruta"].Value.ToString()).Width > delTablaProductos.Columns["foto"].MinimumWidth)
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
            if (DelDGV != delTablaProductos)
            {
                DelDGV = delTablaProductos;
            }
        }

        private void delTablaProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == delTablaProductos.Columns[0].Index) //Como el nombre de la columna está vacío da error si se pone "", hay que poner el indice de la columna
            {
                delTablaProductos.Rows.RemoveAt(e.RowIndex);
                delTablaProductos.Columns["foto"].MinimumWidth = 2; //Si le pongo de anchoMínimo < 2 salta una excepción
                for (int i = 0; i < delTablaProductos.Rows.Count; i++) 
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
