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
        private string apellido;
        private string email;
        private double efectivo; //Dinero Billetera
        private double fichas; //Dinero en fichas
        private int victorias;
        private int jugadas;

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
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
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
        public int Jugadas
        {
            get { return jugadas; }
            set { jugadas = value; }
        }
        public int Victorias
        {
            get { return victorias; }
            set { victorias = value; }
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

        public void SignUp(Player p)
        {
            PlayerDAO playerDAO = new PlayerDAO();
            Players player = new Players();
            player.User = p.User;
            player.Pass = p.Pass;
            player.Nombre = p.Nombre;
            player.Apellido = p.Apellido;
            player.Email = p.Email;
            playerDAO.AltaPlayer(player);
        }

    }
}
