using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace SQLDeveloper.Modulos.Modelador
{
    /// <summary>
    /// clase que implementa el area de dibujo en donde se mostraran todos los objetos
    /// </summary>
    public partial class CLienzo : UserControl
    {
        // grafico de segundo plano donde se van a dibujar los objetos
        //private int FAnchoCuadricula;
        Graphics BkG;
        private int FEscala = 100;
        private int FAlto;
        private int FAnchoCuadricula;
        private int FAncho;
        private Modelo.CModelo FModelo;
        private List<Dibujable.CCApa> Capas;
        private Dibujable.CCApa CapaActiva = null;
        private Dibujable.CCuadricula Cuadricula;
        public CLienzo()
        {
            FAnchoCuadricula = 100; //100 pixeles
            BkG = this.CreateGraphics();
            InitializeComponent();
            FAncho = this.Width;
            FAlto = Height;
            Cuadricula = new Dibujable.CCuadricula();
            Dibujable.CManejadorEventos.Lienzo = this;
        }
        /// <summary>
        /// indica el ancho del area de dibujo en pixeles. 
        /// </summary>
        public int Ancho
        {
            get
            {
                return FAncho;
            }
            set
            {
                FAncho = value;
                Invalidate();
            }
        }
        /// <summary>
        /// indica la altura del area de trabajo en pixeles
        /// </summary>
        public int Alto
        {
            get
            {
                return FAlto;
            }
            set
            {
                FAlto = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Escala en la que se dibujaran los objetos
        /// </summary>
        public int Escala
        {
            get
            {
                return FEscala;
            }
            set
            {
                FEscala = value;
                Invalidate();
            }
        }
        public int AnchoCuadricula
        {
            get
            {
                return FAnchoCuadricula;
            }
            set
            {
                FAnchoCuadricula = value;
                Invalidate();
            }
        }
        #region Funciones graficas
        private void DibujaCuadricula()
        {
            // Dibujable.CCuadricula c = new Dibujable.CCuadricula();
            Cuadricula.Ancho = Ancho;
            Cuadricula.Alto = Alto;
            Cuadricula.AnchoCuadricula = AnchoCuadricula;
            Cuadricula.ColorCuadro = Color.LightBlue; ;
            Cuadricula.Dibuja(BkG);
        }
        #endregion
        private void pruebas()
        {
            Dibujable.CCuadro c = new Dibujable.CCuadro();
            c.Alto = 50;
            c.Ancho = 100;
            c.X = 100;
            c.Y = 100;
            c.ColorFondo = Color.Blue;
            c.FondoActivo = true;
            c.SetRound(true);
            c.ContornoActivo = false;
            c.Dibuja(BkG);

            Dibujable.CCuadroTexto t = new Dibujable.CCuadroTexto();
            t.Alto = 10;
            t.Ancho = 50;
            t.X = 30;
            t.Y = 30;
            t.ColorFondo = Color.Turquoise;
            t.TextColor = Color.White;
            t.FondoActivo = true;
            t.AjustarTexto = true;
            t.Text = "Hola Oscar Resendiz Espinoza";
            t.Padding.SetPadding(0);
            t.ContornoActivo = true;
            t.SetRound(true);
            t.RoundTopLeft = true;
            t.RoundTopRight = true;
            t.Dibuja(BkG);

            Dibujable.CCuadroPuntos cp = new Dibujable.CCuadroPuntos();
            cp.X = 50;
            cp.Y = 50;
            cp.Ancho = 100;
            cp.Alto = 100;
            cp.Dibuja(BkG);

        }
        public Modelo.CModelo Modelo
        {
            get
            {
                return FModelo;
            }
            set
            {
                FModelo = value;
                if (FModelo != null)
                {
                    FModelo.OnCapaActiva += new Modelador.Modelo.ONModeloEvent(OnCapaActiva);
                    FModelo.OnCapaEliminada += new Modelador.Modelo.ONModeloEvent(OnCapaEliminada);
                    FModelo.OnCapaNueva += new Modelador.Modelo.ONModeloEvent(OnCapaNueva);
                    CargaCapas();
                }
            }
        }
        #region Manejo de capas
        private void CargaCapas()
        {
            Capas = new List<Dibujable.CCApa>();
            List<Modelador.Modelo.CCapa> l = FModelo.DameCapas();
            foreach (Modelador.Modelo.CCapa obj in l)
            {
                Dibujable.CCApa Capa = new Dibujable.CCApa();
                Capa.ID_Capa = obj.ID_Capa;
                Capa.Visible = obj.Visible;
                Capa.Orden = obj.Orden;
                Capa.Modelo = FModelo;
                Capas.Add(Capa);
            }
            OnCapaActiva(FModelo.ID_CapaActiva);
        }
        private void OnCapaActiva(int id_capa)
        {
            foreach (Dibujable.CCApa obj in Capas)
            {
                if (obj.ID_Capa == id_capa)
                {
                    CapaActiva = obj;
                }
            }

        }
        private void OnCapaEliminada(int id_capa)
        {
            foreach (Dibujable.CCApa obj in Capas)
            {
                if (obj.ID_Capa == id_capa)
                {
                    Capas.Remove(obj);
                    return;
                }
            }
        }
        private void OnCapaNueva(int id_capa)
        {
            Modelador.Modelo.CCapa obj = FModelo.DameCapa(id_capa);
            Dibujable.CCApa Capa = new Dibujable.CCApa();
            Capa.ID_Capa = obj.ID_Capa;
            Capa.Visible = obj.Visible;
            Capa.Orden = obj.Orden;
            Capa.Modelo = FModelo;
            Capas.Add(Capa);
        }
        #endregion
        private void DibujaCapas()
        {
            if (Capas != null)
            {
                foreach (Dibujable.CCApa capa in Capas)
                {
                    capa.Dibuja(BkG);
                }
            }
        }

        private void CLienzo_MouseClick(object sender, MouseEventArgs e)
        {
            Dibujable.CManejadorEventos.MouseClick(sender, e);
        }

        private void CLienzo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Dibujable.CManejadorEventos.MouseDoubleClick(sender, e);
        }

        private void CLienzo_MouseDown(object sender, MouseEventArgs e)
        {
            Dibujable.CManejadorEventos.MouseDown(sender, e);
        }

        private void CLienzo_MouseMove(object sender, MouseEventArgs e)
        {
            Dibujable.CManejadorEventos.MouseMove(sender, e);
        }

        private void CLienzo_MouseUp(object sender, MouseEventArgs e)
        {
            Dibujable.CManejadorEventos.MouseUp(sender, e);
        }
        public void AgregaRegion()
        {
            if (CapaActiva != null)
                CapaActiva.AgregaRegion();
            // Invalidate();
        }
        private void Dibuja()
        {
            try
            {
                //if(bmp==null)
                float sc = (float)Escala / 100;
                BkG = CreateGraphics();
                BkG.ScaleTransform(sc, sc);
                DibujaCuadricula();
                DibujaCapas();
                BkG.Dispose();
            }
            catch (System.Exception)
            {

            }

        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            try
            {
                Dibuja();
   //             Graphics g = CreateGraphics();
 //               g.DrawImage(bmp, 0, 0);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}