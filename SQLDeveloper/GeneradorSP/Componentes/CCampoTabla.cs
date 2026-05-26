using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneradorSP.Componentes
{
    public delegate void OnVerTablaPadreEvent(string campo);
    public delegate void OnFocoEnterEvent(Component componente);
    public partial class CCampoTabla : UserControl
    {
        public string Documentacion;
        public CCampoTabla Anterior, Siguiente;
        private bool PK;
        private bool FK;
        private bool NULL;
        public event OnVerTablaPadreEvent OnVerTablaPadre;
        public event OnVerTablaPadreEvent OnDocumentacion;
        public event OnVerTablaPadreEvent OnCampoSeleccionado;
        public event OnFocoEnterEvent OnFocoEnter;
        public CCampoTabla()
        {
            InitializeComponent();
            Anterior = null;
            Siguiente = null;
            Documentacion = "";
        }
        public string NombreCampo
        {
            get
            {
                return TCampo.Text;
            }
            set
            {
                TCampo.Text = value;
            }
        }
        public string Tipo
        {
            get
            {
                return TTipo.Text;
            }
            set
            {
                TTipo.Text = value;
            }
        }
        public bool PrimaryKey
        {
            get
            {
                return PK;
            }
            set
            {
                PK = value;
                MuestaImagen();
            }
        }
        public bool ForeignKey
        {
            get
            {
                return FK;
            }
            set
            {
                FK = value;
                MuestaImagen();
            }
        }

        private void MuestaImagen()
        {
            //dependiendo del si esta marcada como llave primaria y/o foranea
            //muestra la imagen correspondiente
            if (PK == false && FK == false)
            {
                //no es nada, no muestra imagen
                PPFK.Image = null;
                return;
            }
            if (PK == true && FK == true)
            {
                //Tiene ambas marcas
                PPFK.Image = imageList1.Images[1];
                return;
            }
            if (PK == true)
            {
                //solo es llave primaria
                PPFK.Image = imageList1.Images[0];
                return;
            }
            if (FK == true)
            {
                //muestro la imagen que es solo llave foranea
                PPFK.Image = imageList1.Images[2];
                return;
            }
        }
        public bool AceptaNulos
        {
            get
            {
                return NULL;
            }
            set
            {
                NULL = value;
                if (NULL == true)
                {
                    PNULLS.Image = imageList1.Images[3];
                }
                else
                {
                    PNULLS.Image = null;
                }
            }
        }

        private void PPFK_DoubleClick(object sender, EventArgs e)
        {
            //solo se ejecuta si esta marcada la llave foranea
            if (ForeignKey == true)
            {
                if (OnVerTablaPadre != null)
                    OnVerTablaPadre(NombreCampo);
            }
        }

        private void TCampo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (Anterior != null)
                {
                    Anterior.TenFoco();
                    return;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (Siguiente != null)
                {
                    Siguiente.TenFoco();
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                if (TCampo.SelectionStart >= TCampo.Text.Length)
                {
                    TTipo.Focus();
                    TTipo.SelectionStart = 0;
                    TTipo.SelectionLength = TTipo.Text.Length;
                }
            }

        }
        public void TenFoco()
        {
            TCampo.Focus();
            TCampo.SelectionStart = 0;
            TCampo.SelectionLength = TCampo.Text.Length;
            if (OnDocumentacion != null)
            {
                OnDocumentacion(Documentacion);
            }
        }
        public void TenFoco2()
        {
            TTipo.Focus();
            TTipo.SelectionStart = 0;
            TTipo.SelectionLength = TTipo.Text.Length;
            if (OnDocumentacion != null)
            {
                OnDocumentacion(Documentacion);
            }
        }

        private void TTipo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (Anterior != null)
                {
                    Anterior.TenFoco2();
                    return;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (Siguiente != null)
                {
                    Siguiente.TenFoco2();
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                if (TTipo.SelectionStart == 0)
                {
                    TenFoco();
                }
            }
        }

        private void TCampo_MouseMove(object sender, MouseEventArgs e)
        {
            //if (OnDocumentacion != null)
            //{
            //    OnDocumentacion(Documentacion);
            //}
        }


        private void PPFK_Click(object sender, EventArgs e)
        {
            if (OnDocumentacion != null)
            {
                OnDocumentacion(Documentacion);
            }
        }
        private void TCampo_Enter(object sender, EventArgs e)
        {
            if (OnDocumentacion != null)
            {
                OnDocumentacion(Documentacion);
            }
            if (OnCampoSeleccionado != null)
            {
                OnCampoSeleccionado(NombreCampo);
            }
            if (OnFocoEnter != null)
                OnFocoEnter((TextBox)sender);
        }
    }
}
