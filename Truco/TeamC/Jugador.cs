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


        public override Accion ContestarTruco(Param param)
        {
         
            Accion accion = Accion.noquiero_truco;
            Accion cantorival = ObtenerUltimoCantoRival(param);


            if (param.rival.puntos == 29) {
                if (param.AccionesDisponibles.Contains(Accion.retruco)) return Accion.retruco;
                if (param.AccionesDisponibles.Contains(Accion.valecuatro)) return Accion.valecuatro;
            }

            if (!YaGaneMano(param))
            {
                // ranking promedio de mis cartas
                int rankingpromedio = Convert.ToInt32(param.misCartas.manos.Average(a => a.carta.ranking));

                if (cantorival == Accion.truco && rankingpromedio > 20) { accion = Accion.quiero_truco; }
                if (cantorival == Accion.truco && rankingpromedio > 25) { accion = Accion.retruco; }

                if (cantorival == Accion.retruco && rankingpromedio > 20) { accion = Accion.quiero_truco; }
                if (cantorival == Accion.retruco && rankingpromedio > 30) { accion = Accion.valecuatro; }

                if (cantorival == Accion.valecuatro && rankingpromedio > 25) { accion = Accion.quiero_truco; }

            }
            else
            {
                if (YaEstoyJugado(param) && cantorival == Accion.truco && TengoAlMenosUnAnchoFalso(param.misCartas)) { return Accion.quiero_truco; }
                if (cantorival == Accion.truco && TengoAlMenosUnDos(param.misCartas)) { accion = Accion.quiero_truco; }
                if (cantorival == Accion.truco && TengoAlMenosUnTres(param.misCartas)) { accion = Accion.retruco; }

                if (cantorival == Accion.retruco && TengoAlMenosUnSiete(param.misCartas)) { accion = Accion.quiero_truco; }
                if (cantorival == Accion.retruco && TengoUnAncho(param.misCartas)) { accion = Accion.valecuatro; }

                if (cantorival == Accion.valecuatro && TengoAlMenosUnSiete(param.misCartas)) { accion = Accion.quiero_truco; }
             
            }
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

            if (!YaGaneMano(param))
            {
                // ranking promedio de mis cartas
                int rankingpromedio = Convert.ToInt32(param.misCartas.manos.Average(a => a.carta.ranking));
                if (param.AccionesDisponibles.Contains(Accion.truco) && rankingpromedio > 20) accion = Accion.truco;
                if (param.AccionesDisponibles.Contains(Accion.retruco) && rankingpromedio > 25) accion = Accion.retruco;
                if (param.AccionesDisponibles.Contains(Accion.valecuatro) && rankingpromedio > 30) accion = Accion.valecuatro;
            }
            else
            {
                if (param.juego.manoNumero == 3 && param.AccionesDisponibles.Contains(Accion.truco))
                {
                    accion = Accion.truco;
                }
                else
                {
                    if (param.AccionesDisponibles.Contains(Accion.truco) && TengoAlMenosUnDos(param.misCartas)) accion = Accion.truco;
                    if (param.AccionesDisponibles.Contains(Accion.retruco) && TengoAlMenosUnSiete(param.misCartas)) accion = Accion.retruco;
                    if (param.AccionesDisponibles.Contains(Accion.valecuatro) && TengoUnAncho(param.misCartas)) accion = Accion.valecuatro;
                }
            }
           
            
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

            if (param.AccionesDisponibles.Contains(Accion.envido) && tantos >= 21 && tantos <= 27)
            {
                accion = Accion.envido;
            }
            else if (param.AccionesDisponibles.Contains(Accion.realenvido) && tantos >= 28 && tantos <= 30)
            {
                accion = Accion.realenvido;
            }
            else if (param.AccionesDisponibles.Contains(Accion.faltaenvido) && tantos >= 31)
            {
                accion = Accion.faltaenvido;
            } 
            else
            {
                if (param.AccionesDisponibles.Contains(Accion.faltaenvido))
                {
                    Random rn = new Random();
                    int radm = rn.Next(0, 10);
                    if (YaEstoyJugado(param) || radm < 4)
                    {
                        accion = Accion.faltaenvido;
                    }
                }
            }

            return accion;
        }

        private bool YaEstoyJugado(Param param)
        {
            int yoPuntos = param.yo.puntos;
            int rivalPuntos = param.rival.puntos;
            return ((yoPuntos < rivalPuntos) && (rivalPuntos - yoPuntos) > 7);
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
            return TengoElSieteDeEspadas(misCartas) || TengoElSieteDeOro(misCartas);
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

        private bool TengoAlMenosUnDos(MisCartas misCartas)
        {
            return TengoUnAncho(misCartas) || TengoUnSiete(misCartas) || TengoUnTres(misCartas) || TengoUnDos(misCartas);
        }

        private bool TengoUnAnchoFalso(MisCartas misCartas)
        {
            return misCartas.manos.Any(c => !c.yajugada && c.carta.nro == 1 && c.carta.palo != 'B' && c.carta.palo != 'E');
        }

        private bool TengoAlMenosUnAnchoFalso(MisCartas misCartas)
        {
            return TengoUnAncho(misCartas) || TengoUnSiete(misCartas) || TengoUnTres(misCartas) || TengoUnDos(misCartas) || TengoUnAnchoFalso(misCartas);
        }

        private bool TengoAlMenosUnTres(MisCartas misCartas)
        {
            return TengoUnAncho(misCartas) || TengoUnSiete(misCartas) || TengoUnTres(misCartas) ;
        }

        private bool TengoAlMenosUnSiete(MisCartas misCartas)
        {
            return TengoUnAncho(misCartas) || TengoUnSiete(misCartas) ;
        }
            
        private bool UltimaMano(Param param)
        {
            if(param.juego.manoNumero==3)
            {
                return true;
            }
            return false;
        }

        private bool YaGaneMano(Param param)
        {
            if (param.juego.logCartas !=null && param.juego.logCartas.Count() > 0)
            {
                var misCartas = param.juego.logCartas.Where(c => c.jugadorid == param.yo.id).ToList();
                var rivalCartas = param.juego.logCartas.Where(c => c.jugadorid == param.rival.id).ToList();

                var misCartasCount= misCartas.Count();
                var rivalCartasCount = rivalCartas.Count();
                var finalCount= misCartasCount<rivalCartasCount?misCartasCount:rivalCartasCount;

                int i = 0;
                for (i = 0; i < finalCount;i++ )
                {
                    if (misCartas[i].carta.ranking > rivalCartas[i].carta.ranking)
                    {
                        return true;
                    }
                }

            }
            return false;
        }
    }
}
