using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegradorProgramacionII.Classes
{   
    public class Ruleta
    {
        public Casillero[] tablero = new Casillero[49];
        public List<Apuesta> apuestas = new List<Apuesta>();

        public Ruleta()
        {
            //Carga Inicial
            for (int i = 0; i < 49; i++)
            {
                tablero[i] = new Casillero();
                tablero[i].Valor = i;
            }

            tablero[1].Color = "Rojo";
            tablero[2].Color = "Negro";
            tablero[3].Color = "Rojo";
            tablero[4].Color = "Negro";
            tablero[5].Color = "Rojo";
            tablero[6].Color = "Negro";
            tablero[7].Color = "Rojo";
            tablero[8].Color = "Negro";
            tablero[9].Color = "Rojo";
            tablero[10].Color = "Negro";
            tablero[11].Color = "Negro";
            tablero[12].Color = "Rojo";
            tablero[13].Color = "Negro";
            tablero[14].Color = "Rojo";
            tablero[15].Color = "Negro";
            tablero[16].Color = "Rojo";
            tablero[17].Color = "Negro";
            tablero[18].Color = "Rojo";
            tablero[19].Color = "Rojo";
            tablero[20].Color = "Negro";
            tablero[21].Color = "Rojo";
            tablero[22].Color = "Negro";
            tablero[23].Color = "Rojo";
            tablero[24].Color = "Negro";
            tablero[25].Color = "Rojo";
            tablero[26].Color = "Negro";
            tablero[27].Color = "Rojo";
            tablero[28].Color = "Negro";
            tablero[29].Color = "Negro";
            tablero[30].Color = "Rojo";
            tablero[31].Color = "Negro";
            tablero[32].Color = "Rojo";
            tablero[33].Color = "Negro";
            tablero[34].Color = "Rojo";
            tablero[35].Color = "Negro";
            tablero[36].Color = "Rojo";

            // 37 par
            // 38 impar
            // 39 rojo
            // 40 negro
            // 41 docena
            // 42 2da
            // 43 3era
            // 44 1/18
            // 45 19/36
            // 46 fila 1
            // 47 fila 2
            // 48 fila 3
        }

        public void Apostar(Apuesta apuesta) 
        {
            apuestas.Add(apuesta);
        }
            
    }
}
