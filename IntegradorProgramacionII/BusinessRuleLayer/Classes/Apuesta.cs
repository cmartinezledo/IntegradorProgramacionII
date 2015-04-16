using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegradorProgramacionII.Classes
{
    public class Apuesta
    {
        private List<Casillero> numeros;
        private List<Ficha> fichas;
        private Modalidad modalidad;

        public Apuesta(List<Casillero> numeros, List<Ficha> fichas, 
            Modalidad modalidad)
        {
            this.numeros = numeros;
            this.fichas = fichas;
            this.modalidad = modalidad;
        }
    
    }
}
