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

        private void ProductoMod_Load(object sender, EventArgs e) 
        {
            if (((Form1)padre).modAccedido == true) //Esto se utiliza para saber si este formulario ya ha sido accedido y no volver a mostrar la información blank screen
            {
                modInfo.Visible = false;
            }
            //El código es exactamente igual que con ProductoDel, ya que lo que hacemos es guardar el listado de productos en la tabla de ProductoMod
            //La única diferencia es a la hora de escribir los valores en la tabla de ProductoMod, donde no hace falta sumar 1 a la celda, ya que tiene las mismas celdas que el listado de productos, no como con ProductoDel
            DataGridView dgv = ((Form1)padre).Productos;
            DataGridView guardaDGV = ((Form1)padre).ProductosNuevo;
            if (guardaDGV != dgv) //Optimización: para que no se actualice la lista cada vez que abramos el form (si esta no ha cambiado desde la ultima vez)
            {   //Por alguna razón no funciona la optimización
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    modTablaProductos.RowTemplate.Height = dgv.Rows[i].Height; 
                    modTablaProductos.Rows.Add("");
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (j == 6) //Para la columna Foto
                        {
                            modTablaProductos.Rows[i].Cells[j].Value = dgv.Rows[i].Cells[j].Value;
                        }
                        else
                        {
                            modTablaProductos.Rows[i].Cells[j/* + 1*/].Value = dgv.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    if (Image.FromFile(dgv.Rows[i].Cells["ruta"].Value.ToString()).Width > modTablaProductos.Columns["foto"].MinimumWidth)
                    {
                        modTablaProductos.Columns["foto"].MinimumWidth = Image.FromFile(dgv.Rows[i].Cells["ruta"].Value.ToString()).Width;
                    }
                }
                ((Form1)padre).ProductosNuevo = modTablaProductos;
            }
            ModDGV = modTablaProductos;
        }

        private void modBotonModificar_Click(object sender, EventArgs e)
        {
            if (botonModPulsado) //Deshabilitar el modo edición si el botón ya había sido pulsado
            {
                modTablaProductos.Columns["nombre"].ReadOnly = true;
                modTablaProductos.Columns["codigo"].ReadOnly = true;
                modTablaProductos.Columns["cantidad"].ReadOnly = true;
                modTablaProductos.Columns["precio"].ReadOnly = true;
                tipoReadOnly = true; 
                modTablaProductos.Columns["descripcion"].ReadOnly = true;
                modTablaProductos.Columns["foto"].ReadOnly = true;
                labelEditando.Visible = false;
                botonModPulsado = false;
                campoNull = false;
                pkRepetida = false;
                //Comprobación de que los valores de todos los campos están correctos antes de poder guardar
                for (int i = 0; i < modTablaProductos.RowCount; i++)
                {
                    for (int j = 0; j < modTablaProductos.ColumnCount - 2; j++) //El - 2 es porque no hace falta comprobar la foto ni su ruta, ya que nunca van a estar vacías
                    {
                        if (modTablaProductos.Rows[i].Cells[j].Value == null) //Comprobación de campo nulo
                        {
                            campoNull = true;
                        }
                    }
                    for (int j = 0; (j < modTablaProductos.RowCount) && (pkRepetida == false) && (campoNull == false); j++)
                    {
                        if ((i != j) && (pkRepetida == false)) //Evitamos que se analice la misma fila 2 veces, ya que siempre nos daría valor repetido
                        {
                            if (modTablaProductos.Rows[i].Cells["codigo"].Value.ToString() == modTablaProductos.Rows[j].Cells["codigo"].Value.ToString()) //Comprobación de valor de la columna Código repetido
                            {
                                pkRepetida = true;
                            }
                        }
                    }
                    if (campoNull == false) //Si la fila no tiene ningún campo nulo
                    {
                        try //Comprobar que los campos Cantidad y Precio sólo tienen valores numéricos
                        {
                            Convert.ToInt32(modTablaProductos.Rows[i].Cells["cantidad"].Value.ToString());
                            String formatoPrecio = modTablaProductos.Rows[i].Cells["precio"].Value.ToString();
                            if (formatoPrecio.Substring(formatoPrecio.Length - 1, formatoPrecio.Length - 1).Equals("€")) //Separamos el valor numérico de €
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
                if (pkRepetida == true) //Si el valor de Código ya está en el listado de productos
                {
                    MessageBox.Show("El valor introducido para el código del producto ya está asociado a otro producto. Asegúrate de corregirlo para poder guardar las modificaciones", "Atención: Código repetido");
                    modBotonSalir.Enabled = false;
                }
                else if (campoNull == true) //En caso contrario, si hay un campo nulo
                {
                    MessageBox.Show("Hay al menos una columna con un valor incorrecto. Asegúrate de corregirlo para poder guardar las modificaciones", "Atención: Valor incorrecto");
                    modBotonSalir.Enabled = false;
                }
                else //Si todos los valores de la tabla son correctos
                {
                    modBotonSalir.Enabled = true;
                }
            }
            else if (modTablaProductos.RowCount > 0) //Habilitar el modo edición si el botón no ha sido pulsado todavía y la tabla no está vacía
            {
                modTablaProductos.Columns["nombre"].ReadOnly = false;
                modTablaProductos.Columns["codigo"].ReadOnly = false;
                modTablaProductos.Columns["cantidad"].ReadOnly = false;
                modTablaProductos.Columns["precio"].ReadOnly = false;
                tipoReadOnly = false; 
                modTablaProductos.Columns["descripcion"].ReadOnly = false;
                modTablaProductos.Columns["foto"].ReadOnly = false;
                labelEditando.Visible = true;
                botonModPulsado = true;
                modBotonSalir.Enabled = false;
                modBotonSalir.Text = "Guardar";
            }

            if (modBotonSalir.DialogResult == DialogResult.Cancel) //Tras pulsar el botón Modificar, al salir se guarda la tabla
            {
                modBotonSalir.DialogResult = DialogResult.OK;
            }
        }

        private void modBotonSalir_Click(object sender, EventArgs e) //Al pulsar el botón Salir / Guardar
        {
            if (((Form1)padre).modAccedido == false) //Si el formulario no había sido accedido antes, ahora queda constancia de que sí (para que no vuelva a aparecer la info de la blank screen)
            {
                ((Form1)padre).modAccedido = true;
            }
            if (ModDGV != modTablaProductos)  //Optimización: con esto nos aseguramos de que solo tengamos que volver a crear un DataGridView en Form1 tras pulsar el botón Salir cuando se haya modificado al menos 1 celda
            {
                ModDGV = modTablaProductos; //Si la tabla ha sido modificada, guardar nueva tabla
            }
        }

        private void modTablaProductos_CellContentClick(object sender, DataGridViewCellEventArgs e) //Al hacer click en una celda
        {
            if ((e.ColumnIndex == modTablaProductos.Columns[6].Index) && (modTablaProductos.Columns["foto"].ReadOnly == false)) //Al pinchar en la columna Foto con el modo edición habilitado
            {
                OpenFileDialog ofd = new OpenFileDialog() { Filter = "Archivos .png (*.png)|*.png|Archivos .jpg (*.jpg)|*.jpg|Archivos .gif (*.gif)|*.gif" };
                ofd.InitialDirectory = @"Imágenes";
                if (ofd.ShowDialog() == DialogResult.OK) //Si se selecciona una imagen, se actualiza la ruta de la imagen también
                {
                    modTablaProductos.Rows[e.RowIndex].Cells[6].Value = Image.FromFile(ofd.FileName);
                    modTablaProductos.Rows[e.RowIndex].Cells[7].Value = ofd.FileName;
                }
                modTablaProductos.Columns["foto"].MinimumWidth = 2; //Se establece el valor mínimo para la columna Foto. Esto es para reevaluar la amplitud de la columna //Si le pongo de anchoMínimo < 2 salta una excepción
                for (int i = 0; i < modTablaProductos.Rows.Count; i++)
                {
                    if (Image.FromFile(modTablaProductos.Rows[i].Cells["ruta"].Value.ToString()).Height != modTablaProductos.Rows[i].Height) //Si la altura de la imagen modificada es distinta a la de la propia fila
                    {
                        modTablaProductos.Rows[i].Height = Image.FromFile(modTablaProductos.Rows[i].Cells["ruta"].Value.ToString()).Height;
                    }
                    if (Image.FromFile(modTablaProductos.Rows[i].Cells["ruta"].Value.ToString()).Width > modTablaProductos.Columns["foto"].MinimumWidth) //Si la amplitud de la imagen modificada es mayor que la amplitud máxima de la celda Foto
                    {
                        modTablaProductos.Columns["foto"].MinimumWidth = Image.FromFile(modTablaProductos.Rows[i].Cells["ruta"].Value.ToString()).Width;
                    }
                }
            }
            if ((e.ColumnIndex == modTablaProductos.Columns[4].Index) && (tipoReadOnly == false)) //Al pinchar en la columna Tipo con el modo edición habilitado
            {
                valorTipo = modTablaProductos.Rows[e.RowIndex].Cells[4].Value.ToString(); //Se guarda el valor de la columna Tipo para que, al abrir el menú despegable, el botón con el mismo nombre esté marcado
                modTipoDespegable listaTipos = new modTipoDespegable(this);
                if (listaTipos.ShowDialog() == DialogResult.OK) //Al pulsar el botón Aceptar se guarda el valor de la opción seleccionada en la columna Tipo
                {
                    modTablaProductos.Rows[e.RowIndex].Cells[4].Value = listaTipos.valorTipo;
                }
            }
        }
    }
}
