using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco
{
    public class TeamGeneric : Jugador
    {
        public TeamGeneric(int id, string nombre)
            : base(id, nombre)
        {

        }


        public override Logitem Jugar(Param param)
        {
            Accion accion = Accion.nulo;
            int tantos = param.misCartas.CalcularEnvido();

            // JUEGO ENVIDO
            

            // Puedo o Quiero cantar envido?
            if (param.AccionesDisponibles.Exists(x => x == Accion.envido || x == Accion.realenvido || x == Accion.faltaenvido))
            {
                accion = CantarEnvido(param, tantos);
                if (accion != Accion.nulo)
                    return new Logitem(param.yo.id, accion);
            }

            // Mi rival canto el Envido y tengo que contestar
            else if (param.AccionesDisponibles.Exists(x => x == Accion.envidoenvido || x == Accion.envidofaltaenvido || x == Accion.envidorealenvido || x == Accion.realenvidofaltaenvido || x == Accion.quiero_tanto))
            {
                accion = ContestarEnvido(param, tantos);
                return new Logitem(param.yo.id, accion);
            }


            // Ahora empezamos con el truco
            //            if (cantorival == Accion.truco || cantorival == Accion.retruco || cantorival == Accion.valecuatro)

            if (param.AccionesDisponibles.Exists(x => x == Accion.quiero_truco))
            {  // Mi rival canto algun truco, le contesto
                accion = ContestarTruco(param);
                return new Logitem(param.yo.id, accion);
            }


            //  Canto algo?
            accion = CantarTruco(param);
            if (accion != Accion.nulo) return new Logitem(param.yo.id, accion);


            // Si no canto nada ni tengo nada para contestar, juego la carta
            accion = Accion.juegacarta;
            Carta carta = JugarUnaCarta(param);

            return new Logitem(param.yo.id, accion, carta);

        }

        public override Accion CantarEnvido(Param param, int tantos)
        {
            Accion accion = Accion.nulo;
            if (param.AccionesDisponibles.Contains(Accion.envido) && tantos > 25) accion = Accion.envido;
            if (param.AccionesDisponibles.Contains(Accion.realenvido) && tantos > 28) accion = Accion.realenvido;
            if (param.AccionesDisponibles.Contains(Accion.faltaenvido) && tantos > 30) accion = Accion.faltaenvido;

            return accion;

        }

        public override Accion ContestarEnvido(Param param, int tantos)
        {
            Accion accion = Accion.noquiero_tanto;
            Accion cantorival = ObtenerUltimoCantoRival(param);

            if (cantorival == Accion.envido && tantos > 24) accion = Accion.quiero_tanto;
            if (cantorival == Accion.envido && tantos > 27) accion = Accion.envidoenvido;
            if (cantorival == Accion.envido && tantos > 29) accion = Accion.envidorealenvido;
            if (cantorival == Accion.envido && tantos > 31) accion = Accion.envidofaltaenvido;

            if (cantorival == Accion.realenvido && tantos > 26) accion = Accion.quiero_tanto;
            if (cantorival == Accion.realenvido && tantos > 31) accion = Accion.realenvidofaltaenvido;

            if (cantorival == Accion.faltaenvido && tantos > 30) accion = Accion.quiero_tanto;

            if (cantorival == Accion.envidoenvido && tantos > 28) accion = Accion.quiero_tanto;
            if (cantorival == Accion.envidorealenvido && tantos > 29) accion = Accion.quiero_tanto;
            if (cantorival == Accion.envidofaltaenvido && tantos > 30) accion = Accion.quiero_tanto;
            if (cantorival == Accion.realenvidofaltaenvido && tantos > 30) accion = Accion.quiero_tanto;

            return accion;
        }

        public override Accion ContestarTruco(Param param)
        {

            Accion accion = Accion.noquiero_truco;
            Accion cantorival = ObtenerUltimoCantoRival(param);

            // ranking promedio de mis cartas
            int rankingpromedio = Convert.ToInt32(param.misCartas.manos.Average(a => a.carta.ranking));

            if (cantorival == Accion.truco && rankingpromedio > 15) { accion = Accion.quiero_truco; }
            if (cantorival == Accion.truco && rankingpromedio > 25) { accion = Accion.retruco; }

            if (cantorival == Accion.retruco && rankingpromedio > 20) { accion = Accion.quiero_truco; }
            if (cantorival == Accion.retruco && rankingpromedio > 30) { accion = Accion.valecuatro; }

            if (cantorival == Accion.valecuatro && rankingpromedio > 25) { accion = Accion.quiero_truco; }

            return accion;
        }

        public override Accion CantarTruco(Param param)
        {
            Accion accion = Accion.nulo;
            // ranking promedio de mis cartas
            int rankingpromedio = Convert.ToInt32(param.misCartas.manos.Average(a => a.carta.ranking));

            if (param.AccionesDisponibles.Contains(Accion.truco) && rankingpromedio > 20) accion = Accion.truco;
            if (param.AccionesDisponibles.Contains(Accion.retruco) && rankingpromedio > 25) accion = Accion.retruco;
            if (param.AccionesDisponibles.Contains(Accion.valecuatro) && rankingpromedio > 30) accion = Accion.valecuatro;
            return accion;

        }

        public override Carta JugarUnaCarta(Param param)
        {
            Carta carta;

            // busco el ranking de la ultima carta jugada por mi rival
            int rankingcartarival = (from j in param.juego.logCartas
                                     where j.jugadorid == param.rival.id
                                     select j.carta.ranking).LastOrDefault();


            if (!SoyManoDeEstaMano(param)) // mi rival ya jugo, trato de ganar esta mano
            {
                carta = ObtenerCartaPrimeraGanaRival(param.misCartas, rankingcartarival);
                if (carta == null) carta = ObtenerCartaMasBaja(param.misCartas);
            }
            else
            //arranco jugando yo la mano y pongo una carta cualquiera
            {
                carta = ObtenerCartaRandom(param.misCartas);
            }

            return carta;

        }

    }

}
