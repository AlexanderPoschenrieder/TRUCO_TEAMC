using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco
{
    internal class Partido
    {
        internal int id { get; set; }
        internal Jugador jugadorizq { get; set; }
        internal Jugador jugadorder { get; set; }
        internal int puntosJugadorIzq { get; set; }
        internal int puntosJugadorDer { get; set; }
        internal List<MisCartas> manosJugadorIzq { get; set; }
        internal List<MisCartas> manosJugadorDer { get; set; }
        internal Log log { get; set; }
        internal int rondaNro { get; set; }
        internal Modo modo { get; set; }
        internal String debug { get; set; }
        internal Jugador jugadormano { get; set; }

        internal Partido(Jugador jugadorIzq, Jugador jugadorDer, Modo modo, String debug, Jugador jugadormano)
        {
            this.id = Convert.ToInt32(new TimeSpan(DateTime.Now.Ticks - DateTime.Today.Ticks).TotalSeconds);
            this.jugadorizq = jugadorIzq;
            this.jugadorder = jugadorDer;
            this.puntosJugadorDer = 0;
            this.puntosJugadorIzq = 0;
            this.manosJugadorIzq = new List<MisCartas>();
            this.manosJugadorDer = new List<MisCartas>();
            this.log = new Log();
            this.rondaNro = 0;
            this.modo = modo;
            this.debug = debug.Trim();
            this.jugadormano = jugadormano;
        }

        internal void DarCartas(int jugadorID, MisCartas cartas)
        {
            if (jugadorizq.Id == jugadorID)
                manosJugadorIzq.Add(cartas);
            else
                manosJugadorDer.Add(cartas);
        }

        internal MisCartas VerCartas(int jugadorID)
        {
            if (jugadorizq.Id == jugadorID)
                return manosJugadorIzq[rondaNro - 1];
            else
                return manosJugadorDer[rondaNro - 1];
        }

        internal void SumarPuntos(int jugadorID, int puntos)
        {
            if (jugadorizq.Id == jugadorID)
                this.puntosJugadorIzq += puntos;
            else
                this.puntosJugadorDer += puntos;

        }

        internal int VerPuntos(int jugadorID)
        {
            if (jugadorizq.Id == jugadorID)
                return puntosJugadorIzq;
            else
                return puntosJugadorDer;
        }

    }
}
