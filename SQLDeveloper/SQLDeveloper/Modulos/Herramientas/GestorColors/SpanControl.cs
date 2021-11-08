using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SintaxColor;

namespace SQLDeveloper.Modulos.Herramientas.GestorColors
{
    public partial class SpanControl : CControlBase
    {
        private CSpan Span;
        public SpanControl()
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
        public bool Negrita
        {
            get
            {
                return ChNegritas.Checked;
            }
            set
            {
                ChNegritas.Checked = value;
            }
        }
        public bool Cursiva
        {
            get
            {
                return ChCursiva.Checked;
            }
            set
            {
                ChCursiva.Checked = value;
            }
        }
        public bool stopateol
        {
            get
            {
                return ChStopateol.Checked;
            }
            set
            {
                ChStopateol.Checked = value;
            }
        }
        public Color Color
        {
            get
            {
                return ColoSpan.Color;
            }
            set
            {
                ColoSpan.Color = value;
            }
        }
        public string Inicio
        {
            get
            {
                return TInicio.Text;
            }
            set
            {
                TInicio.Text = value;
            }
        }
        public string Fin
        {
            get
            {
                return TFin.Text;
            }
            set
            {
                TFin.Text = value;
            }
        }
        public override void Recarga()
        {
            if (Objeto == null)
                return;
            Span = (CSpan)Objeto;
            Nombre = Span.name;
            Negrita = Span.bold;
            Cursiva = Span.italic;
            stopateol = Span.stopateol;
            Color = Span.color.Color;
            Inicio = Span.Begin;
            Fin = Span.End;
        }

        private void TNombre_TextChanged(object sender, EventArgs e)
        {
            Span.name = Nombre;
        }

        private void TInicio_TextChanged(object sender, EventArgs e)
        {
            Span.Begin = Inicio;
        }

        private void TFin_TextChanged(object sender, EventArgs e)
        {
            Span.End = Fin;
        }

        private void ChNegritas_CheckedChanged(object sender, EventArgs e)
        {
            Span.bold = Negrita;
        }

        private void ChCursiva_CheckedChanged(object sender, EventArgs e)
        {
            Span.italic = Cursiva;
        }

        private void ChStopateol_CheckedChanged(object sender, EventArgs e)
        {
            Span.stopateol = stopateol;
        }

        private void ColoSpan_OnColorCahnge(CComponetColor sender, Color color)
        {
            Span.color.Color = Color;
        }
    }
}
