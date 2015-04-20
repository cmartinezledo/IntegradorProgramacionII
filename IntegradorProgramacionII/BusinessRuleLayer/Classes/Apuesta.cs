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
        
        public List<Casillero> Numeros
        {
            get { return numeros; }
            set { numeros = value; }
        }
        
        public List<Ficha> Fichas
        {
            get { return fichas; }
            set { fichas = value; }
        }
        
        public Modalidad Modalidad
        {
            get { return modalidad; }
            set { modalidad = value; }
        }

        public Apuesta(List<Casillero> numeros, List<Ficha> fichas, 
            Modalidad modalidad)
        {
            this.numeros = numeros;
            this.fichas = fichas;
            this.modalidad = modalidad;
        }
    
    }
}
