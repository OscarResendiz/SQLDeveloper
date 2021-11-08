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
    public delegate void OnFiltroEvent(string filtro);
    public partial class FormQuery : Form
    {
        public event OnFiltroEvent OnFiltro;
        public FormQuery()
        {
            InitializeComponent();
        }
        public string Texto
        {
            get
            {
                return TFiltro.Text;
            }
            set
            {
                TFiltro.Text = value;
            }
        }

        private void BAplicar_Click(object sender, EventArgs e)
        {
            if (OnFiltro != null)
                OnFiltro(Texto);
        }

        private void BCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        public DataTable Tabla
        {
            set
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Campos");
                foreach(DataColumn dc in value.Columns)
                {
                    DataRow dr = dt.NewRow();
                    dr["Campos"] = dc.ColumnName;
                    dt.Rows.Add(dr);
                }
                dataGridView1.DataSource = dt;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !checkBox1.Checked;
        }
    }
}
