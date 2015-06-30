using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace PresentationLayer.Models
{
    public class HomeViewModel
    {
        public double dinero { get; set; }
        public double fichas { get; set; }
        public string user { get; set; }
        public double partidas { get; set; }
        public double victorias { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public int avatar { get; set; }
    }
}