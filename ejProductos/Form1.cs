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
        private int indiceFila = 0;
        private int indiceColumna = 0;
        private int anchoMax = 0;
        DataGridViewTextBoxColumn prueba2 = new DataGridViewTextBoxColumn();
        public DataGridView Productos { get; set; }
        public DataGridView ProductosNuevo { get; set; } //Por cuestiones de optimización //No funciona
        public Form1()
        {
            InitializeComponent();
        }

        private void menuAñadir_Click(object sender, EventArgs e)
        {
            ProductoAdd padd = new ProductoAdd(this);
            if (padd.ShowDialog() == DialogResult.OK)
            {
                tablaProductos.RowTemplate.Height = padd.Foto.Height;
                if (padd.Foto.Width > anchoMax)
                {
                    tablaProductos.Columns["foto"].MinimumWidth = padd.Foto.Width;
                    anchoMax = tablaProductos.Columns["foto"].MinimumWidth;
                }
                tablaProductos.Rows.Add(padd.Nombre, padd.Codigo, padd.Cantidad, padd.Precio, padd.Tipo, padd.Descripcion, padd.Foto, padd.Ruta);
                Productos = tablaProductos; 
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

        private void menuEliminar_Click(object sender, EventArgs e) 
        {
            ProductoDel pdel = new ProductoDel(this);
            if (pdel.ShowDialog() == DialogResult.OK)
            {
                DataGridView deldgv = pdel.DelDGV;
                for (int i = 0; tablaProductos.Rows.Count > 0; i++) //IMPORTANTE: NECESITAMOS BORRAR TODAS LAS FILAS DEL DATAGRIDVIEW, PORQUE LO QUE SE HACE DESPUÉS ES MODIFICAR LAS X PRIMERAS FILAS CON LAS X FILAS RESTANTES DE DELDGV, Y ENCIMA SE AÑADEN TANTAS COLUMNAS VACÍAS (Línea 118) COMO X FILAS QUEDEN EN DELDGV
                { 
                    tablaProductos.Rows.RemoveAt(0); 
                }
                for (int i = 0; i < deldgv.Rows.Count; i++)
                {
                    tablaProductos.RowTemplate.Height = deldgv.Rows[i].Height;
                    tablaProductos.Rows.Add("");
                    for (int j = 0; j < deldgv.Columns.Count - 1; j++)
                    {
                        if (j == 6)
                        {
                            tablaProductos.Rows[i].Cells[j].Value = deldgv.Rows[i].Cells[j + 1].Value;
                        }
                        else
                        {
                            tablaProductos.Rows[i].Cells[j].Value = deldgv.Rows[i].Cells[j + 1].Value.ToString();
                        }
                    }
                }
                tablaProductos.Columns["foto"].MinimumWidth = deldgv.Columns["foto"].MinimumWidth; 
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

        private void menuModificar_Click(object sender, EventArgs e)
        {
            ProductoMod pmod = new ProductoMod(this);
            if(pmod.ShowDialog() == DialogResult.OK)
            {
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
                            tablaProductos.Rows[i].Cells[j].Value = moddgv.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }
                tablaProductos.Columns["foto"].MinimumWidth = moddgv.Columns["foto"].MinimumWidth;
            }
        }

        //Para la importación y exportación de archivos .csv haremos uso de la librería csvhelper
        //MUY IMPORTANTE: Si abrimos un archivo exportado con Excel y lo guardamos (ej. modificándolo), este no se podrá importar después. Esto se debe al problema del caracter delimitador, el cual varía según el país o la región del sistema que se haya seleccionado (se explica más adelante)
        private void botonImportar_Click(object sender, EventArgs e)
        {
            if (tablaProductos.RowCount > 0) 
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
                sfd.InitialDirectory = @"Escritorio"; 
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    String fpath = sfd.FileName;
                    StreamWriter sw = new StreamWriter(fpath, false, Encoding.UTF8); //Modificamos el codificador
                    CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";" }; //csv separa por defecto las columnas con comas, pero en la versión Europea de Windows se separan las columnas con ; así que tenemos que cambiar el separador de listas manualmente.
                    CsvWriter csvw = new CsvWriter(sw, config);
                    List<Fila> tablaExp = new List<Fila>();
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
                            ruta = tablaProductos.Rows[i].Cells[7].Value.ToString()
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
        //Crearemos la imagen a partir de la ruta
        [Name("Ruta de la imagen")]
        public String ruta { get; set; }
    }
}