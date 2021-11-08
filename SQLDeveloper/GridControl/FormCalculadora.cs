using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridControl
{
    public partial class FormCalculadora : Form
    {
        private DataTable FTabla;
        public DataTable Tabla
        {
            get
            {
                return FTabla;
            }
            set
            {
                FTabla = value;
            }
        }
        public FormCalculadora()
        {
            InitializeComponent();
            //asigno las operaciones
            ComboOperacion.Items.Add("Promedio");
            ComboOperacion.Items.Add("Suma");
            ComboOperacion.Items.Add("Maxivo");
            ComboOperacion.Items.Add("Minimo");
            ComboOperacion.Items.Add("Cuenta");
        }

        private void BCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            if (FTabla == null)
                return;
            //me traigo la tabla
            //limpio el combo de los campos
            ComboCampo.Items.Clear();
            //lleno el combo
            foreach (DataColumn dc in FTabla.Columns)
            {
                if (EsNumerico(dc))
                {
                    //solo los que son numericos se pueden hacer las operaciones
                    ComboCampo.Items.Add(dc.ColumnName);
                }
            }
        }
        private bool EsNumerico(DataColumn dc)
        {
            if (dc.DataType == typeof(Byte))
                return true;
            if (dc.DataType == typeof(Decimal))
                return true;
            if (dc.DataType == typeof(Double))
                return true;
            if (dc.DataType == typeof(Int16))
                return true;
            if (dc.DataType == typeof(Int32))
                return true;
            if (dc.DataType == typeof(Int64))
                return true;
            if (dc.DataType == typeof(UInt16))
                return true;
            if (dc.DataType == typeof(UInt32))
                return true;
            if (dc.DataType == typeof(UInt64))
                return true;
            return false;
        }


        private void BCalcular_Click(object sender, EventArgs e)
        {
            if (ComboCampo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ComboOperacion.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una operación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                //me traigo la tabla
                //ahora me traigo el campo
                string Campo = ComboCampo.SelectedItem.ToString();
                //selecciono la operacion a realizar
                switch (ComboOperacion.SelectedIndex)
                {
                    case 0: //promedio
                        Promedio( Campo);
                        break;
                    case 1: //suma
                        Suma( Campo);
                        break;
                    case 2: //maximo
                        Maximo( Campo);
                        break;
                    case 3: //minimo
                        Minimo( Campo);
                        break;
                    case 4: //cuenta
                        Cuenta( Campo);
                        break;
                }
            }
            catch(System.Exception)
            {
                TResultado.Text = "Imposible hacer el calculo";
            }
        }
        private void Promedio( string columna)
        {
            object res = FTabla.Compute("avg(" + columna + ")", columna+"="+ columna);
            TResultado.Text = res.ToString();
        }
        private void Suma( string columna)
        {
            object res = FTabla.Compute("sum(" + columna + ")", columna + "=" + columna);
            TResultado.Text = res.ToString();

        }
        private void Maximo(string columna)
        {
            object res = FTabla.Compute("max(" + columna + ")", columna + "=" + columna);
            TResultado.Text = res.ToString();

        }
        private void Minimo(string columna)
        {
            object res = FTabla.Compute("min(" + columna + ")", columna + "=" + columna);
            TResultado.Text = res.ToString();

        }
        private void Cuenta(string columna)
        {
            object res = FTabla.Compute("count(" + columna + ")", columna + "=" + columna);
            TResultado.Text = res.ToString();

        }
    }
}
