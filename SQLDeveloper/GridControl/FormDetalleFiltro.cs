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
    public partial class FormDetalleFiltro : Form
    {
        private DataSet DtSet;
        public FormDetalleFiltro()
        {
            InitializeComponent();
            //lleno el combo de condiciones
            ComboCondicion.Items.Add("Empieza con...");
            ComboCondicion.Items.Add("Contiene...");
            ComboCondicion.Items.Add("Termina con...");
            ComboCondicion.Items.Add("No empieza con...");
            ComboCondicion.Items.Add("No contiene...");
            ComboCondicion.Items.Add("No termina con...");
            ComboCondicion.Items.Add("Exactamente igual a...");
            ComboCondicion.Items.Add(">");
            ComboCondicion.Items.Add(">=");
            ComboCondicion.Items.Add("=");
            ComboCondicion.Items.Add("<>");
            ComboCondicion.Items.Add("<=");
            ComboCondicion.Items.Add("<");
        }
        public DataSet DataSet
        {
            get
            {
                return DtSet;
            }
            set
            {
                DtSet = value;
                if (DtSet == null)
                    return;
                //lleno los combos
                ComboTabla.Items.Clear();
                ComboCampo.Items.Clear();
                foreach (DataTable dt in DtSet.Tables)
                {
                    ComboTabla.Items.Add(dt.TableName);
                }
                if (ComboTabla.Items.Count == 1)
                {
                    ComboTabla.SelectedIndex = 0;
                    ComboTabla.Enabled = false;
                }
            }
        }
        private void AgregaCampo(DataColumn campo)
        {
            foreach(string c in ComboCampo.Items)
            {
                if ( c.ToUpper().Trim() == campo.ColumnName.ToUpper().Trim())
                    return;
            }
            ComboCampo.Items.Add(campo.ColumnName);
        }
        private DataTable DameTabla(string nombre)
        {
            foreach(DataTable dt in DtSet.Tables)
            {
                if (dt.TableName == nombre)
                    return dt;
            }
            return null;
        }
        private void ComboTabla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboTabla.SelectedIndex == -1)
                return;
            DataTable dt = DameTabla(ComboTabla.SelectedItem.ToString());
            //filtro los campos que pertenecen a la tabla
            ComboCampo.Items.Clear();
            //busco la tabla
            foreach(DataColumn dc in dt.Columns)
            {
                AgregaCampo(dc);
            }
        }

        private bool EsNumerico(DataColumn dc)
        {
            if (dc.DataType == typeof(Boolean))
                return true;
            if (dc.DataType == typeof(Byte))
                return true;
            if (dc.DataType == typeof(DateTime))
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
            if (dc.DataType == typeof(TimeSpan))
                return true;
            if (dc.DataType == typeof(UInt16))
                return true;
            if (dc.DataType == typeof(UInt32))
                return true;
            if (dc.DataType == typeof(UInt64))
                return true;
            return false;
        }
        private DataColumn DameCampo(string nombre)
        {
            DataTable dt = DameTabla(ComboTabla.SelectedItem.ToString());
            foreach (DataColumn dc in dt.Columns)
            {
                if (dc.ColumnName == nombre)
                    return dc;
            }
            return null;
        }
        private void ComboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboCampo.SelectedIndex == -1)
                return;
            DataColumn dc = DameCampo(ComboCampo.SelectedItem.ToString());
            ComboCondicion.Items.Clear();
            if (EsNumerico(dc))
            {
                ComboCondicion.Items.Add(">");
                ComboCondicion.Items.Add(">=");
                ComboCondicion.Items.Add("=");
                ComboCondicion.Items.Add("<>");
                ComboCondicion.Items.Add("<=");
                ComboCondicion.Items.Add("<");
            }
            else
            {
                ComboCondicion.Items.Add("Empieza con...");
                ComboCondicion.Items.Add("Contiene...");
                ComboCondicion.Items.Add("Termina con...");
                ComboCondicion.Items.Add("No empieza con...");
                ComboCondicion.Items.Add("No contiene...");
                ComboCondicion.Items.Add("No termina con...");
                ComboCondicion.Items.Add("Exactamente igual a...");
            }
        }
        private void BAceptar_Click(object sender, EventArgs e)
        {
            if(ComboTabla.SelectedIndex==-1)
            {
                MessageBox.Show("Hay que seleccionar una tabla","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
            if (ComboCampo.SelectedIndex == -1)
            {
                MessageBox.Show("Hay que seleccionar una campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
            if (ComboCondicion.SelectedIndex == -1)
            {
                MessageBox.Show("Hay que seleccionar una condicion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
            if (TValor.Text.Trim()== "")
            {
                MessageBox.Show("Falta el valor a comparar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
            if(ValidaTipoDato()==false)
            {
                MessageBox.Show("El dato no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;

            }
        }
        public string Tabla
        {
            get
            {
                return ComboTabla.SelectedItem.ToString();
            }
            set
            {
                //recorro todos los registros para buscar la tabla
                foreach (string dt in ComboTabla.Items)
                {
                    if (dt== value)
                    {
                        ComboTabla.SelectedItem = dt;
                        return;
                    }
                }
            }
        }
        public string Campo
        {
            get
            {
                return ComboCampo.SelectedItem.ToString();
            }
            set
            {
                foreach(string dc in ComboCampo.Items)
                {
                    if(dc.ToUpper().Trim()==value.ToUpper().Trim())
                    {
                        ComboCampo.SelectedItem = dc;
                        return;
                    }
                }
            }
        }
        public string Condicion
        {
            get
            {
                return ComboCondicion.SelectedItem.ToString();
            }
            set
            {
                ComboCondicion.SelectedItem = value;
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
        private bool ValidaTipoDato()
        {
            DataColumn cd = DameCampo(Campo);
            Type TipoDato = cd.DataType;
            string s = Valor;
            try
            {
                if (TipoDato == typeof(Boolean))
                {
                    Boolean a = Boolean.Parse(s);
                    return true;
                }
                if (TipoDato == typeof(Byte))
                {
                    Byte a = Byte.Parse(s);
                    return true;
                }
                if (TipoDato == typeof(DateTime))
                {
                    DateTime a = DateTime.Parse(s);
                    return true;
                }
                if (TipoDato == typeof(Decimal))
                {
                    Decimal a = Decimal.Parse(s);
                    return true;
                }
                if (TipoDato == typeof(Double))
                {
                    Double a = Double.Parse(s);
                    return true;
                }
                if (TipoDato == typeof(Int16))
                {
                    Int16 a = Int16.Parse(s);
                    return true;
                }
                if (TipoDato == typeof(Int32))
                {
                    Int32 a = Int32.Parse(s);
                    return true;
                }
                if (TipoDato == typeof(Int64))
                {
                    Int64 a = Int64.Parse(s);
                    return true;
                }
                if (TipoDato == typeof(TimeSpan))
                {
                    TimeSpan a = TimeSpan.Parse(s);
                    return true;
                }
                if (TipoDato == typeof(UInt16))
                {
                    UInt16 a = UInt16.Parse(s);
                    return true;
                }
                if (TipoDato == typeof(UInt32))
                {
                    UInt32 a = UInt32.Parse(s);
                    return true;
                }
                if (TipoDato == typeof(UInt64))
                {
                    UInt64 a = UInt64.Parse(s);
                    return true;
                }
            }
            catch(System.Exception)
            {
                return false;
            }
            return true;
        }
    }
}
