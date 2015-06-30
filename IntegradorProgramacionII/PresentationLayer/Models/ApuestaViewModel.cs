using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    [Serializable]
    public class ApuestaViewModel
    {
       public string modalidad { get; set; }
       public int[] numeros { get; set; }
       public int dinero { get; set; }    
    }
}