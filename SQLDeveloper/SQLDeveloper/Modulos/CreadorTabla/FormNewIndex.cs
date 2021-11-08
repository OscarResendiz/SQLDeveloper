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
    public partial class FormNewIndex : Form
    {
        string TableName;
        CTabla Tabla;
        public FormNewIndex(CTabla tabla)
        {
            Tabla = tabla;
            TableName = tabla.Nombre; //contiene el nombre de la tabla
            InitializeComponent();
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
        private void CargaCamposTabla()
        {
            //me traigo la tabla de data set
            DataTable dt = dataSet1.Tables["CamposTabla"];
            dt.Rows.Clear();
            //lleno los campos
            foreach (MotorDB.CCampoBase obj in Tabla.Campos)
            {
                DataRow dr = dt.NewRow();
                dr["Campo"] = obj.Nombre;
                dt.Rows.Add(dr);
            }
        }
        private void MuestraCampos()
        {
            //me traigo la tabla de data set
            DataTable dt = dataSet1.Tables["CamposIndex"];
            dt.Rows.Clear();
            //lleno los campos
            foreach (MotorDB.CCampoBase obj in Tabla.Campos)
            {
                DataRow dr = dt.NewRow();
                dr["Campo"] = obj.Nombre;
                dt.Rows.Add(dr);
            }
        }
        private void FormNewIndex_Load(object sender, EventArgs e)
        {
            string nombre = "Index_"+TableName;
            bool encontrado = false;
            int intentos = 0;
            Text = TableName;
            //lleno los campos basicos
            CargaOrdenamiento();
            //cargo los campos de la tabla
            CargaCamposTabla();
            //muestro los campos de la tabla para que el usuario lo pueda editar
            MuestraCampos();
            //asigno un nombre al indice
            do
            {
                encontrado = false;
                if (Tabla.PrimaryKey == null)
                {
                    nombre = "pkc_" + TableName;
                    CHPrimaryKey.Checked = true;
                }
                else
                {
                    nombre = "idx_" + TableName;
                }
                if (intentos>0)
                {
                    nombre+=intentos.ToString();
                }
                intentos++;
                foreach(MotorDB.Cindex obj in Tabla.Indexs)
                {
                    if(obj.Nombre==nombre)
                    {
                        encontrado = true;
                        break; //rompo el foreach
                    }
                }
            }
            while (encontrado==true);
            TNombre.Text = nombre;
            //verififco si la tabla contiene llave primaria
            if (Tabla.PrimaryKey!=null)
            {
                //como ya tiene una llave primaria definida, ya no se puede asignar 
                CHPrimaryKey.Enabled = false;
                CHPrimaryKey.Checked= false;
            }

        }

        private void CHPrimaryKey_CheckedChanged(object sender, EventArgs e)
        {
            if(CHPrimaryKey.Checked)
            {
                //le cambio el nombre al indice
                TNombre.Text = TNombre.Text.Replace( "idx_", "pkc_");
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
            try
            {
                if (CHPrimaryKey.Checked)
                {
                    CreaPrimaryKey();
                }
                else
                {
                    CreaIndex();
                }
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
        }
        private void CreaIndex()
        {
            MotorDB.Cindex idx= new MotorDB.Cindex();
            idx.Nombre = TNombre.Text;
            //me traigo la tabla
            DataTable dt = dataSet1.Tables["CamposIndex"];
            List<MotorDB.CCampoIndex> l = new List<MotorDB.CCampoIndex>();
            foreach(DataRow dr in dt.Rows)
            {
                if (bool.Parse(dr["Seleccionado"].ToString()) == true)
                {
                    MotorDB.CCampoIndex obj = new MotorDB.CCampoIndex();
                    obj.Nombre = dr["Campo"].ToString();
                    MotorDB.CCampo campo = Tabla.GetCampo(obj.Nombre);
                    obj.TipoDato = campo.TipoDato;
                    obj.Longitud = campo.Longitud;
                    if (dr["Ordenamiento"].ToString() == "Descendente")
                    {
                        obj.Ordenamiento = MotorDB.EnumOrdenIndex.DESC;
                    }
                    l.Add(obj);
                }
            }
            if(l.Count()==0)
            {
                throw new Exception("Debe seleccionar los campos del indice");
            }
            idx.Campos = l;
            Tabla.AddIndex(idx);
        }
        private void CreaPrimaryKey()
        {
            MotorDB.CPrimaryKey pk = new MotorDB.CPrimaryKey();
            pk.Nombre = TNombre.Text;
            //me traigo la tabla
            DataTable dt = dataSet1.Tables["CamposIndex"];
            List<MotorDB.CCampoBase> l = new List<MotorDB.CCampoBase>();
            foreach (DataRow dr in dt.Rows)
            {
                if (bool.Parse(dr["Seleccionado"].ToString()) == true)
                {
                    MotorDB.CCampoBase obj = new MotorDB.CCampoBase();
                    obj.Nombre = dr["Campo"].ToString();
                    MotorDB.CCampo campo = Tabla.GetCampo(obj.Nombre);
                    obj.TipoDato = campo.TipoDato;
                    obj.Longitud = campo.Longitud;
                    l.Add(obj);
                }
            }
            if (l.Count() == 0)
            {
                throw new Exception("Debe seleccionar los campos del indice");
            }
            pk.Campos = l;
            Tabla.PrimaryKey = pk;
        }
        public bool ShowPrimaryKey
        {
            set
            {
                CHPrimaryKey.Checked = value;
                CHPrimaryKey.Visible = false;
            }
        }
    }
}
