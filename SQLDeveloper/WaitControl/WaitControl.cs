using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WaitControl
{
    public partial class WaitControl : UserControl
    {
        //private System.Drawing.Color fPrimerColor;
        private bool Animando;
        private System.Drawing.Color fSegundoColor;
        private LinearGradientMode lgm;
        private int FAnchoBarraInterior;
        int anchotmp;
        public WaitControl()
        {
            Animando = false;
            InitializeComponent();
//            BarraInterior.Paint += new PaintEventHandler(Barra_Paint);
            PanelIzquierdo.Paint += new PaintEventHandler(Barra_PaintIzquierdo);
            PanelDerecho.Paint += new PaintEventHandler(Barra_PaintDerecho);

        }
        //especifica el tamaño en relacion al porcentaje del ancho del control completo
        /// <summary>
        /// prueba de comentarios
        /// </summary>
        private void CalculaTamaño()
        {
            BarraInterior.Width = Width * FAnchoBarraInterior / 100;
            BarraInterior.Height = Height; //tiene la misma altura
            PanelIzquierdo.Width = BarraInterior.Width / 2;
            PanelDerecho.Width = BarraInterior.Width / 2;
        }
        [
            Category("Barra Interior"),
            DefaultValue(45),
            Description("Especifica el porcentaje del ancho que ocupa la barra interior")
        ]
        public int AnchoBarraInterior
        {
            get
            {
                if (FAnchoBarraInterior == 0)
                    FAnchoBarraInterior = 45;
                return FAnchoBarraInterior;
            }
            set
            {
                if(value<1 || value>100)
                {
                    throw new Exception("El tamaño esta en porcentaje y debe de ser entre 1 y 100");
                }
                FAnchoBarraInterior = value;
                CalculaTamaño();
            }
        }
        [
            Category("Barra Interior"),
            Description("Especifica el primer color que usara el gradiente")
        ]
        public System.Drawing.Color PrimerColor
        {
            get
            {
                return this.BackColor; //fPrimerColor;
            }
            set
            {
                //fPrimerColor = value;
                this.BackColor = value;
            }
        }
        [
            Category("Barra Interior"),
            //            DefaultValue(45)
            Description("Especifica el Segundo color que usara el gradiente")
        ]
        public System.Drawing.Color SegundoColor
        {
            get
            {
                return fSegundoColor;
            }
            set
            {
                fSegundoColor = value;
                BarraInterior.BackColor = fSegundoColor;
            }
        }
        [
            Category("Barra Interior"),
            //            DefaultValue(45)
            Description("Especifica el tipo de gradiente a utilizar")
        ]
        public LinearGradientMode ModoGradiente
        {
            get
            {
                return lgm;
            }
            set
            {
                lgm = value;
            }
        }
        private void Barra_Paint(object sender, PaintEventArgs e)
        {
            Barra_PaintIzquierdo(sender, e);
            Barra_PaintDerecho(sender, e);
        }
        private void Barra_PaintIzquierdo(object sender, PaintEventArgs e)
        {
            Graphics gp = e.Graphics;
            try
            {
                Rectangle rectangulo = new Rectangle(0, 0, PanelIzquierdo.Width, PanelIzquierdo.Height);
                LinearGradientBrush brocha = new LinearGradientBrush(rectangulo, PrimerColor, SegundoColor, lgm);
                gp.FillRectangle(brocha, rectangulo);
            }
            catch (System.Exception)
            {
                return;
            }
        }
        private void Barra_PaintDerecho(object sender, PaintEventArgs e)
        {
            Graphics gp = e.Graphics;
            try
            {
                Rectangle rectangulo = new Rectangle(0, 0, PanelDerecho.Width, PanelDerecho.Height);
                LinearGradientBrush brocha = new LinearGradientBrush(rectangulo,  SegundoColor, PrimerColor, lgm);
                gp.FillRectangle(brocha, rectangulo);
            }
            catch (System.Exception)
            {
                return;
            }
        }

        private void WaitControl_Resize(object sender, EventArgs e)
        {
            CalculaTamaño();
        }
        [
            Category("Comportamiento"),
            //            DefaultValue(45)
            Description("Inicia o detiene la animacion de labbara de espera")
        ]
        public bool Animar
        {
            get
            {
                return Animando;
            }
            set
            {
                if (value == true)
                {
                    //hay que animar                }
                    if (Animando == false)
                    {
                        Animando = true;
                        anchotmp = BarraInterior.Width;
                        backgroundWorker1.RunWorkerAsync();
                    }
                }
                Animando = value;
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           
            //cada coerto tiempo va a recorrer la barra de izquerda a derecha
            //posiciono la barra al inicio del control para que no se vea
            int pos = 0 - anchotmp;
            int incrementos = Width / 100;
            //mientras hay que animar
            try
            {
                while (Animando)
                {
                    //incremento la posicion
                    pos += incrementos;
                    if (pos >= Width)
                        pos = 0 - anchotmp - 10;
                    //BarraInterior.Left = pos;
                    backgroundWorker1.ReportProgress(pos);
                    //hago una espera de unos cuantos mili segundos
                    System.Threading.Thread.Sleep(15);
                }
            }
            catch(System.Exception)
            {
                return;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            BarraInterior.Left = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Animando = false;
        }
    }
}
   