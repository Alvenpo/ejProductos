using System;
using System.Collections;
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
    public partial class modTipoDespegable : Form
    {
        //public CheckedListBox clbox {  get; set; }
        public List<RadioButton> ListaTipos {  get; set; }
        public String valorTipo {  get; set; }
        Form padre;
        public modTipoDespegable(Form padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        private void checkBotonAceptar_Click(object sender, EventArgs e)
        {
            //clbox = checkboxTipo;
            foreach (RadioButton boton in ListaTipos)
            {
                if (boton.Checked == true)
                {
                    valorTipo = boton.Text;
                }
            }
        }

        private void modTipoDespegable_Load(object sender, EventArgs e)
        {
            List<RadioButton> botones = new List<RadioButton>();
            botones.Add(rbRopa);
            botones.Add(rbAlimentacion);
            botones.Add(rbMueble);
            botones.Add(rbElectrodomestico);
            ListaTipos = botones;
            valorTipo = ((ProductoMod)padre).valorTipo;
            //int i = 0;
            //for (int i = 0; i < checkboxTipo.Items.Count; i++)//each (String tipo in checkboxTipo.Items)
            //{
            //if (valorTipo == checkboxTipo.Items/*tipo*/)
            //{
            //checkboxTipo.SetItemCheckState(i, CheckState.Checked);
            //}
            //i++;
            //}
            //checkboxTipo.SetItemCheckState("Ropa", CheckState.Checked);
            foreach (RadioButton boton in ListaTipos)
            {
                if (valorTipo == boton.Text)
                {
                    boton.Checked = true;
                }
            }
            /*switch (valorTipo)
            {
                case "Ropa": rbRopa.Checked = true; break;
                case "Alimentación": rbAlimentacion.Checked = true; break;
                case "Mueble": rbMueble.Checked = true; break;
                case "Electrodoméstico": rbElectrodomestico.Checked = true; break;
                default: checkBotonAceptar.Enabled = false; break;
            }*/
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //labelTipo.Text = e.ToString();
            //labelTipo.Text = rbAlimentacion.Text;
            
            //if (rbRopa.Checked)
        }
    }
}
