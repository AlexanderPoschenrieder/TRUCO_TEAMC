using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Threading;


namespace Truco
{


    public partial class Main : Form
    {
        internal bool stop = false;
        internal bool pause = false;
        
        public Main()
        {
            InitializeComponent();
        }

        #region Form Events

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Start(Modo.Play);

        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Start(Modo.Debug);
        }

        private void timerLabelIzq_Tick(object sender, EventArgs e)
        {
            labelCantoIzq.Font = new Font(labelCantoIzq.Font, FontStyle.Regular);
        }

        private void timerLabelDer_Tick(object sender, EventArgs e)
        {
            labelCantoDer.Font = new Font(labelCantoDer.Font, FontStyle.Regular);

        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            stop = true;
            textBoxLog.AppendText("Stop\r\n");
        }


        private void PauseButton_Click(object sender, EventArgs e)
        {
            pause = !pause;
            textBoxLog.AppendText("Pausa " + pause.ToString() + "\r\n");
            if (pause == true)
                PauseButton.Image = Truco.Properties.Resources.resume;
            else
                PauseButton.Image = Truco.Properties.Resources.pause;

        }

        #endregion

        private void ResetearPanio()
        {
           labelmanoizq.Visible = false;
           labelmanoder.Visible = false;

            carta11.Image = Properties.Resources.reverso;
            carta21.Image = Properties.Resources.reverso;
            carta12.Image = Properties.Resources.reverso;
            carta22.Image = Properties.Resources.reverso;
            carta13.Image = Properties.Resources.reverso;
            carta23.Image = Properties.Resources.reverso;

            for (int mano = 1; mano <= 3; mano++)
            {
                Control picturebox;
                picturebox = Controls["pbJ1M" + mano.ToString()];
                picturebox.GetType().GetProperty("Visible").SetValue(picturebox, false, null);
                picturebox = Controls["pbJ2M" + mano.ToString()];
                picturebox.GetType().GetProperty("Visible").SetValue(picturebox, false, null);
            }
            labelenv1.Text = Convert.ToString(0);
            labelenv2.Text = Convert.ToString(0);

            labelCantoDer.Text = "";
            labelCantoIzq.Text = "";

            Application.DoEvents();
            Velocidad(1);

        }

        private void ActualizarPanio(Partido partido)
        {

            if (partido.jugadormano == partido.jugadorder)
            {
                labelmanoizq.Visible = false;
                labelmanoder.Visible = true;
            }
            else
            {
                labelmanoizq.Visible = true;
                labelmanoder.Visible = false;
            }

            ActualizarTanteador(partido);

            var cartasjugadas = from j in partido.log.logitemcarta
                                select j;

            if (cartasjugadas.Count() > 0)
            {
                Control label;
                label = Controls["labelenv" + partido.jugadorizq.Id];
                label.GetType().GetProperty("Text").SetValue(label, partido.VerCartas(partido.jugadorizq.Id).CalcularEnvido().ToString(), null);
                label = Controls["labelenv" + partido.jugadorder.Id];
                label.GetType().GetProperty("Text").SetValue(label, partido.VerCartas(partido.jugadorder.Id).CalcularEnvido().ToString(), null);

                int contadorcartas = 0;
                int mano = 1;
                foreach (Logitem j in cartasjugadas)
                {
                    contadorcartas++;

                    //Tira carta
                    Control picturebox;
                    picturebox = Controls["pbJ" + j.jugadorid + "M" + mano.ToString()];
                    picturebox.GetType().GetProperty("Image").SetValue(picturebox, j.carta.imagen, null);
                    picturebox.GetType().GetProperty("Visible").SetValue(picturebox, true, null);

                    //Si el contador es par, jugaron ambos jugadores.
                    if (contadorcartas % 2 == 0)
                    {
                        mano++;
                    }
                }
            }

            Application.DoEvents();

        }

        private void ActualizarPantalla(Logitem jugada, Partido p)
        {


            if (jugada.jugadorid == 1) 
            {
                labelCantoIzq.Text += AccionATexto(jugada.accion) + "\n";
                labelCantoIzq.Font = new Font(labelCantoIzq.Font, FontStyle.Underline);
                labelCantoDer.Font = new Font(labelCantoDer.Font, FontStyle.Regular);
                timerLabelIzq.Start();
            }
            else
            {
                labelCantoDer.Text += AccionATexto(jugada.accion) + "\n";
                labelCantoDer.Font = new Font(labelCantoDer.Font, FontStyle.Underline);
                labelCantoIzq.Font = new Font(labelCantoIzq.Font, FontStyle.Regular);
                timerLabelDer.Start();
            }

            ActualizarTanteador(p);

        }

        private void ActualizarTanteador(Partido p)
        {
            LabelTantosIZQ.Text = p.puntosJugadorIzq.ToString();
            LabelTantosDER.Text = p.puntosJugadorDer.ToString();
            Application.DoEvents();
        }

        private void DibujarCarta(Jugador jugador, int mano, Carta carta)
        {
            Control picturebox;
            picturebox = Controls["carta" + jugador.Id + mano];
            picturebox.GetType().GetProperty("Image").SetValue(picturebox, carta.imagen, null);
            picturebox.GetType().GetProperty("Visible").SetValue(picturebox, true, null);
            Application.DoEvents();
            Velocidad(0);
        }

        private void AgregarLogenPantalla(Logitem j, string jn)
        {
            string s;
            s = jn + ":";
            s += AccionATexto(j.accion) + " ";
            if (j.carta != null) s+=j.carta.nombre;
            textBoxLog.AppendText(s + "\r\n");

        }

        private string AccionATexto(Accion a)
        {
            string s = "";
            switch (a)
            {
                case Accion.envido: s="Envido"; break;
                case Accion.envidoenvido: s = "Envido"; break;
                case Accion.envidofaltaenvido: s = "Falta Envido!"; break;
                case Accion.envidorealenvido: s = "Real Envido!"; break;
                case Accion.faltaenvido: s = "Falta Envido"; break;
                case Accion.noquiero_tanto: s = "No quiero"; break;
                case Accion.noquiero_truco: s = "No quiero"; break;
                case Accion.quiero_tanto: s = "Quiero"; break;
                case Accion.quiero_truco: s = "Quiero"; break;
                case Accion.realenvido: s = "Real Envido"; break;
                case Accion.retruco: s = "Quiero Retruco!"; break;
                case Accion.truco: s = "Truco"; break;
                case Accion.valecuatro: s = "Quiero ValeCuatro!"; break;
            }

            return s;

        }

        internal static void ShowErrors(string error)
        {
            MessageBox.Show(error);
            Application.Exit();
        }

        public void Start(Modo modo)
        {

            Jugador jugadorizq, jugadorder;
            Jugador jugadormano, jugadorpie;

            EnableScreen(false);
            stop = false;

            switch (comboBoxPlayerIZQ.Text)
            {
                case "TeamA":
                    jugadorizq = new TeamA(1, "TeamA");
                    break;
                case "TeamB":
                    jugadorizq = new TeamB(1, "TeamB");
                    break;
                case "TeamC":
                    jugadorizq = new TeamC(1, "TeamC");
                    break;
                case "TeamD":
                    jugadorizq = new TeamD(1, "TeamD");
                    break;
                default:
                    jugadorizq = new TeamGeneric(1, "Generic");
                    break;
            }

            switch (comboBoxPlayerDER.Text)
            {
                case "TeamA":
                    jugadorder = new TeamA(2, "TeamA");
                    break;
                case "TeamB":
                    jugadorder = new TeamB(2, "TeamB");
                    break;
                case "TeamC":
                    jugadorder = new TeamC(2, "TeamC");
                    break;
                case "TeamD":
                    jugadorder = new TeamD(2, "TeamD");
                    break;
                default:
                    jugadorder = new TeamGeneric(2, "Generic");
                    break;
            }


            if (modo == Modo.Debug || new Random().Next(1, 3) == 1)
            {
                 jugadormano = jugadorizq;
                 jugadorpie = jugadorder;
            }
            else
            {
                 jugadormano = jugadorder;
                 jugadorpie = jugadorizq;
            }

            Partido partido = new Partido(jugadorizq, jugadorder, modo, textBoxDebug.Text, jugadormano);

            textBoxLog.Clear();

            ResetearPanio();

            do
            {
                partido.rondaNro++;
                partido.jugadormano = jugadormano;
                JugarRonda(partido, jugadormano, jugadorpie);
                Velocidad(2);
                ResetearPanio();
                ActualizarPanio(partido);

                Jugador j = jugadormano;
                jugadormano = jugadorpie;
                jugadorpie = j;

            } while (((partido.modo == Modo.Play && partido.VerPuntos(jugadorizq.Id) < 30 && partido.VerPuntos(jugadorder.Id) < 30) || (partido.modo == Modo.Debug && partido.debug.Trim().Length > 0)) && stop == false);

            EnableScreen(true);
        }

        private void EnableScreen(bool e)
        {
            menuStrip1.Enabled = e;
            buttonDebug.Enabled = e;
            comboBoxPlayerDER.Enabled = e;
            comboBoxPlayerIZQ.Enabled = e;
            PauseButton.Enabled = !e;
            buttonStop.Enabled = !e;

        }

        private void JugarRonda(Partido partido, Jugador jugadormano, Jugador jugadorpie)
        {
            ResetearPanio();
            var croupier = new Truco.Croupier();
            partido.DarCartas(jugadormano.Id, croupier.DarCartas(partido));
            partido.DarCartas(jugadorpie.Id, croupier.DarCartas(partido));

            textBoxLog.AppendText(jugadormano.Id + "-" + jugadormano.Nombre + "(" + partido.VerPuntos(jugadormano.Id).ToString() + "):" + partido.VerCartas(jugadormano.Id).manos[0].carta.nombre + partido.VerCartas(jugadormano.Id).manos[1].carta.nombre + partido.VerCartas(jugadormano.Id).manos[2].carta.nombre + "\r\n");
            textBoxLog.AppendText(jugadorpie.Id + "-" + jugadorpie.Nombre + "(" + partido.VerPuntos(jugadorpie.Id).ToString() + "):" + partido.VerCartas(jugadorpie.Id).manos[0].carta.nombre + partido.VerCartas(jugadorpie.Id).manos[1].carta.nombre + partido.VerCartas(jugadorpie.Id).manos[2].carta.nombre + "\r\n");

            //ActualizarPanio(partido);

            partido.log = new Log();

            DibujarCarta(jugadormano, 1, partido.VerCartas(jugadormano.Id).manos[0].carta);
            DibujarCarta(jugadorpie, 1, partido.VerCartas(jugadorpie.Id).manos[0].carta);
            DibujarCarta(jugadormano, 2, partido.VerCartas(jugadormano.Id).manos[1].carta);
            DibujarCarta(jugadorpie, 2, partido.VerCartas(jugadorpie.Id).manos[1].carta);
            DibujarCarta(jugadormano, 3, partido.VerCartas(jugadormano.Id).manos[2].carta);
            DibujarCarta(jugadorpie, 3, partido.VerCartas(jugadorpie.Id).manos[2].carta);
            Velocidad(1);

            ActualizarPanio(partido);

            Logitem jugada;

            int manosganadasmano = 0, manosganadaspie = 0, cem = 0;
            int rankingdif;

            Quienesmano quienesmano = Quienesmano.Vos;
            Jugador tujugador = jugadormano;
            Jugador rival = jugadorpie;
            int manonumero = 1;
            Jugador proximacarta = jugadormano;

            do
            {

                List<Accion> podescantar = AccionesPosibles(partido.log, tujugador.Id);

                if (tujugador == jugadormano) { quienesmano = Quienesmano.Vos; } else { quienesmano = Quienesmano.Rival; }

                Param jp = new Param(
                    partido.id,
                    tujugador.Id,
                    tujugador.Nombre,
                    partido.VerPuntos(tujugador.Id),
                    rival.Id,
                    rival.Nombre,
                    partido.VerPuntos(rival.Id),
                    rival.CuantoTantoCanto,
                    quienesmano,
                    manonumero,
                    partido.log.logitemcarta.Count,
                    partido.log.logitemcarta,
                    partido.log.logitemcanto,
                    new MisCartas(partido.VerCartas(tujugador.Id).manos),
                    podescantar
                  );


                jugada = tujugador.Jugar(jp);

                jugada = new Logitem(tujugador.Id, jugada.accion, jugada.carta);

                ProcesarJugada(jugada, jp, partido, tujugador, rival);

                if (jugada.accion == Accion.quiero_tanto)
                {
                    int tantosmano, tantospie;

                    tantosmano = partido.VerCartas(jugadormano.Id).CalcularEnvido();
                    tantospie = partido.VerCartas(jugadorpie.Id).CalcularEnvido();

                    jugadormano.AsignarTantosCantados(tantosmano);
                    if (tantospie > tantosmano) jugadorpie.AsignarTantosCantados(tantospie);

                }

                if (jugada.accion == Accion.juegacarta)
                {

                    var a = (from c in partido.VerCartas(tujugador.Id).manos
                             where c.carta.id == jugada.carta.id
                             select c).FirstOrDefault();
                    a.JugoCarta();

                    ActualizarPanio(partido);
                    cem = partido.log.logitemcarta.Count;
                    if (cem % 2 == 0)  // hay una cantidad par de cartas en la mesa.  Quien gano la mano?
                    {
                        rankingdif = partido.log.logitemcarta[cem - 2].carta.ranking - partido.log.logitemcarta[cem - 1].carta.ranking;

                        if (rival == jugadorpie) rankingdif *= -1;  // invierte el ranking si el que jugo primero en la mano fue el pie

                        if (rankingdif > 0)
                        {
                            manosganadasmano++;
                            proximacarta = jugadormano;
                        };

                        if (rankingdif < 0)
                        {
                            manosganadaspie++;
                            proximacarta = jugadorpie;
                        }

                        manonumero += 1;

                        if (manosganadasmano == 2 || manosganadaspie == 2) break;
                        if (manosganadasmano + manosganadaspie != (cem / 2) && manosganadasmano + manosganadaspie > 0) break;

                    }
                    else
                    {
                        if (proximacarta == jugadormano) { proximacarta = jugadorpie; } else { proximacarta = jugadormano; }
                    }

                }
                else
                {
                    ActualizarPantalla(jugada, partido);
                }

                if (jugada.accion == Accion.noquiero_tanto || jugada.accion == Accion.quiero_tanto || jugada.accion == Accion.quiero_truco || jugada.accion == Accion.juegacarta)
                { // a quien le toca jugar la proxima carta
                    //                    if (jugada.accion == Accion.quiero_truco) { tieneelquiero = jugada.jugador; }

                    if (proximacarta == jugadormano)
                    {
                        tujugador = jugadormano;
                        rival = jugadorpie;
                    }
                    else
                    {
                        tujugador = jugadorpie;
                        rival = jugadormano;
                    }

                }
                else
                {  // le toca al otro jugador
                    Jugador j = tujugador;
                    tujugador = rival;
                    rival = j;
                }

            } while (cem < 6 && jugada.accion != Accion.noquiero_truco && partido.VerPuntos(jugadormano.Id) < 30 && partido.VerPuntos(jugadorpie.Id) < 30 && stop == false);

            if (stop == true) return;


            if (partido.VerPuntos(jugadormano.Id) < 30 && partido.VerPuntos(jugadorpie.Id) < 30)
            {

                int puntos = CalcularPuntosTruco(partido.log);

                if (jugada.accion == Accion.noquiero_truco)
                {

                    if (partido.log.logitemcanto[partido.log.logitemcanto.Count - 1].jugadorid == jugadorpie.Id)
                        partido.SumarPuntos(jugadormano.Id, puntos);
                    else
                        partido.SumarPuntos(jugadorpie.Id, puntos);

                }
                else
                {
                    if (manosganadasmano > manosganadaspie)
                        partido.SumarPuntos(jugadormano.Id, puntos);
                    else
                    {
                        if (manosganadasmano < manosganadaspie)
                            partido.SumarPuntos(jugadorpie.Id, puntos);
                        else  // es parda la 3ra y ganaron una mano cada uno, hay que buscar quien gano la 1er mano
                        {
                            if (partido.log.logitemcarta[0].carta.ranking > partido.log.logitemcarta[1].carta.ranking)
                                partido.SumarPuntos(jugadormano.Id, puntos);
                            else
                                partido.SumarPuntos(jugadorpie.Id, puntos);
                        }
                    }
                }
            }

            ActualizarTanteador(partido);

        }

        private int ProcesarJugada(Truco.Logitem jugada, Param jp, Partido partido, Jugador tujugador, Jugador rival)
        {

            AgregarLogenPantalla(jugada, tujugador.Nombre);

            if (jugada.accion == Accion.juegacarta)
            {
                bool yalajugo;

                yalajugo = jp.juego.logCartas.Exists(x => x.carta.id == jugada.carta.id);

                if (yalajugo)
                {
                    MessageBox.Show("Jugador " + tujugador.Nombre + "eliminado.  Intenta volver a jugar una carta");
                    stop = true;
                    return -1;
                }

                jp.juego.logCartas.Add(jugada);

                //var a = (from c in jp.misCartas.manos
                //         where c.carta.id == jugada.carta.id
                //         select c).FirstOrDefault();
                //a.JugoCarta();

                ActualizarPanio(partido);

            }
            else
            {
                if (jp.juego.manoNumero == 1 && jp.juego.quienEsMano == Quienesmano.Rival && jp.juego.logCantos.Exists(x => x.accion == Accion.truco) && (jugada.accion == Accion.envido || jugada.accion == Accion.realenvido || jugada.accion == Accion.faltaenvido))
                {  // Si el mano canto truco y el pie canta el envido, hay que borrar el truco cantado por el mano
                    jp.juego.logCantos.RemoveAt(0);
                }


                jp.juego.logCantos.Add(jugada);
                if (!jp.AccionesDisponibles.Exists(x => x == jugada.accion))
                {
                    MessageBox.Show("Jugador " + tujugador.Nombre + "eliminado.  Intenta una accion no listada");
                    stop = true;
                    return -1;
                }

                if (jugada.accion == Accion.quiero_tanto || jugada.accion == Accion.noquiero_tanto)
                {

                    int i = partido.VerCartas(partido.jugadorizq.Id).CalcularEnvido();
                    int d = partido.VerCartas(partido.jugadorder.Id).CalcularEnvido();


                    if (jugada.accion == Accion.noquiero_tanto)
                        partido.SumarPuntos(rival.Id, CalcularPuntosEnvido(partido.log, partido.VerPuntos(tujugador.Id)));
                    else
                    {

                        if (i > d)
                            partido.SumarPuntos(partido.jugadorizq.Id, CalcularPuntosEnvido(partido.log, partido.VerPuntos(partido.jugadorder.Id)));
                        else
                        {
                            if (d > i)
                                partido.SumarPuntos(partido.jugadorder.Id, CalcularPuntosEnvido(partido.log, partido.VerPuntos(partido.jugadorizq.Id)));
                            else
                            {
                                if (jp.juego.quienEsMano == Quienesmano.Vos)
                                    partido.SumarPuntos(tujugador.Id, CalcularPuntosEnvido(partido.log, partido.VerPuntos(rival.Id)));
                                else
                                    partido.SumarPuntos(rival.Id, CalcularPuntosEnvido(partido.log, partido.VerPuntos(rival.Id)));
                            }
                        }
                    }

                }

            }

            Velocidad(1);

            return 0;

        }

        public List<Accion> AccionesPosibles(Log l, int j)
        {
            List<Accion> r = new List<Accion>();

            if (l.logitemcarta.Count < 2 && !l.logitemcanto.Exists(x => x.accion == Accion.quiero_tanto || x.accion == Accion.noquiero_tanto || x.accion == Accion.retruco || x.accion == Accion.quiero_truco))
            {  // Si es la 1er mano, el tanto no se cerro y el truco no se quiso ni se retruco, se puede cantar el tanto

                Logitem last = l.logitemcanto.LastOrDefault(n => n.accion == Accion.envido || n.accion == Accion.realenvido || n.accion == Accion.faltaenvido);

                if (last == null)
                {  // Si no se canto nada todavia
                    r.Add(Accion.envido);
                    r.Add(Accion.realenvido);
                    r.Add(Accion.faltaenvido);

                }
                else
                {  // Si ya se canto algo, se puede revirar

                    r.Add(Accion.quiero_tanto);
                    r.Add(Accion.noquiero_tanto);
                    switch (last.accion)
                    {
                        case Accion.envido:
                            r.Add(Accion.envidoenvido);
                            r.Add(Accion.envidorealenvido);
                            r.Add(Accion.envidofaltaenvido);
                            break;
                        case Accion.realenvido:
                            r.Add(Accion.realenvidofaltaenvido);
                            break;
                    }

                }

            }  // terminamos con el tanto

            // empezamos con el truco

            if (!r.Exists(x => x == Accion.quiero_tanto))  // Si esta esperando contestacion del tanto, paso el truco de largo
            {

                // busco lo ultimo que canto mi rival y lo ultimo que se canto del truco
                Logitem lastother = l.logitemcanto.LastOrDefault(n => n.jugadorid != j);
                Logitem lastall = l.logitemcanto.LastOrDefault(n => n.accion == Accion.truco || n.accion == Accion.retruco || n.accion == Accion.valecuatro || n.accion == Accion.quiero_truco);


                if (lastall == null)
                    r.Add(Accion.truco);
                else
                {
                    if ((lastall.jugadorid == j && lastall.accion == Accion.quiero_truco) || (lastall.jugadorid != j && lastall.accion != Accion.quiero_truco))  // tengo el quiero
                        switch (lastother.accion)
                        {
                            case Accion.truco:
                                r.Add(Accion.retruco);
                                break;
                            case Accion.retruco:
                                r.Add(Accion.valecuatro);
                                break;
                        }

                    if (lastall.accion != Accion.quiero_truco)
                    {
                        r.Add(Accion.quiero_truco);
                        r.Add(Accion.noquiero_truco);
                    }

                }

                // y por ultimo, puedo jugar una carta?
                if (lastall == null)
                    r.Add(Accion.juegacarta);
                else
                {
                    Accion a = lastall.accion;
                    if (a == Accion.quiero_tanto || a == Accion.quiero_truco || a == Accion.noquiero_tanto)
                        r.Add(Accion.juegacarta);
                }
            }

            return r;

        }

        public int CalcularPuntosTruco(Log l)
        {
            int ret = 1;

            for (int r = l.logitemcanto.Count() - 1; r > 0; r--)
            {
                if (l.logitemcanto[r].accion == Accion.quiero_truco) { ret++; }
                if (l.logitemcanto[r].accion == Accion.retruco) { ret++; break; }
                if (l.logitemcanto[r].accion == Accion.valecuatro) { ret += 2; break; }
            }

            return ret;
        }

        public int CalcularPuntosEnvido(Log l, int puntosOtro)
        {
            Accion ult = l.logitemcanto[l.logitemcanto.Count - 1].accion;
            Accion ant = l.logitemcanto[l.logitemcanto.Count - 2].accion;
            int ret = 0;

            int falta = 30 - puntosOtro;

            switch (ant)
            {

                case Accion.envido:
                    if (ult == Accion.quiero_tanto) ret = 2; else ret = 1;
                    break;
                case Accion.realenvido:
                    if (ult == Accion.quiero_tanto) ret = 3; else ret = 1;
                    break;
                case Accion.envidoenvido:
                    if (ult == Accion.quiero_tanto) ret = 4; else ret = 2;
                    break;
                case Accion.envidorealenvido:
                    if (ult == Accion.quiero_tanto) ret = 5; else ret = 2;
                    break;
                case Accion.faltaenvido:
                    if (ult == Accion.quiero_tanto) ret = falta; else ret = 1;
                    break;
                case Accion.envidofaltaenvido:
                    if (ult == Accion.quiero_tanto) ret = falta; else ret = 2;
                    break;
                case Accion.realenvidofaltaenvido:
                    if (ult == Accion.quiero_tanto) ret = falta; else ret = 3;
                    break;

            }
            return ret;
        }

        public void Velocidad(int a)
        {


            if (a == 0)
            {
                if (trackBarVel.Value == 1) return;
                else Thread.Sleep(150);
            }
            else
            {
                do
                {
                    Thread.Sleep(trackBarVel.Value * 50 * (1 + a));
                    Application.DoEvents();
                } while (this.pause == true);
            }


        }

      



       


    
        

    }
}
