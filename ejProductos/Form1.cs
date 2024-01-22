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
        private int anchoMax = 0;
        public DataGridView Productos { get; set; }
        public DataGridView ProductosNuevo { get; set; } //Por cuestiones de optimización //No funciona
        public Boolean addAccedido {  get; set; }
        public Boolean delAccedido { get; set; }
        public Boolean modAccedido { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void menuAñadir_Click(object sender, EventArgs e) //Abrir form Añadir productos
        {
            ProductoAdd padd = new ProductoAdd(this);
            if (padd.ShowDialog() == DialogResult.OK) //Si pulsamos el botón Añadir dentro del form ProductoAdd
            {
                tablaProductos.RowTemplate.Height = padd.Foto.Height; //La amplitud de la fila se adapta a la altura de la foto
                if (padd.Foto.Width > anchoMax) //La fila con la foto más ancha definirá la anchura de la columna Foto
                {
                    tablaProductos.Columns["foto"].MinimumWidth = padd.Foto.Width;
                    anchoMax = tablaProductos.Columns["foto"].MinimumWidth;
                }
                tablaProductos.Rows.Add(padd.Nombre, padd.Codigo, padd.Cantidad, padd.Precio, padd.Tipo, padd.Descripcion, padd.Foto, padd.Ruta); //Se añaden los campos rellenados de ProductosAdd al listado de productos
                Productos = tablaProductos; //Guardamos toda la información de la tabla en una variable que nos permite traspasar dicha información a la tabla de ProductoDel y ProductoMod
            }
            if (tablaProductos.RowCount > 0) //Si hay al menos 1 fila el botón de exportar es funcional y la información de la blank screen desaparece (si no había desaparecido ya)
            {
                botonExportar.Enabled = true;
                if (mainInfo.Visible == true)
                {
                    mainInfo.Visible = false;
                }
            }
            else //Si siguen habiendo 0 filas (no se ha añadido nada) el botón de exportar no se puede utilizar
            {
                botonExportar.Enabled = false;
            }
        }

        private void menuEliminar_Click(object sender, EventArgs e) //Abrir form Borrar productos
        {
            ProductoDel pdel = new ProductoDel(this);
            if (pdel.ShowDialog() == DialogResult.OK) //Si se ha borrado al menos algún producto (actualizar listado)
            {
                DataGridView deldgv = pdel.DelDGV;
                for (int i = 0; tablaProductos.Rows.Count > 0; i++) //IMPORTANTE: NECESITAMOS BORRAR TODAS LAS FILAS DEL DATAGRIDVIEW, PORQUE LO QUE SE HACE DESPUÉS ES MODIFICAR LAS X PRIMERAS FILAS CON LAS X FILAS RESTANTES DE DELDGV, Y ENCIMA SE AÑADEN TANTAS COLUMNAS VACÍAS (Línea 118) COMO X FILAS QUEDEN EN DELDGV
                { 
                    tablaProductos.Rows.RemoveAt(0); //Borrar todas las tablas del listado
                }
                for (int i = 0; i < deldgv.Rows.Count; i++) //Insertar tablas de ProductosDel que no hayan sido borradas
                {
                    tablaProductos.RowTemplate.Height = deldgv.Rows[i].Height; //Coge la misma amplitud de la fila que en la tabla de ProductoDel
                    tablaProductos.Rows.Add("");
                    for (int j = 0; j < deldgv.Columns.Count - 1; j++)
                    {
                        if (j == 6) //Esto es sólo para la columna Foto
                        {
                            tablaProductos.Rows[i].Cells[j].Value = deldgv.Rows[i].Cells[j + 1].Value; 
                        }
                        else
                        {
                            tablaProductos.Rows[i].Cells[j].Value = deldgv.Rows[i].Cells[j + 1].Value.ToString(); //En el caso de la columna siempre le sumamos 1 en la tabla de ProductoDel, para no añadir el botón de Borrar al listado de productos
                        }
                    }
                }
                tablaProductos.Columns["foto"].MinimumWidth = deldgv.Columns["foto"].MinimumWidth; //Coge la misma amplitud de la columna Foto que en la tabla de ProductoDel
            }
            if (tablaProductos.RowCount > 0) //Si queda al menos una fila, se puede exportar el listado
            {
                botonExportar.Enabled = true;
            }
            else
            {
                botonExportar.Enabled = false;
            }
        }

        private void menuModificar_Click(object sender, EventArgs e) //Abrir form Modificar productos
        {
            ProductoMod pmod = new ProductoMod(this);
            if(pmod.ShowDialog() == DialogResult.OK) //Si se ha pulsado el botón Modificar
            {
                //El código es exactamente igual que con ProductoDel, ya que lo que hacemos es guardar los cambios de la tabla de ProductoMod en el listado de productos
                //La única diferencia es a la hora de leer los valores de la tabla de ProductoMod, donde no hace falta sumar 1 a la celda, ya que tiene las mismas celdas que el listado de productos, no como con ProductoDel
                DataGridView moddgv = pmod.ModDGV;
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
                            tablaProductos.Rows[i].Cells[j].Value = moddgv.Rows[i].Cells[j].Value.ToString(); //Aquí no hace falta sumarle 1 a j
                        }
                    }
                }
                tablaProductos.Columns["foto"].MinimumWidth = moddgv.Columns["foto"].MinimumWidth;
            }
        }

        //Para la importación y exportación de archivos .csv haremos uso de la librería csvhelper
        //MUY IMPORTANTE: Si abrimos un archivo exportado con Excel y lo guardamos (ej. modificándolo), este no se podrá importar después. Esto se debe al problema del caracter delimitador, el cual varía según el país o la región del sistema que se haya seleccionado (se explica más adelante)
        private void botonImportar_Click(object sender, EventArgs e) //Importar archivo .csv
        {
            if (tablaProductos.RowCount > 0) //Si la tabla no está vacía, lanza una advertencia
            {
                MessageBox.Show("Si importas un archivo, la tabla actual se borrará", "Atención: La tabla no está vacía");
            }
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "*.csv|*.csv" }; //Ventana de selección de tabla. Adicionalmente se filtran archivos que se pueden seleccionar
            ofd.InitialDirectory = @"Escritorio"; //Esto es para que cada vez que pulsemos el botón, nos situemos directamente en la carpeta de Escritorio, pero parece ser que no funciona bien
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String fpath = ofd.FileName; //Ruta del archivo
                StreamReader sr = new StreamReader(fpath, Encoding.UTF8); //StreamReader que indica el archivo del que se va a leer y la codificación
                CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";" }; //Establecemos el carácter delimitador (en América es , pero en Europa es ;)
                CsvReader csvr = new CsvReader(sr, config); //Creamos CsvReader con los datos del StreamReader y la configuración establecida
                var tabla = csvr.GetRecords<Fila>(); //Almacenamos todos los registros (filas) del archivo en una tabla
                int numFilas = 0;
                for (int i = 0; tablaProductos.Rows.Count > 0; i++) //Se elimina el listado de productos actual (previo a la importación)
                {
                    tablaProductos.Rows.RemoveAt(0);
                }
                try
                {
                    foreach (var fila in tabla) //Por cada registro creamos una nueva fila con los valores del registro
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
                        if (Image.FromFile(fila.ruta).Width > tablaProductos.Columns["foto"].MinimumWidth) //La fila con la foto más ancha definirá la anchura de la columna Foto
                        {
                            tablaProductos.Columns["foto"].MinimumWidth = Image.FromFile(fila.ruta).Width;
                        }
                        numFilas++;
                    } 
                } catch (CsvHelper.HeaderValidationException csvex) //Si se produce un error durante la importación
                {
                    MessageBox.Show("El formato del archivo importado es incorrecto o las celdas no coinciden", "Error de importación");
                }
                Productos = tablaProductos;
                if (tablaProductos.RowCount > 0) //Si hay al menos 1 fila el botón de exportar es funcional y la información de la blank screen desaparece (si no había desaparecido ya)
                {
                    botonExportar.Enabled = true;
                    if (mainInfo.Visible == true)
                    {
                        mainInfo.Visible = false;
                    }
                }
                else
                {
                    botonExportar.Enabled = false;
                }
            }
        }

        private void botonExportar_Click(object sender, EventArgs e) //Exportar archivo .csv
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "*.csv|*.csv" }; //Filtrar los archivos para que solo se puedan seleccionar archivos csv
            sfd.InitialDirectory = @"Escritorio"; 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                String fpath = sfd.FileName;
                StreamWriter sw = new StreamWriter(fpath, false, Encoding.UTF8); //Modificamos el codificador
                CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";" }; //csv separa por defecto las columnas con comas, pero en la versión Europea de Windows se separan las columnas con ; así que tenemos que cambiar el separador de listas manualmente.
                CsvWriter csvw = new CsvWriter(sw, config); //Creamos CsvWriter con los datos del StreamReader y la configuración establecida
                List<Fila> tablaExp = new List<Fila>(); //Creamos una tabla de exportación que es en realidad una lista de objetos Fila
                for (int i = 0; i < tablaProductos.Rows.Count; i++)
                {
                    tablaExp.Add(new Fila() //Añadimos nueva fila definiendo las propiedades del objeto Fila
                    {
                        nombre = tablaProductos.Rows[i].Cells[0].Value.ToString(),
                        codigo = tablaProductos.Rows[i].Cells[1].Value.ToString(),
                        cantidad = Convert.ToInt32(tablaProductos.Rows[i].Cells[2].Value.ToString()),
                        precio = tablaProductos.Rows[i].Cells[3].Value.ToString(),
                        tipo = tablaProductos.Rows[i].Cells[4].Value.ToString(),
                        descripcion = tablaProductos.Rows[i].Cells[5].Value.ToString(),
                        //No exportamos la foto porque se crean varias columnas adicionales que no coinciden con los nombres para el mapeo
                        ruta = tablaProductos.Rows[i].Cells[7].Value.ToString()
                    });
                }
                csvw.WriteRecords(tablaExp); //Escribimos los registros en el nuevo archivo
                csvw.Dispose(); //Liberamos recursos del CsvWriter
                sw.Dispose(); //Liberamos recursos del StreamWriter
            }
        }

        private void menuFiltrar_SelectedIndexChanged(object sender, EventArgs e) //Cada vez que se marca o desmarca una casilla del menú de filtrado
        {
            for (int i = 0; i < menuFiltrar.Items.Count; i++)
            {
                if (menuFiltrar.GetItemCheckState(i) == CheckState.Checked) //Si la casilla está marcada mostrar columna
                {
                    tablaProductos.Columns[i].Visible = true;
                }
                else //Si no está marcada no mostrar la columna
                {
                    tablaProductos.Columns[i].Visible = false;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e) //Al cargar la aplicación
        {
            addAccedido = false; //Inicializamos los valores para comprobar si se debe mostrar la información de las blank screens
            delAccedido = false;
            modAccedido = false;
            for (int i = 0; i < menuFiltrar.Items.Count - 1; i++) //Esto sólo se utiliza para marcar las casillas automáticamente al iniciar el programa 
            {
                //La ruta no se muestra por defecto, de ahí el -1
                menuFiltrar.SetItemCheckState(i, CheckState.Checked);
                tablaProductos.Columns[i].Visible = true;
            }
        }
    }

    class Fila //Creamos objeto Fila con distintos atributos para mapear las columnas durante la importación y exportación de archivos .csv
    {
        [Name("Nombre")] //Nombre utilizado para el mapeo (opcional, aunque obligatorio si el nombre de una columna tiene espacios)
        public String nombre { get; set; } //Propiedad (si no se especifica un nombre para el mapeo se tomará este como referencia)
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
        //Crearemos la imagen a partir de la ruta
        [Name("Ruta de la imagen")]
        public String ruta { get; set; }
    }
}