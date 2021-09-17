using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // Se importa esta libreria
using System.Linq;
using System.Threading.Tasks;



// Aca se crea el modelo de la BD
namespace apiAnimales.models
{
    public class Animales
    {
        [Key]  // se importo libreria System.ComponentModel.DataAnnotations, para indicar a la app que es la primarykey
        public int id { get; set; }

        public string nombre { get; set; }
        public int patas { get; set; }
        public string imagen { get; set; }

    }
}
