using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.AppsAnalizer.Formularios
{
    public delegate void CProcesoAvanceEvent(CProcesoAvance e);
    public partial class CProcesoAvance : UserControl// Form
    {
        private ObjetosModelo.CHistoryModel HistoryModel;
        public event CProcesoAvanceEvent VisibleOn;
        public event CProcesoAvanceEvent VisibleOff;

        private Analizadores.IAnalizer FAnalizador;
        public void SetHistoryModel(ObjetosModelo.CHistoryModel m)
        {
            HistoryModel = m;
        }
        public Analizadores.IAnalizer Analizador
        {
            get
            {
                return FAnalizador;
            }
            set
            {
                FAnalizador = value;
                if (FAnalizador != null)
                {
                    FAnalizador.AddMessageEvent(AddMensaje);
                    FAnalizador.AddInitAnalisisEvent(InitAnalisis);
                    FAnalizador.AddEndAnalisisEvent(EndAnalisis);
                    TMensaje.Text = "";
                }
            }
        }
        public CProcesoAvance()
        {
            InitializeComponent();
        }
        public string Titulo
        {
            get
            {
                return this.Text;
            }
            set
            {
               Text = value;
            }
        }
        private void AddMensaje(String msg)
        {
            TMensaje.AppendText(msg + "\r\n");
                //.Text =  msg + "\r\n"+TMensaje.Text ;
//            TMensaje.Focus();
        }

        private void FormProcesoAvance_Load(object sender, EventArgs e)
        {
           // TMensaje.Focus();
        }
        public void Analiza()
        {
            if (Analizador == null)
                return;
            HistoryModel.Pausa = true;
            Analizador.IniciaAnalisis();
        }
        private void InitAnalisis()
        {
            if (VisibleOn != null)
                VisibleOn(this);
            BCerrar.Enabled = false;
            BCancelar.Enabled = true;
            LStatus.Text = "Analizando";
            BCancelar.Text = "Cancelar";
            waitControl1.Animar = true;
        }
        private void EndAnalisis()
        {
            LStatus.Text = "Analisis terminado";
            BCerrar.Enabled = true;
            BCancelar.Enabled = false;
            waitControl1.Animar = false;
            HistoryModel.Pausa = false;

        }

        private void BCerrar_Click(object sender, EventArgs e)
        {
            if (VisibleOff != null)
                VisibleOff(this);
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            BCancelar.Text = "Cancelando";
            LStatus.Text = "Cancelando";
            BCancelar.Enabled = false;
            FAnalizador.cancelarAnalisis();
        }
    }
}
   