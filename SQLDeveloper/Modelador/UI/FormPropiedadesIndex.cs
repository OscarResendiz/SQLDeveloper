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

namespace Modelador.UI
{
    public delegate void OnFormPropiedadesIndexEvent(string nombre, bool pk);
    public partial class FormPropiedadesIndex : Form
    {
        public event OnFormPropiedadesIndexEvent OnIndex;
        public event OnFormPropiedadesIndexEvent OnCampoIndex;
        public string Nombre
        {
            get
            {
                return TNombre.Text.Trim();
            }
            set
            {
                TNombre.Text = value.Trim();
            }
        }
        public bool PrimaryKey
        {
            get
            {
                return CHPrimaryKey.Checked;
            }
            set
            {
                CHPrimaryKey.Checked = value;
            }
        }
        private DataTable CamposIndex;
        public FormPropiedadesIndex()
        {
            InitializeComponent();
            CamposIndex= dataSet1.Tables["CamposIndex"];
            CargaOrdenamiento();
        }
        private void CargaOrdenamiento()
        {
            DataTable dt = dataSet1.Tables["Ordenamiento"];
            DataRow dr1 = dt.NewRow();
            dr1["Ordenamiento"] = "Acendente";
            dt.Rows.Add(dr1);
            DataRow dr2 = dt.NewRow();
            dr2["Ordenamiento"] = "Descendente";
            dt.Rows.Add(dr2);
        }
        public void AddCampoTabla(string campo)
        {
            DataTable CamposTabla = dataSet1.Tables["CamposTabla"];
            DataRow dr1 = CamposTabla.NewRow();
            dr1["Campo"] = campo;
            CamposTabla.Rows.Add(dr1);
            //lleno los campos
            DataRow dr = CamposIndex.NewRow();
            dr["Campo"] = campo;
            dr["Ordenamiento"] = "Acendente";
            CamposIndex.Rows.Add(dr);
        }
        public void AddCampoIndex(string campo,bool Descendente)
        {
            foreach(DataRow row in CamposIndex.Rows)
            {
                if(row["Campo"].ToString()==campo)
                {
                    row["Seleccionado"] = true;
                    if(Descendente)
                    {
                        row["Ordenamiento"] = "Descendente";
                    }
                    else
                    {
                        row["Ordenamiento"] = "Acendente";
                    }
                }
            }
        }
        private void FormPropiedadesIndex_Load(object sender, EventArgs e)
        {
        }

        private void CHPrimaryKey_CheckedChanged(object sender, EventArgs e)
        {
            if (CHPrimaryKey.Checked)
            {
                //le cambio el nombre al indice
                TNombre.Text = TNombre.Text.Replace("idx_", "pkc_");
                dataGridView1.Columns[2].Visible = false;
            }
            else
            {

                TNombre.Text = TNombre.Text.Replace("pkc_", "idx_");
                dataGridView1.Columns[2].Visible = true;
            }
        }

        private void Baceptar_Click(object sender, EventArgs e)
        {
            if (OnIndex != null)
                OnIndex(Nombre, PrimaryKey);
            foreach (DataRow row in CamposIndex.Rows)
            {
                if(bool.Parse(row["Seleccionado"].ToString())==true)
                {
                    bool desc = false;
                    if (row["Ordenamiento"].ToString() == "Descendente")
                        desc = true;
                    if (OnCampoIndex != null)
                        OnCampoIndex(row["Campo"].ToString(), desc);
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok = true;
            if (Nombre == "")
                ok = false;
            if (CamposIndex.Rows.Count == 0)
                ok = false;
            Baceptar.Enabled = ok;
        }
    }
}
