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
    public partial class FormImportarCampos : Form
    {
        CTabla Tabla;
        List<CCampo> CamposLista;
        public FormImportarCampos(CTabla tabla)
        {
            Tabla = tabla;
            InitializeComponent();
        }
        private void LLenaComboTablas()
        {
            List<MotorDB.CObjeto> l = DBProvider.DB.Buscar("", MotorDB.EnumTipoObjeto.TABLE);
            ComboTablas.Items.Clear();
            foreach (MotorDB.CObjeto obj in l)
            {
                ComboTablas.Items.Add(obj);
            }
        }

        private void FormImportarCampos_Load(object sender, EventArgs e)
        {
            LLenaComboTablas();
        }
        private void MuestraCampos(string nombre)
        {
            //me traigo los campos de la tabla
            CTabla tabla = DBProvider.DB.DameTabla(nombre);
            //Tabla = DBProvider.DB.DameTabla(NombreTabla);
            DataTable dt = dataSet1.Tables["Campos"];
            dt.Rows.Clear();
            CamposLista = new List<CCampo>();
            foreach (MotorDB.CCampo campo in tabla.Campos)
            {
                bool pk = false;
                bool fk = false;
                bool id = false;
                string s = "";
                CamposLista.Add(campo);
                DataRow dr = dt.NewRow();
                //veo si el campo es llave primaria, foranea o identidad
                pk = tabla.EsPrimaryKey(campo);
                fk = tabla.EsForeignKey(campo);
                id = tabla.EsIdentidad(campo);
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

        private void ComboTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            MuestraCampos(ComboTablas.Text);
        }

        private void BTablas_Click(object sender, EventArgs e)
        {
            //muestro el cuadro de dialogo de busqueda de tablas
            FormBuscadorTablas dlg = new FormBuscadorTablas();
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            string tabla = dlg.Tabla;
            //selecciono la tabla en el combo
            foreach (MotorDB.CObjeto obj in ComboTablas.Items)
            {
                if (obj.Nombre == tabla)
                {
                    ComboTablas.SelectedItem = obj;
                    return;
                }
            }
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            //me traigo la tabla
            int conteo = 0;
            DataTable dt = dataSet1.Tables["Campos"];
            List<MotorDB.CCampoIndex> l = new List<MotorDB.CCampoIndex>();
            foreach (DataRow dr in dt.Rows)
            {
                if (bool.Parse(dr["Seleccionado"].ToString()) == true)
                {
                    string nombre = dr["Campo"].ToString();
                    foreach (CCampo campo in CamposLista)
                    {
                        if (campo.Nombre == nombre)
                        {
                            Tabla.AddCampo(campo);
                            conteo++;
                        }
                    }
                }
            }
            if (conteo == 0)
            {
                throw new Exception("Debe seleccionar los campos a importar");
                DialogResult = DialogResult.None;
            }
        }
    }
}
