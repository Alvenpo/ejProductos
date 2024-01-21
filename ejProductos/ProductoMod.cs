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
        public String valorTipo {  get; set; }
        private Boolean tipoReadOnly = true;
        public Boolean botonModPulsado { get; set; }
        private Boolean campoNull = false;
        private Boolean pkRepetida = false;
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
                    modTablaProductos.RowTemplate.Height = dgv.Rows[i].Height; //ATENCIÓN: Esto tal vez no sea necesario, probarlo comentado más tarde
                    //Forma1
                    modTablaProductos.Rows.Add(""/*"Modificar"*/);
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (j == 6)
                        {
                            modTablaProductos.Rows[i].Cells[j].Value = dgv.Rows[i].Cells[j].Value;
                        }
                        else
                        {
                            //Forma1
                            modTablaProductos.Rows[i].Cells[j/* + 1*/].Value = dgv.Rows[i].Cells[j].Value.ToString(); //IMPORTANTE: PARA HACER ESTO EL DATAGRIDVIEW NO DEBE ESTAR ASOCIADO A NINGUN DATASOURCE
                            //Forma2
                            //CeldasFila[j] = dgv.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    //Forma2
                    //modTablaProductos.Rows.Add(CeldasFila[0], CeldasFila[1], CeldasFila[2], CeldasFila[3], CeldasFila[4], CeldasFila[5]); //IMPORTANTE: LO MISMO QUE ARRIBA
                    if (Image.FromFile(dgv.Rows[i].Cells["ruta"/*7*/].Value.ToString()).Width > modTablaProductos.Columns["foto"].MinimumWidth)
                    {
                        modTablaProductos.Columns["foto"].MinimumWidth = Image.FromFile(dgv.Rows[i].Cells["ruta"].Value.ToString()).Width;
                        //anchoMax = tablaProductos.Columns["foto"].MinimumWidth;
                    }
                }
                ((Form1)padre).ProductosNuevo = modTablaProductos;
                //modTablaProductos
            }
            ModDGV = modTablaProductos;
            //String formatoPrecio = modTablaProductos.Rows[0].Cells["precio"].Value.ToString()/*.Substring(0, -1)*/;
            //label1.Text = formatoPrecio.Substring(0, formatoPrecio.Length - 1);
            //label1.Text = formatoPrecio.Substring(formatoPrecio.Length - 1, formatoPrecio.Length - 1);
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
                tipoReadOnly = true; //modTablaProductos.Columns["tipo"].ReadOnly = true;
                modTablaProductos.Columns["descripcion"].ReadOnly = true;
                modTablaProductos.Columns["foto"].ReadOnly = true;
                botonModPulsado = false;
                campoNull = false;
                pkRepetida = false;
                //PENDIENTE: HACER COMPROBACION DE QUE LOS VALORES DE TODOS LOS CAMPOS ESTÁN CORRECTOS ANTES DE PODER GUARDAR
                for (int i = 0; i < modTablaProductos.RowCount; i++)
                {
                    for (int j = 0; j < modTablaProductos.ColumnCount - 2; j++) //El - 2 es porque no hace falta comprobar la foto ni su ruta, ya que nunca van a estar vacías
                    {
                        if (modTablaProductos.Rows[i].Cells[j].Value/*.ToString()*/ == null) //Si descomentamos el ToString() falla, incluso con un try catch, ya que la excepción salta al tratar de pasar un valor nulo a string
                        {
                            campoNull = true;
                        }
                        /*try
                        {
                            modTablaProductos.Rows[i].Cells[j].Value.ToString();
                        }
                        catch (NullReferenceException nre)
                        {
                            campoNull = true;
                        }*/
                    }
                    for (int j = 0; (j < modTablaProductos.RowCount) && (pkRepetida == false) && (campoNull == false); j++)
                    {
                        //MessageBox.Show("1", "1");
                        if ((i != j) && (pkRepetida == false))
                        {
                            //MessageBox.Show("2", "2");
                            if (modTablaProductos.Rows[i].Cells["codigo"].Value.ToString() == modTablaProductos.Rows[j].Cells["codigo"].Value.ToString())
                            {
                                //MessageBox.Show("3", "3");
                                pkRepetida = true;
                                //MessageBox.Show("El valor introducido para el código del producto ya está asociado a otro producto. Asegúrate de corregirlo para poder guardar las modificaciones", "Atención: Código repetido");
                            }
                        }
                    }
                    if (campoNull == false)
                    {
                        try //Comprobar que los campos Cantidad y Precio sólo tienen valores numéricos
                        {
                            Convert.ToInt32(modTablaProductos.Rows[i].Cells["cantidad"].Value.ToString());
                            String formatoPrecio = modTablaProductos.Rows[i].Cells["precio"].Value.ToString();
                            if (formatoPrecio.Substring(formatoPrecio.Length - 1, formatoPrecio.Length - 1).Equals("€"))
                            {
                                Convert.ToDouble(formatoPrecio.Substring(0, formatoPrecio.Length - 1));
                            }
                            else
                            {
                                campoNull = true;
                            }
                        }
                        catch (FormatException fe)
                        {
                            campoNull = true;
                        }
                    }
                }
                if (pkRepetida == true)
                {
                    MessageBox.Show("El valor introducido para el código del producto ya está asociado a otro producto. Asegúrate de corregirlo para poder guardar las modificaciones", "Atención: Código repetido");
                    modBotonSalir.Enabled = false;
                }
                else if (campoNull == true /*&& (modBotonSalir.Enabled == true)*//* || (pkRepetida == true)*/)
                {
                    MessageBox.Show("Hay al menos una columna con un valor incorrecto. Asegúrate de corregirlo para poder guardar las modificaciones", "Atención: Valor incorrecto");
                    modBotonSalir.Enabled = false;
                }
                else //if (campoNull == false)
                {
                    modBotonSalir.Enabled = true;
                }
                //modBotonSalir.Enabled = true;
            }
            else if (modTablaProductos.RowCount > 0)
            {
                modTablaProductos.Columns["nombre"].ReadOnly = false;
                modTablaProductos.Columns["codigo"].ReadOnly = false;
                modTablaProductos.Columns["cantidad"].ReadOnly = false;
                modTablaProductos.Columns["precio"].ReadOnly = false;
                tipoReadOnly = false; //modTablaProductos.Columns["tipo"].ReadOnly = false;
                modTablaProductos.Columns["descripcion"].ReadOnly = false;
                modTablaProductos.Columns["foto"].ReadOnly = false;
                botonModPulsado = true;
                modBotonSalir.Enabled = false;
                modBotonSalir.Text = "Guardar";
            }
            //DelDGV = delTablaProductos;
            //Si se pudiese acceder a la propiedad Columns["foto"].Image.Width, cada vez que modificase una foto la cambiaría para que se ajustase de manera automática
            if (modBotonSalir.DialogResult == DialogResult.Cancel) //Es el peor sitio donde colocarlo, pero es la única forma de hacerlo funcionar (abajo se explican las razones)
            {
                modBotonSalir.DialogResult = DialogResult.OK;
                /*modBotonSalir.Text = "Guardar";*/
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

        private void modTablaProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == modTablaProductos.Columns[6].Index) && (modTablaProductos.Columns["foto"].ReadOnly == false))
            {
                OpenFileDialog ofd = new OpenFileDialog() { Filter = "Archivos .png (*.png)|*.png|Archivos .jpg (*.jpg)|*.jpg|Archivos .gif (*.gif)|*.gif"/*"Todos los archivos (*.*)|*.*"*/ };
                ofd.InitialDirectory = @"Imágenes";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    modTablaProductos.Rows[e.RowIndex].Cells[6].Value = Image.FromFile(ofd.FileName);
                    modTablaProductos.Rows[e.RowIndex].Cells[7].Value = ofd.FileName;
                }
                modTablaProductos.Columns["foto"].MinimumWidth = 2; //Si le pongo de anchoMínimo < 2 salta una excepción
                for (int i = 0; i < modTablaProductos.Rows.Count; i++)
                {
                    //modTablaProductos.RowTemplate.Height = 2; //No he comprobado aún si le pongo de altoMínimo < 2 salta una excepción
                    if (Image.FromFile(modTablaProductos.Rows[i].Cells["ruta"/*7*/].Value.ToString()).Height != modTablaProductos.Rows[i].Height)
                    {
                        modTablaProductos.Rows[i].Height = Image.FromFile(modTablaProductos.Rows[i].Cells["ruta"/*7*/].Value.ToString()).Height;
                    }
                    if (Image.FromFile(modTablaProductos.Rows[i].Cells["ruta"/*7*/].Value.ToString()).Width > modTablaProductos.Columns["foto"].MinimumWidth)
                    {
                        modTablaProductos.Columns["foto"].MinimumWidth = Image.FromFile(modTablaProductos.Rows[i].Cells["ruta"].Value.ToString()).Width;
                        //anchoMax = tablaProductos.Columns["foto"].MinimumWidth;
                    }
                }
            }
            if ((e.ColumnIndex == modTablaProductos.Columns[4].Index) && (/*modTablaProductos.Columns["tipo"].ReadOnly*/tipoReadOnly == false))
            {
                /*ComboBox cbo = new ComboBox();
                cbo.Items.Add("Ropa");
                cbo.Items.Add("Alimentación");
                cbo.Items.Add("Mueble");
                cbo.Items.Add("Electrodoméstico");
                cbo.Show();*/
                valorTipo = modTablaProductos.Rows[e.RowIndex].Cells[4].Value.ToString();
                modTipoDespegable listaTipos = new modTipoDespegable(this);
                if (listaTipos.ShowDialog() == DialogResult.OK)
                {
                    modTablaProductos.Rows[e.RowIndex].Cells[4].Value = listaTipos.valorTipo;
                }
            }
        }

        /*private void modTablaProductos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            campoNull = false;
            pkRepetida = false;
            for (int i = 0; i < modTablaProductos.RowCount; i++)
            {
                for (int j = 1; j < modTablaProductos.ColumnCount - 2; j++) //El - 2 es porque no hace falta comprobar la foto ni su ruta, ya que nunca van a estar vacías
                {
                    if (modTablaProductos.Rows[i].Cells[j].Value.ToString() == "")
                    {
                        campoNull = true;
                    }
                }
                if (e.RowIndex != i)
                {
                    if (modTablaProductos.Rows[e.RowIndex].Cells["codigo"].Value.ToString() == modTablaProductos.Rows[i].Cells["codigo"].Value.ToString())
                    {
                        pkRepetida = true;
                        MessageBox.Show("El valor introducido para el código del producto ya está asociado a otro producto", "Atención: Código repetido");
                    }
                }
                if ((campoNull == true) || (pkRepetida == true))
                {
                    modBotonSalir.Enabled = false;
                }
                else
                {
                    modBotonSalir.Enabled = true;
                }
            }
        }*/

        /*private void modTablaProductos_CurrentCellChanged(object sender, EventArgs e)
        {
            /*if (modBotonSalir.DialogResult == DialogResult.Cancel) //Esto sería ideal, pero no se usa porque siempre se activa, ya que al escribir los datos de TablaProductos en modTablaProductos se activa el evento
            {
                modBotonSalir.DialogResult = DialogResult.OK;
            }*/
            /*campoNull = false;
            pkRepetida = false;
            for (int i = 0; i < modTablaProductos.RowCount; i++)
            {
                for (int j = 1; j < modTablaProductos.ColumnCount - 2; j++) //El - 2 es porque no hace falta comprobar la foto ni su ruta, ya que nunca van a estar vacías
                {
                    try
                    {
                        if (modTablaProductos.Rows[i].Cells[j].Value.ToString() == "")
                        {
                            campoNull = true;
                        }
                    } catch (NullReferenceException nre)
                    {
                        MessageBox.Show("Testeando", "Atención: esto es otro test");
                    }
                }
                //if (e.RowIndex != i)
                //{
                    if (e.Equals(modTablaProductos.Rows[i].Cells["codigo"].Value.ToString()))
                    {
                        pkRepetida = true;
                        MessageBox.Show("El valor introducido para el código del producto ya está asociado a otro producto", "Atención: Código repetido");
                    }
                //}
                if ((campoNull == true) || (pkRepetida == true))
                {
                    modBotonSalir.Enabled = false;
                }
                else
                {
                    modBotonSalir.Enabled = true;
                }
            }
            //MessageBox.Show("Probando", "Atención: esto es un test");
        }*/
    }
}
