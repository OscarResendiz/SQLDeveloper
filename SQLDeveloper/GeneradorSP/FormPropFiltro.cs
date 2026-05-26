using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeneradorSP
{
    public partial class FormPropFiltro : Form
    {
        List<Objetos.CParametro> Parametros;
        public FormPropFiltro()
        {
            InitializeComponent();
            //carga los parametros 
            Parametros = (List<Objetos.CParametro>)AsistBaseSP.DameValor("ListaParametros");
            foreach (Objetos.CParametro obj in Parametros)
            {
                ComboParametros.Items.Add(obj);
            }
        }
        public string Nombre
        {
            get
            {
                return TNombre.Text;
            }
            set
            {
                TNombre.Text = value;
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
        public Objetos.TIPO_FILTRO Filtro
        {
            get
            {
                if (RBIgual.Checked == true)
                    return Objetos.TIPO_FILTRO.IGUAL;
                if (RBDiferente.Checked == true)
                    return Objetos.TIPO_FILTRO.DIFERENTE;
                if (RBLike.Checked == true)
                    return Objetos.TIPO_FILTRO.LIKE;
                if (RBMayoIgual.Checked == true)
                    return Objetos.TIPO_FILTRO.MAYOR_IGUAL;
                if (RBMayor.Checked == true)
                    return Objetos.TIPO_FILTRO.MAYOR_QUE;
                if (RBMenor.Checked == true)
                    return Objetos.TIPO_FILTRO.MENOR_QUE;
                return Objetos.TIPO_FILTRO.MENOR_IGUAL;
            }
            set
            {
                switch (value)
                {
                    case Objetos.TIPO_FILTRO.DIFERENTE:
                        RBDiferente.Checked = true;
                        break;
                    case Objetos.TIPO_FILTRO.IGUAL:
                        RBIgual.Checked = true;
                        break;
                    case Objetos.TIPO_FILTRO.LIKE:
                        RBLike.Checked = true;
                        break;
                    case Objetos.TIPO_FILTRO.MAYOR_IGUAL:
                        RBMayoIgual.Checked = true;
                        break;
                    case Objetos.TIPO_FILTRO.MAYOR_QUE:
                        RBMayor.Checked = true;
                        break;
                    case Objetos.TIPO_FILTRO.MENOR_IGUAL:
                        RBMenorIgual.Checked = true;
                        break;
                    case Objetos.TIPO_FILTRO.MENOR_QUE:
                        RBMenor.Checked = true;
                        break;
                }
            }
        }
        public string Parametro
        {
            get
            {
                if (ComboParametros.SelectedIndex == -1)
                    return "";
                Objetos.CParametro obj = (Objetos.CParametro)ComboParametros.Items[ComboParametros.SelectedIndex];
                return obj.nombre;
            }
            set
            {
                int i, n;
                n=ComboParametros.Items.Count;
                for(i=0;i<n;i++)
                {
                    Objetos.CParametro obj =(Objetos.CParametro)ComboParametros.Items[i];
                    if(obj.nombre==value)
                    {
                        ComboParametros.SelectedIndex=i;
                        return;
                    }
                }
                ComboParametros.SelectedIndex=-1;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok = true;
            if (ComboParametros.SelectedIndex == -1)
                ok = false;
            BAceptar.Enabled = ok;
        }
    }
}