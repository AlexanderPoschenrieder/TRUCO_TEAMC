using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco;

namespace TeamC
{
    class ModuloTruco
    {
        public Jugador Jugador { get; set; }
        public MisCartas Cartas { get; set; }

        public List<Carta> CartasEnMano
        {
            get { return Cartas.manos.Where(carta => !carta.yajugada).Select(c => c.carta).ToList(); }
        }


        public ModuloTruco(Jugador parent)
        {
            Jugador = parent;
        }



        public Accion ContestarTruco(Param param)
        {
            Cartas = param.misCartas;
            return Accion.retruco;
        }

        public Accion CantarTruco(Param param)
        {
            Cartas = param.misCartas;

            var cartaMasAlta = Jugador.ObtenerCartaMasAlta(Cartas);
            //if (cartaMasAlta.ranking > )
            //{
                
            //}

            return Accion.truco;
        }

        private bool GaneMano()
        {
            return false;
        }


    }
}

