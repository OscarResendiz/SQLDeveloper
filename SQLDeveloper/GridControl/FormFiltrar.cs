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
    public delegate void OnFiltrarEvent(FormFiltrar dlg);
    public partial class FormFiltrar : Form
    {
        public event OnFiltrarEvent OnFiltrar;
        public event OnFiltrarEvent OnFiltrarClose;
        DataSet DtSet;
        public FormFiltrar()
        {
            InitializeComponent();
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
            }
        }
        private void Bagregar_Click(object sender, EventArgs e)
        {
            FormDetalleFiltro dlg = new FormDetalleFiltro();
            dlg.DataSet = DtSet;
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            DataTable dt = dataSet1.Tables["Filtros"];
            DataRow dr = dt.NewRow();
            dr["Tabla"] = dlg.Tabla;
            dr["Campo"] = dlg.Campo;
            dr["Condicion"] = dlg.Condicion;
            dr["Valor"] = dlg.Valor;
            dt.Rows.Add(dr);
            Grid.DataSource = dataSet1;
        }

        private void BEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Eliminar los filtros seleccionados?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                return;
            foreach(DataGridViewRow dr in Grid.SelectedRows)
            {
                Grid.Rows.Remove(dr);
            }
        }
        public DataSet DtSetFiltros
        {
            get
            {
                return dataSet1;
            }
            set
            {
                dataSet1 = value;
                Grid.DataSource = dataSet1;
            }
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            if (OnFiltrar != null)
                OnFiltrar(this);
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            if(OnFiltrarClose!=null)
            {
                OnFiltrarClose(this);
            }
            Close();
        }
    }
}
