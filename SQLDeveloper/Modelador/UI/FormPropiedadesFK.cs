using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelador.Modelo;
using MotorDB;
namespace Modelador.UI
{
    public partial class FormPropiedadesFK : Form
    {
        public int ID_TablaHija
        {
            get;
            set;
        }
        private ModeloDatos FModelo;
        private bool cargaInicial = true;
        private Modelo.CTabla GetTabla()
        {
            return Modelo.Get_Tabla(ID_TablaHija);
        }
        public ModeloDatos Modelo
        {
            get
            {
                return FModelo;
            }
            set
            {
                FModelo = value;
                TTablaHija.Text = GetTabla().Nombre;

            }
        }
        public FormPropiedadesFK()
        {
            InitializeComponent();
        }
        private void FormPropiedadesFK_Load(object sender, EventArgs e)
        {
            if(ComboTablas.Items.Count==0)
                LLenaComboTablas();
            LLenaAccionesReferenciales();
        }
        public Color LineColor
        {
            get
            {
                return BForeColor.BackColor;
            }
            set
            {
                BForeColor.BackColor = value;
            }
        }
        private void LLenaComboTablas()
        {
            List<Modelo.CTabla> l = Modelo.Get_Tablas();
            ComboTablas.Items.Clear();
            foreach(Modelo.CTabla obj in l)
            {
                ComboTablas.Items.Add(obj);
            }
        }
        public List<EnumAccionReferencial> DameAccionesReferencialesBorradoValidos()
        {
            List<EnumAccionReferencial> l = new List<EnumAccionReferencial>();
            l.Add(EnumAccionReferencial.NO_ACTION);
            l.Add(EnumAccionReferencial.CASCADE);
            l.Add(EnumAccionReferencial.SET_NULL);
            l.Add(EnumAccionReferencial.SET_DEFAULT);
            return l;
        }
        public List<EnumAccionReferencial> DameAccionesReferencialesActualizadoValidos()
        {
            List<EnumAccionReferencial> l = new List<EnumAccionReferencial>();
            l.Add(EnumAccionReferencial.NO_ACTION);
            l.Add(EnumAccionReferencial.CASCADE);
            l.Add(EnumAccionReferencial.SET_NULL);
            l.Add(EnumAccionReferencial.SET_DEFAULT);
            return l;
        }

        private void LLenaAccionesReferenciales()
        {
            List<MotorDB.EnumAccionReferencial> la,ld;
            la = DameAccionesReferencialesActualizadoValidos();
            ld = DameAccionesReferencialesBorradoValidos();
            //lleno los combos
            if (ComboUpdate.Items.Count == 0)
            {
                foreach (MotorDB.EnumAccionReferencial obj1 in la)
                {
                    ComboUpdate.Items.Add(obj1);
                }
            }
            if (ComboDelete.Items.Count == 0)
            {
                foreach (MotorDB.EnumAccionReferencial obj2 in ld)
                {
                    ComboDelete.Items.Add(obj2);
                }
            }
            //asigno valores de default
            if(ComboUpdate.SelectedIndex==-1)
                ComboUpdate.SelectedItem = MotorDB.EnumAccionReferencial.NO_ACTION;
            if(ComboDelete.SelectedIndex==-1)
                ComboDelete.SelectedItem = MotorDB.EnumAccionReferencial.NO_ACTION;
        }

        private void BTablas_Click(object sender, EventArgs e)
        {
            //muestro el cuadro de dialogo de busqueda de tablas
            FormBuscadorTablas dlg = new FormBuscadorTablas();
            dlg.Modelo = Modelo;
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            string tabla = dlg.Tabla;
            //selecciono la tabla en el combo
            foreach(Modelo.CTabla obj in ComboTablas.Items)
            {
                if(obj.Nombre==tabla)
                {
                    ComboTablas.SelectedItem = obj;
                    return;
                }
            }
        }

        private void CargaCamposTablaPadre(string padre)
        {
            //me traigo la tabla
            Modelo.CTabla Tabla = Modelo.Get_Tabla(padre); ;
            if (Tabla == null)
            {
                return;
            }
            //limpio la tabla de los campos
            DataTable dt = dataSet1.Tables["Columnas"];
            dt.Rows.Clear();
            DataTable dt3 = dataSet1.Tables["TablaHija"];
            dt3.Rows.Clear();
            DataTable dt2 = dataSet1.Tables["TipoDato"];
            dt2.Rows.Clear();
            //recorro los campos que pertenecen a la llave primaria
            foreach (Modelo.CCampo campo in Tabla.Get_Campos())
            {
                //agrego el tipo de dato
                if (campo.PK)
                {
                   string tipo =AgregaTipo(campo.Get_TipoDato(), campo.Longitud);
                    DataRow dr = dt.NewRow();
                    dr["ColumnaPadre"] = campo.NombreX;
                    dr["Tipo"] = tipo;
                    dt.Rows.Add(dr);
                }
            }
            CargaCamposTablaHija();
            //le asigno un nombre a la llave foranea
            AsignaNombreFK();
        }
        private string AgregaTipo(Modelo.CTipoDato tipo, int tamaño)
        {
            string s = tipo.Nombre;
            if(tipo.TipoLongitud!= TIPO_LONGITUD.NOREQUERIDO)
            {
                if (tipo.TipoLongitud == TIPO_LONGITUD.OBLIGATORIO)
                {
                    s = s + "(" + tamaño + ")";
                }
                else if (tipo.TipoLongitud == TIPO_LONGITUD.OPCIONAL)
                {
                    if (tamaño > 1)
                    {
                        s = s + "(" + tamaño + ")";
                    }

                }
            }
            //reviso si el tipo de dato exist
            DataTable dt = dataSet1.Tables["TipoDato"];
            foreach(DataRow dr in dt.Rows)
            {
                string s2 = dr["Tipo"].ToString();
                if (s2.ToUpper().Trim()==s.ToUpper().Trim())
                {
                    //ya existe, por lo que no hago nada
                    return s;
                }
            }
            //como no existe lo agrego 
            DataRow dr1 = dt.NewRow();
            dr1["Tipo"] = s;
            dt.Rows.Add(dr1);
            return s;
        }
        private bool ValidaTipoDato(Modelo.CTipoDato tipo, int tamaño)
        {
            string s = tipo.Nombre;
            switch (tipo.TipoLongitud)
            {
                case TIPO_LONGITUD.OPCIONAL:
                    if (tamaño > 1)
                    {
                        s = s + "(" + tamaño + ")";
                    }
                    break;
                case TIPO_LONGITUD.OBLIGATORIO:
                    s = s + "(" + tamaño + ")";
                    break;
            }
            //reviso si el tipo de dato exist
            DataTable dt = dataSet1.Tables["TipoDato"];
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Tipo"].ToString() == s)
                {
                    //si existe el ctipo en la tabla
                    return true;
                }
            }
            //no existe
            return false;
        }
        private void CargaCamposTablaHija()
        {
            //me traigo la tabla hija
            //me traigo la tabla que va a contener los datos
            DataTable dt = dataSet1.Tables["TablaHija"];
            //recooro todos los campos de la tabla
            foreach (Modelo.CCampo obj in GetTabla().Get_Campos())
            {
                if (ValidaTipoDato(obj.Get_TipoDato(), obj.Longitud))
                {
                    //si y solo si existe el tipo de dato lo agrega
                    DataRow dr = dt.NewRow();
                    dr["Campo"] = obj.NombreX;
                    dt.Rows.Add(dr);
                }
            }
        }
        private void ComboTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaCamposTablaPadre(ComboTablas.Text);
            //ahora hago un match entre los campos de tablas
            if(cargaInicial==false)
            {
                Modelo.CTabla Tabla = GetTabla();

                foreach (DataRow dr in dataSet1.Tables["Columnas"].Rows)
                {
                    //busco el campo que le coorezponde
                    foreach (Modelo.CCampo campo in Tabla.Get_Campos())
                    {
                        if (campo.NombreX == dr["ColumnaPadre"].ToString() && AgregaTipo(campo.Get_TipoDato(), campo.Longitud)== dr["Tipo"].ToString())
                        {
                            dr["ColumnaHija"] = campo.NombreX;
                            break;
                        }
                    }
                }

            }
            cargaInicial = false;
        }
        private void AsignaNombreFK()
        {
            int consecutivo = 0;
            bool ok = true; //doy por hecho que el nombre no existe
            string nombre = "";
            if (TForeignKey.Text.Trim() != "")
                return;

            //verifico si existe el objeto
            do
            {
                //genero un nombre
                nombre = "fkc_" + TTablaHija.Text;// + "_" + ComboTablas.Text;
                if (consecutivo > 0)
                    nombre += consecutivo; //le asigno un consecutivo al nombre
                consecutivo++;
                //me traigo todas las llaves foraneas para ver si no se repite el nombre
                ok = true;//asumo que no existe
                if (Modelo.Get_LlaveForanea(nombre) != null)
                {
                    ok = false;
                }
            }
            while (ok == false);
            TForeignKey.Text = nombre; ;
        }
        private void BAceptar_Click(object sender, EventArgs e)
        {
            //hago validaciones
            //primero si existe la tabla hija (cosa que en teoria no debe de pasar
            if (TTablaHija.Text.Trim() == "")
            {
                MessageBox.Show("Falta la tabla hija", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
            //verifico que se tenga la tabla padre
            if (ComboTablas.Text.Trim() == "")
            {
                MessageBox.Show("Falta la tabla padre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
            //verifico que el FK tenga nombre
            if (TForeignKey.Text.Trim() == "")
            {
                MessageBox.Show("Falta el nombre del FK", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
            //ahora checo si los campos estan asignados
            DataTable dt = dataSet1.Tables["Columnas"];
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("La tabla padre no tiene llave primaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
            foreach(DataRow dr in dt.Rows)
            {
                if(dr["ColumnaHija"].ToString().Trim()=="")
                {
                    MessageBox.Show("Faltan campos por asignar en las tablas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                    return;
                }
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        public List<CCampoProFk> Get_Campos()
        {
            List<CCampoProFk> l = new List<CCampoProFk>();
            foreach(DataRow dr in dataSet1.Tables["Columnas"].Rows)
            {
                l.Add(new CCampoProFk()
                {
                    ID_CampoHijo = getCampoHijo(dr["ColumnaHija"].ToString()),
                     ID_CampoPadre= getCampoPadre(dr["ColumnaPadre"].ToString()),
                      Tipo=getTipo( dr["Tipo"].ToString())
                }); ;
            }
            return l;
        }
        private int getCampoHijo(string nombre)
        {
            return GetTabla().Get_Campo(nombre).ID_Campo;
        }
        private EnumAccionReferencial getTipo(string nombre)
        {
            EnumAccionReferencial r = EnumAccionReferencial.NO_ACTION;
            if (EnumAccionReferencial.NO_ACTION.ToString() == nombre)
                r = EnumAccionReferencial.NO_ACTION;
            if (EnumAccionReferencial.CASCADE.ToString() == nombre)
                r = EnumAccionReferencial.CASCADE;
            if (EnumAccionReferencial.SET_NULL.ToString() == nombre)
                r = EnumAccionReferencial.SET_NULL;
            if (EnumAccionReferencial.SET_DEFAULT.ToString() == nombre)
                r = EnumAccionReferencial.SET_DEFAULT;
            return r;
        }
        public string Nombre
        {
            get
            {
                return TForeignKey.Text.Trim();
            }
            set
            {
                TForeignKey.Text = value.Trim();
            }
        }
        private int getCampoPadre(string nombre)
        {
            Modelo.CTabla Tabla = Modelo.Get_Tabla(ComboTablas.Text);
            return Tabla.Get_Campo(nombre).ID_Campo;
        }
        public Modelo.CTabla TablaPadre
        {
            get
            {
                return (Modelo.CTabla)ComboTablas.SelectedItem;
            }
            set
            {
                if(ComboTablas.Items.Count==0)
                {
                    LLenaComboTablas();
                    for(int i=0;i< ComboTablas.Items.Count;i++)
                    {
                        Modelo.CTabla Tabla = (Modelo.CTabla)ComboTablas.Items[i];
                        if(Tabla.ID_Tabla==value.ID_Tabla)
                        {
                            ComboTablas.SelectedIndex = i;
                            CargaCamposTablaPadre(ComboTablas.Text);
                        }
                    }
                }
            }
        }
        public void SetCamposReferencia(List<Modelo.CCampoReferencia> campos)
        {
            foreach (DataRow dr in dataSet1.Tables["Columnas"].Rows)
            {
                //busco el campo que le coorezponde
                foreach(Modelo.CCampoReferencia campo in campos)
                {
                    if(campo.Get_CampoPadre().NombreX== dr["ColumnaPadre"].ToString())
                    {
                        dr["ColumnaHija"] = campo.Get_CampoHijo().NombreX;
                        break;
                    }
                }
            }
        }
        public EnumAccionReferencial AcctionDelete
        {
            get
            {
                return (EnumAccionReferencial)ComboDelete.SelectedItem;
            }
            set
            {
                if(ComboDelete.Items.Count==0)
                {
                    LLenaAccionesReferenciales();
                }
                ComboDelete.SelectedItem = value;
            }
        }
        public EnumAccionReferencial AcctionUpdate
        {
            get
            {
                return (EnumAccionReferencial)ComboUpdate.SelectedItem;
            }
            set
            {
                if (ComboUpdate.Items.Count == 0)
                {
                    LLenaAccionesReferenciales();
                }
                ComboUpdate.SelectedItem = value;
            }
        }

        private void BForeColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = LineColor;
            if (colorDialog1.ShowDialog() != DialogResult.OK)
                return;
            LineColor = colorDialog1.Color;

        }
    }
}
