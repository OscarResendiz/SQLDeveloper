using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeneradorSP
{
    public partial class FormPropParametro : Form
    {
        public FormPropParametro()
        {
            InitializeComponent();
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
        public string Comentario
        {
            get
            {
                return TComentario.Text;
            }
            set
            {
                TComentario.Text = value;
            }
        }
    }
}