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
namespace SQLDeveloper.Modulos.CreadorTabla
{
    public partial class FormAgregarCampo : Form
    {
        CTabla Tabla;
        private CTipoDato TipoDato;
        TIPO_LONGITUD FTipoLongitud;
        public FormAgregarCampo(CTabla tabla)
        {
            //me traigo la tabla
            Tabla = tabla;
            InitializeComponent();
        }
        private void CargaTiposDatos()
        {
            ComboTipo.Items.Clear();
            List<CTipoDato> l=DBProvider.DB.DameTiposDato();
            foreach(CTipoDato obj in l)
            {
                ComboTipo.Items.Add(obj);
            }
        }
        private TIPO_LONGITUD EnableLongitd
        {
            get
            {
                return FTipoLongitud;// TLongitud.Visible;
            }
            set
            {
                FTipoLongitud = value;
                if (FTipoLongitud== TIPO_LONGITUD.NOREQUERIDO)
                TLongitud.Enabled = false;
                else
                    TLongitud.Enabled = true;
                //LLongitud.Visible = value;
            }
        }
        private void FormAgregarCampo_Load(object sender, EventArgs e)
        {
            //inicializo componentes
            TTabla.Text = Tabla.Nombre;
            EnableLongitd =  TIPO_LONGITUD.NOREQUERIDO; //por default no se va a poder ver la longitud
            EnableAutoIncremental = false; //por default no es auto incremental
            EnableValInicial = false;
            EnableMasterAutoIncvremental = true;
            CargaTiposDatos();
        }

        private void ComboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoDato = (CTipoDato)ComboTipo.SelectedItem;
            EnableLongitd = TipoDato.UsaLongitud;
        }
        private bool EnableAutoIncremental
        {
            set
            {
                TValorInicial.Enabled = value;
                TIncremento.Enabled = value;
            }
        }
        private bool EnableValInicial
        {
            set
            {
                TValor.Enabled = value;
                RBDefault.Enabled = value;
                RBCalculado.Enabled = value;
            }
        }

        private void CHAutoIncremental_CheckedChanged(object sender, EventArgs e)
        {
            EnableAutoIncremental = CHAutoIncremental.Checked;
            EnableMasterAvanzado=!CHAutoIncremental.Checked;
        }

        private void CHInicializado_CheckedChanged(object sender, EventArgs e)
        {
            EnableValInicial = CHInicializado.Checked;
            EnableMasterAutoIncvremental = !CHInicializado.Checked;
        }
        private bool EnableMasterAvanzado
        {
            set
            {
                CHInicializado.Enabled = value;
                EnableValInicial = value;
            }
        }
        private bool EnableMasterAutoIncvremental
        {
            set
            {
                if (Tabla.Identidad != null)
                {
                    CHAutoIncremental.Enabled = false;
                    EnableAutoIncremental = false;
                    return;

                }
                CHAutoIncremental.Enabled = value;
                EnableAutoIncremental = value;
            }
        }
        private void BAceptar_Click(object sender, EventArgs e)
        {
            CIdentidad identidad = null;
            try
            {
                //valido los datos
                if (TNombre.Text.Trim() == "")
                {
                    MessageBox.Show("Falta el nombre del campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                    TNombre.Focus();
                    return;
                }
                //verifico que no se repita
                if (Tabla.GetCampo(TNombre.Text) != null)
                {
                    MessageBox.Show("El campo ya existe en la tabla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                    TNombre.Focus();
                    return;
                }
                if(ComboTipo.SelectedIndex==-1)
                {
                    MessageBox.Show("Seleccione el tipo de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                    ComboTipo.Focus();
                    return;

                }
                if (TipoDato.UsaLongitud== TIPO_LONGITUD.OBLIGATORIO)
                {
                    if (TLongitud.Value == 0)
                    {
                        MessageBox.Show("Nececita asignar una longitud", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DialogResult = DialogResult.None;
                        TLongitud.Focus();
                        return;
                    }
                }
                if (CHAutoIncremental.Checked)
                {
                    if (TIncremento.Value == 0)
                    {
                        MessageBox.Show("el incremento no puede ser cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DialogResult = DialogResult.None;
                        TIncremento.Focus();
                        return;
                    }
                }
                if (CHInicializado.Checked)
                {
                    if (TValor.Text.Trim() == "")
                    {
                        MessageBox.Show("Nececita asignar el valor inicial", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DialogResult = DialogResult.None;
                        TValor.Focus();
                        return;
                    }
                }
                //ahora si mando a agregar el campo a la tabla
                CCampo campo = new CCampo();
                campo.Nombre = TNombre.Text;
                campo.TipoDato = TipoDato;
                campo.Longitud = (int)TLongitud.Value;
                campo.AceptaNulo = CHNulos.Checked;
                if (CHInicializado.Enabled == true && CHInicializado.Checked)
                {
                    campo.CampoCalculado = RBCalculado.Checked;
                    campo.EsDefault = RBDefault.Checked;
                    campo.Formula = TValor.Text;
                }
                if (CHAutoIncremental.Enabled && CHAutoIncremental.Checked)
                {
                    identidad = new CIdentidad();
                    identidad.Nombre = "idt" + Tabla.Nombre;
                    identidad.Campo = campo;
                    identidad.ValorInicial = (int)TValorInicial.Value;
                    identidad.Incremento = (int)TIncremento.Value;
                    Tabla.Identidad = identidad;
                }
                Tabla.AddCampo(campo);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
        }
    }
}
