﻿using System;
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
    public partial class Form1 : Form
    {
        //int numColumna = 0, numEncabezado = 0;
        int indiceFila = 0;
        int indiceColumna = 0;
        //string idColumna = "col" + numColumna, encabezado = "Columna " + numEncabezado; //no deja hacerlo así
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void añadirFila_Click(object sender, EventArgs e)
        {
            /*numColumna++;
            numEncabezado++;*/
            indiceFila++;
            //indiceColumna++;
            //string[] columnaNueva = new string[2];
            string[] filaNueva = new string[/*2*/1];
            /*columnaNueva[0] = "Columna1";
            columnaNueva[1] = "Columna2";*/
            filaNueva[0] = $"Fila {dataGridView1.Rows.Count + 1}";
            //filaNueva[1] = numUDpeso.Value.ToString();
            //dataGridView1.Columns.Add($"col{indiceColumna}", $"Columna {indiceColumna}"); //dataGridView1.Columns.Add(columnaNueva[0], columnaNueva[1]);
            dataGridView1.Rows.Add(filaNueva);
            /*if (dataGridView1.Rows.Count == 2){ //PARA QUE NO APAREZCA LA ÚLTIMA FILA VACÍA AL FINAL: cambiar propiedad dataGridView1.AllowUserToAddRows a False
                dataGridView1.Rows.Count = 1;
            }*/
            //dataGridView1.Rows.Add("Ey", "Qué tal", "Bien", "Y tú" , "?"); //En cada fila añade un elemento nuevo a una nueva columna
        }

        private void añadirColumna_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add($"col{indiceColumna}", $"Columna {indiceColumna}"); //dataGridView1.Columns.Add(columnaNueva[0], columnaNueva[1]);
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
            dataGridView1.Rows.Add("Ey", "Qué tal", "Bien", "Y tú" , "?"); //En cada fila añade un elemento nuevo a una nueva columna
        }

        private void cuentaFilasColumnas_Click(object sender, EventArgs e)
        {
            int numeroFilas = dataGridView1.Rows.Count;
            int numeroColumnas = dataGridView1.Columns.Count;
            comprobarVacio.Text = $"Número de filas en el DataGridView: {numeroFilas} \nNúmero de columnas en el DataGridView: {numeroColumnas}";
            //comprobarVacio.Text += /*(dataGridView1.Rows.Count)*/numeroFilas.ToString();
        }
    }
}
