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
    public partial class Form1 : Form
    {
        //int numColumna = 0, numEncabezado = 0;
        private int indiceFila = 0;
        private int indiceColumna = 0;
        //string idColumna = "col" + numColumna, encabezado = "Columna " + numEncabezado; //no deja hacerlo así
        DataGridViewTextBoxColumn prueba2 = new DataGridViewTextBoxColumn();
        /*prueba2.Name = "Prueba2";
        prueba2.Value = "prueba2";*/
        private String[] CeldasFila = new string[6]; //Para la forma alternativa de menuborrar
        public DataGridView Productos { get; set; }
        public DataGridView ProductosNuevo { get; set; } //Por cuestiones de optimización //No sirve para nada jaja
        public String Nombre { get; set; }
        public String Codigo { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public String Tipo { get; set; }
        public String Descripcion { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void añadirFila_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns["ColumnaBorrar"].HeaderText = "culo";
            /*numColumna++;
            numEncabezado++;*/
            //indiceColumna++;
            //string[] columnaNueva = new string[2];
            string[] filaNueva = new string[/*2*/1]; //TODO esto no es óptimo porque creamos un nuevo array cada vez que ejecutamos el método. crear el array aparte
            /*columnaNueva[0] = "Columna1";
            columnaNueva[1] = "Columna2";*/
            filaNueva[0] = $"Fila {/*dataGridView1.Rows.Count*/indiceFila + 1}";
            //filaNueva[1] = numUDpeso.Value.ToString();
            //dataGridView1.Columns.Add($"col{indiceColumna}", $"Columna {indiceColumna}"); //dataGridView1.Columns.Add(columnaNueva[0], columnaNueva[1]);
            dataGridView1.Rows.Add(filaNueva);
            /*if (dataGridView1.Rows.Count == 2){ //PARA QUE NO APAREZCA LA ÚLTIMA FILA VACÍA AL FINAL: cambiar propiedad dataGridView1.AllowUserToAddRows a False
                dataGridView1.Rows.Count = 1;
            }*/
            //dataGridView1.Rows.Add("Ey", "Qué tal", "Bien", "Y tú" , "?"); //En cada fila añade un elemento nuevo a una nueva columna
            if (indiceFila == 1) {
                dataGridView1.Rows[0].Cells[0].Value = "PocaJontas";
            }
            indiceFila++;
        }

        private void añadirColumna_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add($"col{indiceColumna}", $"Columna {indiceColumna}"); //dataGridView1.Columns.Add(nombreColumna/*columnaNueva[0]*/, textoColumna/*columnaNueva[1]*/);
            indiceColumna++;
            if (añadirFila.Visible == false)
            {
                añadirFila.Visible = true;
            }
            if (dataGridView1.Columns.Count >= 5)
            {
                añadirFilaSeguido.Visible = true;
            }
        }

        private void añadirFilaSeguido_Click(object sender, EventArgs e)
        {
            indiceFila++;
            dataGridView1.Rows.Add("Ey", "Qué tal", "Bien", "Y tú" , "?"); //En cada fila añade un elemento nuevo a una nueva columna
        }

        private void cuentaFilasColumnas_Click(object sender, EventArgs e)
        {
            int numeroFilas = dataGridView1.Rows.Count;
            int numeroColumnas = dataGridView1.Columns.Count;
            comprobarVacio.Text = $"Número de filas en el DataGridView: {numeroFilas} \nNúmero de columnas en el DataGridView: {numeroColumnas}";
            //comprobarVacio.Text += /*(dataGridView1.Rows.Count)*/numeroFilas.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuAñadir_Click(object sender, EventArgs e)
        {
            ProductoAdd padd = new ProductoAdd();
            if (padd.ShowDialog() == DialogResult.OK)
            {
                tablaProductos.Rows.Add(padd.Nombre, padd.Codigo, padd.Cantidad, padd.Precio, padd.Tipo, padd.Descripcion);
                Productos = tablaProductos; //Tras poner esto, he comentado al usarlo en menuEliminar_Click y menuModificar_Click (tal vez arregle el error de Borrar) //No lo arregla :^|
                textoPrueba.Text = tablaProductos.Rows[0].Cells[0].Value.ToString();
            }
        }

        private void menuEliminar_Click(object sender, EventArgs e) //PREGUNTAR A MIGUEL
        {
            ProductoDel pdel = new ProductoDel(this);
            //DataGridView deldgv = pdel.DelDGV;
            //Productos = tablaProductos; //Esto estaba antes de hacerlo en menuAñadir_Click
            if (pdel.ShowDialog() == DialogResult.OK)
            {
                //tablaProductos = pdel.DelDGV;
                DataGridView deldgv = pdel.DelDGV;
                textoPrueba.Text = tablaProductos.Rows.Count.ToString();
                for (int i = 0; /*i <*/ tablaProductos.Rows.Count > 0/*RowCount*//*+1*//*+2*//**2*//*+(tablaProductos.Rows.Count/2)*/; i++) //IMPORTANTE: NECESITAMOS BORRAR TODAS LAS FILAS DEL DATAGRIDVIEW, PORQUE LO QUE SE HACE DESPUÉS ES MODIFICAR LAS X PRIMERAS FILAS CON LAS X FILAS RESTANTES DE DELDGV, Y ENCIMA SE AÑADEN TANTAS COLUMNAS VACÍAS (Línea 118) COMO X FILAS QUEDEN EN DELDGV
                { 
                    //YA ESTA ARREGLADOOOOOOOOOOOOOOOOOOO //HABÍA QUE PONER for (i++; tablaProductos.Rows.Count > 0; i++) ----------------
                    tablaProductos.Rows.RemoveAt(/*i*/0/*(tablaProductos.Rows.Count-1)-i*/); //MUY MUY IMPORTANTE: EL ORIGEN DEL ERROR ESTÁ AQUI. SIEMPRE BORRA LA MITAD DE LAS FILAS DEL DATAGRIDVIEW (si hay 2 borra 1, si hay 4 borra 2, ...)
                    /*if (i == tablaProductos.Rows.Count - 1)
                    {
                        tablaProductos.Rows.RemoveAt(0);
                    }*/
                }
                /*if (tablaProductos.Rows.Count < 1)
                {
                    tablaProductos.Rows.RemoveAt(0);
                }*/
                for (int i = 0; i < deldgv.Rows.Count /*3*/; i++)
                {
                    //tablaProductos.Rows.Add(""); //MUY IMPORTANTE!!!!!!!!!!!: AL AÑADIR FILAS SE INSERTAN ALGUNAS EN BLANCO AL FINAL 
                    for (int j = 0; j < deldgv.Columns.Count - 1; j++)
                    {
                        //IMPORTANTE: ERROR DE LECTURA. Tanto de la forma 1 como la 2, al leer el valor de una celda de delDGV no existe (delDGV = null)
                        //ARREGLADOOOOO: EL PROBLEMA ERA QUE EL VALOR MÁXIMO DE CeldasFila[5], E INICIALMENTE "J" ITERABA HASTA EL NUMERO 6, APUNTANDO A UNA FILA NO EXISTENTE. POR ESA RAZÓN A J SE LE RESTA 1
                        //tablaProductos.Rows[i].Cells[j].Value = deldgv.Rows[i].Cells[j+1].Value.ToString();
                        CeldasFila[j]/*textoPrueba.Text*/ = deldgv.Rows[/*0*/i].Cells[j+1/*6*//*7*/].Value.ToString(); //Forma alternativa
                    }
                    tablaProductos.Rows.Add(CeldasFila[0], CeldasFila[1], CeldasFila[2], CeldasFila[3], CeldasFila[4], CeldasFila[5]); //Forma alternativa
                }
                //textoPrueba.Text = deldgv.Rows.Count.ToString();
                //textoPrueba.Text = deldgv./*Rows*/Columns.Count.ToString();
                //textoPrueba.Text = deldgv.Rows[0/*1*/].Cells[1].Value.ToString(); //IMPORTANTE: AL PARECER EL ERROR SE DA PORQUE LEE MÁS FILAS DE LAS QUE HAY (ArrayOutOfBoundsException)
            }
            //tablaProductos = pdel.guardaDGV;
        }

        private void menuModificar_Click(object sender, EventArgs e)
        {
            ProductoMod pmod = new ProductoMod(this);
            //Productos = tablaProductos; //Esto estaba antes de hacerlo en menuAñadir_Click
            if(pmod.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("Hey");
            }
        }
    }
}
