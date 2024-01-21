using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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
        private int anchoMax = 0;
        //private int altoMax = 0;
        //string idColumna = "col" + numColumna, encabezado = "Columna " + numEncabezado; //no deja hacerlo así
        DataGridViewTextBoxColumn prueba2 = new DataGridViewTextBoxColumn();
        /*prueba2.Name = "Prueba2";
        prueba2.Value = "prueba2";*/
        //private String[] CeldasFila = new string[6]; //Para la forma alternativa de menuborrar
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
            ProductoAdd padd = new ProductoAdd(this);
            if (padd.ShowDialog() == DialogResult.OK)
            {
                //if (padd.Foto.Height > altoMax)
                //{
                tablaProductos.RowTemplate.Height = padd.Foto.Height;
                //altoMax = tablaProductos.RowTemplate.Height;
                //}
                if (padd.Foto.Width > anchoMax)
                {
                    tablaProductos.Columns["foto"].MinimumWidth = padd.Foto.Width;
                    anchoMax = tablaProductos.Columns["foto"].MinimumWidth;
                }
                //tablaProductos.Columns["foto"].Width = padd.Foto.Width; //Este atributo no importa, ya que no puede ser menor a minWidth, y en caso de ser "mayor", minWidth = Width
                tablaProductos.Rows.Add(padd.Nombre, padd.Codigo, padd.Cantidad, padd.Precio, padd.Tipo, padd.Descripcion, padd.Foto, padd.Ruta);
                Productos = tablaProductos; //Tras poner esto, he comentado al usarlo en menuEliminar_Click y menuModificar_Click (tal vez arregle el error de Borrar) //No lo arregla :^|
                textoPrueba.Text = tablaProductos.Rows[0].Cells[0].Value.ToString();
            }
            if (tablaProductos.RowCount > 0)
            {
                botonExportar.Enabled = true;
            }
            else
            {
                botonExportar.Enabled = false;
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
                    //textoPrueba.Text = i.ToString();
                }
                /*if (tablaProductos.Rows.Count < 1)
                {
                    tablaProductos.Rows.RemoveAt(0);
                }*/
                for (int i = 0; i < deldgv.Rows.Count /*3*/; i++)
                {
                    tablaProductos.RowTemplate.Height = deldgv.Rows[i].Height;
                    tablaProductos.Rows.Add(""); //MUY IMPORTANTE!!!!!!!!!!!: AL AÑADIR FILAS SE INSERTAN ALGUNAS EN BLANCO AL FINAL 
                    for (int j = 0; j < deldgv.Columns.Count - 1; j++)
                    {
                        if (j == 6)
                        {
                            tablaProductos.Rows[i].Cells[j].Value = deldgv.Rows[i].Cells[j + 1].Value;
                        }
                        else
                        {
                            //IMPORTANTE: ERROR DE LECTURA. Tanto de la forma 1 como la 2, al leer el valor de una celda de delDGV no existe (delDGV = null)
                            //ARREGLADOOOOO: EL PROBLEMA ERA QUE EL VALOR MÁXIMO DE CeldasFila[5], E INICIALMENTE "J" ITERABA HASTA EL NUMERO 6, APUNTANDO A UNA FILA NO EXISTENTE. POR ESA RAZÓN A J SE LE RESTA 1
                            tablaProductos.Rows[i].Cells[j].Value = deldgv.Rows[i].Cells[j + 1].Value.ToString();
                            //CeldasFila[j]/*textoPrueba.Text*/ = deldgv.Rows[/*0*/i].Cells[j+1/*6*//*7*/].Value.ToString(); //Forma alternativa
                        }
                    }
                    //tablaProductos.Rows.Add(CeldasFila[0], CeldasFila[1], CeldasFila[2], CeldasFila[3], CeldasFila[4], CeldasFila[5]); //Forma alternativa
                }
                tablaProductos.Columns["foto"].MinimumWidth = deldgv.Columns["foto"].MinimumWidth; //ARREGLADO Se explica el mismo problema en la línea 60 de ProductoDel.cs
                //textoPrueba.Text = deldgv.Rows.Count.ToString();
                //textoPrueba.Text = deldgv./*Rows*/Columns.Count.ToString();
                //textoPrueba.Text = deldgv.Rows[0/*1*/].Cells[1].Value.ToString(); //IMPORTANTE: AL PARECER EL ERROR SE DA PORQUE LEE MÁS FILAS DE LAS QUE HAY (ArrayOutOfBoundsException)
            }
            //tablaProductos = pdel.guardaDGV;
            if (tablaProductos.RowCount > 0)
            {
                botonExportar.Enabled = true;
            }
            else
            {
                botonExportar.Enabled = false;
            }
        }

        private void menuModificar_Click(object sender, EventArgs e)
        {
            ProductoMod pmod = new ProductoMod(this);
            if(pmod.ShowDialog() == DialogResult.OK)
            {
                DataGridView moddgv = pmod.ModDGV;
                //textoPrueba.Text = tablaProductos.Rows.Count.ToString();
                for (int i = 0; tablaProductos.Rows.Count > 0; i++) 
                {
                    tablaProductos.Rows.RemoveAt(0); 
                }
                for (int i = 0; i < moddgv.Rows.Count; i++)
                {
                    tablaProductos.Rows.Add("");
                    tablaProductos.Rows[i].Height = moddgv.Rows[i].Height;
                    for (int j = 0; j < moddgv.Columns.Count; j++)
                    {
                        if (j == 6)
                        {
                            tablaProductos.Rows[i].Cells[j].Value = moddgv.Rows[i].Cells[j].Value;
                        }
                        else
                        {
                            tablaProductos.Rows[i].Cells[j].Value = moddgv.Rows[i].Cells[j].Value.ToString();
                            //CeldasFila[j]/*textoPrueba.Text*/ = moddgv.Rows[i].Cells[j].Value.ToString(); //Forma alternativa
                        }
                    }
                    //tablaProductos.Rows.Add(CeldasFila[0], CeldasFila[1], CeldasFila[2], CeldasFila[3], CeldasFila[4], CeldasFila[5]); //Forma alternativa
                }
                tablaProductos.Columns["foto"].MinimumWidth = moddgv.Columns["foto"].MinimumWidth;
                textoPrueba.Text = "Tabla actualizada";
            }
        }

        private void botonSecreto_Click(object sender, EventArgs e)
        {
            tablaProductos.Columns["codigo"].Visible = false;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.Cancel)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.ShowDialog();
            }
        }

        //Para la importación y exportación de archivos .csv haremos uso de la librería csvhelper
        //MUY IMPORTANTE: Si abrimos un archivo exportado con Excel y lo guardamos (ej. modificándolo), este no se podrá importar después. Esto se debe al problema del caracter delimitador, el cual varía según el país o la región del sistema que se haya seleccionado (se explica más adelante)
        private void botonImportar_Click(object sender, EventArgs e)
        {
            if (tablaProductos.RowCount > 0) //Esto nunca se va a ejecutar porque cuando la tabla esté vacía el botón estará desactivado
            {
                MessageBox.Show("Si importas un archivo, la tabla actual se borrará", "Atención: La tabla no está vacía");
            }
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "*.csv|*.csv" };
            ofd.InitialDirectory = @"Escritorio";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String fpath = ofd.FileName;
                StreamReader sr = new StreamReader(fpath, Encoding.UTF8);
                CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";" };
                CsvReader csvr = new CsvReader(sr, config);
                var tabla = csvr.GetRecords<Fila>();
                int numFilas = 0;
                for (int i = 0; tablaProductos.Rows.Count > 0; i++)
                {
                    tablaProductos.Rows.RemoveAt(0);
                }
                try
                {
                    foreach (var fila in tabla)
                    {
                        tablaProductos.Rows.Add("");
                        tablaProductos.Rows[numFilas].Cells[0].Value = fila.nombre;
                        tablaProductos.Rows[numFilas].Cells[1].Value = fila.codigo;
                        tablaProductos.Rows[numFilas].Cells[2].Value = fila.cantidad;
                        tablaProductos.Rows[numFilas].Cells[3].Value = fila.precio;
                        tablaProductos.Rows[numFilas].Cells[4].Value = fila.tipo;
                        tablaProductos.Rows[numFilas].Cells[5].Value = fila.descripcion;
                        tablaProductos.Rows[numFilas].Cells[6].Value = Image.FromFile(fila.ruta);
                        tablaProductos.Rows[numFilas].Cells[7].Value = fila.ruta;
                        tablaProductos.Rows[numFilas].Height = Image.FromFile(fila.ruta).Height;
                        if (Image.FromFile(fila.ruta).Width > tablaProductos.Columns["foto"].MinimumWidth)
                        {
                            tablaProductos.Columns["foto"].MinimumWidth = Image.FromFile(fila.ruta).Width;
                        }
                        numFilas++;
                    } 
                } catch (CsvHelper.HeaderValidationException csvex)
                {
                    MessageBox.Show("El formato del archivo importado es incorrecto o las celdas no coinciden", "Error de importación");
                }
                Productos = tablaProductos;
                if (tablaProductos.RowCount > 0)
                {
                    botonExportar.Enabled = true;
                }
                else
                {
                    botonExportar.Enabled = false;
                }
            }
        }

        private void botonExportar_Click(object sender, EventArgs e)
        {
            if (tablaProductos.RowCount > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog() { Filter = "*.csv|*.csv" }; //Filtrar los archivos para que solo se puedan seleccionar archivos csv
                sfd.InitialDirectory = @"Escritorio"; //Para que esto funcione hay que hacer un poco de lío (https://stackoverflow.com/a/18586187)
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    String fpath = sfd.FileName;
                    StreamWriter sw = new StreamWriter(fpath, false, Encoding.UTF8); //Modificamos el codificador aquí, ya que en el CsvConfiguration no hace nada 
                    CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";"/*, Encoding = Encoding.UTF8*/ }; //csv separa por defecto las columnas con comas, pero en la versión Europea de Windows se separan las columnas con ; así que tenemos que cambiar el separador de listas manualmente.
                    CsvWriter csvw = new CsvWriter(sw, config/*CultureInfo.InvariantCulture*/);
                    List<Fila> tablaExp = new List<Fila>();
                    //csvw.Configuration.Delimiter = ";"; //Forma antigua de establecer el separador de listas (ya no funciona)
                    for (int i = 0; i < tablaProductos.Rows.Count; i++)
                    {
                        tablaExp.Add(new Fila()
                        {
                            nombre = tablaProductos.Rows[i].Cells[0].Value.ToString(),
                            codigo = tablaProductos.Rows[i].Cells[1].Value.ToString(),
                            cantidad = Convert.ToInt32(tablaProductos.Rows[i].Cells[2].Value.ToString()),
                            precio = tablaProductos.Rows[i].Cells[3].Value.ToString(),
                            tipo = tablaProductos.Rows[i].Cells[4].Value.ToString(),
                            descripcion = tablaProductos.Rows[i].Cells[5].Value.ToString(),
                            //foto = Image.FromFile(tablaProductos.Rows[i].Cells[7].Value.ToString()), //Es mejor no guardar la foto (ver l.343)
                            ruta = tablaProductos.Rows[i].Cells[7].Value.ToString()
                            /*val1 = 2,
                            val2 = "Ola"*/
                        });
                    }
                    csvw.WriteRecords(tablaExp);
                    csvw.Dispose();
                    sw.Dispose();
                }
            }
            else
            {
                MessageBox.Show("", "Atención: La tabla está vacía");
            }
        }

        private void menuFiltrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < menuFiltrar.Items.Count; i++)
            {
                if (menuFiltrar.GetItemCheckState(i) == CheckState.Checked)
                {
                    tablaProductos.Columns[i].Visible = true;
                }
                else
                {
                    tablaProductos.Columns[i].Visible = false;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e) //Esto sólo se utiliza para marcar las casillas automáticamente al iniciar el programa
        {
            for (int i = 0; i < menuFiltrar.Items.Count - 1; i++) //La ruta no se muestra por defecto, de ahí el -1
            {
                menuFiltrar.SetItemCheckState(i, CheckState.Checked);
                tablaProductos.Columns[i].Visible = true;
            }
        }
    }

    class Fila
    {
        [Name("Nombre")]
        public String nombre { get; set; }
        [Name("Código")]
        public String codigo { get; set; }
        [Name("Cantidad")]
        public int cantidad {  get; set; }
        [Name("Precio (unidad)")]
        public String precio { get; set; }
        [Name("Tipo")]
        public String tipo { get; set; }
        [Name("Descripción")]
        public String descripcion { get; set; }
        //[Name("Foto")]
        //public Image foto { get; set; } //Al guardar una foto se guardan varios campos que darán error durante la importación, ya que no se corresponden con el nombre "Foto". Crearemos la imagen a partir de la ruta
        [Name("Ruta de la imagen")]
        public String ruta { get; set; }
        /*public int val1 {  get; set; }
        public String val2 { get; set; }*/
    }
}

//Fuentes:
//https://www.youtube.com/watch?v=6gfPeexF3vM
//https://www.youtube.com/watch?v=z3BwMlcGdhg
//https://www.youtube.com/watch?v=5U2qf52PTTY
//https://www.youtube.com/watch?v=ZwY3DkelSE0
//https://www.youtube.com/watch?v=UAFXi9sXzyM
//https://www.youtube.com/watch?v=aIsMwEAiOKs
//https://www.c-sharpcorner.com/UploadFile/mahesh/openfiledialog-in-C-Sharp/#:~:text=Setting%20OpenFileDialog%20Properties
//https://stackoverflow.com/a/11567074
//https://stackoverflow.com/a/11203062
//https://kb.paessler.com/en/topic/2293-i-have-trouble-opening-csv-files-with-microsoft-excel-is-there-a-quick-way-to-fix-this#reply-5193
//https://github.com/JoshClose/CsvHelper/issues/1653#issuecomment-763608811
//https://stackoverflow.com/a/66532784
//https://stackoverflow.com/a/18586187
//https://stackoverflow.com/a/24074609
