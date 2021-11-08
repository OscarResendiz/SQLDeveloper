using Modelador.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
namespace Modelador.UI
{
    public partial class FormPropiedadesCampo : Form
    {
        Modelo.ModeloDatos Modelo;
        public FormPropiedadesCampo(Modelo.ModeloDatos modelo)
        {
            Modelo = modelo;
            InitializeComponent();
            CargaTiposDatos();
        }
        public string NombreX
        {
            get
            {
                return TNombre.Text.Trim();
            }
            set
            {
                TNombre.Text = value.Trim();
            }
        }
        public string Comentarios
        {
            get
            {
                return TComentarios.Text;
            }
            set
            {
                if(value!=null)
                    TComentarios.Text= value.Trim();
            }
        }
        private void CargaTiposDatos()
        {
            ComboTipoDato.Items.Clear();
            List<Modelo.CTipoDato> l = Modelo.Get_TiposDatos();
            foreach (Modelo.CTipoDato tipo in l)
            {
                ComboTipoDato.Items.Add(tipo);
            }
        }
        private void FormPropiedadesCampo_Load(object sender, EventArgs e)
        {
            HabilitaFormulas();
        }
        public int ID_TipoDato
        {
            get
            {
                Modelo.CTipoDato obj = (Modelo.CTipoDato)ComboTipoDato.SelectedItem;
                return obj.ID_TipoDato;
            }
            set
            {
                for(int i=0;i<ComboTipoDato.Items.Count;i++)
                {
                    Modelo.CTipoDato obj = (Modelo.CTipoDato)ComboTipoDato.Items[i];
                    if(obj.ID_TipoDato==value)
                    {
                        ComboTipoDato.SelectedIndex = i;
                        return;
                    }
                }
            }
        }
        public int Longitud
        {
            get
            {
                return (int)TLongitud.Value;
            }
            set
            {
                TLongitud.Value = value;
            }
        }
        public bool PK
        {
            get
            {
                return ChPk.Checked;
            }
            set
            {
                ChPk.Checked = value;
            }
        }
        public bool AceptaNulos
        {
            get
            {
                return ChNull.Checked;
            }
            set
            {
                ChNull.Checked = value;
            }
        }
        public bool CampoCalculado
        {
            get
            {
                return ChCalculado.Checked;
            }
            set
            {
                ChCalculado.Checked = value;
            }
        }
        public bool EsDefault
        {
            get
            {
                return ChDefault.Checked;
            }
            set
            {
                ChDefault.Checked = value;
            }
        }
        public string Formula
        {
            get
            {
                return TFormula.Text.Trim();
            }
            set
            {
                TFormula.Text = value.Trim();
            }
        }
        public string DefaultName
        {
            get
            {
                return TDefault.Text.Trim();
            }
            set
            {
                TDefault.Text = value;
            }
        }

        private void ChCalculado_CheckedChanged(object sender, EventArgs e)
        {
            if(ChCalculado.Checked)
            {
                ChDefault.Checked = false;
            }
            HabilitaFormulas();
        }

        private void ChDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (ChDefault.Checked)
            {
                ChCalculado.Checked = false;
                if(DefaultName=="" && NombreX!="")
                {
                    DefaultName = "Default" + NombreX;
                }
            }
            HabilitaFormulas();

        }
        private void HabilitaFormulas()
        {
            if(ChCalculado.Checked==false && ChDefault.Checked==false)
            {
                TFormula.Enabled = false;
                TDefault.Enabled = false;
                return;
            }
            TDefault.Enabled = ChDefault.Checked;
            TFormula.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok = true;
            if (NombreX == "")
                ok = false;
            if (ComboTipoDato.SelectedIndex == -1)
                ok = false;
            if(ChCalculado.Checked || ChDefault.Checked)
            {
                if (Formula == "")
                    ok = false;
            }
            if (ChDefault.Checked && DefaultName == "")
                ok = false;
            BAceptar.Enabled = ok;
        }

        private void ComboTipoDato_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboTipoDato.SelectedIndex == -1)
                return;
            Modelo.CTipoDato tipo = (Modelo.CTipoDato)ComboTipoDato.SelectedItem;
            if(tipo.TipoLongitud== TIPO_LONGITUD.NOREQUERIDO)
            {
                TLongitud.Enabled = false;
            }
            else
            {
                TLongitud.Enabled = true;
            }
        }
    }
}
