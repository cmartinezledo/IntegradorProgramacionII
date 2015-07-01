using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegradorProgramacionII.Classes
{
    public class Modalidad
    {
        private String nombre;
        private int multiplicador;

        public Modalidad(String nombre) 
        {
            switch (nombre)
            {
                case "Pleno":
                    this.multiplicador = 35;
                    break;
                case "Semi":
                    this.multiplicador = 17;
                    break;
                case "Calle":
                    this.multiplicador = 11;
                    break;
                case "Cuadro": case "Cubre":
                    this.multiplicador = 8;
                    break;
                case "Linea":
                    this.multiplicador = 5;
                    break;
                case "Columna": case "Docena":
                    this.multiplicador = 2;
                    break;
                case "Chances Simples": //Color, Paridad, 1-18, 19-36
                    this.multiplicador = 1;
                    break;
            }
            this.nombre = nombre;
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Multiplicador
        {
            get { return multiplicador; }
            set { multiplicador = value; }
        }
    }
}
