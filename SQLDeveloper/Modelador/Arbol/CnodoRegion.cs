using Modelador.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Modelador.UI;
using System.Data.SqlClient;
using MotorDB;
using ManagerConnect;

namespace Modelador.Arbol
{
    public class CnodoRegion : CNodoFolder
    {
        public int ID_Region
        {
            get;
            set;
        }
        public CnodoRegion()
        {
            Nombre = "Region";
        }
        public CRegion GetRegion()
        {
            return Modelo.Get_Region(ID_Region);
        }
        public override void ModeloAsignado()
        {
            base.ModeloAsignado();
            Nombre = GetRegion().Nombre;
            Modelo.OnRegionDelete += new DelegateModeloDatosEvent(RegionDelete);
            Modelo.OnRegionInsert += new DelegateModeloDatosEvent(RegionInsert);
            Modelo.OnRegionUpdate += new DelegateModeloDatosEvent(RegionUpdate);
            Modelo.OnRegionTablaInsert += new DelegateModeloDatosEvent2(RegionTablaInsert);
            Modelo.OnRegionTablaDelete += new DelegateModeloDatosEvent2(RegionTablaDelete);
            Modelo.OnMoveRegionRegion += new DelegateModeloDatosEvent3(MoveRegionRegion);
            Modelo.OnMoveRegionCapa += new DelegateModeloDatosEvent3(MoveRegionCapa);
            CargaRegiones();
            Cargatablas();
        }
        private void RegionTablaDelete(ModeloDatos modelo, int id_region, int ID_Tabla)
        {
            if (this.ID_Region != id_region)
                return;
            foreach(CNodoBase nodo in Nodes)
            {
                if(nodo.GetType()==typeof(CNodoTablaCapa))
                {
                    CNodoTablaCapa nodo2 = (CNodoTablaCapa)nodo;
                    if(nodo2.ID_Tabla==ID_Tabla)
                    {
                        nodo2.Free();
                        nodo2.Remove();
                        return;
                    }
                }
            }

        }
        private void RegionTablaInsert(ModeloDatos modelo, int id_region, int ID_Tabla)
        {
            if (this.ID_Region != id_region)
                return;
            
            Modelador.Modelo.CTabla tabla = Modelo.Get_TablaCapa(GetRegion().ID_Capa,ID_Tabla);
            if(tabla==null)
            {
                //no existe la tabla, por lo que viene desde otra capa
                CNodoTablaCapa nodo = new CNodoTablaCapa();
                nodo.ID_Tabla = ID_Tabla;
                nodo.ID_Capa = GetRegion().ID_Capa;
                nodo.Modelo = Modelo;
                Nodes.Add(nodo);
                return;
            }
            CRegion reg = GetRegion();
  //          if (reg.ID_Region == this.ID_Region)
            {
                CNodoTablaCapa nodo = new CNodoTablaCapa();
                nodo.ID_Tabla = ID_Tabla;
                nodo.ID_Capa = reg.ID_Capa;
                nodo.Modelo = Modelo;
                Nodes.Add(nodo);
            }
        }
        private void RegionDelete(ModeloDatos modelo, int id_Region)
        {
            if(ID_Region== id_Region)
            {
                Free();
                Remove();
            }
        }
        public override void Free()
        {
            base.Free();
            Modelo.OnRegionDelete -= RegionDelete;
            Modelo.OnRegionInsert -= RegionInsert;
            Modelo.OnRegionUpdate -= RegionUpdate;
            Modelo.OnRegionTablaInsert -= RegionTablaInsert;
            Modelo.OnRegionTablaDelete -= RegionTablaDelete;
            Modelo.OnMoveRegionRegion -= MoveRegionRegion;
            Modelo.OnMoveRegionCapa -= MoveRegionCapa;
        }

        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            AddMenuItem("Agregar Region", "IconoAgregar", MenuAgregarRegion_Click);
            AddMenuItem("Nueva Tabla", "Table_Field_Insert", MenuNuevaTabla_Click);
            AddMenuItem("Importar Tabla", "Tabla", MenuImportarTabla_Click);
            AddMenuItem("Editar", "IconoEditar", MenuEditar_Click);
            AddMenuItem("Ocultar/Mostrar", "ojo2", MenuVisible_Click);
            AddMenuItem("Eliminar", "Eliminar", MenuEliminar_Click);
        }
        private void MenuVisible_Click(object sender, EventArgs arg)
        {
            CRegion region = GetRegion();
            region.Visible = !region.Visible;
            region.Update();
        }
        private void RegionInsert(ModeloDatos modelo, int id_Region)
        {
            CRegion region = Modelo.Get_Region(id_Region);
            if(region.ID_RegionPadre==this.ID_Region)
            {
                CnodoRegion nodo = new CnodoRegion();
                nodo.ID_Region = id_Region;
                nodo.Modelo = Modelo;
                Nodes.Add(nodo);
            }
        }
        private void RegionUpdate(ModeloDatos modelo, int id_Region)
        {
            if(this.ID_Region==id_Region)
            {
                CRegion region = Modelo.Get_Region(id_Region);
                Nombre = region.Nombre;
            }
        }
        private void MenuAgregarRegion_Click(object sender, EventArgs e)
        {
          UI.FormPropiedadesRegion dlg = new UI.FormPropiedadesRegion();
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            CRegion region = GetRegion();
            region.Insert_Region(dlg.Nombre, dlg.Bk_Color, dlg.RegionVisible, "",region.ID_Capa, dlg.Fore_Color);
        }
        private void MenuNuevaTabla_Click(object sender, EventArgs e)
        {
           UI. FormPropiedadesTabla dlg = new UI.FormPropiedadesTabla();
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            CRegion region = GetRegion();
            region.Insert_Tabla(dlg.Nombre, 0, 0, 10, 10, Color.White,  "", 0, "",region.ID_Capa, Color.Black,dlg.Comentarios);

        }
        private void MenuEditar_Click(object sender, EventArgs e)
        {
            CRegion region = GetRegion();
            UI.FormPropiedadesRegion dlg = new UI.FormPropiedadesRegion();
            dlg.Nombre = region.Nombre;
            dlg.Bk_Color = region.BkColor;
            dlg.RegionVisible = region.Visible;
            dlg.Fore_Color = region.ForeColor;
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            region.Nombre= dlg.Nombre;
            region.BkColor= dlg.Bk_Color;
            region.Visible= dlg.RegionVisible;
            region.ForeColor= dlg.Fore_Color;
            region.Update();

        }
        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            CRegion region = GetRegion();
            if (MessageBox.Show("¿Eliminar la Region"+region.Nombre+"?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                region.Delete();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void CargaRegiones()
        {
            List<CRegion> regiones = GetRegion().Get_Regiones();
            foreach(CRegion region in regiones)
            {
                CnodoRegion nodo = new CnodoRegion();
                nodo.ID_Region = region.ID_Region;
                nodo.Modelo = Modelo;
                Nodes.Add(nodo);
            }
        }
        private void Cargatablas()
        {
            List<Modelador.Modelo.CTabla> tablas = GetRegion().Get_Tablas();
            foreach(Modelador.Modelo.CTabla tabla in tablas)
            {
                CNodoTablaCapa nodo = new CNodoTablaCapa();
                nodo.ID_Capa = GetRegion().ID_Capa;
                nodo.ID_Tabla = tabla.ID_Tabla;
                nodo.Modelo = Modelo;
                Nodes.Add(nodo);
            }
        }
        public override void NodeDrop(CNodoBase nodo)
        {
            if (nodo.GetType() == typeof(CNodoTablaCapa))
            {
                CNodoTablaCapa objeto = (CNodoTablaCapa)nodo;
                if (GetRegion().ID_Capa != objeto.ID_Capa)
                    return;
                Modelador.Modelo.CTabla tabla = objeto.GetTabla();
                CRegion regionOrigen = Modelo.Get_RegionTablaCapa(objeto.ID_Capa, objeto.ID_Tabla);// tabla.Get_Region();
                if(regionOrigen!=null)
                {
                    if (regionOrigen.ID_Region == this.ID_Region)
                        return;
                    Modelo.Delete_RegionTabla(regionOrigen.ID_Region, tabla.ID_Tabla);
                }
                int id_capaDestino = GetRegion().ID_Capa;
                if (objeto.ID_Capa!= id_capaDestino)
                {
                    //se mueve de capa, por lo que lo agrego
                    //pero primero veo si ya existe
                    Modelador.Modelo.CTabla tabla2 = Modelo.Get_TablaCapa(id_capaDestino, tabla.ID_Tabla);
                    if (tabla2==null)
                    {
                        //lo agrego
                        Modelo.Insert_TablaCapa(id_capaDestino, tabla.ID_Tabla, tabla.X, tabla.Y, tabla.Visible);
                    }
                }
                Modelo.Insert_RegionTabla(ID_Region, tabla.ID_Tabla);
                return;
            }
            else if (nodo.GetType() == typeof(CnodoRegion))
            {
                CnodoRegion ndoregion = (CnodoRegion)nodo;
                CRegion region = ndoregion.GetRegion();
                Modelo.Move_RegionRegion(region.ID_Region, region.ID_RegionPadre, this.ID_Region);
            }
        }
        private void MoveRegionRegion(ModeloDatos modelo, int id_region,int id_regionOrigen,int id_regionDestino)
        {
            if(id_regionOrigen==ID_Region)
            {
                //busco la region hija dentro de mis nodos
                foreach(CNodoBase nodo in Nodes)
                {
                    if(nodo.GetType()==typeof(CnodoRegion))
                    {
                        CnodoRegion nodoRegion = (CnodoRegion)nodo;
                        if(nodoRegion.ID_Region==id_region)
                        {
                            nodoRegion.Remove();
                            return;
                        }
                    }
                }
            }
            if(id_regionDestino==ID_Region)
            {
                //hay que agregarlo
                RegionInsert(Modelo, id_region);
            }
        }
        private void MoveRegionCapa(ModeloDatos modelo, int ID_Region, int ID_CapaOrigen, int ID_CapaDestino)
        {
            //como se movio de una regio a una capa, hay que quitarlo de los hijos
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
        private void MenuImportarTabla_Click(object sender, EventArgs e)
        {
            FormSelectConecion dlg = new FormSelectConecion();
            dlg.OnConexion += new OnFormConexionInicialEvent(OnConexionEvent);
            dlg.ShowDialog();
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
                    CRegion region = GetRegion();
                    tbl = region.Insert_Tabla(tabla.Nombre, 0, 0, 10, 10, Color.White,  "", 0, "",region.ID_Capa, Color.Black,tbl.Comentarios);                     
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

    }
}