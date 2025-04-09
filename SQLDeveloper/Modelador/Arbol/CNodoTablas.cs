using Modelador.Modelo;
using Modelador.UI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
using ManagerConnect;

namespace Modelador.Arbol
{
    public class CNodoTablas: CNodoFolder
    {
        public CNodoTablas()
        {
            Nombre = "Tablas";
        }
        public override void ModeloAsignado()
        {
            base.ModeloAsignado();
            Modelo.OnTablaInsert += new Modelo.DelegateModeloDatosEvent(TablaInsert);
            CargaTablas();
        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            AddMenuItem("Nueva Tabla", "Table_Field_Insert", MenuNuevaTabla_Click);
            AddMenuItem("Importar Tabla", "Tabla", MenuImportarTabla_Click);
        }
        private void CargaTablas()
        {
            List<Modelo.CTabla> tablas = Modelo.Get_Tablas();
            foreach (Modelo.CTabla tabla in tablas)
            {
                //solo tomo en cuenta las que no estan enuna region
                if (tabla.Get_Region() == null)
                {
                    CNodoTabla nodo = new CNodoTabla();
                    nodo.ID_Tabla = tabla.ID_Tabla;
                    nodo.Modelo = Modelo;
                    Nodes.Add(nodo);
                }
            }
        }
        private void MenuNuevaTabla_Click(object sender, EventArgs e)
        {
            FormPropiedadesTabla dlg = new FormPropiedadesTabla();
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            Modelo.Insert_Tabla(dlg.Nombre, 10, 10, Color.White, "",0, "", Color.Black,dlg.Comentarios);
        }
        private void MenuImportarTabla_Click(object sender, EventArgs e)
        {
            FormSelectConecion dlg = new FormSelectConecion();
            dlg.OnConexion += new OnFormConexionInicialEvent(OnConexionEvent);
            dlg.ShowDialog();

        }
        public override void Free()
        {
            Modelo.OnTablaInsert -= TablaInsert;
            base.Free();
        }
        private void TablaInsert(ModeloDatos modelo, int ID_Tabla)
        {
            
            Modelo.CTabla tabla = Modelo.Get_Tabla(ID_Tabla);
            CNodoTabla nodo = new CNodoTabla();
            nodo.ID_Tabla = ID_Tabla;
            nodo.Modelo = Modelo;
            Nodes.Add(nodo);
            
        }
        private void OnConexionEvent(string nombre, CConexion con)
        {
            IMotorDB motor = ControladorConexiones.DameMotor(con);
            FormSelectObjet dlg = new FormSelectObjet();
            dlg.Motor = motor;
            dlg.OnVerObjeto += new MotorDB.OnVerObjetoEvent(TablaSeleccionada);
            dlg.ShowDialog();
        }
        private void TablaSeleccionada(MotorDB.IMotorDB motor, string nombre, MotorDB.EnumTipoObjeto tipo)
        {
            if (tipo == EnumTipoObjeto.TABLE)
            {
                //inserto la tabla
                MotorDB.CTabla tabla = motor.DameTabla(nombre);
                if (tabla == null)
                    return;
                Modelo.CTabla tbl = Modelo.Get_Tabla(nombre);
                if (tbl == null)
                {
                    int id_tabla = Modelo.Insert_Tabla(tabla.Nombre, 10, 10, Color.White,  "", 0, "", Color.Black, "");
                    tbl = Modelo.Get_Tabla(id_tabla);
                }
                if (tabla.PrimaryKey != null)
                {
                    tbl.PK_Nombre = tabla.PrimaryKey.Nombre;
                    tbl.Update();
                }
                AgregaCampos(tabla, tbl);
                AgregaIndices(tabla, tbl);
                AgregaForaneas(motor, tabla, tbl);
                AgregaForaneasHijas(motor, tabla, tbl);
            }
        }
        private void AgregaCampos(MotorDB.CTabla tabla, Modelo.CTabla tbl)
        {
            //me traigo sus campos
            int orden = 0;
            if (tabla == null)
                return;
            foreach (MotorDB.CCampo campo in tabla.Campos)
            {
                Modelo.CTipoDato td = Modelo.Get_TipoDato(campo.TipoDato.Nombre);
                if (td == null)
                {
                    int id_tipoDato = Modelo.Insert_TipoDato(campo.TipoDato.Nombre, campo.TipoDato.UsaLongitud);
                    td = Modelo.Get_TipoDato(id_tipoDato);
                }
                bool pk = false;
                if (tabla.PrimaryKey != null)
                {
                    pk = tabla.PrimaryKey.ContieneCampo(campo);
                }
                if (tbl.Get_Campo(campo.Nombre) == null)
                {
                    int id_campo = Modelo.Insert_Campo(campo.Nombre, tbl.ID_Tabla, td.ID_TipoDato, campo.Longitud, pk, campo.AceptaNulo, campo.CampoCalculado, campo.Formula, campo.EsDefault, campo.DefaultName, orden,"");
                    if (tabla.EsIdentidad(campo))
                    {
                        tbl.ID_Identidad = id_campo;
                        tbl.Update();
                    }
                }
                orden++;
            }
        }
        private void AgregaIndices(MotorDB.CTabla tabla, Modelo.CTabla tbl)
        {
            //me traigo los indices
            foreach (Cindex index in tabla.Indexs)
            {
                CIndexX Index2 = Modelo.Get_Index(index.Nombre)
;                if (Index2 != null)
                {
                    int id_index = Modelo.Insert_IndexX(index.Nombre, tbl.ID_Tabla, Index2.GenerarFuncionX,Index2.MultiplesObjetos);
                    //ahora me traigo los campos
                    foreach (MotorDB.CCampoIndex ci in index.Campos)
                    {
                        foreach (Modelo.CCampo obj2 in tbl.Get_Campos())
                        {
                            if (obj2.Nombre == ci.Nombre)
                            {
                                Modelo.Insert_CampoIndex(id_index, obj2.ID_Campo, ci.Ordenamiento == EnumOrdenIndex.DESC);
                            }
                        }
                    }
                }
            }
        }
        private void AgregaForaneas(MotorDB.IMotorDB motor, MotorDB.CTabla tabla, Modelo.CTabla tbl)
        {
            //me traigo las llaves foraneas
            foreach (CForeignKey fk in motor.DameLLavesForaneas(tabla.Nombre))
            {
                if (Modelo.Get_LlaveForanea(fk.Nombre) == null)
                {
                    try
                    {
                        Modelo.CTabla padre = Modelo.Get_Tabla(fk.TablaPadre);
                        if (padre != null)
                        {
                            bool ok = true;
                            //verifico si existen los campos
                            foreach (CCampoFereneces campo in fk.Campos)
                            {
                                Modelo.CCampo campoPadre = padre.Get_Campo(campo.CampoPadre.Nombre);
                                Modelo.CCampo campoHijo = tbl.Get_Campo(campo.CampoHijo.Nombre);
                                if (campoPadre == null || campoHijo == null)
                                {
                                    ok = false;
                                    break;
                                }
                            }
                            if (ok == true)
                            {
                                int id_Fk = Modelo.Insert_LlaveForanea(padre.ID_Tabla, tbl.ID_Tabla, fk.Nombre, fk.AccionBorrar, fk.AccionActualizar, Color.Black);
                                CLlaveForanea Fk3 = Modelo.Get_LlaveForanea(id_Fk);
                                //agrego los campos
                                foreach (CCampoFereneces campo in fk.Campos)
                                {
                                    Fk3.Insert_CampoReferencia(padre.Get_Campo(campo.CampoPadre.Nombre).ID_Campo, tbl.Get_Campo(campo.CampoHijo.Nombre).ID_Campo);
                                }
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        continue;
                    }
                }
            }
        }
        private void AgregaForaneasHijas(MotorDB.IMotorDB motor, MotorDB.CTabla tabla, Modelo.CTabla tbl)
        {
            //me traigo las llaves foraneas
            foreach (CForeignKey fk in motor.DameLLavesForaneasHijas(tabla.Nombre))
            {
                if (Modelo.Get_LlaveForanea(fk.Nombre) == null)
                {
                    try
                    {
                        Modelo.CTabla hija = Modelo.Get_Tabla(fk.TablaHija);
                        if (hija != null)
                        {
                            bool ok = true;
                            //verifico si existen los campos
                            foreach (CCampoFereneces campo in fk.Campos)
                            {
                                Modelo.CCampo campoHijo = hija.Get_Campo(campo.CampoPadre.Nombre);
                                Modelo.CCampo campoPadre = tbl.Get_Campo(campo.CampoHijo.Nombre);
                                if (campoPadre == null || campoHijo == null)
                                {
                                    ok = false;
                                    break;
                                }
                            }
                            if (ok == true)
                            {
                                int id_Fk = Modelo.Insert_LlaveForanea(tbl.ID_Tabla, hija.ID_Tabla, fk.Nombre, fk.AccionBorrar, fk.AccionActualizar, Color.Black);
                                CLlaveForanea Fk3 = Modelo.Get_LlaveForanea(id_Fk);
                                //agrego los campos
                                foreach (CCampoFereneces campo in fk.Campos)
                                {
                                    Fk3.Insert_CampoReferencia(tbl.Get_Campo(campo.CampoHijo.Nombre).ID_Campo, hija.Get_Campo(campo.CampoPadre.Nombre).ID_Campo);
                                }
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        continue;
                    }
                }
            }
        }

    }
}
