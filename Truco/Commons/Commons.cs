using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Resources;

namespace Truco
{


    public class Param
    {
        /// <summary>
        /// Datos propios: id, nombre, puntos en el partido
        /// </summary>
        public Yo yo { get; private set; }

        /// <summary>
        /// Datos del rival y puntos del envido si fue cantado
        /// </summary>
        public Rival rival { get; private set; }

        /// <summary>
        /// Datos generales del partido, ronda o mano, quien es mano?, cantidad de cartas en la mesa, log de cartas y log de cantos.
        /// </summary>
        public Juego juego { get; private set; }

        /// <summary>
        /// Las cartas que tengo, es una lista de objetos de tipo "Mano" que contienen un objeto carta y si ya fue jugada o no.
        /// </summary>
        public MisCartas misCartas { get; private set; }

        /// <summary>
        /// Listado de acciones disponibles para cantar.
        /// </summary>
        public List<Accion> AccionesDisponibles { get; private set; }

        public Param(int partidoid, int yoid, string yonombre, int yoporotos, int rivalid, string rivalnombre, int rivalporotos, int rivaltantosenvido, Quienesmano quienesmano, int manonumero, int cartasenmesa, List<Logitem> logcartas, List<Logitem> logcantos, MisCartas miscartas, List<Accion> quepuedocantar)
        {
            this.yo = new Yo(yoid, yonombre, yoporotos);
            this.rival = new Rival(rivalid, rivalnombre, rivalporotos, rivaltantosenvido);
            this.juego = new Juego(partidoid, quienesmano, manonumero, cartasenmesa, logcartas, logcantos);
            this.misCartas = miscartas;
            this.AccionesDisponibles = (from accion in quepuedocantar
                                   select accion).ToList();
        }

        public class Yo
        {
            public int id { get; private set; }
            public string nombre { get; private set; }

            /// <summary>
            /// Mis puntos en el partido
            /// </summary>
            public int puntos { get; private set; }

            public Yo(int id, string nombre, int puntos)
            {
                this.id = id;
                this.nombre = nombre;
                this.puntos = puntos;
            }
        }

        public class Rival
        {
            public int id { get; private set; }
            public string nombre { get; private set; }

            /// <summary>
            /// Puntos del rival en el partido
            /// </summary>
            public int puntos { get; private set; }

            /// <summary>
            /// Contiene los puntos cantados de envido del rival, solo si se canto.
            /// </summary>
            public int tantosEnvido { get; private set; }

            public Rival(int id, string nombre, int puntos, int tantosenvido)
            {
                this.id = id;
                this.nombre = nombre;
                this.puntos = puntos;
                this.tantosEnvido = tantosenvido;
            }
        }

        public class Juego
        {

            /// <summary>
            /// Id del partido
            /// </summary>
            public int partidoId { get; private set; }

            /// <summary>
            /// Quien juega primero en la mano en juego
            /// </summary>
            public Quienesmano quienEsMano { get; private set; }

            /// <summary>
            /// Devuelve el numero de mano dentro de la ronda: 1, 2 o 3.
            /// </summary>
            public int manoNumero { get; private set; }

            /// <summary>
            /// Cantidad de cartas que hay en mesa
            /// </summary>
            public int cartasEnMesa { get; private set; }

            /// <summary>
            /// Log de cartas jugadas
            /// </summary>
            public List<Logitem> logCartas { get; private set; }

            /// <summary>
            /// Log de cosas cantadas
            /// </summary>
            public List<Logitem> logCantos { get; private set; }

            public Juego(int partidoid, Quienesmano quienesmano, int manonumero, int cartasenmesa, List<Logitem> logcartas, List<Logitem> logcantos)
            {
                this.partidoId = partidoid;
                this.quienEsMano = quienesmano;
                this.manoNumero = manonumero;
                this.cartasEnMesa = cartasenmesa;
                this.logCantos = logcantos;
                this.logCartas = logcartas;
            }

        }

    }

    public class MisCartas
    {
        public List<Mano> manos { get; private set; }

        public MisCartas()
        {
            this.manos = new List<Mano>();
        }

        public MisCartas(List<Mano> manos)
        {
            this.manos = new List<Mano>(from m in manos
                                        select m.Clone(m));

        }

        private class CartaEnvido
        {
            public int nro;
            public char palo;

            public CartaEnvido(int nro, char palo)
            {
                this.nro = nro;
                this.palo = palo;
            }

        }

        public int CalcularEnvido()
        {
            int nro, ret;
            List<CartaEnvido> c = new List<CartaEnvido>();
            for (int i = 0; i < 3; i++)
            {
                nro = manos[i].carta.nro;
                if (nro == 10 || nro == 11 || nro == 12) { nro = 0; };
                c.Add(new CartaEnvido(nro, manos[i].carta.palo));
            }

            var d = c.OrderByDescending(o => o.nro).ToList();

            if (d[0].palo == d[1].palo) { ret = d[0].nro + d[1].nro + 20; }
            else if (d[0].palo == d[2].palo) { ret = d[0].nro + d[2].nro + 20; }
            else if (d[1].palo == d[2].palo) { ret = d[1].nro + d[2].nro + 20; }
            else { ret = d[0].nro; }

            return ret;
        }



    }

    public class Mano
    {
        public Carta carta { get; private set; }
        public bool yajugada { get; private set; }

        public Mano(Carta carta, bool yajugada)
        {
            this.carta = carta;
            this.yajugada = yajugada;
        }

        public void JugoCarta()
        {
            yajugada = true;
        }

        public Mano Clone(Mano org)
        {
            return new Mano(org.carta, org.yajugada);
        }

    }

    public class Carta
    {
        public int id { get; private set; }

        //Ranking de la carta, el Ancho de espada es el mas alto
        public int ranking { get; private set; }

        //Numero de la carta
        public int nro { get; private set; }

        //Palo: Basto (B), Copa (C), Espada (E) y Oro (O)
        public char palo { get; private set; }

        //Nombre de la carta
        public string nombre { get; private set; }

        //Imagen de la carta
        public Image imagen { get; private set; }

        public Carta(int id, int ranking, int nro, char palo, Image imagen)
        {
            this.id = id;
            this.ranking = ranking;
            this.nro = nro;
            this.palo = palo; ; ;
            this.imagen = imagen;

            string s;
            switch (nro)
            {
                case 10: s = "S"; break;
                case 11: s = "C"; break;
                case 12: s = "R"; break;
                default: s = nro.ToString(); break;
            }

            this.nombre = s + palo;

        }

    }

    public class Logitem
    {
        public int jugadorid { get; private set; }
        public Accion accion { get; private set; }
        public Carta carta { get; private set; }

        public Logitem(int jugadorid)
        {
            this.jugadorid = jugadorid;
        }

        public Logitem(int jugadorid, Accion accion, Carta carta)
        {
            this.jugadorid = jugadorid;
            this.accion = accion;
            this.carta = carta;
        }

        public Logitem(int jugadorid, Accion accion)
        {
            this.jugadorid = jugadorid;
            this.accion = accion;
        }


    }

    public class Log
    {
        public List<Logitem> logitemcarta { get; private set; }
        public List<Logitem> logitemcanto { get; private set; }

        public Log()
        {
            this.logitemcarta = new List<Logitem>();
            this.logitemcanto = new List<Logitem>();
        }

    }


    /// <summary>
    /// Hay quieros y no quiero distintos para envido y para truco
    /// </summary>
    public enum Accion
    {
        nulo,
        juegacarta,
        truco,
        retruco,
        valecuatro,
        quiero_truco,
        noquiero_truco,
        envido,
        realenvido,
        faltaenvido,
        envidoenvido,
        envidorealenvido,
        envidofaltaenvido,
        realenvidofaltaenvido,
        quiero_tanto,
        noquiero_tanto
    }

    public enum Modo
    {
        Play,
        Debug
    }

    public enum Quienesmano
    {
        Vos,
        Rival
    };



}
