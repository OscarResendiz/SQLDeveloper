using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SQLDeveloper.Modulos.Visores.Vista
{
    public partial class FormVista : Form
    {
        MotorDB.IMotorDB Motor;
        public event MotorDB.OnVerObjetoEvent OnVerCodigoVista;
        public event MotorDB.OnVerObjetoEvent OnVerTablaPadre;
        public event MotorDB.OnVerObjetoEvent OnVerDependencias;
        public event MotorDB.OnVerObjetoEvent OnVerRelaciones;
        public event MotorDB.OnVerObjetoEvent OnVerTrrigers;
        public event OnPropiedadesEvent OnPropiedadesCampo;
        private string NombreVista;
        MotorDB.CVista Vista;
        public FormVista(MotorDB.IMotorDB motor,string vista)
        {
            Motor = motor;
            InitializeComponent();
            NombreVista = vista;
            this.Text = NombreVista;
        }
        private void MuestraDatos()
        {
            TNombre.Text = NombreVista;
            //me traigo los campos de la tabla
            Vista = Motor.DameVista(NombreVista);
            if (Vista == null)
                return;
            DataTable dt = dataSet1.Tables["Campos"];
            dt.Rows.Clear();
            foreach (MotorDB.CCampoBase campo in Vista.Campos)
            {
                string s = "";
                DataRow dr = dt.NewRow();
                //verifico las 8 posibles combinaciones
                dr["Campo"] = campo.Nombre;
                dr["Tipo"] = campo.GetTipoString();
                dr["Nulos"] = imageList1.Images[3];
                dt.Rows.Add(dr);
            }

        }
        private void FormVista_Load(object sender, EventArgs e)
        {
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
            MotorDB.CCampoBase campo = Vista.GetCampo(nombre);
            //mando a mostrar las propiedades del campo seleccionado
            if(OnPropiedadesCampo!=null                )
            {
                CpropiedadesCampo propiedades = new CpropiedadesCampo(campo);
                OnPropiedadesCampo(propiedades);
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            //hay que verificar si el campo apunta a una llave foranea
            string nombre = "";
            DataGridViewRow r = dataGridView1.Rows[e.RowIndex];
            nombre = r.Cells["Campo"].Value.ToString();
            //me traigo el campo
            MotorDB.CCampoBase campo = Vista.GetCampo(nombre);
        }

        private void BDependencias_Click(object sender, EventArgs e)
        {
            if(OnVerDependencias!=null)
            {
                OnVerDependencias(Motor,NombreVista, MotorDB.EnumTipoObjeto.VIEW);
            }
        }

        private void BRelacion_Click(object sender, EventArgs e)
        {
        }

        private void Btrrigers_Click(object sender, EventArgs e)
        {
            if(OnVerTrrigers!=null)
            {
                OnVerTrrigers(Motor,NombreVista, MotorDB.EnumTipoObjeto.VIEW);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
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
            if(OnVerCodigoVista!=null)
            {
                OnVerCodigoVista(Motor, TNombre.Text, MotorDB.EnumTipoObjeto.VIEW);
            }
        }
    }
}
