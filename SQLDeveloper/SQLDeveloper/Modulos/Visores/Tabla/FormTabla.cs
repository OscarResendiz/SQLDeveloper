using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SQLDeveloper.Modulos.Visores.Tabla
{
    public partial class FormTabla : Form
    {
        MotorDB.IMotorDB Motor;
        public event MotorDB.OnVerObjetoEvent OnVerCodigoTabla;
        public event MotorDB.OnVerObjetoEvent OnVerTablaPadre;
        public event MotorDB.OnVerObjetoEvent OnVerDependencias;
        public event MotorDB.OnVerObjetoEvent OnVerRelaciones;
        public event MotorDB.OnVerObjetoEvent OnVerTrrigers;
        public event OnPropiedadesEvent OnPropiedadesCampo;
        bool IsTypeTable = false;
        private string NombreTabla;
        MotorDB.CTabla Tabla;
        private bool LecturaExitosa;
        public FormTabla(MotorDB.IMotorDB motor,string tabla, bool tt = false)
        {
            Motor = motor;
            IsTypeTable = tt;
            InitializeComponent();
            NombreTabla = tabla;
            this.Text = NombreTabla;
        }
        private void FormTabla_Load(object sender, EventArgs e)
        {
            TNombre.Text = NombreTabla;
            MuestraDatos();
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            if (e.Control && e.KeyCode == Keys.C)
            {
                Clipboard.SetDataObject(dg.GetClipboardContent());
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //me traigo la columna a la que se hace referencia
            string nombre = "";
            DataGridViewRow r = dataGridView1.Rows[e.RowIndex];
            nombre = r.Cells["Campo"].Value.ToString();
            //me traigo el campo
            MotorDB.CCampo campo = Tabla.GetCampo(nombre);
            //mando a mostrar las propiedades del campo seleccionado
            if(OnPropiedadesCampo!=null                )
            {
                CpropiedadesCampo propiedades = new CpropiedadesCampo(campo, Tabla.Identidad);
                if(Tabla.EsPrimaryKey(campo))
                {
                    propiedades.SetPrimaryKey(Tabla.PrimaryKey);
                }
                OnPropiedadesCampo(propiedades);
            }
        }

        private void dataGridView1_RowDividerDoubleClick(object sender, DataGridViewRowDividerDoubleClickEventArgs e)
        {
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //hay que verificar si el campo apunta a una llave foranea
            string nombre = "";
            if (e.RowIndex == -1)
                return;
            DataGridViewRow r = dataGridView1.Rows[e.RowIndex];
            nombre = r.Cells["Campo"].Value.ToString();
            //me traigo el campo
            MotorDB.CCampo campo = Tabla.GetCampo(nombre);
            if (Tabla.EsForeignKey(campo))
            {
                //recorro las llavez foraneas y muestro las tablas a las que hace referencia el campo
                foreach (MotorDB.CForeignKey fk in Tabla.ForeignKeys)
                {
                    if (fk.ContieneCampo(campo))
                    {
                        if (OnVerTablaPadre != null)
                        {
                            OnVerTablaPadre(Motor,fk.TablaPadre, MotorDB.EnumTipoObjeto.TABLE);
                        }
                    }
                }
            }

        }

        private void BDependencias_Click(object sender, EventArgs e)
        {
            if(OnVerDependencias!=null)
            {
                OnVerDependencias(Motor,NombreTabla, MotorDB.EnumTipoObjeto.TABLE);
            }
        }

        private void BRelacion_Click(object sender, EventArgs e)
        {
            if(OnVerRelaciones!=null)
            {
                OnVerRelaciones(Motor,NombreTabla, MotorDB.EnumTipoObjeto.TABLE);
            }
        }

        private void BAddFk_Click(object sender, EventArgs e)
        {
            FormForeignKeys dlg = new FormForeignKeys(NombreTabla, Motor);
            dlg.ShowDialog();
            if(dlg.Modificado)
            {
                //hay que recargar la informacion de la tabla
                MuestraDatos();
            }
        }

        private void Btrrigers_Click(object sender, EventArgs e)
        {
            if(OnVerTrrigers!=null)
            {
                OnVerTrrigers(Motor,NombreTabla, MotorDB.EnumTipoObjeto.TABLE);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormIndexs dlg = new FormIndexs(this.NombreTabla, Motor);
            dlg.ShowDialog();
            if(dlg.Modificado)
            {
                MuestraDatos();
            }
        }

        private void BAgregarCampos_Click(object sender, EventArgs e)
        {
            FormAgregarCampo dlg = new FormAgregarCampo(NombreTabla, Motor);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            MuestraDatos();
        }

        private void BEliminarCampos_Click(object sender, EventArgs e)
        {
            FormQuitarCampo dlg = new FormQuitarCampo(NombreTabla, Motor);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            MuestraDatos();

        }

        private void BUniques_Click(object sender, EventArgs e)
        {
            FormUniques dlg = new FormUniques(NombreTabla, Motor);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            MuestraDatos();
        }

        private void BotonChecks_Click(object sender, EventArgs e)
        {
            FormChecks dlg = new FormChecks(NombreTabla, Motor);
            dlg.ShowDialog();
        }

        private void BEditarCampos_Click(object sender, EventArgs e)
        {
            FormEditarColumna dlg = new FormEditarColumna(NombreTabla, Motor);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            MuestraDatos();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FormDatosAvanzados dlg = new FormDatosAvanzados(NombreTabla,Motor);
            dlg.ShowDialog();
        }

        private void TNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.C)
                {
                    Clipboard.SetText(TNombre.Text);
                }
                if (e.KeyCode == Keys.V)
                {
                    TNombre.Text = Clipboard.GetText();
                }
            }
        }

        private void BCodigo_Click(object sender, EventArgs e)
        {
            if (OnVerCodigoTabla != null)
                OnVerCodigoTabla(Motor, NombreTabla, MotorDB.EnumTipoObjeto.TABLE);
        }
        private void MuestraDatos()
        {
            LecturaExitosa = true;
            waitControl1.Animar = true;
            BKExtractor.RunWorkerAsync();
        }

        private void BKExtractor_DoWork(object sender, DoWorkEventArgs e)
        {
            //me traigo los campos de la tabla
            try
            {
                if (IsTypeTable == false)
                    Tabla = Motor.DameTabla(NombreTabla);
                else
                    Tabla = Motor.DameTypeTable(NombreTabla);
            }
            catch(System.Exception ex)
            {
                BKExtractor.ReportProgress(-1, ex.Message);
                return;
            }

        }

        private void BKExtractor_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LecturaExitosa = false;
            MessageBox.Show(e.UserState.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BKExtractor_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            waitControl1.Animar = false;
            if (LecturaExitosa == false)
                return;
            TNombre.Text = NombreTabla;
            if (Tabla == null)
                return;
            DataTable dt = dataSet1.Tables["Campos"];
            dt.Rows.Clear();
            foreach (MotorDB.CCampo campo in Tabla.Campos)
            {
                bool pk = false;
                bool fk = false;
                bool id = false;
                string s = "";
                DataRow dr = dt.NewRow();
                //veo si el campo es llave primaria, foranea o identidad
                pk = Tabla.EsPrimaryKey(campo);
                fk = Tabla.EsForeignKey(campo);
                id = Tabla.EsIdentidad(campo);
                //verifico las 8 posibles combinaciones
                if (id == false && pk == false && fk == false)
                {
                    //no es ninguno
                    dr["PK"] = imageList1.Images[3];
                }
                if (id == false && pk == false && fk == true)
                {
                    //FK
                    dr["PK"] = imageList1.Images[1];
                }
                if (id == false && pk == true && fk == false)
                {
                    //PK
                    dr["PK"] = imageList1.Images[0];
                }
                if (id == false && pk == true && fk == true)
                {
                    //PK FK
                    dr["PK"] = imageList1.Images[2];
                }
                if (id == true && pk == false && fk == false)
                {
                    //I 
                    dr["PK"] = imageList1.Images[5];
                }
                if (id == true && pk == false && fk == true)
                {
                    //I FK
                    dr["PK"] = imageList1.Images[7];
                }
                if (id == true && pk == true && fk == false)
                {
                    //I PK
                    dr["PK"] = imageList1.Images[6];
                }
                if (id == true && pk == true && fk == true)
                {
                    //I PK FK
                    dr["PK"] = imageList1.Images[8];
                }

                dr["Campo"] = campo.Nombre;
                dr["Tipo"] = campo.GetTipoString();
                if (campo.AceptaNulo)
                {
                    dr["Nulos"] = imageList1.Images[4];
                }
                else
                {
                    dr["Nulos"] = imageList1.Images[3];
                }

                dt.Rows.Add(dr);
            }

        }
    }
}
