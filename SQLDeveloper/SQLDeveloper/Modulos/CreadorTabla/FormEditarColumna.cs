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
    public partial class FormEditarColumna : Form
    {
        private CTabla Tabla;
        private string TableName;
        private TIPO_LONGITUD FTipoLongitud;
        public FormEditarColumna(CTabla tabla)
        {
            Tabla = tabla;
            TableName = tabla.Nombre;           
            InitializeComponent();
            CargaTabla();
        }
        private void CargaTabla()
        {
            //me traigo la tabla
            ComboCampos.Items.Clear();
            TTabla.Text = TableName;
            //lleno los datos del combo
            foreach(MotorDB.CCampo campo in Tabla.Campos)
            {
                ComboCampos.Items.Add(campo);
            }
            //cargo los tipos de datos
            ComboTipo.Items.Clear();
            foreach(MotorDB.CTipoDato tipo in DBProvider.DB.DameTiposDato())
            {
                ComboTipo.Items.Add(tipo);
            }
            LimpiaControles();
        }
        private void LimpiaControles()
        {
            //limpia los controles que muestran las caracteristicas del campo seleccionado
            TNombreCampo.Text = "";
            ComboTipo.SelectedIndex = -1;
            TLongitud.Value = 0;
            CHNulos.Checked = true;
        }
        private void FormEditarColumna_Load(object sender, EventArgs e)
        {
        }

        private void ComboCampos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboCampos.SelectedIndex == -1)
                return;
            Baceptar.Enabled = true;
            //me traigo el campo
            MotorDB.CCampo campo = (MotorDB.CCampo)ComboCampos.SelectedItem;
            //muestro los datos del campo
            TNombreCampo.Text = campo.Nombre;
            ComboTipo.SelectedItem = campo.TipoDato;
            if (campo.TipoDato.UsaLongitud!= TIPO_LONGITUD.NOREQUERIDO)
            {
                TLongitud.Value = campo.Longitud;
                TLongitud.Enabled = true;
            }
            else
            {
                TLongitud.Value = 0;
                TLongitud.Enabled = false;
            }
            CHNulos.Checked = campo.AceptaNulo;
                Bdefault.Enabled = campo.EsDefault;
            Baceptar.Enabled = !campo.CampoCalculado;
            LCalculado.Visible= campo.CampoCalculado;
        }
        private  bool ValidaDatos()
        {
            if(ComboCampos.SelectedIndex==-1)
            {
                MessageBox.Show("Seleccione un campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(ComboTipo.SelectedIndex==-1)
            {
                MessageBox.Show("Seleccione el tipo de dato", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //verifico el tipo de datos
            MotorDB.CTipoDato td = (MotorDB.CTipoDato)ComboTipo.SelectedItem;
            if (td.UsaLongitud== TIPO_LONGITUD.OBLIGATORIO)
            {
                if(TLongitud.Value==0)
                {
                    MessageBox.Show("debe asignar la longitud", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            //todo ok
            return true;
        }
        private MotorDB.CCampo ExtraeCampo()
        {
            //regresa el campo con los datos seleccionados
            MotorDB.CCampo campo = new MotorDB.CCampo();
            campo.Nombre = TNombreCampo.Text;
            campo.TipoDato = (MotorDB.CTipoDato)ComboTipo.SelectedItem;
            campo.Longitud = (int)TLongitud.Value;
            campo.AceptaNulo = CHNulos.Checked;
            return campo;
        }
        private void Baceptar_Click(object sender, EventArgs e)
        {
            if(ValidaDatos()==false)
            {
                DialogResult = DialogResult.None;
                return;
            }
            //me traigo los valores seleccionados por el usuario
            MotorDB.CCampo campo = (MotorDB.CCampo)ComboCampos.SelectedItem;
            MotorDB.CCampo nuevo = ExtraeCampo();
            try
            {
                foreach(CCampo obj in                Tabla.Campos)
                {
                    if(obj.Nombre==campo.Nombre)
                    {
                        obj.AceptaNulo = nuevo.AceptaNulo;
                        obj.CampoCalculado = nuevo.CampoCalculado;
                        obj.DefaultName = nuevo.DefaultName;
                        obj.Formula = nuevo.Formula;
                        obj.Longitud = nuevo.Longitud;
                        obj.Nombre = nuevo.Nombre;
                        obj.Tipo = nuevo.Tipo;
                        obj.TipoDato = nuevo.TipoDato;
                        return;
                    }
                }
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
        }

        private void Bdefault_Click(object sender, EventArgs e)
        {
            MotorDB.CCampo campo = (MotorDB.CCampo)ComboCampos.SelectedItem;
            if (MessageBox.Show("Seguro que quiere quitar el valor default al campo: " + campo.Nombre, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                Tabla.RemoveDeafult(campo.Nombre);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
            CargaTabla();
        }

        private void ComboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MotorDB.CTipoDato TipoDato = (MotorDB.CTipoDato)ComboTipo.SelectedItem;
            EnableLongitd = TipoDato.UsaLongitud;

        }
        private TIPO_LONGITUD  EnableLongitd
        {
            get
            {
                return FTipoLongitud;//TLongitud.Visible;
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
        public string Campo
        {
            set
            {
                foreach(MotorDB.CCampo obj in ComboCampos.Items)
                {
                    if(obj.Nombre==value)
                    {
                        ComboCampos.SelectedItem = obj;
                        ComboCampos.Enabled = false;
                        return;
                    }
                }
            }
        }
    }
}
