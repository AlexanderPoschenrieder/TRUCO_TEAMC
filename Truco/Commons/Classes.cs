using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public class Carta
    {
        private int cartaId;
        private char palo;
        private int numero;
        private int ranking;
        //private string imagePath;

        public Carta(int id, int ranking, int numero, char palo)
        {
            this.cartaId = id;
            this.palo = palo;
            this.numero = numero;
            this.ranking = ranking;
        }

        public String toString()
        {
            return palo.ToString() + numero.ToString();
        }
    }

    public class ManoJugador
    {
        private Mano mano;
        private Jugador jugador;
        private List<AccionesEnvido> accionesEnvido;
        private List<AccionesTruco> accionesTruco;
        private Carta cartaJugada;
    }

    public class Mano
    {
        private int manoId;
        private int manoJugadorId;

        public Mano(int manoPreviaId)
        {
            manoId = manoPreviaId + 1;

        }

        public Boolean SoyMano(int jugadorId)
        {
            return manoJugadorId == jugadorId;
        }
    }

    public class Ronda
    {
        private int Id;
        private int manoJugadorId;
        private List<Carta> cartasJugador1;
        private List<Carta> cartasJugador2;
        private List<Mano> manos;

        public Ronda(int rondaPreviaId)
        {
            this.Id = rondaPreviaId + 1;
            if (Id % 2 != 0)
                manoJugadorId = 1;
            else
                manoJugadorId = 2;

            this.manos = new List<Mano>();

        }

        internal void JugarRonda()
        {
            do
            {
                Mano mano = new Mano(manos.Count());
                

            }
            while (manos.Count() == 3);
            
        }

        internal void RepartirCartas()
        {
            Croupier croupier = new Croupier();
            List<Carta> cartasJugadorMano = new List<Carta>();
            List<Carta> cartasJugadorPie = new List<Carta>();
            cartasJugadorMano.Add(croupier.DarCarta());
            cartasJugadorPie.Add(croupier.DarCarta());
            cartasJugadorMano.Add(croupier.DarCarta());
            cartasJugadorPie.Add(croupier.DarCarta());
            cartasJugadorMano.Add(croupier.DarCarta());
            cartasJugadorPie.Add(croupier.DarCarta());
            cartasJugador1 = ((SoyMano(1)) ? cartasJugadorMano : cartasJugadorPie);
            cartasJugador2 = ((SoyMano(2)) ? cartasJugadorMano : cartasJugadorPie);
        }

        internal void SumarPuntos()
        {
            throw new NotImplementedException();
        }

        internal Boolean SoyMano(int jugadorId)
        {
            return manoJugadorId == jugadorId;
        }

    }

    public class Partido
    {
        private int partidoId;
        private Jugador jugador1;
        private Jugador jugador2;
        private List<Ronda> rondas;
        private int puntosJugador1;
        private int puntosJugador2;

        public Partido(string nombreJugador1, string nombreJugador2)
        {
            this.partidoId = new Random().Next(int.MinValue, int.MaxValue);
            this.jugador1 = new Jugador(1, nombreJugador1);
            this.jugador2 = new Jugador(2, nombreJugador2);
            this.rondas = new List<Ronda>();
            this.puntosJugador1 = 0;
            this.puntosJugador2 = 0;

            JugarPartido();
        }

        private void JugarPartido()
        {

            do
            {
                Ronda ronda = new Ronda(rondas.Count());
                ronda.RepartirCartas();
                ronda.JugarRonda();
                ronda.SumarPuntos();
                rondas.Add(ronda);
            }
            while (puntosJugador1 < 30 && puntosJugador2 < 30);

        }
    }

    public class Jugador
    {
        public int Id { get; internal set; }
        public string nombre { get; internal set; }
        private int puntos;

        public Jugador(int id, string nombre)
        {
            this.Id = id;
            this.nombre = nombre;
            this.puntos = 0;
        }

        internal void SumarPuntos(int puntos)
        {
            this.puntos += puntos;
        }
    }

    public class Croupier
    {
        private List<Carta> Mazo;
        private List<Carta> CartasRepartidas;
        private RNGCryptoServiceProvider rngCsp;

        public Croupier()
        {
            rngCsp = new RNGCryptoServiceProvider();
            CartasRepartidas = new List<Carta>();
            Mazo = new List<Carta>();

            // Mazo[0] es la carta nula
            //Cartas.Add(new Carta(-1, -1, 0, '-'  Properties.Resources.reverso));

            Mazo.Add(new Carta(0, 39, 1, 'E'));
            Mazo.Add(new Carta(1, 38, 1, 'B'));
            Mazo.Add(new Carta(2, 37, 7, 'E'));
            Mazo.Add(new Carta(3, 36, 7, 'O'));
            Mazo.Add(new Carta(4, 32, 3, 'B'));
            Mazo.Add(new Carta(5, 32, 3, 'C'));
            Mazo.Add(new Carta(6, 32, 3, 'E'));
            Mazo.Add(new Carta(7, 32, 3, 'O'));
            Mazo.Add(new Carta(8, 28, 2, 'B'));
            Mazo.Add(new Carta(9, 28, 2, 'C'));
            Mazo.Add(new Carta(10, 28, 2, 'E'));
            Mazo.Add(new Carta(11, 28, 2, 'O'));
            Mazo.Add(new Carta(12, 26, 1, 'C'));
            Mazo.Add(new Carta(13, 26, 1, 'O'));

            Mazo.Add(new Carta(14, 22, 12, 'B'));
            Mazo.Add(new Carta(15, 22, 12, 'C'));
            Mazo.Add(new Carta(16, 22, 12, 'E'));
            Mazo.Add(new Carta(17, 22, 12, 'O'));
            Mazo.Add(new Carta(18, 18, 11, 'B'));
            Mazo.Add(new Carta(19, 18, 11, 'C'));
            Mazo.Add(new Carta(20, 18, 11, 'E'));
            Mazo.Add(new Carta(21, 18, 11, 'O'));
            Mazo.Add(new Carta(22, 14, 10, 'B'));
            Mazo.Add(new Carta(23, 14, 10, 'C'));
            Mazo.Add(new Carta(24, 14, 10, 'E'));
            Mazo.Add(new Carta(25, 14, 10, 'O'));

            Mazo.Add(new Carta(26, 12, 7, 'B'));
            Mazo.Add(new Carta(27, 12, 7, 'C'));
            Mazo.Add(new Carta(28, 8, 6, 'B'));
            Mazo.Add(new Carta(29, 8, 6, 'C'));
            Mazo.Add(new Carta(30, 8, 6, 'E'));
            Mazo.Add(new Carta(31, 8, 6, 'O'));
            Mazo.Add(new Carta(32, 4, 5, 'B'));
            Mazo.Add(new Carta(33, 4, 5, 'C'));
            Mazo.Add(new Carta(34, 4, 5, 'E'));
            Mazo.Add(new Carta(35, 4, 5, 'O'));
            Mazo.Add(new Carta(36, 0, 4, 'B'));
            Mazo.Add(new Carta(37, 0, 4, 'C'));
            Mazo.Add(new Carta(38, 0, 4, 'E'));
            Mazo.Add(new Carta(39, 0, 4, 'O'));
        }

        public Carta DarCarta()
        {
            int cartaIndex;
            byte[] rc;
            do
            {
                rc = new byte[1];
                rngCsp.GetBytes(rc);
                cartaIndex = Convert.ToInt32(rc[0]);

            }
            while (cartaIndex > 40 || cartaIndex == 0 || CartasRepartidas.Contains(Mazo[cartaIndex]));
            CartasRepartidas.Add(Mazo[cartaIndex]);
            return Mazo[cartaIndex];
        }
    }

    public enum AccionesEnvido
    {
        Envido,
        RealEnvido,
        FaltaEnvido,
        EnvidoEnvido,
        EnvidoRealEnvido,
        EnvidoFaltaEnvido,
        RealEnvidoFaltaEnvido,
        Quiero,
        NoQuiero
    }

    public enum AccionesTruco
    {
        Truco,
        ReTruco,
        ValeCuatro,
        Quiero,
        NoQuiero,
    }

    public enum EstadoPartido
    {
        Iniciado,
        Jugando,
        Finalizado,
        Pausa
    }
}
