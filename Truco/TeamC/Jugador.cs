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

        public override Accion ContestarEnvido(Param param, int tantos)
        {
            Accion accion = Accion.noquiero_tanto;
            Accion cantorival = ObtenerUltimoCantoRival(param);

            if (cantorival == Accion.envido && tantos <= 25) accion = Accion.noquiero_tanto;
            if (cantorival == Accion.envido && tantos >= 26 && tantos <= 28) accion = Accion.quiero_tanto;
            if (cantorival == Accion.envido && (tantos == 29 || tantos == 30)) accion = Accion.envidoenvido;
            if (cantorival == Accion.envido && tantos > 30) accion = Accion.realenvido;

            if (cantorival == Accion.realenvido && tantos >= 25 && tantos >= 28) accion = Accion.quiero_tanto;
            if (cantorival == Accion.realenvido && tantos >= 19) accion = Accion.quiero_tanto;

            if (cantorival == Accion.faltaenvido) accion = Accion.noquiero_tanto;

            //if (cantorival == Accion.envidoenvido && tantos > 28) accion = Accion.quiero_tanto;
            //if (cantorival == Accion.envidorealenvido && tantos > 29) accion = Accion.quiero_tanto;
            //if (cantorival == Accion.envidofaltaenvido && tantos > 30) accion = Accion.quiero_tanto;
            //if (cantorival == Accion.realenvidofaltaenvido && tantos > 30) accion = Accion.quiero_tanto;
            
            return accion;
        }

        public override Accion CantarEnvido(Param param, int tantos)
        {
            Accion accion = Accion.nulo;
            if (param.juego.quienEsMano == Quienesmano.Vos)
            {
                if (param.AccionesDisponibles.Contains(Accion.envido) && tantos >= 25 && tantos <= 29) accion = Accion.envido;
                if (param.AccionesDisponibles.Contains(Accion.realenvido) && tantos >= 29) accion = Accion.realenvido;
                //if (param.AccionesDisponibles.Contains(Accion.faltaenvido) && tantos > 30) accion = Accion.faltaenvido;
            }

            return accion;
        }
    }
}
