using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace juego_ahorcado
{
    
    class listado_palabras
    { 
        //Aqui vamos a almacenar en List a todos los animales
        public List<string> animales = new List<string>();
        public List<string> frutas = new List<string>();
        public List<string> carros = new List<string>();
        public int palabra_seleccionada = 0;
        public void anadir()
        {
            frutas.Add("mango");
            frutas.Add("banana");
            frutas.Add("melon");
            frutas.Add("piña");
            frutas.Add("melocoton");
            frutas.Add("uva");
            frutas.Add("manzana");
            frutas.Add("pera");
            frutas.Add("zapote");
            frutas.Add("sandia");

            animales.Add("elefante");
            animales.Add("perro");
            animales.Add("gato");
            animales.Add("raton");
            animales.Add("leon");
            animales.Add("tigre");
            animales.Add("ballena");
            animales.Add("tiburon");
            animales.Add("mono");
            animales.Add("gorila");

            carros.Add("hyunday");
            carros.Add("toyota");
            carros.Add("honda");
            carros.Add("audi");
            carros.Add("chevrolet");
            carros.Add("rolroyce");
            carros.Add("ferrari");
            carros.Add("lamborghini");
            carros.Add("suzuki");
            carros.Add("volvo");
        }
        public string seleccionar_palabra()
        {
            anadir();//con este metodo llena
            Random rnd = new Random();
            int aleatorio = rnd.Next(0, 10);
            
            switch (palabra_seleccionada)
            {
                case 1:
                    
                    string animales = this.animales[aleatorio].ToString();
                    return animales;
                    break;
                case 2:
                    
                    string frutas = this.frutas[aleatorio].ToString();
                    return frutas;
                    break;
                case 3:
                    string carros = this.carros[aleatorio].ToString();
                    return carros;
                    break;
                default:
                    break;
            }
            return "";

        }
    }
}
