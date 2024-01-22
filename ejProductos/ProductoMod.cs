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
                        if (j == 6)
                        {
                            modTablaProductos.Rows[i].Cells[j].Value = dgv.Rows[i].Cells[j].Value;
                        }
                        else
                        {
                            modTablaProductos.Rows[i].Cells[j/* + 1*/].Value = dgv.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    if (Image.FromFile(dgv.Rows[i].Cells["ruta"/*7*/].Value.ToString()).Width > modTablaProductos.Columns["foto"].MinimumWidth)
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
            if (botonModPulsado)
            {
                modTablaProductos.Columns["nombre"].ReadOnly = true;
                modTablaProductos.Columns["codigo"].ReadOnly = true;
                modTablaProductos.Columns["cantidad"].ReadOnly = true;
                modTablaProductos.Columns["precio"].ReadOnly = true;
                tipoReadOnly = true; 
                modTablaProductos.Columns["descripcion"].ReadOnly = true;
                modTablaProductos.Columns["foto"].ReadOnly = true;
                botonModPulsado = false;
                campoNull = false;
                pkRepetida = false;
                //Comprobación de que los valores de todos los campos están correctos antes de poder guardar
                for (int i = 0; i < modTablaProductos.RowCount; i++)
                {
                    for (int j = 0; j < modTablaProductos.ColumnCount - 2; j++) //El - 2 es porque no hace falta comprobar la foto ni su ruta, ya que nunca van a estar vacías
                    {
                        if (modTablaProductos.Rows[i].Cells[j].Value == null) 
                        {
                            campoNull = true;
                        }
                    }
                    for (int j = 0; (j < modTablaProductos.RowCount) && (pkRepetida == false) && (campoNull == false); j++)
                    {
                        if ((i != j) && (pkRepetida == false))
                        {
                            if (modTablaProductos.Rows[i].Cells["codigo"].Value.ToString() == modTablaProductos.Rows[j].Cells["codigo"].Value.ToString())
                            {
                                pkRepetida = true;
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
                else if (campoNull == true)
                {
                    MessageBox.Show("Hay al menos una columna con un valor incorrecto. Asegúrate de corregirlo para poder guardar las modificaciones", "Atención: Valor incorrecto");
                    modBotonSalir.Enabled = false;
                }
                else 
                {
                    modBotonSalir.Enabled = true;
                }
            }
            else if (modTablaProductos.RowCount > 0)
            {
                modTablaProductos.Columns["nombre"].ReadOnly = false;
                modTablaProductos.Columns["codigo"].ReadOnly = false;
                modTablaProductos.Columns["cantidad"].ReadOnly = false;
                modTablaProductos.Columns["precio"].ReadOnly = false;
                tipoReadOnly = false; 
                modTablaProductos.Columns["descripcion"].ReadOnly = false;
                modTablaProductos.Columns["foto"].ReadOnly = false;
                botonModPulsado = true;
                modBotonSalir.Enabled = false;
                modBotonSalir.Text = "Guardar";
            }

            if (modBotonSalir.DialogResult == DialogResult.Cancel) 
            {
                modBotonSalir.DialogResult = DialogResult.OK;
            }
        }

        private void modBotonSalir_Click(object sender, EventArgs e)
        {
            if (ModDGV != modTablaProductos)  //Optimización: con esto nos aseguramos de que solo tengamos que volver a crear un DataGridView en Form1 tras pulsar el botón Salir cuando se haya modificado al menos 1 celda
            {
                ModDGV = modTablaProductos; //Si la tabla ha sido modificada, guardar nueva tabla
            }
        }

        private void modTablaProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == modTablaProductos.Columns[6].Index) && (modTablaProductos.Columns["foto"].ReadOnly == false))
            {
                OpenFileDialog ofd = new OpenFileDialog() { Filter = "Archivos .png (*.png)|*.png|Archivos .jpg (*.jpg)|*.jpg|Archivos .gif (*.gif)|*.gif" };
                ofd.InitialDirectory = @"Imágenes";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    modTablaProductos.Rows[e.RowIndex].Cells[6].Value = Image.FromFile(ofd.FileName);
                    modTablaProductos.Rows[e.RowIndex].Cells[7].Value = ofd.FileName;
                }
                modTablaProductos.Columns["foto"].MinimumWidth = 2; //Si le pongo de anchoMínimo < 2 salta una excepción
                for (int i = 0; i < modTablaProductos.Rows.Count; i++)
                {
                    if (Image.FromFile(modTablaProductos.Rows[i].Cells["ruta"].Value.ToString()).Height != modTablaProductos.Rows[i].Height)
                    {
                        modTablaProductos.Rows[i].Height = Image.FromFile(modTablaProductos.Rows[i].Cells["ruta"].Value.ToString()).Height;
                    }
                    if (Image.FromFile(modTablaProductos.Rows[i].Cells["ruta"].Value.ToString()).Width > modTablaProductos.Columns["foto"].MinimumWidth)
                    {
                        modTablaProductos.Columns["foto"].MinimumWidth = Image.FromFile(modTablaProductos.Rows[i].Cells["ruta"].Value.ToString()).Width;
                    }
                }
            }
            if ((e.ColumnIndex == modTablaProductos.Columns[4].Index) && (tipoReadOnly == false))
            {
                valorTipo = modTablaProductos.Rows[e.RowIndex].Cells[4].Value.ToString();
                modTipoDespegable listaTipos = new modTipoDespegable(this);
                if (listaTipos.ShowDialog() == DialogResult.OK)
                {
                    modTablaProductos.Rows[e.RowIndex].Cells[4].Value = listaTipos.valorTipo;
                }
            }
        }
    }
}
