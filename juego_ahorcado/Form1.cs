using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace juego_ahorcado
{
    public partial class Form1 : Form
    {
        public int contador = 1;
        public Form1()
        {
            listado_palabras listado_palabras = new listado_palabras();
            InitializeComponent();
            ocultar_imagenes();
            
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCombobox();
        }

        private void btnimprimir_Click(object sender, EventArgs e)
        {
            imprimir(txtnombre.Text);
        }

        private void ocultar_imagenes()
        {
            pb_1.Hide();
            pb_2.Hide();
            pb_3.Hide();
            pb_4.Hide();
            pb_5.Hide();
        }

        
        private void imprimir(string nombre)
        {

            //int retenedor = Convert.ToInt32(nombre.Length);
            /*char retener = nombre.ToCharArray()[1];

            lblnombre.Text = retener.ToString();*/
            
            /*switch (contador)
            {
                case 1:
                    pb_0.Hide();
                    pb_1.Show();
                    contador++;
                    break;
                case 2:
                    pb_1.Hide();
                    pb_2.Show();
                    contador++;
                    break;
                case 3:
                    pb_2.Hide();
                    pb_3.Show();
                    contador++;
                    break;
                case 4:
                    pb_3.Hide();
                    pb_4.Show();
                    contador++;
                    break;
                case 5:
                    pb_4.Hide();
                    pb_5.Show();
                    contador++;
                    break;

            }*/

        }

        private void LoadCombobox()
        {
            comboboxitem opcion_animales = new comboboxitem
            {
                text = "Animales",
                value = 1
            };
            comboboxitem opcion_frutas = new comboboxitem
            {
                text = "Frutas",
                value = 2
            };
            comboboxitem opcion_carros = new comboboxitem
            {
                text = "Carros",
                value = 3
            };
            comboboxitem opcion_pordefecto = new comboboxitem
            {
                text = "Seleccione la categoria",
                value = 0
            };

            cb_opciones.Items.Add(opcion_pordefecto); //aqui cargamos una opcion para el combobox
            cb_opciones.Items.Add(opcion_animales);
            cb_opciones.Items.Add(opcion_frutas);
            cb_opciones.Items.Add(opcion_carros);
            cb_opciones.SelectedItem = opcion_pordefecto;//Aqui utilizamos una opcion de las cargadas
            //para que aparezca por defecto

            cb_opciones.SelectedItem = "Seleccione una opcion";
            
        }

        private void btn_seleccionar_cat_Click(object sender, EventArgs e)
        {
            try
            {
                comboboxitem opcion_seleccionada = cb_opciones.SelectedItem as comboboxitem;
                listado_palabras listados = new listado_palabras();
                int retencion = listados.seleccionar_palabra(opcion_seleccionada.value);
                lblnombre.Text = retencion.ToString();
                

                
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
