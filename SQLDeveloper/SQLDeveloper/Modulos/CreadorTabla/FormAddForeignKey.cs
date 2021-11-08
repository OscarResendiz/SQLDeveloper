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
    public partial class FormAddForeignKey : Form
    {
        CTabla Tabla;
        public FormAddForeignKey(CTabla tablaHija)
        {
            Tabla = tablaHija;
            InitializeComponent();
            TTablaHija.Text = Tabla.Nombre;
        }
        private void LLenaComboTablas()
        {
            List<MotorDB.CObjeto> l = DBProvider.DB.Buscar("", MotorDB.EnumTipoObjeto.TABLE);
            ComboTablas.Items.Clear();
            foreach(MotorDB.CObjeto obj in l)
            {
                ComboTablas.Items.Add(obj);
            }
        }
        private void LLenaAccionesReferenciales()
        {
            List<MotorDB.EnumAccionReferencial> la,ld;
            la = DBProvider.DB.DameAccionesReferencialesActualizadoValidos();
            ld = DBProvider.DB.DameAccionesReferencialesBorradoValidos();
            //limpio los combos
            ComboUpdate.Items.Clear();
            ComboDelete.Items.Clear();
            //lleno los combos
            foreach (MotorDB.EnumAccionReferencial obj1 in la)
            {
                ComboUpdate.Items.Add(obj1);
            }
            foreach (MotorDB.EnumAccionReferencial obj2 in ld)
            {
                ComboDelete.Items.Add(obj2);
            }
            //asigno valores de default
            ComboUpdate.SelectedItem = MotorDB.EnumAccionReferencial.NO_ACTION;
            ComboDelete.SelectedItem = MotorDB.EnumAccionReferencial.NO_ACTION;
        }
        private void FormAddForeignKey_Load(object sender, EventArgs e)
        {
            LLenaComboTablas();
            LLenaAccionesReferenciales();
//            CargaCamposTablaHija();
        }

        private void BTablas_Click(object sender, EventArgs e)
        {
            //muestro el cuadro de dialogo de busqueda de tablas
            FormBuscadorTablas dlg = new FormBuscadorTablas();
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            string tabla = dlg.Tabla;
            //selecciono la tabla en el combo
            foreach(MotorDB.CObjeto obj in ComboTablas.Items)
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
            MotorDB.CTabla Tabla = DBProvider.DB.DameTabla(padre);
            if(Tabla==null)
            {
                return;
            }
            if(Tabla.PrimaryKey==null)
            {
                //no tiene llave primaria
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
            foreach (MotorDB.CCampoBase obj in            Tabla.PrimaryKey.Campos)
            {
                //agrego el tipo de dato
                AgregaTipo(obj.TipoDato, obj.Longitud);
                DataRow dr = dt.NewRow();
                dr["ColumnaPadre"] = obj.Nombre;
                dt.Rows.Add(dr);
            }
            CargaCamposTablaHija();
            //le asigno un nombre a la llave foranea
            AsignaNombreFK();
        }
        private void AgregaTipo(MotorDB.CTipoDato tipo, int tamaño)
        {
            string s = tipo.Nombre;
            if(tipo.UsaLongitud!= TIPO_LONGITUD.NOREQUERIDO)
            {
                if (tipo.UsaLongitud != TIPO_LONGITUD.OBLIGATORIO)
                {
                    s = s + "(" + tamaño + ")";
                }
                else if (tipo.UsaLongitud != TIPO_LONGITUD.OPCIONAL)
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
                    return;
                }
            }
            //como no existe lo agrego 
            DataRow dr1 = dt.NewRow();
            dr1["Tipo"] = s;
            dt.Rows.Add(dr1);
        }
        private bool ValidaTipoDato(MotorDB.CTipoDato tipo, int tamaño)
        {
            string s = tipo.Nombre;
            switch (tipo.UsaLongitud)
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
            foreach (MotorDB.CCampo obj in Tabla.Campos)
            {
                if (ValidaTipoDato(obj.TipoDato, obj.Longitud))
                {
                    //si y solo si existe el tipo de dato lo agrega
                    DataRow dr = dt.NewRow();
                    dr["Campo"] = obj.Nombre;
                    dt.Rows.Add(dr);
                }
            }
        }
        private void ComboTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaCamposTablaPadre(ComboTablas.Text);
        }
        private void  AsignaNombreFK()
        {
            int consecutivo = 0;
            bool ok = true; //doy por hecho que el nombre no existe
            string nombre = "";
            //verifico si existe el objeto
            do
            {
                //genero un nombre
                nombre = "fkc_" + TTablaHija.Text;// + "_" + ComboTablas.Text;
                if (consecutivo > 0)
                    nombre += consecutivo; //le asigno un consecutivo al nombre
                consecutivo++;
                //me traigo todas las llaves foraneas para ver si no se repite el nombre
                List<MotorDB.CObjeto> l = DBProvider.DB.Buscar(nombre, MotorDB.EnumTipoObjeto.FOREIGNKEY);
                ok = true;//asumo que no existe
                foreach (MotorDB.CObjeto obj in l)
                {
                    if (obj.Nombre.ToUpper().Trim() == nombre.ToUpper().Trim())
                    {
                        ok = false;
                        //rompo el for
                        break;
                    }
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
            //lleno los datos de FK
            MotorDB.CForeignKey fk = new MotorDB.CForeignKey();
            fk.Nombre = TForeignKey.Text;
            fk.TablaHija = TTablaHija.Text;
            fk.TablaPadre = ComboTablas.Text;
            fk.AccionActualizar =(MotorDB.EnumAccionReferencial) ComboUpdate.SelectedItem;
            fk.AccionBorrar = (MotorDB.EnumAccionReferencial)ComboDelete.SelectedItem;
            //me traigo la tabla padre
            MotorDB.CTabla tablaPadre = DBProvider.DB.DameTabla(ComboTablas.Text);
            //asigno los campos
            foreach(DataRow dr in dt.Rows)
            {
                string columnaMaestra = dr["ColumnaPadre"].ToString();
                string columnaHija = dr["ColumnaHija"].ToString();
                //me traigo el campo de la tabla maestra
                MotorDB.CCampo campo = tablaPadre.GetCampo(columnaMaestra);
                MotorDB.CCampoFereneces obj = new MotorDB.CCampoFereneces(columnaMaestra, columnaHija,campo.TipoDato, campo.Longitud);
                fk.Add(obj);
            }
            //ahora a mandar a crear el FK
            try
            {
                Tabla.AddForeignKey(fk);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;

            }
            //cierrro la pantalla ya que no tube problemas para crear el FK
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
