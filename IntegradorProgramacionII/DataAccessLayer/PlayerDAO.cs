using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PlayerDAO
    {
        private GameModelContainer c;

        public Players ValidarLogin(string user, string password)
        {
            c = new GameModelContainer();
            return c.PlayerSet.Where(p => p.User == user && p.Pass == password).FirstOrDefault();
        }
        
        public void AltaPlayer(Players p) 
        {
            c = new GameModelContainer();
            c.PlayerSet.Add(p);
            c.SaveChanges();
        }

        public void BajaPlayer(Players p)
        {
            c = new GameModelContainer();
            var a = c.PlayerSet.Where(k => k.Id == p.Id).Single();
            c.PlayerSet.Remove(a);
            c.SaveChanges();
        }
        
        public void Comprar(int id, double fichas)
        {
            c = new GameModelContainer();
            var original = c.PlayerSet.Find(id);

            if(original != null)
            {
                original.Fichas += fichas;
                original.Efectivo -= fichas;
                c.SaveChanges();
            } 
        }

        public void Guardar(int id, double fichas, Boolean victoria) 
        {
            c = new GameModelContainer();
            var original = c.PlayerSet.Find(id);

            if (original != null)
            {
                original.Fichas += fichas;
                original.Jugadas++;
                if (!victoria)
                    original.Victorias--;
                else
                    original.Victorias++;
                c.SaveChanges();
            }
        }

        public Players BuscarUsuario(string user, string pass)
        {
            c = new GameModelContainer();
            return c.PlayerSet.Where(p => p.User == user && p.Pass == pass).FirstOrDefault();
        }
    }
}
