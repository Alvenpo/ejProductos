using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejProductos
{
    public partial class ProductoMod : Form
    {
        Form padre;
        //public DataGridView guardaDGV {  get; set; }
        //private String[] CeldasFila = new String[6]; //En caso de usar la forma 2
        public DataGridView ModDGV { get; set; }
        public Boolean botonModPulsado { get; set; }
        public ProductoMod(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        //public String[] Columnas = new string[7];
        /*private enum Columnas
        {
            botonModificar = 0,
            Nombre = 1,
            Codigo = 2,
            Cantidad = 3,
            Precio = 4,
            Tipo = 5,
            Descripcion = 6
        }*/

        private void ProductoMod_Load(object sender, EventArgs e)
        {
            //Columnas = ["AQUI NO DEJA TAMPOCOOOOOOOOOOOOOOOOOOOOOOOOOO"];//Esto no me dejaba ponerlo como propiedad (l26) porque no le daba la gana asi que lo hago aquí
            DataGridView dgv = ((Form1)padre).Productos;
            DataGridView guardaDGV = ((Form1)padre).ProductosNuevo;
            /*DataGridView*/ //modTablaProductos = ((Form1)padre).Productos;
                             //modTablaProductos.Rows.Add(dgv.Nombre, dgv.Codigo, dgv.Cantidad, dgv.Precio, dgv.Tipo, dgv.Descripcion);
                             //label1.Text = /*dataGridView2*/dgv.Rows[0].Cells[0].Value.ToString()/*+", "+dgv.Rows.Count+", "+dgv.Columns.Count*/;
            label1.Text = "La lista no se ha actualizado";
            if (/*modTablaProductos*/guardaDGV != dgv) //Optimización: para que no se actualice la lista cada vez que abramos el form (si esta no ha cambiado desde la ultima vez)
            {   //Por alguna razón no funciona la optimización
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    label1.Text = "Se ha actualizado la lista";
                    //Forma1
                    modTablaProductos.Rows.Add(""/*"Modificar"*/);
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        //Forma1
                        modTablaProductos.Rows[i].Cells[j/* + 1*/].Value = dgv.Rows[i].Cells[j].Value.ToString(); //IMPORTANTE: PARA HACER ESTO EL DATAGRIDVIEW NO DEBE ESTAR ASOCIADO A NINGUN DATASOURCE
                        //Forma2
                        //CeldasFila[j] = dgv.Rows[i].Cells[j].Value.ToString();
                    }
                    //Forma2
                    //modTablaProductos.Rows.Add(CeldasFila[0], CeldasFila[1], CeldasFila[2], CeldasFila[3], CeldasFila[4], CeldasFila[5]); //IMPORTANTE: LO MISMO QUE ARRIBA
                }
                ((Form1)padre).ProductosNuevo = modTablaProductos;
                //modTablaProductos
            }
            ModDGV = modTablaProductos;
        }

        //private void modTablaProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
            //if (e.ColumnIndex == modTablaProductos.Columns[0/*""*/].Index) //Da error si se pone "", hay que poner el indice de la columna
            //{
                //label1.Text = "Momaaaa";
                //for (int i = 0; i < dataGridView; i++)
                //delTablaProductos.Rows.RemoveAt(e.RowIndex);
                /*foreach(x in Columnas)
                {
                    modTablaProductos.Columns[$"{x}"].ReadOnly = true;
                }*/
                /*foreach(DataGridViewColumn x in modTablaProductos.Columns)
                {
                    modTablaProductos.Columns[$"{x}"].ReadOnly = true;
                }*/
                //Bueno como no se puede iterar pues voy a dejar esto así de chulo
                //modTablaProductos.Columns["nombre"/*$"{Columnas.Nombre}"*//*"nombre"*//*"Nombre"*/].ReadOnly = true;
                /*modTablaProductos.Columns["codigo"].ReadOnly = true;
                modTablaProductos.Columns["cantidad"].ReadOnly = true;
                modTablaProductos.Columns["precio"].ReadOnly = true;
                modTablaProductos.Columns["tipo"].ReadOnly = true;
                modTablaProductos.Columns["descripcion"].ReadOnly = true;
                label1.Text = e.RowIndex.ToString();*/
                //DelDGV = delTablaProductos;
                /*if (delBotonSalir.DialogResult == DialogResult.Cancel) //Optimización: con esto nos aseguramos de que solo tengamos que volver a crear un DataGridView en Form1 tras pulsar el botón Salir cuando se haya borrado al menos 1 fila (sin embargo, si se pulsa la cruz para cerrar la ventana, SIEMPRE se creará un nuevo DataGridView, pues siempre devuelve Cancel)
                {
                    delBotonSalir.DialogResult = DialogResult.OK;
                }*/
            //}
        //}

        private void modBotonModificar_Click(object sender, EventArgs e)
        {
            //label1.Text = "Momaaaa";
            //for (int i = 0; i < dataGridView; i++)
            //delTablaProductos.Rows.RemoveAt(e.RowIndex);
            /*foreach(x in Columnas)
            {
                modTablaProductos.Columns[$"{x}"].ReadOnly = true;
            }*/
            /*foreach(DataGridViewColumn x in modTablaProductos.Columns)
            {
                modTablaProductos.Columns[$"{x}"].ReadOnly = true;
            }*/
            //Bueno como no se puede iterar pues voy a dejar esto así de chulo
            if (botonModPulsado)
            {
                modTablaProductos.Columns["nombre"/*$"{Columnas.Nombre}"*//*"nombre"*//*"Nombre"*/].ReadOnly = true;
                modTablaProductos.Columns["codigo"].ReadOnly = true;
                modTablaProductos.Columns["cantidad"].ReadOnly = true;
                modTablaProductos.Columns["precio"].ReadOnly = true;
                modTablaProductos.Columns["tipo"].ReadOnly = true;
                modTablaProductos.Columns["descripcion"].ReadOnly = true;
                botonModPulsado = false;
            }
            else
            {
                modTablaProductos.Columns["nombre"].ReadOnly = false;
                modTablaProductos.Columns["codigo"].ReadOnly = false;
                modTablaProductos.Columns["cantidad"].ReadOnly = false;
                modTablaProductos.Columns["precio"].ReadOnly = false;
                modTablaProductos.Columns["tipo"].ReadOnly = false;
                modTablaProductos.Columns["descripcion"].ReadOnly = false;
                botonModPulsado = true;
            }
            //DelDGV = delTablaProductos;
            if (modBotonSalir.DialogResult == DialogResult.Cancel) //Es el peor sitio donde colocarlo, pero es la única forma de hacerlo funcionar (abajo se explican las razones)
            {
                modBotonSalir.DialogResult = DialogResult.OK;
            }
        }

        private void modBotonSalir_Click(object sender, EventArgs e)
        {
            if (ModDGV != modTablaProductos)  //Optimización: con esto nos aseguramos de que solo tengamos que volver a crear un DataGridView en Form1 tras pulsar el botón Salir cuando se haya modificado al menos 1 celda
            {
                /*if (modBotonSalir.DialogResult == DialogResult.Cancel) //No se usa aquí porque la propiedad se cambia después de pulsar el botón, con lo que el valor siempre sería Cancel
                {
                    modBotonSalir.DialogResult = DialogResult.OK;
                }*/
                ModDGV = modTablaProductos;
                //Si la tabla ha sido modificada, guardar nueva tabla
            }
        }

       /* private void modTablaProductos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (modBotonSalir.DialogResult == DialogResult.Cancel) //Esto sería ideal, pero no se usa porque siempre se activa, ya que al escribir los datos de TablaProductos en modTablaProductos se activa el evento
            {
                modBotonSalir.DialogResult = DialogResult.OK;
            }
        }*/
    }
}
