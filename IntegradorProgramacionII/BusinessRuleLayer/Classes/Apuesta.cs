using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegradorProgramacionII.Classes
{
    public class Apuesta
    {
        private Casillero numero;
        private double dinero;
        private Modalidad modalidad;
        private Player player;

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        public Casillero Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        
        public double Dinero
        {
            get { return dinero; }
            set { dinero = value; }
        }
        
        public Modalidad Modalidad
        {
            get { return modalidad; }
            set { modalidad = value; }
        }

        public Apuesta(Casillero numero, double fichas, 
            Modalidad modalidad, Player player)
        {
            this.numero = numero;
            this.dinero = fichas;
            this.modalidad = modalidad;
            this.player = player;
        }
    
    }
}
