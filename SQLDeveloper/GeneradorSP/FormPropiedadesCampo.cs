using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneradorSP
{
    public partial class FormPropiedadesCampo : Form
    {
        private bool ControlKey;
        public FormPropiedadesCampo()
        {
            InitializeComponent();
            CargaTiposdeCampos();
        }
        private void CargaTiposdeCampos()
        {
            ComboTipos.Items.Add(new Objetos.CTipoDato("bigint", false));
            ComboTipos.Items.Add(new Objetos.CTipoDato("binary", true));
            ComboTipos.Items.Add(new Objetos.CTipoDato("bit", false));
            ComboTipos.Items.Add(new Objetos.CTipoDato("char", true));
            ComboTipos.Items.Add(new Objetos.CTipoDato("datetime", false));
            ComboTipos.Items.Add(new Objetos.CTipoDato("decimal", false));
            ComboTipos.Items.Add(new Objetos.CTipoDato("float", false));
            ComboTipos.Items.Add(new Objetos.CTipoDato("image", false));
            ComboTipos.Items.Add(new Objetos.CTipoDato("int", false));
            ComboTipos.Items.Add(new Objetos.CTipoDato("money", false));
            ComboTipos.Items.Add(new Objetos.CTipoDato("nchar", true));
            ComboTipos.Items.Add(new Objetos.CTipoDato("ntext", false));
            ComboTipos.Items.Add(new Objetos.CTipoDato("numeric", false));
            ComboTipos.Items.Add(new Objetos.CTipoDato("nvarchar", true));
            ComboTipos.Items.Add(new Objetos.CTipoDato("real", false));
            ComboTipos.Items.Add(new Objetos.CTipoDato("smalldatetime", false));
            ComboTipos.Items.Add(new Objetos.CTipoDato("smallint", false));
            ComboTipos.Items.Add(new Objetos.CTipoDato("smallmoney", false));
            ComboTipos.Items.Add(new Objetos.CTipoDato("sql_variant", false));
            ComboTipos.Items.Add(new Objetos.CTipoDato("sysname", false));
            ComboTipos.Items.Add(new Objetos.CTipoDato("text", false));
            ComboTipos.Items.Add(new Objetos.CTipoDato("timestamp", false));
            ComboTipos.Items.Add(new Objetos.CTipoDato("tinyint", false));
            ComboTipos.Items.Add(new Objetos.CTipoDato("uniqueidentifier", false));
            ComboTipos.Items.Add(new Objetos.CTipoDato("varbinary", true));
            ComboTipos.Items.Add(new Objetos.CTipoDato("varchar", true));
            ComboTipos.Items.Add(new Objetos.CTipoDato("xml", false));
        }

        private void FormPropiedadesCampo_Load(object sender, EventArgs e)
        {
        }

        private void TNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ControlKey == true)
                return;
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == '\b')
                return;
            if (e.KeyChar == '_')
                return;
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar < 'a' || e.KeyChar > 'z') && (e.KeyChar < 'A' || e.KeyChar > 'Z'))
                e.Handled = true;
        }

        private void Tlongitud_KeyPress(object sender, KeyPressEventArgs e)
        {
            //valido que solo acepte numeros
            if (e.KeyChar == '\b')
                return;
            if (e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
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
                Objetos.CTipoDato obj;
                obj = (Objetos.CTipoDato)ComboTipos.Items[ComboTipos.SelectedIndex];
                return obj.Nombre;
            }
            set
            {
                int i, n;
                n = ComboTipos.Items.Count;
                for (i = 0; i < n; i++)
                {
                    Objetos.CTipoDato obj;
                    obj = (Objetos.CTipoDato)ComboTipos.Items[i];
                    if (value.ToLower().Trim() == obj.Nombre.ToLower().Trim())
                    {
                        ComboTipos.SelectedIndex = i;
                        return;
                    }
                }
                ComboTipos.SelectedIndex = -1;
            }
        }
        public int Longitud
        {
            get
            {
                if (Tlongitud.Text.Trim() == "")
                    return 0;
                return int.Parse(Tlongitud.Text);
            }
            set
            {
                Tlongitud.Text = value.ToString();
            }
        }
        public string PermitirNulos
        {
            get
            {
                if (CHNulos.Checked == true)
                    return "SI";
                return "NO";
            }
            set
            {
                if (value.ToUpper().Trim() == "SI")
                    CHNulos.Checked = true;
                else
                    CHNulos.Checked = false;
            }
        }
        public bool ValorPorDefault
        {
            get
            {
                return CHDefault.Checked;
            }
            set
            {
                CHDefault.Checked = value;
            }
        }
        public string Default
        {
            get
            {
                return TDefault.Text;
            }
            set
            {
                TDefault.Text = value;
            }
        }
        public bool AuntoIncremental
        {
            get
            {
                return CHIncremental.Checked;
            }
            set
            {
                CHIncremental.Checked = value;
            }
        }
        public int ValorCalculado
        {
            get
            {
                if (CHCalculado.Checked == true)
                    return 1;
                else
                    return 0;
            }
            set
            {
                if (value == 1)
                    CHCalculado.Checked = true;
                else
                    CHCalculado.Checked = false;

            }
        }
        public string ExprecionCalculado
        {
            get
            {
                return TCalculado.Text;
            }
            set
            {
                TCalculado.Text = value;
            }
        }
        public string Docuemntacion
        {
            get
            {
                return TDocuementacion.Text;
            }
            set
            {
                TDocuementacion.Text = value;
            }
        }

        private void CHDefault_CheckedChanged(object sender, EventArgs e)
        {
            TDefault.Enabled = CHDefault.Checked;
        }

        private void CHCalculado_CheckedChanged(object sender, EventArgs e)
        {
            TCalculado.Enabled = CHCalculado.Checked;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok = true;
            if (TNombre.Text.Trim() == "")
                ok = false;
            else
            {
                if (ComboTipos.SelectedIndex > -1)
                {
                    Objetos.CTipoDato obj = (Objetos.CTipoDato)ComboTipos.Items[ComboTipos.SelectedIndex];
                    if (obj.Variable == true)
                    {
                        if (Tlongitud.Text.Trim() == "")
                            ok = false;
                    }
                }
            }
            if (CHDefault.Checked == true)
            {
                if (TDefault.Text.Trim() == "")
                    ok = false;
            }
            if (CHCalculado.Checked == true)
            {
                if (TCalculado.Text.Trim() == "")
                    ok = false;
                if (CHIncremental.Checked == true)
                    ok = false;
                if (CHDefault.Checked == true)
                    ok = false;
            }
            else if (ComboTipos.SelectedIndex == -1)
                ok = false;

            BAceptar.Enabled = ok;
        }

        private void ComboTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Objetos.CTipoDato obj = (Objetos.CTipoDato)ComboTipos.Items[ComboTipos.SelectedIndex];
            Tlongitud.Enabled = obj.Variable;
        }
        public bool Variable
        {
            get
            {
                return Tlongitud.Enabled;
            }
        }

        private void TNombre_KeyDown(object sender, KeyEventArgs e)
        {
            ControlKey = e.Control;
        }
    }
}