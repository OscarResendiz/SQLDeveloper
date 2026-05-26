using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SPGenerator
{
    public partial class FormCasos : Form
    {
        public List<Objetos.CCaso> Casos;
        public FormCasos()
        {
            if (Casos == null)
                Casos = new List<Objetos.CCaso>();
            InitializeComponent();
            MuestraCasos();
        }
        private void MuestraCasos()
        {
            if (Casos == null)
                return;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Tabla");
            //Creando las columnas y agregando los items a la tabla
            DataColumn dcWhen = new DataColumn("When");
            DataColumn dcDhen = new DataColumn("Dhen");
            //Asignando los campos ala tabla
            dt.Columns.Add(dcWhen);
            dt.Columns.Add(dcDhen);
            //agregarndo la tabla al data set
            ds.Tables.Add(dt);
            //llenando la tabla con datos
            int i, n;
            n = Casos.Count;
            for (i = 0; i < n; i++)
            {
                Objetos.CCaso dato = (Objetos.CCaso)Casos[i];
                DataRow drRow = dt.NewRow();
                drRow["When"] = dato.When;
                drRow["Dhen"] = dato.Dhen;
                dt.Rows.Add(drRow);
            }
//            dataGrid1.DataSource = ds.Tables[0];
          
//            DataGridTableStyle ts = new DataGridTableStyle();
  //          ts.AllowSorting = false;
    //        ts.MappingName = "Tabla";
            //creando las columnas que se van a ver
            //------------------When---------------------------------------- 
            //DataGridColumnStyle When = new DataGridTextBoxColumn();
            //When.MappingName = "When";
            //When.HeaderText = "When";
            //When.Width = 100;
            //When.ReadOnly = true;
            //ts.GridColumnStyles.Add(When);
            //------------------Dhen---------------------------------------- 
            //DataGridColumnStyle Dhen = new DataGridTextBoxColumn();
            //Dhen.MappingName = "Dhen";
            //Dhen.HeaderText = "Dhen";
            //Dhen.Width = 100;
            //Dhen.ReadOnly = true;
            //ts.GridColumnStyles.Add(Dhen);
            ////finalizando la creacion del data grid
            //ts.MappingName = "Tabla";
          
            //dataGrid1.TableStyles.Clear();
            //dataGrid1.TableStyles.Add(ts);
            //dataGrid1.AllowSorting = false;
        }

        private void BAgregar_Click(object sender, EventArgs e)
        {
            FormPropCaso dlg = new FormPropCaso();
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            if (Casos == null)
                Casos = new List<Objetos.CCaso>();
            Objetos.CCaso obj = new Objetos.CCaso();
            obj.When = dlg.When;
            obj.Dhen = dlg.Dhen;
            foreach (Objetos.CCaso obj2 in Casos)
            {
                if (obj.When.ToLower().Trim() == obj2.When.ToLower().Trim())
                {
                    MessageBox.Show("El caso ya existe");
                    return;
                }
            }
            Casos.Add(obj);
            MuestraCasos();
        }

        private void BEditar_Click(object sender, EventArgs e)
        {
            FormPropCaso dlg = new FormPropCaso();
//            dlg.When = Casos[dataGrid1.CurrentRowIndex].When;
//            dlg.Dhen = Casos[dataGrid1.CurrentRowIndex].Dhen;
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
  //          Casos[dataGrid1.CurrentRowIndex].When = dlg.When;
    //        Casos[dataGrid1.CurrentRowIndex].Dhen = dlg.Dhen;
            MuestraCasos();
        }

        private void BEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea eliminar el caso", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
//            Casos.RemoveAt(dataGrid1.CurrentRowIndex);
            MuestraCasos();
        }

        private void BDefault_Click(object sender, EventArgs e)
        {
            if (Casos == null)
                Casos = new List<Objetos.CCaso>();
            FormPropCaso dlg = new FormPropCaso();
            //primero busco si existe el caso default
            foreach (Objetos.CCaso obj in Casos)
            {
                if (obj.When == "default")
                {
                    dlg.When = obj.When;
                    dlg.Dhen = obj.Dhen;
                    if (dlg.ShowDialog() == DialogResult.Cancel)
                        return;
                    obj.When = dlg.When;
                    obj.Dhen = dlg.Dhen;
                    MuestraCasos();
                    return;
                }
            }
            //no esta, por lo que hay que agregarlo
            dlg.When = "default";
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            Objetos.CCaso obj2 = new Objetos.CCaso();
            obj2.When = dlg.When;
            obj2.Dhen = dlg.Dhen;
            Casos.Add(obj2);
            MuestraCasos();
        }

        private void BCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok = true;
//            if (dataGrid1.CurrentRowIndex == -1)
  //              ok = false;
            BEliminar.Enabled = ok;
            BEditar.Enabled = ok;
            ok=true;
            if (Casos == null)
                ok = false;
            else if (Casos.Count == 0)
                ok = false;
            BDefault.Enabled = ok;
        }

        private void FormCasos_Load(object sender, EventArgs e)
        {
            MuestraCasos();
        }
    }
}