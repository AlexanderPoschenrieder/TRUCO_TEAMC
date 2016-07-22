using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Truco
{
    internal class Croupier
    {
        internal List<Carta> Mazo;
        internal RNGCryptoServiceProvider rngCsp;
        internal List<Carta> CartasRepartidas;

        internal Croupier()
        {
            rngCsp = new RNGCryptoServiceProvider();
            CartasRepartidas = new List<Carta>();

            //Crea las cartas y las agrega al mazo
            Mazo = new List<Carta>();

            // Mazo[0] es la carta nula
            Mazo.Add(new Carta(-1, -1, 0, '-', Truco.Properties.Resources.reverso));

            Mazo.Add(new Carta(0, 39, 1, 'E', Truco.Properties.Resources.e01));
            Mazo.Add(new Carta(1, 38, 1, 'B', Truco.Properties.Resources.b01));
            Mazo.Add(new Carta(2, 37, 7, 'E', Truco.Properties.Resources.e07));
            Mazo.Add(new Carta(3, 36, 7, 'O', Truco.Properties.Resources.o07));
            Mazo.Add(new Carta(4, 32, 3, 'B', Truco.Properties.Resources.b03));
            Mazo.Add(new Carta(5, 32, 3, 'C', Truco.Properties.Resources.c03));
            Mazo.Add(new Carta(6, 32, 3, 'E', Truco.Properties.Resources.e03));
            Mazo.Add(new Carta(7, 32, 3, 'O', Truco.Properties.Resources.o03));
            Mazo.Add(new Carta(8, 28, 2, 'B', Truco.Properties.Resources.b02));
            Mazo.Add(new Carta(9, 28, 2, 'C', Truco.Properties.Resources.c02));
            Mazo.Add(new Carta(10, 28, 2, 'E', Truco.Properties.Resources.e02));
            Mazo.Add(new Carta(11, 28, 2, 'O', Truco.Properties.Resources.o02));
            Mazo.Add(new Carta(12, 26, 1, 'C', Truco.Properties.Resources.c01));
            Mazo.Add(new Carta(13, 26, 1, 'O', Truco.Properties.Resources.o01));

            Mazo.Add(new Carta(14, 22, 12, 'B', Truco.Properties.Resources.b12));
            Mazo.Add(new Carta(15, 22, 12, 'C', Truco.Properties.Resources.c12));
            Mazo.Add(new Carta(16, 22, 12, 'E', Truco.Properties.Resources.e12));
            Mazo.Add(new Carta(17, 22, 12, 'O', Truco.Properties.Resources.o12));
            Mazo.Add(new Carta(18, 18, 11, 'B', Truco.Properties.Resources.b11));
            Mazo.Add(new Carta(19, 18, 11, 'C', Truco.Properties.Resources.c11));
            Mazo.Add(new Carta(20, 18, 11, 'E', Truco.Properties.Resources.e11));
            Mazo.Add(new Carta(21, 18, 11, 'O', Truco.Properties.Resources.o11));
            Mazo.Add(new Carta(22, 14, 10, 'B', Truco.Properties.Resources.b10));
            Mazo.Add(new Carta(23, 14, 10, 'C', Truco.Properties.Resources.c10));
            Mazo.Add(new Carta(24, 14, 10, 'E', Truco.Properties.Resources.e10));
            Mazo.Add(new Carta(25, 14, 10, 'O', Truco.Properties.Resources.o10));

            Mazo.Add(new Carta(26, 12, 7, 'B', Truco.Properties.Resources.b07));
            Mazo.Add(new Carta(27, 12, 7, 'C', Truco.Properties.Resources.c07));
            Mazo.Add(new Carta(28, 8, 6, 'B', Truco.Properties.Resources.b06));
            Mazo.Add(new Carta(29, 8, 6, 'C', Truco.Properties.Resources.c06));
            Mazo.Add(new Carta(30, 8, 6, 'E', Truco.Properties.Resources.e06));
            Mazo.Add(new Carta(31, 8, 6, 'O', Truco.Properties.Resources.o06));
            Mazo.Add(new Carta(32, 4, 5, 'B', Truco.Properties.Resources.b05));
            Mazo.Add(new Carta(33, 4, 5, 'C', Truco.Properties.Resources.c05));
            Mazo.Add(new Carta(34, 4, 5, 'E', Truco.Properties.Resources.e05));
            Mazo.Add(new Carta(35, 4, 5, 'O', Truco.Properties.Resources.o05));
            Mazo.Add(new Carta(36, 0, 4, 'B', Truco.Properties.Resources.b04));
            Mazo.Add(new Carta(37, 0, 4, 'C', Truco.Properties.Resources.c04));
            Mazo.Add(new Carta(38, 0, 4, 'E', Truco.Properties.Resources.e04));
            Mazo.Add(new Carta(39, 0, 4, 'O', Truco.Properties.Resources.o04));

        }

        internal MisCartas DarCartas(Partido p)
        {

            int randomcarta;
            MisCartas ret = new MisCartas();

            byte[] rc = new byte[1];

            for (int k = 1; k <= 3; k++)
            {

                if (p.modo == Modo.Play)
                {
                    do
                    {
                        rngCsp.GetBytes(rc);
                        randomcarta = Convert.ToInt32(rc[0]);

                    } while (randomcarta > 40 || randomcarta == 0 || CartasRepartidas.Contains(Mazo[randomcarta]));

                    CartasRepartidas.Add(Mazo[randomcarta]);
                    ret.manos.Add(new Mano(Mazo[randomcarta], false));
                }
                else  // modo debug
                {
                    ret.manos.Add(new Mano(DameCartaDebug(p), false));
                }
            }

            return ret;
        }

        internal Carta DameCartaDebug(Partido p)
        {
            Carta ret = null;
            if (p.debug.Length < 2)
            {

            }
            else
            {
                string s = p.debug.Substring(0, 2);
                ret = Mazo.Find(x => x.nombre == s);

                p.debug = p.debug.Substring(2, p.debug.Length - 2).Trim();
                if (ret == null)
                {
                    Main.ShowErrors("Error en archivo debug - carta " + s + " no encontrada");
                }

            }

            return ret;

        }

    }

}
