﻿using System;
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
        //public DataGridView guardaDGV {  get; set; }
        //private String[] CeldasFila = new String[6]; //En caso de usar la forma 2
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
            /*DataGridView*/ //dataGridView1 = ((Form1)padre).Productos;
            //dataGridView1.Rows.Add(dgv.Nombre, dgv.Codigo, dgv.Cantidad, dgv.Precio, dgv.Tipo, dgv.Descripcion);
            //label1.Text = /*dataGridView2*/dgv.Rows[0].Cells[0].Value.ToString()/*+", "+dgv.Rows.Count+", "+dgv.Columns.Count*/;
            label1.Text = "La lista no se ha actualizado";
            if (/*dataGridView1*/guardaDGV != dgv) //Optimización: para que no se actualice la lista cada vez que abramos el form (si esta no ha cambiado desde la ultima vez)
            {   //Por alguna razón no funciona la optimización
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    label1.Text = "Se ha actualizado la lista";
                    //Forma1
                    delTablaProductos.Rows.Add("Borrar");
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        //Forma1
                        delTablaProductos.Rows[i].Cells[j+1].Value = dgv.Rows[i].Cells[j].Value.ToString(); //IMPORTANTE: PARA HACER ESTO EL DATAGRIDVIEW NO DEBE ESTAR ASOCIADO A NINGUN DATASOURCE
                        //Forma2
                        //CeldasFila[j] = dgv.Rows[i].Cells[j].Value.ToString();
                    }
                    //Forma2
                    //dataGridView1.Rows.Add(CeldasFila[0], CeldasFila[1], CeldasFila[2], CeldasFila[3], CeldasFila[4], CeldasFila[5]); //IMPORTANTE: LO MISMO QUE ARRIBA
                }
                ((Form1)padre).ProductosNuevo = delTablaProductos;
                //dataGridView1
            }
            DelDGV = delTablaProductos;
        }

        private void delTablaProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == delTablaProductos.Columns[0/*""*/].Index) //Da error si se pone "", hay que poner el indice de la columna
            {
                //label1.Text = "Momaaaa";
                //for (int i = 0; i < dataGridView; i++)
                delTablaProductos.Rows.RemoveAt(e.RowIndex);
                label1.Text = e.RowIndex.ToString();
                DelDGV = delTablaProductos;
                if (delBotonSalir.DialogResult == DialogResult.Cancel) //Optimización: con esto nos aseguramos de que solo tengamos que volver a crear un DataGridView en Form1 tras pulsar el botón Salir cuando se haya borrado al menos 1 fila (sin embargo, si se pulsa la cruz para cerrar la ventana, SIEMPRE se creará un nuevo DataGridView, pues siempre devuelve Cancel)
                {
                    delBotonSalir.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
