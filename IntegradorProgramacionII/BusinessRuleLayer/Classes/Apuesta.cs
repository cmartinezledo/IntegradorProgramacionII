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
        private int dinero;
        private Modalidad modalidad;
        private Player player;

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        public List<Casillero> Numeros
        {
            get { return numeros; }
            set { numeros = value; }
        }
        
        public int Dinero
        {
            get { return dinero; }
            set { dinero = value; }
        }
        
        public Modalidad Modalidad
        {
            get { return modalidad; }
            set { modalidad = value; }
        }

        public Apuesta(List<Casillero> numeros, int fichas, 
            Modalidad modalidad, Player player)
        {
            this.numeros = numeros;
            this.dinero = fichas;
            this.modalidad = modalidad;
            this.player = player;
        }
    
    }
}
