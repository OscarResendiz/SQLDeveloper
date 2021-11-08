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
    public partial class FormUniqueProperty : Form
    {
        private CTabla Tabla;
        public FormUniqueProperty(CTabla tabla)
        {
            Tabla = tabla;
            InitializeComponent();
        }
        private void MuestraCampos()
        {
            DataTable dt = dataSet1.Tables["CamposIndex"];
            dt.Rows.Clear();
            //lleno los campos
            foreach (MotorDB.CCampoBase obj in Tabla.Campos)
            {
                DataRow dr = dt.NewRow();
                dr["Campo"] = obj.Nombre;
                dr["Tipo"] = obj.GetTipoString();
                dt.Rows.Add(dr);
            }
        }

        private void FormUniqueProperty_Load(object sender, EventArgs e)
        {
            MuestraCampos();
            AsignaNombre();
        }
        private void AsignaNombre()
        {
            int n = 1;
            string s = "";
            bool ok = true;
            do
            {
                s = "Unq_" + Tabla.Nombre + n;
                ok = true;
                //veo si ya existe
                foreach (MotorDB.CUnique obj in Tabla.Uniques)
                {
                    if (obj.Nombre.ToUpper().Trim() == s.ToUpper().Trim())
                    {
                        ok = false;
                        break;
                    }
                }
                n++;
            }
            while (ok == false);
            TNombre.Text = s;
        }

        private void Baceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if(TNombre.Text.Trim()=="")
                {
                    MessageBox.Show("Falta el nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                    return;
                }
                MotorDB.CUnique obj = new MotorDB.CUnique();
                obj.Nombre = TNombre.Text;
                DataTable dt = dataSet1.Tables["CamposIndex"];
                foreach (DataRow dr in dt.Rows)
                {
                    if (bool.Parse(dr["Seleccionado"].ToString()) == true)
                    {
                        MotorDB.CCampoBase cb = new MotorDB.CCampoBase();
                        cb.Nombre = dr["Campo"].ToString();
                        foreach(CCampo campo in Tabla.Campos)
                        {
                            if(campo.Nombre==cb.Nombre)
                            {
                                cb.TipoDato = campo.TipoDato;
                                cb.Longitud = campo.Longitud;
                            }
                        }
                        obj.AddCampo(cb);
                    }
                }
                if(obj.Campos.Count==0)
                {
                    MessageBox.Show("No ha seleccionado ningun campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                    return;
                }
                Tabla.AddUnique(obj);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
        }
    }
}
