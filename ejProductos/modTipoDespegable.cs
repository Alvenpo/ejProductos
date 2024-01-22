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
            foreach (RadioButton boton in ListaTipos)
            {
                if (valorTipo == boton.Text)
                {
                    boton.Checked = true;
                }
            }
        }
    }
}
