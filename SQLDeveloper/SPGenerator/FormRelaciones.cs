using SPGenerator.Objetos;
using MotorDB;
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
namespace SPGenerator
{
    public partial class FormRelaciones : Form
    {
        DialogResult res;
        IMotorDB DB;
        //private List<Objetos.CParametro> CamposPK;
        CPrimaryKey PK;
        private List<string> CamposFK;
        public FormRelaciones(List<string> camposfk, IMotorDB db, String tabla)
        {
            DB = db;
            InitializeComponent();
            CamposFK = camposfk;
            TTabla.Text = tabla;
            cRelacionTabla1.Campos = CamposFK;
            res = DialogResult;
        }

        private void FormRelaciones_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormBuscarTabla dlg = new FormBuscarTabla(DB, EnumTipoObjeto.TABLE);
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            TTablaPrimaria.Text = dlg.Tabla;
            PK = DB.DameLLavePrimaria(TTablaPrimaria.Text);
            cRelacionTabla1.Clear();
            foreach (CCampoBase obj in PK.Campos)
            {
                cRelacionTabla1.Add(obj.Nombre);
            }
            TRelacion.Text = "FK_" + TTabla.Text + "_" + TTablaPrimaria.Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok;
            ok = cRelacionTabla1.TodosAsignados;
            if (TTabla.Text.Trim() == "")
                ok = false;
            if (TTablaPrimaria.Text.Trim() == "")
                ok = false;
            if (TRelacion.Text.Trim() == "")
                ok = false;
            BAceptar.Enabled = ok;
        }
        public Objetos.CRelacion Relacion
        {
            get
            {
                Objetos.CRelacion obj = new Objetos.CRelacion();
                obj.TablaHija = TTabla.Text;
                obj.TablaPadre = TTablaPrimaria.Text;
                obj.CamposFK = cRelacionTabla1.Relaciones;
                obj.ActualisarCascada = CHActualizar.Checked;
                obj.EliminarCascada = CHEliminar.Checked;
                obj.Nombre = TRelacion.Text;
                return obj;
            }
        }
        public string CreaRelacion()
        {
            //regresa la cadena que genera el constraint
            Objetos.CRelacion obj = Relacion;
            string s = "";
            s = "alter table " + obj.TablaHija + " add ";//constraint " + TRelacion.Text + " foreign key(";
                                                         //asigno los campos de la llave foranea
            bool primero = true;
            foreach (CCampoFK fk in obj.CamposFK)
            {
                if (primero == true)
                {
                    s = s + "constraint " + obj.Nombre + " foreign key(";
                    primero = false;
                }
                else
                    s = s + ",";
                s = s + fk.columnahija;
            }
            s = s + ") references " + obj.TablaPadre + "(";
            primero = true;
            foreach (CCampoFK fk in obj.CamposFK)
            {
                if (primero == true)
                {
                    primero = false;
                }
                else
                    s = s + ",";
                s = s + fk.columnaMaestra;
            }
            s = s + ")";
            if (obj.EliminarCascada == true)
            {
                s = s + " ON DELETE  CASCADE ";
            }
            if (obj.ActualisarCascada == true)
            {
                s = s + " ON UPDATE  CASCADE ";
            }

            s = s + "";
            return s;
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            res = DialogResult.OK;
        }

        private void FormRelaciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = res;
        }
    }
}