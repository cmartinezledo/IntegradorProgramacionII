using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace IntegradorProgramacionII.Classes
{
    public class Player
    {
        private string user;
        private string pass;
        private string nombre;
        private double efectivo; //Dinero Billetera
        private double fichas; //Dinero en fichas

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
        public double Efectivo
        {
            get { return efectivo; }
            set { efectivo = value; }
        }
        public double Fichas
        {
            get { return fichas; }
            set { fichas = value; }
        }

        public Player()
        { 
            
        }

        public bool ValidarLogin(string user, string pass)
        {
            PlayerDAO playerDAO = new PlayerDAO();
            if (playerDAO.ValidarLogin(user, pass) != null)
                return true;
            return false;
        }

    }
}
