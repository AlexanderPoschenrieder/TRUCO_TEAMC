using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using TeamC;

namespace Truco
{
    public class TeamC : Jugador
    {
        public TeamC(int id, string nombre)
            : base(id, nombre)
        {
        }

        public override Accion ContestarTruco(Param param)
        {
            var moduloTruco = new ModuloTruco();
            return moduloTruco.ContestarTruco(param);
        }

        public override Accion CantarTruco(Param param)
        {
            return Accion.truco;
        }


    }
}
