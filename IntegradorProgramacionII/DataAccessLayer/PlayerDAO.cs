using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PlayerDAO
    {
        public Players ValidarLogin(string user, string password)
        {
            GameModelContainer c = new GameModelContainer();
            return c.PlayerSet.Where(p => p.User == user && p.Pass == password).FirstOrDefault();
        }
        
        public void AltaPlayer(Players p) 
        {
            GameModelContainer c = new GameModelContainer();
            c.PlayerSet.Add(p);
            c.SaveChanges();
        }

        public void BajaPlayer(Players p)
        {
            GameModelContainer c = new GameModelContainer();
            var a = c.PlayerSet.Where(k => k.Id == p.Id).Single();
            c.PlayerSet.Remove(a);
            c.SaveChanges();
        }
        
        public Players BuscarUsuario(string user, string pass)
        {
            GameModelContainer c = new GameModelContainer();
            return c.PlayerSet.Where(p => p.User == user && p.Pass == pass).FirstOrDefault();
        }
    }
}
