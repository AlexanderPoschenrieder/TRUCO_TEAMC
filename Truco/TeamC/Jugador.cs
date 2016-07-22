using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

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
            ////var moduloTruco = new ModuloTruco(this);
            ////return moduloTruco.ContestarTruco(param);
            //var cartas = param.misCartas;
            //Accion accion = Accion.noquiero_truco;
            //Accion cantorival = ObtenerUltimoCantoRival(param);

            //// ranking promedio de mis cartas
            //int rankingpromedio = Convert.ToInt32(param.misCartas.manos.Average(a => a.carta.ranking));

            //if (cantorival == Accion.truco && TengoMasDeUnDos(cartas)) { accion = Accion.quiero_truco; }
            //if (cantorival == Accion.truco && TengoMasDeUnSiete(cartas)) { accion = Accion.retruco; }

            //if (cantorival == Accion.retruco && TengoMasDeUnSiete(cartas)) { accion = Accion.quiero_truco; }
            //if (cantorival == Accion.retruco && TengoUnAncho(cartas)) { accion = Accion.valecuatro; }

            //if (cantorival == Accion.valecuatro && TengoUnAncho(cartas)) { accion = Accion.quiero_truco; }

            //return accion;

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
            //Accion accion = Accion.nulo;
            //var cartas = param.misCartas;
            //// ranking promedio de mis cartas
            //int rankingpromedio = Convert.ToInt32(param.misCartas.manos.Average(a => a.carta.ranking));

            //if (param.AccionesDisponibles.Contains(Accion.truco) && TengoMasDeUnDos(cartas)) accion = Accion.truco;
            //if (param.AccionesDisponibles.Contains(Accion.retruco) && TengoMasDeUnSiete(cartas)) accion = Accion.retruco;
            //if (param.AccionesDisponibles.Contains(Accion.valecuatro) && TengoUnAncho(cartas)) accion = Accion.valecuatro;
            //return accion;

            Accion accion = Accion.nulo;
            // ranking promedio de mis cartas
            int rankingpromedio = Convert.ToInt32(param.misCartas.manos.Average(a => a.carta.ranking));

            if (param.AccionesDisponibles.Contains(Accion.truco) && rankingpromedio > 20) accion = Accion.truco;
            if (param.AccionesDisponibles.Contains(Accion.retruco) && rankingpromedio > 25) accion = Accion.retruco;
            if (param.AccionesDisponibles.Contains(Accion.valecuatro) && rankingpromedio > 30) accion = Accion.valecuatro;
            return accion;
        }

        public override Accion ContestarEnvido(Param param, int tantos)
        {
            Accion accion = Accion.noquiero_tanto;
            Accion cantorival = ObtenerUltimoCantoRival(param);

            if (cantorival == Accion.envido && param.AccionesDisponibles.Contains(Accion.noquiero_tanto) && tantos <= 23) accion = Accion.noquiero_tanto;
            if (cantorival == Accion.envido && param.AccionesDisponibles.Contains(Accion.quiero_tanto) && tantos >= 24 && tantos <= 28) accion = Accion.quiero_tanto;
            if (cantorival == Accion.envido && param.AccionesDisponibles.Contains(Accion.envidoenvido) && (tantos == 29 || tantos == 30)) accion = Accion.envidoenvido;
            if (cantorival == Accion.envido && param.AccionesDisponibles.Contains(Accion.realenvido) && tantos > 30) accion = Accion.realenvido;

            if (cantorival == Accion.realenvido && param.AccionesDisponibles.Contains(Accion.noquiero_tanto) && tantos >= 25 && tantos <= 28) accion = Accion.noquiero_tanto;
            if (cantorival == Accion.realenvido && param.AccionesDisponibles.Contains(Accion.quiero_tanto) && tantos >= 29 && tantos <= 30) accion = Accion.quiero_tanto;
            if (cantorival == Accion.realenvido && param.AccionesDisponibles.Contains(Accion.quiero_tanto) && tantos >= 31) accion = Accion.faltaenvido;

            if (cantorival == Accion.faltaenvido && param.AccionesDisponibles.Contains(Accion.quiero_tanto) && tantos >= 30) accion = Accion.quiero_tanto;
                        
            return accion;
        }

        public override Accion CantarEnvido(Param param, int tantos)
        {
            Accion accion = Accion.nulo;
            if (param.juego.quienEsMano == Quienesmano.Vos)
            {
                if (param.AccionesDisponibles.Contains(Accion.envido) && tantos >= 21 && tantos <= 27) accion = Accion.envido;
                if (param.AccionesDisponibles.Contains(Accion.realenvido) && tantos >= 28 && tantos <= 30) accion = Accion.realenvido;
                if (param.AccionesDisponibles.Contains(Accion.faltaenvido) && tantos >= 31) accion = Accion.faltaenvido;
            }
            else
            {
                if (param.AccionesDisponibles.Contains(Accion.faltaenvido))
                {
                    int yoPuntos = param.rival.puntos;
                    int rivalPuntos = param.yo.puntos;
                    bool faltaEnvido = ((yoPuntos < rivalPuntos) && (rivalPuntos - yoPuntos) > 6);
                    Random rn = new Random();
                    int radm = rn.Next(0, 10);
                    if (faltaEnvido || radm > 4)
                    {
                        accion = Accion.faltaenvido;
                    }
                }
            }

            return accion;
        }

        private Carta JugarCartaPrimeraMano(Param param) { 
            Carta carta = null;
            
         
            if (NoTengoNada(param.misCartas))
            {
                carta = carta = ObtenerCartaMasAlta(param.misCartas); 
            }
            else
            {
                if (TengoUnSiete(param.misCartas))
                {
                    if (TengoUnAncho(param.misCartas))
                    {
                        var paloDelSiete = 'E';
                        if (!TengoElSieteDeEspadas(param.misCartas))
                            paloDelSiete = 'O';

                        List<Mano> manos = param.misCartas.manos.Where(c => !c.yajugada && c.carta.nro == 7 && c.carta.palo == paloDelSiete).ToList();
                        if (manos.FirstOrDefault() != null)
                        {
                            carta = manos.FirstOrDefault().carta;
                        }
                    }

                    if (TengoUnTres(param.misCartas))
                    {
                        if (TengoElSieteDeEspadas(param.misCartas))
                        {
                            carta = param.misCartas.manos.Where(c => !c.yajugada && c.carta.nro == 3).FirstOrDefault().carta;
                        }
                        else
                        {
                            carta = param.misCartas.manos.Where(c => !c.yajugada && c.carta.nro == 7 && c.carta.palo == 'O').FirstOrDefault().carta;
                        }
                    }

                    else
                    {
                        var paloDelSiete = 'E';
                        if (!TengoElSieteDeEspadas(param.misCartas))
                            paloDelSiete = 'O';

                        List<Mano> manos = param.misCartas.manos.Where(c => !c.yajugada && c.carta.nro == 7 && c.carta.palo == paloDelSiete).ToList();
                        if (manos.FirstOrDefault() != null)
                        {
                            carta = manos.FirstOrDefault().carta;
                        }

                    }
                }
                else {

                    if (TengoUnAncho(param.misCartas))
                    {
                        if (TengoUnTres(param.misCartas))
                        {
                            carta = param.misCartas.manos.Where(c => !c.yajugada && c.carta.nro == 3).FirstOrDefault().carta;
                        }
                        else if (TengoUnDos(param.misCartas))
                        {
                            carta = param.misCartas.manos.Where(c => !c.yajugada && c.carta.nro == 2).FirstOrDefault().carta;
                        }
                        else
                        {
                            var paloAncho = 'E';

                            if (!TengoElAnchoDeEspada(param.misCartas))
                            {
                                paloAncho = 'B';
                            }

                            carta = param.misCartas.manos.Where(c => !c.yajugada && c.carta.nro == 1 && c.carta.palo == paloAncho).FirstOrDefault().carta;
                        }
                    }

                    else {
                        carta = ObtenerCartaMasAlta(param.misCartas);
                    }
                }


                }
            return carta;
        }

          public override Carta JugarUnaCarta(Param param)
        {
            Carta carta = null;

            if (SoyManoDeEstaMano(param) && param.juego.manoNumero == 1)
            {
                carta = JugarCartaPrimeraMano(param);
            }
            else
            {
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
            }
            return carta;
        }

            //// busco el ranking de la ultima carta jugada por mi rival
            //int rankingcartarival = (from j in param.juego.logCartas
            //                         where j.jugadorid == param.rival.id
            //                         select j.carta.ranking).LastOrDefault();


            //if (!SoyManoDeEstaMano(param)) // mi rival ya jugo, trato de ganar esta mano
            //{
            //    carta = ObtenerCartaPrimeraGanaRival(param.misCartas, rankingcartarival);
            //    if (carta == null) carta = ObtenerCartaMasBaja(param.misCartas);
            //}
            //else
            ////arranco jugando yo la mano y pongo una carta cualquiera
            //{
            //    carta = ObtenerCartaRandom(param.misCartas);
            //}

        
        


        private bool NoTengoNada(MisCartas misCartas)
        {
            return !TengoUnTres(misCartas) && !TengoUnDos(misCartas) && !TengoUnSiete(misCartas) && TengoUnAncho(misCartas);
        }

        private bool TengoCartaN(MisCartas misCartas, int n)
        {
            return misCartas.manos.Any(c => !c.yajugada && c.carta.nro == n);
        }

        private bool TengoUnTres(MisCartas misCartas)
        {
            return TengoCartaN(misCartas, 3);
        }

        private bool TengoUnDos(MisCartas misCartas)
        {
            return TengoCartaN(misCartas, 2);
        }

        private bool TengoUnSiete(MisCartas misCartas)
        {
            return TengoElAnchoDeEspada(misCartas) || TengoElSieteDeOro(misCartas);
        }

        private bool TengoElAnchoDeEspada(MisCartas misCartas)
        {
            return misCartas.manos.Any(c => !c.yajugada && c.carta.nro == 1 && c.carta.palo == 'E');
        }

        private bool TengoElAnchoDeBasto(MisCartas misCartas)
        {
            return misCartas.manos.Any(c => !c.yajugada && c.carta.nro == 1 && c.carta.palo == 'B');
        }

        private bool TengoUnAncho(MisCartas misCartas)
        {
            return TengoElAnchoDeBasto(misCartas) || TengoElAnchoDeEspada(misCartas);
        }

        private bool TengoElSieteDeEspadas(MisCartas misCartas)
        {
            return misCartas.manos.Any(c => !c.yajugada && c.carta.nro == 7 && c.carta.palo == 'E');
        }

        private bool TengoElSieteDeOro(MisCartas misCartas)
        {
            return misCartas.manos.Any(c => !c.yajugada && c.carta.nro == 7 && c.carta.palo == 'O');
        }

        private bool TengoMasDeUnDos(MisCartas misCartas)
        {
            return TengoUnAncho(misCartas) || TengoUnSiete(misCartas) || TengoUnTres(misCartas) || TengoUnDos(misCartas);
        }

        private bool TengoMasDeUnSiete(MisCartas misCartas)
        {
            return TengoUnAncho(misCartas) || TengoUnSiete(misCartas) ;
        }
    }
}
