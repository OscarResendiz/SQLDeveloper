using Modelador.Modelo;
using MotorDB;
using SPGenerator;
using System;
using System.Collections;
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
    public delegate void OnCodigoEvent(MotorDB.IMotorDB motor,string Nombre, string Codigo);

    public partial class FormTabla : Form
    {
        MotorDB.IMotorDB Motor;
        public event MotorDB.OnVerObjetoEvent OnVerCodigoTabla;
        public event MotorDB.OnVerObjetoEvent OnVerTablaPadre;
        public event MotorDB.OnVerObjetoEvent OnVerDependencias;
        public event MotorDB.OnVerObjetoEvent OnVerRelaciones;
        public event MotorDB.OnVerObjetoEvent OnVerTrrigers;
        public event OnPropiedadesEvent OnPropiedadesCampo;
        public event OnCodigoEvent OnCodigo;
        bool IsTypeTable = false;
        private string NombreTabla;
        MotorDB.CTabla Tabla;
        private bool LecturaExitosa;
        private Dictionary<String, String> TiposKotlin;
        public FormTabla(MotorDB.IMotorDB motor, string tabla, bool tt = false)
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
            if (OnPropiedadesCampo != null)
            {
                CpropiedadesCampo propiedades = new CpropiedadesCampo(campo, Tabla.Identidad);
                if (Tabla.EsPrimaryKey(campo))
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
                            OnVerTablaPadre(Motor, fk.TablaPadre, MotorDB.EnumTipoObjeto.TABLE);
                        }
                    }
                }
            }

        }

        private void BDependencias_Click(object sender, EventArgs e)
        {
            if (OnVerDependencias != null)
            {
                OnVerDependencias(Motor, NombreTabla, MotorDB.EnumTipoObjeto.TABLE);
            }
        }

        private void BRelacion_Click(object sender, EventArgs e)
        {
            if (OnVerRelaciones != null)
            {
                OnVerRelaciones(Motor, NombreTabla, MotorDB.EnumTipoObjeto.TABLE);
            }
        }

        private void BAddFk_Click(object sender, EventArgs e)
        {
            FormForeignKeys dlg = new FormForeignKeys(NombreTabla, Motor);
            dlg.ShowDialog();
            if (dlg.Modificado)
            {
                //hay que recargar la informacion de la tabla
                MuestraDatos();
            }
        }

        private void Btrrigers_Click(object sender, EventArgs e)
        {
            if (OnVerTrrigers != null)
            {
                OnVerTrrigers(Motor, NombreTabla, MotorDB.EnumTipoObjeto.TABLE);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormIndexs dlg = new FormIndexs(this.NombreTabla, Motor);
            dlg.ShowDialog();
            if (dlg.Modificado)
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
            FormDatosAvanzados dlg = new FormDatosAvanzados(NombreTabla, Motor);
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
            catch (System.Exception ex)
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
        private void GeneraCodigoSP(SPGenerator.Objetos.TIPO_SP tipo)
        {
            FormAsistSP dlg = new FormAsistSP(Motor.Clone(), tipo);
            dlg.Tabla = TNombre.Text;
            dlg.OnCodigoSP += new OnCodigoSPEvent(GenCodigo);
            dlg.ShowDialog();

        }
        private void BSPInsert_Click(object sender, EventArgs e)
        {
            GeneraCodigoSP(SPGenerator.Objetos.TIPO_SP.INSERT);
        }
        private void GenCodigo(string nombre, string codigo)
        {
            if (OnCodigo != null)
                OnCodigo(Motor, nombre, codigo);
        }

        private void BSPUpdate_Click(object sender, EventArgs e)
        {
            GeneraCodigoSP(SPGenerator.Objetos.TIPO_SP.UPDATE);
        }

        private void BSPDelete_Click(object sender, EventArgs e)
        {
            GeneraCodigoSP(SPGenerator.Objetos.TIPO_SP.DELETE);
        }

        private void BSPSelect_Click(object sender, EventArgs e)
        {
            GeneraCodigoSP(SPGenerator.Objetos.TIPO_SP.SELECT);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (OnCodigo != null)
            {
                string nombreTabla = Tabla.Nombre[0].ToString().ToUpper() + Tabla.Nombre.Substring(1);
                OnCodigo(Motor, $"{nombreTabla}Repository", GeneraRepositoryKotlin());
                OnCodigo(Motor, $"{nombreTabla}DAO", GeneraDaoKotlin());
                OnCodigo(Motor, $"{nombreTabla}Entity", GeneraEntidadKotlin());
            }
        }
        private void GeneraDiccionarioKotlin()
        {
            if (TiposKotlin != null)
                return;
            TiposKotlin = new Dictionary<string, string>();
            TiposKotlin.Add("geography".ToUpper().Trim(), "String");
            TiposKotlin.Add("geometry".ToUpper().Trim(), "String");
            TiposKotlin.Add("xml".ToUpper().Trim(), "String");
            TiposKotlin.Add("bit".ToUpper().Trim(), "Boolean");
            TiposKotlin.Add("tinyint".ToUpper().Trim(), "Int");
            TiposKotlin.Add("smallint".ToUpper().Trim(), "Int");
            TiposKotlin.Add("date".ToUpper().Trim(), "Date");
            TiposKotlin.Add("int".ToUpper().Trim(), "Int");
            TiposKotlin.Add("real".ToUpper().Trim(), "Double");
            TiposKotlin.Add("INTEGER".ToUpper().Trim(), "Int");
            TiposKotlin.Add("smalldatetime".ToUpper().Trim(), "Date");
            TiposKotlin.Add("smallmoney".ToUpper().Trim(), "Float");
            TiposKotlin.Add("time".ToUpper().Trim(), "LocalTime");
            TiposKotlin.Add("bigint".ToUpper().Trim(), "Long");
            TiposKotlin.Add("datetime".ToUpper().Trim(), "Date");
            TiposKotlin.Add("money".ToUpper().Trim(), "Float");
            TiposKotlin.Add("timestamp".ToUpper().Trim(), "LocalTime");
            TiposKotlin.Add("image".ToUpper().Trim(), "String");
            TiposKotlin.Add("ntext".ToUpper().Trim(), "String");
            TiposKotlin.Add("text".ToUpper().Trim(), "String");
            TiposKotlin.Add("uniqueidentifier".ToUpper().Trim(), "UUID");
            TiposKotlin.Add("sysname".ToUpper().Trim(), "String");
            TiposKotlin.Add("hierarchyid".ToUpper().Trim(), "String");
            TiposKotlin.Add("sql_variant".ToUpper().Trim(), "String");
            TiposKotlin.Add("datetime2".ToUpper().Trim(), "Date");
            TiposKotlin.Add("float".ToUpper().Trim(), "Float");
            TiposKotlin.Add("datetimeoffset".ToUpper().Trim(), "Date");
            TiposKotlin.Add("decimal".ToUpper().Trim(), "Float");
            TiposKotlin.Add("numeric".ToUpper().Trim(), "Int");
            TiposKotlin.Add("binary".ToUpper().Trim(), "Boolean");
            TiposKotlin.Add("char".ToUpper().Trim(), "String");
            TiposKotlin.Add("nchar".ToUpper().Trim(), "String");
            TiposKotlin.Add("nvarchar".ToUpper().Trim(), "String");
            TiposKotlin.Add("varbinary".ToUpper().Trim(), "Boolean");
            TiposKotlin.Add("varchar".ToUpper().Trim(), "String");
            TiposKotlin.Add("uuid".ToUpper().Trim(), "UUID");
        }
        private string DameTipoDatoKotlin(MotorDB.CTipoDato tipoDato)
        {
            GeneraDiccionarioKotlin();
            return TiposKotlin[tipoDato.Nombre.ToUpper().Trim()];
        }
        private string GeneraEntidadKotlin()
        {
            string nombreTabla= Tabla.Nombre[0].ToString().ToUpper()+ Tabla.Nombre.Substring(1);
            string nombreEntidad = nombreTabla + "Entity";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("import androidx.room.Entity");
            sb.AppendLine("import androidx.room.PrimaryKey");
            sb.AppendLine("import androidx.room.ForeignKey");            
            sb.AppendLine("import java.util.Date");
            sb.AppendLine("import java.util.UUID");
            string entity = $"@Entity( tableName = \"" + nombreTabla + "\"";
            //me traigo los campos de llave primaria
            if (Tabla.PrimaryKey.Campos.Count > 0)
            {
                string pk = "\n\t, primaryKeys = [";
                bool primeroc = true;
                foreach (MotorDB.CCampoBase campo in Tabla.PrimaryKey.Campos)
                {
                    if (primeroc)
                        primeroc = false;
                    else
                        pk = pk + ",";
                    pk = pk + $"\"{campo.Nombre}\"";
                }
                pk = pk + "]";
                entity = entity + pk;
            }
            entity = entity + AgregaFKKotlin();
            entity = entity + ")";
            sb.AppendLine(entity);
            //creo el nombre
            sb.AppendLine($"data class {nombreEntidad}(");
            //voy creando los campos
            bool primero = true;
            foreach (MotorDB.CCampo campo in Tabla.Campos)
            {
                string scampo = "\t";
                if (primero)
                {
                    primero = false;
                }
                else
                {
                    scampo = scampo + ",";
                }
                scampo = scampo + $"val {campo.Nombre}: {DameTipoDatoKotlin(campo.TipoDato)} ";
                sb.AppendLine(scampo);
            }
            sb.AppendLine(")");
            return sb.ToString();
        }
        private string GeneraDaoKotlin()
        {
            string nombreTabla = Tabla.Nombre[0].ToString().ToUpper() + Tabla.Nombre.Substring(1);
            string nombreEntidad = nombreTabla + "Entity";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("import androidx.room.Dao");
            sb.AppendLine("import androidx.room.Delete");
            sb.AppendLine("import androidx.room.Insert");
            sb.AppendLine("import androidx.room.OnConflictStrategy");
            sb.AppendLine("import androidx.room.Query");
            sb.AppendLine("import androidx.room.Update");
            sb.AppendLine("import java.util.UUID");
            sb.AppendLine("");
            sb.AppendLine("@Dao");
            sb.AppendLine($"interface {nombreTabla}DAO {{");
            sb.AppendLine("");
            sb.AppendLine($"\t@Query(\"select * from {nombreTabla}\")");
            sb.AppendLine($"\tsuspend fun Dame{nombreTabla}s(): List<{nombreEntidad}>");

            //me traigo los campos de llave primaria
            if (Tabla.PrimaryKey.Campos.Count > 0)
            {
                string s1 = $"\t@Query(\"select * from {nombreTabla} where ";
                string s2 = $"\tsuspend fun Dame{nombreTabla}(";
                bool primeroc = true;
                foreach (MotorDB.CCampoBase campo in Tabla.PrimaryKey.Campos)
                {
                    if (primeroc)
                        primeroc = false;
                    else
                    {
                        s1 = s1 + " and ";
                        s2 = s2 + ", ";
                    }
                    s1 = s1 + $"{campo.Nombre}=:{campo.Nombre}";
                    s2 = s2 + $"{campo.Nombre}:{DameTipoDatoKotlin(campo.TipoDato)}";
                }
                s1 = s1 + " limit 1\")";
                s2 = s2 + $"): {nombreEntidad}";
                sb.AppendLine(s1);
                sb.AppendLine(s2);
            }
            sb.AppendLine("\t@Insert(onConflict = OnConflictStrategy.REPLACE)");
            sb.AppendLine($"\tsuspend fun Inserta{nombreTabla}(obj: {nombreEntidad})");
            sb.AppendLine("\t@Update");
            sb.AppendLine($"\tsuspend fun Actualiza{nombreTabla}(obj: {nombreEntidad})");
            sb.AppendLine("\t@Delete");
            sb.AppendLine($"\tsuspend fun Elimina{nombreTabla}(obj: {nombreEntidad})");
            sb.AppendLine("}");
            return sb.ToString();
        }
        private string GeneraRepositoryKotlin()
        {
            string nombreTabla = Tabla.Nombre[0].ToString().ToUpper() + Tabla.Nombre.Substring(1);
            string nombreRepository = nombreTabla + "Repository";
            string nombreEntidad = nombreTabla + "Entity";
            string nombreDao = nombreTabla + "Dao";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("import androidx.room.Delete");
            sb.AppendLine("import androidx.room.Insert");
            sb.AppendLine("import androidx.room.OnConflictStrategy");
            sb.AppendLine("import androidx.room.Query");
            sb.AppendLine("import androidx.room.Update");
            sb.AppendLine("import java.util.UUID");
            sb.AppendLine("");
//            sb.AppendLine("@Dao");
            sb.AppendLine($"class {nombreTabla}Repository(private val {nombreDao}: {nombreTabla}DAO) {{");
            //sb.AppendLine($"\t@Query(\"select * from {nombreTabla}\")");
            sb.AppendLine($"\tsuspend fun Dame{nombreTabla}s(): List<{nombreEntidad}>");
            sb.AppendLine("\t{");
            sb.AppendLine($"\t\treturn {nombreDao}.Dame{nombreTabla}s()");
            sb.AppendLine("\t}");

            //me traigo los campos de llave primaria
            if (Tabla.PrimaryKey.Campos.Count > 0)
            {
                string s1 = $"\tsuspend fun Dame{nombreTabla}(";
                string s2 = $"\t\treturn {nombreDao}.Dame{nombreTabla}(";
                bool primeroc = true;
                foreach (MotorDB.CCampoBase campo in Tabla.PrimaryKey.Campos)
                {
                    if (primeroc)
                        primeroc = false;
                    else
                    {
                        s1 = s1 + ", ";
                        s2 = s2 + ", ";
                    }
                    s1 = s1 + $"{campo.Nombre}:{DameTipoDatoKotlin(campo.TipoDato)}";
                    s2 = s2 + $"{campo.Nombre}";
                }
                s1 = s1 + $"): {nombreEntidad}";
                s2 = s2 + $")";
                sb.AppendLine(s1);
                sb.AppendLine("\t{");
                sb.AppendLine(s2);
                sb.AppendLine("\t}");
            }
            sb.AppendLine($"\tsuspend fun Inserta{nombreTabla}(obj: {nombreEntidad})");
            sb.AppendLine("\t{");
            sb.AppendLine($"\t\t{nombreDao}.Inserta{nombreTabla}(obj)");
            sb.AppendLine("\t}");

            sb.AppendLine($"\tsuspend fun Actualiza{nombreTabla}(obj: {nombreEntidad})");
            sb.AppendLine("\t{");
            sb.AppendLine($"\t\t{nombreDao}.Actualiza{nombreTabla}(obj)");
            sb.AppendLine("\t}");

            sb.AppendLine($"\tsuspend fun Elimina{nombreTabla}(obj: {nombreEntidad})");
            sb.AppendLine("\t{");
            sb.AppendLine($"\t\t {nombreDao}.Elimina{nombreTabla}(obj)");
            sb.AppendLine("\t}");

            sb.AppendLine("}");
            return sb.ToString();

        }

        private string ConvierteCapital(string cadena)
        {
            return cadena[0].ToString().ToUpper() + cadena.Substring(1);
        }
        private string AgregaFKKotlin()
        {
            StringBuilder sb = new StringBuilder();
            List<CForeignKey> fks = Motor.DameLLavesForaneas(Tabla.Nombre);
            if (fks.Count == 0)
                return "";
            sb.AppendLine("\n\t,foreignKeys = [");
            bool primerfk = true;
            foreach (CForeignKey fk in fks)
            {
                if(primerfk)
                {
                    primerfk = false;
                    sb.AppendLine("\t\tForeignKey(");
                }
                else
                {
                    sb.AppendLine("\t\t,ForeignKey(");

                }
                sb.AppendLine($"\t\t\tentity = {ConvierteCapital(fk.TablaPadre)}Entity::class, //padre");
                //recorro los campos
                bool primero = true;
                string parentColumns = "";
                string childColumns = "";
                foreach (CCampoReference campofk in fk.Campos)
                {
                    if(primero)
                    {
                        primero = false;
                    }
                    else
                    {
                        parentColumns = parentColumns + ",";
                        childColumns= childColumns + ",";
                    }
                    parentColumns= parentColumns + $"\"{campofk.CampoPadre}\"";
                    childColumns= childColumns + $"\"{campofk.CampoHijo}\"";
                }

                sb.AppendLine($"\t\t\tparentColumns = [{parentColumns}], // Columna padre");
                sb.AppendLine($"\t\t\tchildColumns = [{childColumns}], // Columna hija");
                sb.AppendLine("\t\t\tonDelete = ForeignKey.CASCADE           // Qué pasa si se borra el padre");
                sb.AppendLine("\t\t)");
            }
            sb.AppendLine("\t]");
//            sb.AppendLine("");
  //          sb.AppendLine("");
    //        sb.AppendLine("");
      //      sb.AppendLine("");
        //    sb.AppendLine("");
          //  sb.AppendLine("");
            //sb.AppendLine("");
            //sb.AppendLine("");
            return sb.ToString() ;
        }
    }
}
