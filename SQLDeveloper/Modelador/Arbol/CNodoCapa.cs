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
    public class CNodoCapa : CNodoFolder
    {
        public int ID_Capa
        {
            get;
            set;
        }
        public CNodoCapa()
        {
            Nombre = "Capa";
        }
        public override void ModeloAsignado()
        {
            base.ModeloAsignado();
            CCapa capa = GetCapa();
            Nombre = capa.Nombre;
            Modelo.OnCapaUpdate += new DelegateModeloDatosEvent(CapaUpdate);
            Modelo.OnRegionInsert += new DelegateModeloDatosEvent(RegionInsert);
//            Modelo.OnTablaInsert += new DelegateModeloDatosEvent(TablaInsert);
            Modelo.OnCapaDelete += new DelegateModeloDatosEvent(CapaDelete);
            Modelo.OnRegionTablaInsert += new DelegateModeloDatosEvent2(RegionTablaInsert);
            Modelo.OnTablaCapaMove += new DelegateModeloDatosEvent3(TablaCapaMove);
            Modelo.OnMoveRegionCapa += new DelegateModeloDatosEvent3(MoveRegionCapa);
            Modelo.OnMoveRegionRegion += new DelegateModeloDatosEvent3(MoveRegionRegion);
            Modelo.OnCapaTablaInsert += new DelegateModeloDatosEvent2(CapaTablaInsert);
            CargaRegiones();
            CargaTablas();
        }
        public CCapa GetCapa()
        {
            return Modelo.Get_Capa(ID_Capa);
        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            AddMenuItem("Agregar Region", "IconoAgregar", MenuAgregarRegion_Click);
            AddMenuSeparator();
            AddMenuItem("Agregar Tablas", "Table_Field_Insert", MenuNAgregarTabla_Click);
            AddMenuItem("Nueva Tabla", "Table_Field_Insert", MenuNuevaTabla_Click);
            AddMenuItem("Importar Tabla", "Tabla", MenuImportarTabla_Click);
            AddMenuSeparator();
            AddMenuItem("Ocultar/Mostrar", "ojo2", MenuVisible_Click);
            AddMenuItem("Editar", "IconoEditar", MenuEditar_Click);
            AddMenuSeparator();
            AddMenuItem("Eliminar", "Eliminar", MenuEliminar_Click);
        }
        private void MenuVisible_Click(object sender, EventArgs arg)
        {
            CCapa capa = GetCapa();
            capa.Visible = !capa.Visible;
            capa.Update();
        }
        private void CargaRegiones()
        {
            List<CRegion> regiones = Modelo.Get_RegionesCapa(this.ID_Capa);
            foreach (CRegion region in regiones)
            {
                if (region.ID_RegionPadre == 0)
                {
                    CnodoRegion nodo = new CnodoRegion();
                    nodo.ID_Region = region.ID_Region;
                    nodo.Modelo = Modelo;
                    Nodes.Add(nodo);
                }
            }
        }
        private void CargaTablas()
        {
            List<Modelo.CTabla> tablas = Modelo.Get_TablasCapa(ID_Capa);
            foreach (Modelo.CTabla tabla in tablas)
            {
                //solo tomo en cuenta las que no estan enuna region
                if (tabla.Get_Region() == null || tabla.Get_Region().ID_Capa!=ID_Capa)
                {
                    CNodoTablaCapa nodo = new CNodoTablaCapa();
                    nodo.ID_Capa = ID_Capa;
                    nodo.ID_Tabla = tabla.ID_Tabla;
                    nodo.Modelo = Modelo;
                    Nodes.Add(nodo);
                }
            }
        }
        private void MenuAgregarRegion_Click(object sender, EventArgs e)
        {
            FormPropiedadesRegion dlg = new FormPropiedadesRegion();
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            CCapa capa = GetCapa();
            capa.Insert_Region(dlg.Nombre, dlg.Bk_Color, dlg.RegionVisible, "", 0, dlg.Fore_Color);
        }
        private void MenuNuevaTabla_Click(object sender, EventArgs e)
        {
            FormPropiedadesTabla dlg = new FormPropiedadesTabla();
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            CCapa capa = GetCapa();
            capa.Insert_Tabla(dlg.Nombre, 0, 0, 10, 10, Color.White,  "", 0, "", Color.Black,dlg.Comentarios);
        }
        private void MenuImportarTabla_Click(object sender, EventArgs e)
        {
            FormSelectConecion dlg = new FormSelectConecion();
            dlg.OnConexion += new OnFormConexionInicialEvent(OnConexionEvent);
            dlg.ShowDialog();

        }
        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Eliminar la capa?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                CCapa capa = GetCapa();
                capa.Delete();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MenuEditar_Click(object sender, EventArgs e)
        {
            FormPropiedadesCapa dlg = new FormPropiedadesCapa();
            CCapa capa = GetCapa();
            dlg.NombreCapa = capa.Nombre;
            dlg.CapaVisible = capa.Visible;
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            capa.Nombre = dlg.NombreCapa;
            capa.Visible = dlg.CapaVisible;
            capa.Update();
        }
        public override void Free()
        {
            Modelo.OnCapaUpdate -= CapaUpdate;
            Modelo.OnRegionInsert -= RegionInsert;
//            Modelo.OnTablaInsert -= TablaInsert;
            Modelo.OnCapaDelete -= CapaDelete;
            Modelo.OnRegionTablaInsert -= RegionTablaInsert;
            Modelo.OnTablaCapaMove -= TablaCapaMove;
            Modelo.OnMoveRegionCapa -= MoveRegionCapa;
            Modelo.OnMoveRegionRegion -= MoveRegionRegion;

            base.Free();
        }
        private void CapaUpdate(ModeloDatos modelo, int id_Capa)
        {
            if (id_Capa != ID_Capa)
                return;
            CCapa capa = GetCapa();
            Nombre = capa.Nombre;
        }
        private void RegionInsert(ModeloDatos modelo, int ID_Region)
        {
            CRegion region = Modelo.Get_Region(ID_Region);
            if (region.ID_Capa != ID_Capa)
            {
                return;
            }
            if (region.ID_RegionPadre != 0)
                return;
            CnodoRegion nodo = new CnodoRegion();
            nodo.ID_Region = ID_Region;
            nodo.Modelo = Modelo;
            Nodes.Add(nodo);
        }
        private void CapaDelete(Modelo.ModeloDatos modelo, int id_Cpa)
        {
            if (ID_Capa == id_Cpa)
            {
                Remove();
            }

        }
        private void RegionTablaInsert(ModeloDatos modelo, int id_region, int ID_Tabla)
        {
            Modelo.CRegion region = Modelo.Get_Region(id_region);
            if (region.ID_Capa != ID_Capa)
                return;
            Modelo.CTabla tabla = Modelo.Get_TablaCapa(ID_Capa, ID_Tabla);
            if (tabla==null)
                return;
            foreach (CNodoBase nodo in Nodes)
            {
                if (nodo.GetType() == typeof(CNodoTablaCapa))
                {
                    CNodoTablaCapa nodo2 = (CNodoTablaCapa)nodo;
                    if (nodo2.ID_Tabla == ID_Tabla)
                    {
                        nodo2.Free();
                        nodo2.Remove();
                        return;
                    }
                }
            }
            
        }
        private void OnConexionEvent(string nombre, CConexion con)
        {
            IMotorDB motor = ControladorConexiones.DameMotor(con);
            FormSelectObjet dlg = new FormSelectObjet();
            dlg.Motor = motor;
            dlg.OnVerObjeto += new MotorDB.OnVerObjetoEvent(TablaSeleccionada);
            dlg.ShowDialog();
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
                    int id_campo = Modelo.Insert_Campo(campo.Nombre, tbl.ID_Tabla, td.ID_TipoDato, campo.Longitud, pk, campo.AceptaNulo, campo.CampoCalculado, campo.Formula, campo.EsDefault, campo.DefaultName, orden, "");
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
                CIndexX index2 = Modelo.Get_Index(index.Nombre)
;                if (index2 == null)
                {
                    int id_index = Modelo.Insert_IndexX(index.Nombre, tbl.ID_Tabla, index2.GenerarFuncionX,index2.MultiplesObjetos);
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
                    int id_tabla = Modelo.Insert_Tabla(tabla.Nombre, 10, 10, Color.White,  "", 0, "",Color.Black,tbl.Comentarios);
                    Modelo.Insert_TablaCapa(ID_Capa, id_tabla, 0, 0, true);
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
        public override void NodeDrop(CNodoBase nodo)
        {
            if (nodo.GetType() == typeof(CNodoTablaCapa))
            {
                CNodoTablaCapa objeto = (CNodoTablaCapa)nodo;
                int id_CapaOrigen = objeto.ID_Capa;
                Modelo.Move_TablaCapa(objeto.ID_Tabla, id_CapaOrigen, this.ID_Capa);
            }
            else if (nodo.GetType() == typeof(CnodoRegion))
            {
                CnodoRegion ndoregion = (CnodoRegion)nodo;
                CRegion region = ndoregion.GetRegion();
                Modelo.Move_RegionCapa(region.ID_Region, region.ID_Capa, this.ID_Capa);
            }
        }
        private void TablaCapaMove(ModeloDatos modelo, int ID_Tabla, int ID_CapaOrigen, int ID_CapaDestino)
        {
            //caso especial
            if (ID_Capa == ID_CapaOrigen && ID_CapaOrigen == ID_CapaDestino)
            {
                //veo si ya existe el nodo
                foreach (CNodoBase nodo in Nodes)
                {
                    if (nodo.GetType() == typeof(CNodoTablaCapa))
                    {
                        CNodoTablaCapa tabla = (CNodoTablaCapa)nodo;
                        if (tabla.ID_Tabla == ID_Tabla)
                        {
                            return;
                        }
                    }
                }
                //como no existe, lo agrego
                Modelo.Insert_TablaCapa(ID_Capa, ID_Tabla,0,0,true);
                return;
            }
            if (ID_Capa == ID_CapaOrigen)
            {
                foreach (CNodoBase nodo in Nodes)
                {
                    if (nodo.GetType() == typeof(CNodoTablaCapa))
                    {
                        CNodoTablaCapa tabla = (CNodoTablaCapa)nodo;
                        if (tabla.ID_Tabla == ID_Tabla)
                        {
                            tabla.Remove();
                            return;
                        }
                    }
                }
            }
            if (ID_Capa == ID_CapaDestino)
            {
                //TablaInsert(modelo, ID_Tabla);
                Modelo.Insert_TablaCapa(ID_Capa, ID_Tabla,0,0,true);
            }
        }
        private void MoveRegionCapa(ModeloDatos modelo, int ID_Region, int ID_CapaOrigen, int ID_CapaDestino)
        {
            if (ID_Capa == ID_CapaOrigen)
            {
                foreach (CNodoBase nodo in Nodes)
                {
                    if (nodo.GetType() == typeof(CnodoRegion))
                    {
                        CnodoRegion region = (CnodoRegion)nodo;
                        if (region.ID_Region == ID_Region)
                        {
                            region.Remove();
                            return;
                        }
                    }
                }
            }
            if (ID_Capa == ID_CapaDestino)
            {
                RegionInsert(modelo, ID_Region);
            }

        }
        private void MoveRegionRegion(ModeloDatos modelo, int id_region, int id_regionOrigen, int id_regionDestino)
        {
            //busco la region hija dentro de mis nodos
            foreach (CNodoBase nodo in Nodes)
            {
                if (nodo.GetType() == typeof(CnodoRegion))
                {
                    CnodoRegion nodoRegion = (CnodoRegion)nodo;
                    if (nodoRegion.ID_Region == id_region)
                    {
                        nodoRegion.Remove();
                        return;
                    }
                }
            }
        }
        private void MenuNAgregarTabla_Click(object sender, EventArgs arg)
        {
            UI.FormSeleccionarTablas dlg = new FormSeleccionarTablas(Modelo,ID_Capa);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            List<Modelo.CTabla> l = dlg.DameTablas();
            foreach(Modelo.CTabla obj in l)
            {
                Modelo.Insert_TablaCapa(ID_Capa, obj.ID_Tabla,0,0,true);
            }
        }
        private void CapaTablaInsert(Modelo.ModeloDatos modelo, int id_Capa, int id_Tabla)
        {
            if (ID_Capa != id_Capa)
                return;
            //veo si ya existe 
            foreach (CNodoBase nodo1 in Nodes)
            {
                if (nodo1.GetType() == typeof(CNodoTablaCapa))
                {
                    CNodoTablaCapa nodox = (CNodoTablaCapa)nodo1;
                    if(nodox.ID_Capa==id_Capa && nodox.ID_Tabla==id_Tabla)
                    {
                        //como ya existe, ya no lo vuelvo a agregar
                        return;
                    }
                }
            }
            CNodoTablaCapa nodo = new CNodoTablaCapa();
            nodo.ID_Tabla = id_Tabla;
            nodo.ID_Capa = ID_Capa;
            nodo.Modelo = Modelo;
            Nodes.Add(nodo);
        }
    }

}

