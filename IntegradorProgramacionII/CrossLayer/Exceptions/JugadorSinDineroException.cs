using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossLayer.Exceptions
{
    public class JugadorSinDineroException:ApplicationException
    {
        public JugadorSinDineroException(string jugador) : base(string.Format("El jugador {0} no tiene dinero suficiente", jugador)) { }
    }
}
