using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.CSharpLibaryGenerator
{
    public partial class FormPropiedadesSP : Form
    {
        MotorDB.IMotorDB Motor;
        private CStoreProcedures StoreProcedure;
        private ModeloNet Modelo;
        int ID_Store;
        public FormPropiedadesSP(MotorDB.IMotorDB motor,ModeloNet modelo, int id_Store)
        {
            ID_Store = id_Store;
            Modelo = modelo;
            Motor = motor;
            InitializeComponent();
        }

        private void FormPropiedadesSP_Load(object sender, EventArgs e)
        {
            try
            {
                BAceptar.Enabled = false;
                StoreProcedure = Modelo.DameSp(ID_Store);
                TNombre.Text = StoreProcedure.Nombre;
                TRegreso.Text = StoreProcedure.ObjetoRegreso;
                if (StoreProcedure.Simple)
                {
                    RbLista.Checked = false;
                    RbSolo.Checked = true;
                }
                else
                {
                    RbLista.Checked = true;
                    RbSolo.Checked = false;
                }
                this.Cursor = Cursors.WaitCursor;
                backgroundWorker1.RunWorkerAsync();
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BAceptar_Click(object sender, EventArgs e)
        {
            try
            {
            Modelo.ActualizaSP(ID_Store, TRegreso.Text, RbSolo.Checked);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message,"Error");
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable tablaCampos = new DataTable();
            tablaCampos.Columns.Add("Campo");
            tablaCampos.Columns.Add("Tipo");
            List<MotorDB.CCampo> campos = new List<MotorDB.CCampo>();
            try
            {
                List<MotorDB.CTabla> Tablas = Motor.DameResultadoProcedimientoAlmacenado(StoreProcedure.Nombre);
                if (Tablas.Count == 0)
                {
                    backgroundWorker1.ReportProgress(0);
                    return;
                }
                foreach (MotorDB.CTabla t in Tablas)
                {
                    foreach (MotorDB.CCampo c in t.Campos)
                    {
                        bool encontrado = false;
                        foreach (MotorDB.CCampo c2 in campos)
                        {
                            if (c2.Nombre == c.Nombre)
                            {
                                encontrado = true;
                            }
                        }
                        if (encontrado == false)
                        {
                            campos.Add(c);
                        }
                    }
                }
                foreach (MotorDB.CCampo c3 in campos)
                {
                    DataRow dr = tablaCampos.NewRow();
                    dr["Campo"] = c3.Nombre;
                    dr["Tipo"] = c3.Tipo;
                    tablaCampos.Rows.Add(dr);
                }
                backgroundWorker1.ReportProgress(1, tablaCampos);
            }
            catch(System.Exception ex)
            {
                //como visual estudio cuando le pa
                backgroundWorker1.ReportProgress(1, tablaCampos);
//                backgroundWorker1.ReportProgress(-1, ex.Message);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch(e.ProgressPercentage)
            {
                case 0: //no hay datos
                    //no regresa valores
                    RbSolo.Enabled = false;
                    RbLista.Enabled = false;
                    TRegreso.Text = "";
                    TRegreso.Enabled = false;
                    BAceptar.Visible = false;
                    BCancelar.Text = "Cerrar";
                    break;
                case 1: //todo bien
                    Grid.DataSource = (DataTable)e.UserState;
                    break;
                case -1://hayun error
                    BAceptar.Visible = false;
                    MessageBox.Show(e.UserState.ToString(),"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BAceptar.Enabled = true;
            this.Cursor = Cursors.Default;
        }
    }
}
