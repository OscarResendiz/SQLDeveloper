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
    public partial class PropertyControl : CControlBase
    {
        CProperty Property;

        public PropertyControl()
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
        public string Valor
        {
            get
            {
                return TValor.Text;
            }
            set
            {
                TValor.Text = value;
            }
        }
        public bool NombreSoloLectura
        {
            get
            {
                return TNombre.ReadOnly;
            }
            set
            {
                TNombre.ReadOnly = value;
            }
        }
        public override void Recarga()
        {
            Property = (CProperty)Objeto;
            Nombre = Property.name;
            Valor = Property.value;
        }

        private void TNombre_TextChanged(object sender, EventArgs e)
        {
            Property.name = Nombre;
        }

        private void TValor_TextChanged(object sender, EventArgs e)
        {
            Property.value = Valor;
        }
    }
}
