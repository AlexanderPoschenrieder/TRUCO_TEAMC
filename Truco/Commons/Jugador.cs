using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace Truco
{
    public class Jugador
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public int CuantoTantoCanto { get; internal set; }

        public Jugador(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }

        public void AsignarTantosCantados(int tantos)
        {
            CuantoTantoCanto = tantos;
        }


        public virtual Logitem Jugar(Param param)
        {

            throw new NotImplementedException("Jugar no implementado");

        }

        public virtual Accion CantarEnvido(Param param, int tantos)
        {
            throw new NotImplementedException("CantarEnvido no implementado");

        }

        public virtual Accion ContestarEnvido(Param param, int tantos)
        {
            throw new NotImplementedException("ContestarEnvido no implementado");
        }

        public virtual Accion ContestarTruco(Param param)
        {

            throw new NotImplementedException("ContestarTruco no implementado");
        }

        public virtual Accion CantarTruco(Param param)
        {

            throw new NotImplementedException("CantarTruco no implementado");

        }

        public virtual Carta JugarUnaCarta(Param param)
        {
            throw new NotImplementedException("JugarUnaCarta no implementado");

        }



        /// <summary>
        /// Devuelve la carta con mayor ranking
        /// </summary>
        /// <param name="cartas"></param>
        /// <returns></returns>
        public Carta ObtenerCartaMasAlta(MisCartas cartas)
        {
            return (from c in cartas.manos
                    where c.yajugada == false
                    orderby c.carta.ranking descending
                    select c.carta).FirstOrDefault();
        }

        /// <summary>
        /// Devuelve la carta con menor ranking
        /// </summary>
        /// <param name="cartas"></param>
        /// <returns></returns>
        public Carta ObtenerCartaMasBaja(MisCartas cartas)
        {
            return (from c in cartas.manos
                    where c.yajugada == false
                    orderby c.carta.ranking ascending
                    select c.carta).FirstOrDefault();
        }

        /// <summary>
        /// Devuelve una carta con cualquier ranking
        /// </summary>
        /// <param name="cartas"></param>
        /// <returns></returns>
        public Carta ObtenerCartaRandom(MisCartas cartas)
        {
            return (from c in cartas.manos
                    where c.yajugada == false
                    select c.carta).FirstOrDefault();
        }

        /// <summary>
        /// Devuelve la carta con mayor ranking inmediato a un ranking dado.
        /// </summary>
        /// <param name="cartas">Las cartas actuales</param>
        /// <param name="rankingCartaRival">El ranking que quiero superar</param>
        /// <returns></returns>
        public Carta ObtenerCartaPrimeraGanaRival(MisCartas cartas, int rankingCartaRival)
        {
            return (from c in cartas.manos
                    where (c.yajugada == false && c.carta.ranking > rankingCartaRival)
                    orderby c.carta.ranking ascending
                    select c.carta).FirstOrDefault();
        }

        /// <summary>
        /// Devuelve True si soy mano, False si soy pie
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public Boolean SoyManoDeEstaMano(Param param)
        {
            if (param.juego.cartasEnMesa % 2 != 0)
                return false;
            else
                return true;
        }


        /// <summary>
        /// Obtiene lo ultimo que canto mi rival
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public Accion ObtenerUltimoCantoRival(Param param)
        {
            // busco lo ultimo que canto mi rival
            return (from j in param.juego.logCantos
                                 where j.jugadorid == param.rival.id
                                 select j.accion).LastOrDefault();
        }


        /// <summary>
        /// Obtiene el ranking de la ultima carta que jugo mi rival
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public Int32 ObtenerRankingUltimaCartaRival(Param param)
        {

            // busco el ranking de la ultima carta jugada por mi rival
            return (from j in param.juego.logCartas
                    where j.jugadorid == param.rival.id
                    select j.carta.ranking).LastOrDefault();
        }


    }
}
