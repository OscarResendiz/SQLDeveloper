using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MotorDB;
using SPGenerator.Objetos;
namespace SPGenerator
{
    public partial class FormNuevoCampo : Form
    {
        private DialogResult result;
        IMotorDB DB;
        public FormNuevoCampo(IMotorDB db)
        {
            DB = db;
            InitializeComponent();
            result = DialogResult;
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

        private void ComboTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Objetos.CTipoDato obj = (Objetos.CTipoDato)ComboTipos.Items[ComboTipos.SelectedIndex];
            Tlongitud.Enabled = obj.Variable;
        }

        private void RdbManual_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbManual.Checked == true)
            {
                PnlManual.Enabled = true;
                PnlTabla.Enabled = false;
            }
            else
            {
                PnlManual.Enabled = false;
                PnlTabla.Enabled = true;
            }
        }

        private void animatedWaitTextBox1_EsperaCompletada(string Texto, int Decimas)
        {
            try
            {
                ListaObjetos.Items.Clear();
                DlstCampos.Items.Clear();
                List<CObjeto> Lista;
                Lista = DB.Buscar(Texto.Trim(), EnumTipoObjeto.TABLE);
                int i, n;
                n = Lista.Count;
                for (i = 0; i < n; i++)
                {
                    CObjeto obj = Lista[i];
                    ListaObjetos.Items.Add(obj.Nombre);
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void ListaObjetos_SelectedIndexChanged(object sender, EventArgs e)
        {
            DlstCampos.Items.Clear();
            if (ListaObjetos.SelectedIndex == -1)
                return;
            List<CCampo> campos;
            string tabla=(string)ListaObjetos.Items[ListaObjetos.SelectedIndex];
            campos = DB.DameCamposTabla(tabla);
            foreach (CCampo obj in campos)
            {
                DlstCampos.Items.Add(obj);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //valido los datos segun el tipo de campo que se va a utilizar (manual o desde una tabla)
            bool ok=true;
            if (RdbManual.Checked == true)
            {
                if (TxtNombreCampo.Text.Trim() == "")
                    ok = false;
                if (ComboTipos.SelectedIndex == -1)
                    ok = false;
                if (Tlongitud.Enabled == true)
                {
                    if (Tlongitud.Text.Trim() == "")
                        ok = false;
                }
            }
            else
            {
                //es de una tabla
                if (DlstCampos.SelectedIndex == -1)
                    ok = false;
                if(ListaObjetos.SelectedIndex==-1)
                    ok=false;
            }
            BAceptar.Enabled=ok;
        }

        private void animatedWaitTextBox1_Load(object sender, EventArgs e)
        {

        }
        public CParametroSP Parametro
        {
            get
            {
                CParametroSP obj =null;
                if (RdbManual.Checked == true)
                {
                    obj = new CParametroSP();
                    obj.nombre = TxtNombreCampo.Text;
                    Objetos.CTipoDato tipo;
                    tipo = (Objetos.CTipoDato)ComboTipos.Items[ComboTipos.SelectedIndex];
                    obj.tipo = tipo.Nombre;
                    obj.ValidarUnicidad = false;
                    obj.Descripcion = "";
                    obj.Vacios = true;
                    if (Tlongitud.Text.Trim() != "")
                    {
                        obj.Logitud = int.Parse(Tlongitud.Text);
                    }
                }
                else
                {
                    obj = (CParametroSP)DlstCampos.Items[DlstCampos.SelectedIndex];
                }
                return obj;
            }
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            result = DialogResult.OK;

        }

        private void FormNuevoCampo_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult=result ;

        }
    }
}
