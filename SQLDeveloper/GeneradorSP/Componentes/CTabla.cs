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
    public partial class CTabla : UserControl
    {
        private int pos;
        public event OnVerTablaPadreEvent OnVerTablaPadre;
        public event OnVerTablaPadreEvent OnCampoSeleccionado;
        public event OnFocoEnterEvent OnFocoEnter;

        CCampoTabla Ultimo;
        public CTabla()
        {
            InitializeComponent();
            pos = 0;
            Ultimo = null;
        }
        public void Clear()
        {
            PCampos.Controls.Clear();
            pos = 0;
            Ultimo = null;
        }
        public void Add(string Campo, string Tipo, bool PK, bool FK, bool NULL, string documentacion)
        {

            CCampoTabla ct = new CCampoTabla();
            ct.OnVerTablaPadre += new OnVerTablaPadreEvent(VerTablaPadre);
            ct.OnDocumentacion += new OnVerTablaPadreEvent(VerDocumentacion);
            ct.OnCampoSeleccionado += new OnVerTablaPadreEvent(CampoSeleccionado);
            ct.OnFocoEnter += new OnFocoEnterEvent(OnFoco);
            ct.Parent = PCampos;
            ct.Top = pos;
            pos = pos + ct.Height;
            //ct.Dock = DockStyle.Top;
            ct.NombreCampo = Campo;
            ct.Tipo = Tipo;
            ct.PrimaryKey = PK;
            ct.AceptaNulos = NULL;
            ct.ForeignKey = FK;
            ct.Documentacion = documentacion;
            if (Ultimo != null)
            {
                ct.Anterior = Ultimo;
                Ultimo.Siguiente = ct;
            }
            Ultimo = ct;
        }
        private void VerTablaPadre(string campo)
        {
            if (OnVerTablaPadre != null)
                OnVerTablaPadre(campo);
        }
        private void VerDocumentacion(string documentacion)
        {
            LDocumentacion.Rtf = documentacion;
        }
        public int Tamaño
        {
            get
            {
                return pos + panel1.Height;
            }
        }
        public bool VerticalScroll
        {
            get
            {
                return PCampos.VerticalScroll.Visible;
            }
        }
        public void CampoSeleccionado(string campo)
        {
            if (OnCampoSeleccionado != null)
            {
                OnCampoSeleccionado(campo);
            }
        }
        private void OnFoco(Component componente)
        {
            if (OnFocoEnter != null)
                OnFocoEnter(componente);
        }
    }
}
