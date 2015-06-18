﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PlayerDAO
    {
        public Player ValidarLogin(string user, string password)
        {
            GameModelContainer c = new GameModelContainer();
            return c.PlayerSet.Where(p => p.Nombre == user && p.Password == password).FirstOrDefault();
        }
        
        public void AltaPlayer(Player p) 
        {
            GameModelContainer c = new GameModelContainer();
            c.PlayerSet.Add(p);
            c.SaveChanges();
        }

        public void BajaPlayer(Player p)
        {
            GameModelContainer c = new GameModelContainer();
            var a = c.PlayerSet.Where(k => k.Id == p.Id).Single();
            c.PlayerSet.Remove(a);
            c.SaveChanges();
        }
        /*
        public Player BuscarUsuario(int id)
        {
            GameModelContainer c = new GameModelContainer();
            //return c.PlayerSet.Find(id);
            return c.PlayerSet.Where(p => p.Id == id).FirstOrDefault();
        }
         * */
    }
}
