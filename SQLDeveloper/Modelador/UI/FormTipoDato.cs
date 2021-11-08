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
    public partial class FormTipoDato : Form
    {
        public FormTipoDato()
        {
            InitializeComponent();
            //carlo los tipod de lonfitud
            ComboTipoLongitud.Items.Add(TIPO_LONGITUD.NOREQUERIDO);
            ComboTipoLongitud.Items.Add(TIPO_LONGITUD.OBLIGATORIO);
            ComboTipoLongitud.Items.Add(TIPO_LONGITUD.OPCIONAL);
        }
        public string Nombre
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
        public TIPO_LONGITUD TipoLongitud
        {
            get
            {
                return (TIPO_LONGITUD)ComboTipoLongitud.SelectedItem;
            }
            set
            {
                for(int i=0;i<ComboTipoLongitud.Items.Count; i++)
                {
                    TIPO_LONGITUD t =(TIPO_LONGITUD)ComboTipoLongitud.Items[i];
                    if(t.ToString()==value.ToString())
                    {
                        ComboTipoLongitud.SelectedIndex = i;
                        return;
                    }
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok = true;
            if (Nombre == "")
                ok = false;
            if (ComboTipoLongitud.SelectedIndex == -1)
                ok = false;
            BAceptar.Enabled = ok;
        }
    }
}
