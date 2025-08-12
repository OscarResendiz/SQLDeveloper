using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MotorDB;
namespace GeneradorSP
{
    public delegate void OnCodigoSPEvent(string Nombre, string Codigo);
    public partial class FormAsistSP : Form
    {
        IGeneradorCodigo GeneradorCodigo;
        public event OnCodigoSPEvent OnCodigoSP;
        IMotorDB DB;
        private AsistBaseSP Asistente;
        public string Tabla;
        int Modo;
        public FormAsistSP(IMotorDB db, int modo, IGeneradorCodigo generadorCodigo)
        {
            Modo = modo;
            DB = db;
            InitializeComponent();
            GeneradorCodigo = generadorCodigo;
        }
        #region Propiedades del boton Anterior
        public bool EnableAnterior
        {
            get
            {
                return BAnterior.Enabled;
            }
            set
            {
                BAnterior.Enabled = value;
            }
        }
        public string TextAnterior
        {
            get
            {
                return BAnterior.Text;
            }
            set
            {
                BAnterior.Text = value;
            }
        }
        #endregion
        #region Propiedades del boton Siguiente
        public bool EnableSiguiente
        {
            get
            {
                return BSiguiente.Enabled;
            }
            set
            {
                BSiguiente.Enabled = value;
            }
        }
        public string TextSiguiente
        {
            get
            {
                return BSiguiente.Text;
            }
            set
            {
                BSiguiente.Text = value;
            }
        }
        #endregion
        #region Propiedades del boton Cancelar
        public bool EnableCancelar
        {
            get
            {
                return BCancelar.Enabled;
            }
            set
            {
                BCancelar.Enabled = value;
            }
        }
        public string TextCancelar
        {
            get
            {
                return BCancelar.Text;
            }
            set
            {
                BCancelar.Text = value;
            }
        }
        #endregion
        #region manejo de eventos
        protected void FEnableAnterior(bool Valor)
        {
            EnableAnterior = Valor;
        }
        protected void FEnableSiguiente(bool Valor)
        {
            EnableSiguiente = Valor;
        }
        protected void FEnableCancelar(bool Valor)
        {
            EnableCancelar = Valor;
        }
        protected void FTextoAnterior(string Texto)
        {
            TextAnterior = Texto;
        }
        protected void FTextoSiguiente(string Texto)
        {
            TextSiguiente = Texto;
        }
        protected void FTextoCancelar(string Texto)
        {
            TextCancelar = Texto;
        }
        protected void FTextoPntalla(string Texto)
        {
            Text = Texto;
        }
        #endregion
        protected void OnInstalaAsistente(AsistBaseSP obj)
        {
            //se llama cuando el asistente base cambia
            if (Asistente != null)
            {
                if (Asistente == obj)
                    return;
                Asistente.Visible = false;
            }
            Asistente = obj;
           //le asigno todos sus eventos
            Asistente.OnEnableAnterior += new OnEnableEvent(FEnableAnterior);
            Asistente.OnEnableCancelar += new OnEnableEvent(FEnableCancelar);
            Asistente.OnEnableSiguiente += new OnEnableEvent(FEnableSiguiente);
            Asistente.OnTextoAnterior += new OnCambiaTexto(FTextoAnterior);
            Asistente.OnTextoCancelar += new OnCambiaTexto(FTextoCancelar);
            Asistente.OnTextoSiguiente += new OnCambiaTexto(FTextoSiguiente);
            Asistente.InstalameEvent += new OnInstalameEvent(OnInstalaAsistente);
            Asistente.OnCodigoSP += new OnCodigoSPEvent(CodigoSP);
            Asistente.OnClose += new OnCloseEvent(CloseEvent);
            Asistente.Parent = Contenedor;
            Asistente.Dock = DockStyle.Fill;
            Asistente.Inicializate();
            Asistente.Visible = true;
        }

        private void FormAsistSP_Load(object sender, EventArgs e)
        {
            switch (Modo)
            {
                case 1: //SELECCION
                    Asistente = new AsisBienVenidaSelect(DB, GeneradorCodigo);
                    Asistente.OnEnableAnterior += new OnEnableEvent(FEnableAnterior);
                    Asistente.OnEnableCancelar += new OnEnableEvent(FEnableCancelar);
                    Asistente.OnEnableSiguiente += new OnEnableEvent(FEnableSiguiente);
                    Asistente.OnTextoAnterior += new OnCambiaTexto(FTextoAnterior);
                    Asistente.OnTextoCancelar += new OnCambiaTexto(FTextoCancelar);
                    Asistente.OnTextoSiguiente += new OnCambiaTexto(FTextoSiguiente);
                    Asistente.InstalameEvent += new OnInstalameEvent(OnInstalaAsistente);
                    Asistente.Parent = Contenedor;
                    Asistente.Dock = DockStyle.Fill;
                    AsisBienVenidaSelect tmp = (AsisBienVenidaSelect)Asistente;
                    tmp.NombreTabla = Tabla;
                    Asistente.Visible = true;
                    break;
                case 2: //INSERCION
                    Asistente = new AsisBienVenidaInsert(DB, GeneradorCodigo);
                    Asistente.OnEnableAnterior += new OnEnableEvent(FEnableAnterior);
                    Asistente.OnEnableCancelar += new OnEnableEvent(FEnableCancelar);
                    Asistente.OnEnableSiguiente += new OnEnableEvent(FEnableSiguiente);
                    Asistente.OnTextoAnterior += new OnCambiaTexto(FTextoAnterior);
                    Asistente.OnTextoCancelar += new OnCambiaTexto(FTextoCancelar);
                    Asistente.OnTextoSiguiente += new OnCambiaTexto(FTextoSiguiente);
                    Asistente.InstalameEvent += new OnInstalameEvent(OnInstalaAsistente);
                    Asistente.Parent = Contenedor;
                    Asistente.Dock = DockStyle.Fill;
                    AsisBienVenidaInsert tmp2 = (AsisBienVenidaInsert)Asistente;
                    tmp2.NombreTabla = Tabla;
                    Asistente.Visible = true;
                    break;
                case 3://actualizacion
                    Asistente = new AsisBienVenidaUpdate(DB, GeneradorCodigo);
                    Asistente.OnEnableAnterior += new OnEnableEvent(FEnableAnterior);
                    Asistente.OnEnableCancelar += new OnEnableEvent(FEnableCancelar);
                    Asistente.OnEnableSiguiente += new OnEnableEvent(FEnableSiguiente);
                    Asistente.OnTextoAnterior += new OnCambiaTexto(FTextoAnterior);
                    Asistente.OnTextoCancelar += new OnCambiaTexto(FTextoCancelar);
                    Asistente.OnTextoSiguiente += new OnCambiaTexto(FTextoSiguiente);
                    Asistente.InstalameEvent += new OnInstalameEvent(OnInstalaAsistente);
                    Asistente.Parent = Contenedor;
                    Asistente.Dock = DockStyle.Fill;
                    AsisBienVenidaUpdate tmp3 = (AsisBienVenidaUpdate)Asistente;
                    tmp3.NombreTabla = Tabla;
                    Asistente.Visible = true;
                    break;
                case 4://Borrado
                    Asistente = new AsisBienVenidaDelete(DB, GeneradorCodigo);
                    Asistente.OnEnableAnterior += new OnEnableEvent(FEnableAnterior);
                    Asistente.OnEnableCancelar += new OnEnableEvent(FEnableCancelar);
                    Asistente.OnEnableSiguiente += new OnEnableEvent(FEnableSiguiente);
                    Asistente.OnTextoAnterior += new OnCambiaTexto(FTextoAnterior);
                    Asistente.OnTextoCancelar += new OnCambiaTexto(FTextoCancelar);
                    Asistente.OnTextoSiguiente += new OnCambiaTexto(FTextoSiguiente);
                    Asistente.InstalameEvent += new OnInstalameEvent(OnInstalaAsistente);
                    Asistente.Parent = Contenedor;
                    Asistente.Dock = DockStyle.Fill;
                    AsisBienVenidaDelete tmp4 = (AsisBienVenidaDelete)Asistente;
                    tmp4.NombreTabla = Tabla;
                    Asistente.Visible = true;
                    break;
            }
        }

        private void BAnterior_Click(object sender, EventArgs e)
        {
            Asistente.BAnterio();
        }

        private void BSiguiente_Click(object sender, EventArgs e)
        {
            Asistente.BSiguiente();
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("¿Desea salir del asistente?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
              //  return;
            Close();
        }
        public void CodigoSP(string Nombre, string Codigo)
        {
            if (OnCodigoSP != null)
                OnCodigoSP(Nombre, Codigo);
        }
        public void CloseEvent()
        {
            Close();
        }

    }
}