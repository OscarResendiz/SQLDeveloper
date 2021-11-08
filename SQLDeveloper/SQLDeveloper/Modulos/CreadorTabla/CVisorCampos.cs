using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
namespace SQLDeveloper.Modulos.CreadorTabla
{
    public partial class CVisorCampos : CVisorBase
    {
        CTabla Tabla;
        string NombreTabla;
        public CVisorCampos(CTabla tabla)
        {
            Tabla = tabla;
            NombreTabla = Tabla.Nombre;
            InitializeComponent();
        }
        private void MuestraDatos()
        {
            //me traigo los campos de la tabla
            //Tabla = DBProvider.DB.DameTabla(NombreTabla);
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

        private void CVisorCampos_Load(object sender, EventArgs e)
        {
            MuestraDatos();
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
                CpropiedadesCampo propiedades = new CpropiedadesCampo(campo, Tabla.Identidad);
                if (Tabla.EsPrimaryKey(campo))
                {
                    propiedades.SetPrimaryKey(Tabla.PrimaryKey);
                }
            propertyGrid1.SelectedObject = propiedades;

        }
        private void BAgregar_Click(object sender, EventArgs e)
        {
            FormAgregarCampo dlg = new FormAgregarCampo(Tabla);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            MuestraDatos();
            ChangeData();
        }

        private void BEliminar_Click(object sender, EventArgs e)
        {
            FormQuitarCampo dlg = new FormQuitarCampo(Tabla);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            MuestraDatos();
            ChangeData();

        }

        private void BEditar_Click(object sender, EventArgs e)
        {
            FormEditarColumna dlg = new FormEditarColumna(Tabla);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            MuestraDatos();
            ChangeData();
        }
        public override void RefreshData()
        {
            MuestraDatos();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormImportarCampos dlg = new FormImportarCampos(Tabla);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            RefreshData();
            ChangeData();
        }
    }
}
