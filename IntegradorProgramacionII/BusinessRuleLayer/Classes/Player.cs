using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegradorProgramacionII.Classes
{
    public class Player
    {
        private string user;
        private string pass;
        private string nombre;
        private Ficha[] fichas;

        public string User
        {
            get { return user; }
            set { user = value; }
        }
        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public Ficha[] Fichas
        {
            get { return fichas; }
            set { fichas = value; }
        }

        public Player()
        { 
            
        }
    }
}
