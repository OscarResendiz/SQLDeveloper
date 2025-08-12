using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneradorSP
{
    public delegate void OnTextWaitEnded(string Texto, int Decimas);
    public partial class AnimatedWaitTextBox : UserControl
    {
        private Image IImage;
        int CurPos, CurImage;
        private int _WaitInterval;
        public event OnTextWaitEnded EsperaCompletada;
        public AnimatedWaitTextBox()
        {
            InitializeComponent();
            CurPos = CurImage = 0;
        }
        private void TOText_FontChanged(object sender, EventArgs e)
        {
            Edit.Font = Font;
            this.Height = Edit.Height;
        }
        public int WaitInterval
        {
            get { return _WaitInterval; }
            set { _WaitInterval = value; }
        }
        public Image ImagenInicial
        {
            get
            {
                return IImage;
            }
            set
            {
                IImage = value;
                Img.Image = value;
            }
        }
        private void Edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (Step.Enabled)
                    Step.Enabled = false;
                if (EsperaCompletada != null)
                    EsperaCompletada(Edit.Text, CurPos);
                CurImage = 0;
                Img.Image = IImage;
            }
            //else
            //{
            //    if (!Step.Enabled)
            //        Step.Enabled = true;
            //    CurPos = 0;
            //    Img.Image = IList.Images[CurImage % IList.Images.Count];
            //}
        }
        private void Step_Tick(object sender, EventArgs e)
        {
            CurPos++;
            CurImage++;
            Img.Image = IList.Images[CurImage % IList.Images.Count];
            if (CurPos >= WaitInterval)
            {
                CurImage = 0;
                Step.Enabled = false;
                if (EsperaCompletada != null)
                    EsperaCompletada(Edit.Text, CurPos);
                Img.Image = IImage;
            }
        }
        public override string Text
        {
            get
            {
                return Edit.Text;
            }
            set
            {
                Edit.Text = value;
            }
        }

        private void Edit_TextChanged(object sender, EventArgs e)
        {
            if (!Step.Enabled)
                Step.Enabled = true;
            CurPos = 0;
            Img.Image = IList.Images[CurImage % IList.Images.Count];
        }
    }
}
