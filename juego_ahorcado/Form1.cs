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
        public int contador = 1, contador_intentos = 0,contador_espacios_flowlyout =0;

        listado_palabras listados;
        public Form1()
        {
            listados = new listado_palabras();
            InitializeComponent();
            ocultar_imagenes();
            
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCombobox();
            ocultar_imagenes();
        }

        private void btnimprimir_Click(object sender, EventArgs e)
        {
            imprimir(txtnombre.Text);
            
            adivinar_letra();
            txtnombre.Clear();
            txtnombre.Focus();
        }

        private void ocultar_imagenes()
        {
            pb_0.Show();
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
                contador_intentos = 0; //Aqui reiniciamos el contador de intentos
                //para que los fallos puedan funcionar
                //listado_palabras listados = new listado_palabras();
                listados.palabra_seleccionada = opcion_seleccionada.value;

                crear_labels();
                
                

                
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        private void crear_labels()
        {
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < listados.contar_numero_de_letras(); i++)
            {
                Label lbl = new Label();
                lbl.AutoSize = true;
                lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                lbl.Name = "label2";
                lbl.Size = new System.Drawing.Size(238, 24);
                lbl.TabIndex = 11;
                lbl.Text = "_";
                flowLayoutPanel1.Controls.Add(lbl);
            }
        }

        private void adivinar_letra()
        {
            try
            {
                
                
                    bool correcto = false;
                    string[] letras = listados.palabra_elegida.Split();// aqui cpnvertimos la palabra en un array
                                                                       //para despues poder separarla letra por letra
                    int contador = 0;

                    while (contador < listados.palabra_elegida.Length) //este while es para asegurarnos de recorrer
                                                                       //la palabra letra por letra
                    {
                        foreach (var item in letras)
                        {
                            if (txtnombre.Text.Length == 1 && txtnombre.Text == item.ElementAt(contador).ToString())//aqui utilizamos el elementAr
                                                                                                                    //para poder seleccionar cada letra a un punto de la plabra en especifico
                            {
                                flowLayoutPanel1.Controls[contador].Text = txtnombre.Text;
                                correcto = true;
                                
                            }

                            contador++;

                        }
                    }

                    if (correcto == false)//si el usuario fallo, entonces entrara aqui para aumentar los intentos
                    {
                        contador_intentos++;
                        switch (contador_intentos)
                        {
                            case 1:
                                pb_0.Hide();
                                pb_1.Show();

                                break;
                            case 2:
                                pb_1.Hide();
                                pb_2.Show();
                                break;
                            case 3:
                                pb_2.Hide();
                                pb_3.Show();
                                break;
                            case 4:
                                pb_3.Hide();
                                pb_4.Show();
                                break;
                            case 5:
                                pb_4.Hide();
                                pb_5.Show();

                                var resultado = MessageBox.Show("Desea volver a jugar?", "Ahorcado", MessageBoxButtons.YesNo);
                                if (resultado == DialogResult.Yes)
                                {
                                    /*this.Controls.Clear(); //Este metodo lo utilizamos para limpiar todo el form
                                    this.InitializeComponent();//Este para reiniciar todos los procesos
                                    LoadCombobox();
                                    ocultar_imagenes();*/
                                    txtnombre.Clear();
                                    ocultar_imagenes();

                                    int contador2 = flowLayoutPanel1.Controls.Count;
                                    do
                                    {
                                        flowLayoutPanel1.Controls.RemoveAt(contador2 - 1);
                                        contador2--;
                                    } while (contador2 >= 0);
                                }
                            
                                else
                                {
                                    Application.Exit();
                                }
                            
                            break;
                            default:
                                break;
                        }
                    }



                /* var resultado2 = MessageBox.Show("GANASTE!!, DESEAS VOLVER A INTENTARLO?", "AHORCADO",MessageBoxButtons.YesNo);
                 if (resultado2 ==DialogResult.Yes)
                 {
                     txtnombre.Clear();
                     LoadCombobox();
                 }*/


               confirmar_ganador();
            }
            catch (Exception)
            {
                MessageBox.Show("Solo te puede insertar letras", "Advertensia");
                
            }
            
            
        }

        private void confirmar_ganador()
        {
            int contador = 0; bool ganador = false;
            do
            {
                if (flowLayoutPanel1.Controls[contador].Text=="_")
                {
                    break;
                }
                if (flowLayoutPanel1.Controls.Count == contador)
                {
                    MessageBox.Show("GANATE!!","AHORCADO");
                    ganador = true;
                }
                contador++;
            } while (ganador==false);
        }
    }
}
