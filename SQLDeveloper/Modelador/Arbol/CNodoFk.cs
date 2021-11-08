using Modelador.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelador.Arbol
{
    public class CNodoFk: CNodoBase
    {
        public int ID_FK
        {
            get;
            set;
        }
        public CNodoFk()
        {
            Nombre = "Fk";
        }
        public CLlaveForanea getFk()
        {
            return Modelo.Get_LlaveForanea(ID_FK);                
        }
        public override void ModeloAsignado()
        {
            base.ModeloAsignado();
            Nombre = getFk().Nombre;
            Modelo.OnLlaveForaneaDelete += new DelegateModeloDatosEvent(LlaveForaneaDelete);
            Modelo.OnLlaveForaneaUpdate += new DelegateModeloDatosEvent(LlaveForaneaUpdate);
        }
        public override void Free()
        {
            base.Free();
            Modelo.OnLlaveForaneaDelete -= LlaveForaneaDelete;
            Modelo.OnLlaveForaneaUpdate -= LlaveForaneaUpdate;
        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            AddMenuItem("Editar", "IconoEditar", MenuEditar_Click);
            AddMenuItem("Eliminar", "Eliminar", MenuEliminar_Click);
        }

        private void LlaveForaneaDelete(ModeloDatos modelo, int Id_Fk)
        {
            if (ID_FK == Id_Fk)
            {
                Free();
                Remove();
            }
        }
        private void LlaveForaneaUpdate(ModeloDatos modelo, int Id_Fk)
        {
            if (ID_FK == Id_Fk)
            {
                Modelo.CLlaveForanea llave = getFk();
                Nombre = llave.Nombre;
                CNodoFks fks = (CNodoFks)this.Parent;
                Modelo.CTabla tabla = fks.GetTabla();
                if (tabla.Nombre != llave.Get_TablaHija().Nombre)// && tabla.Nombre!=llave.Get_TablaPadre().Nombre)
                {
                    Remove();
                }
            }
            else
            {
                //posiblemente cambio de tabla y si es mia tengo que agregarme
                if (this.Parent == null)
                    return;
                Modelo.CLlaveForanea llave = getFk();
                CNodoFks fks = (CNodoFks)this.Parent;
                Modelo.CTabla tabla = fks.GetTabla();
                if (tabla.Nombre != llave.Get_TablaHija().Nombre)// && tabla.Nombre != llave.Get_TablaPadre().Nombre)
                    return;
                //veo si la tabla ya tiene la llave
                foreach (CNodoFk nodox in fks.Nodes)
                {
                    if (nodox.ID_FK == ID_FK)
                        return;
                }

                CNodoFk nodo = new CNodoFk();
                nodo.ID_FK = llave.ID_FK;
                nodo.Modelo = Modelo;
                fks.Nodes.Add(nodo);

            }
        }
        private void MenuEliminar_Click(object sender, EventArgs arg)
        {
            try
            {
                if (MessageBox.Show("Eliminar la Relacion " + Nombre, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                getFk().Delete();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void MenuEditar_Click(object sender, EventArgs arg)
        {
            try
            {
                CLlaveForanea fk = getFk();
                UI.FormPropiedadesFK dlg = new UI.FormPropiedadesFK();
                dlg.ID_TablaHija = fk.ID_TablaHija;
                dlg.Modelo = Modelo;
                dlg.TablaPadre = fk.Get_TablaPadre();
                dlg.SetCamposReferencia(fk.Get_Campos());
                dlg.Nombre = fk.Nombre;
                dlg.AcctionUpdate = fk.AcctionUpdate;
                dlg.AcctionDelete = fk.AcctionDelete;
                dlg.LineColor = fk.LineColor;
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                Modelo.CTabla tablaPadre = dlg.TablaPadre;
                List<UI.CCampoProFk> l = dlg.Get_Campos();
                if(fk.Nombre!=dlg.Nombre || fk.AcctionDelete!=dlg.AcctionDelete || fk.AcctionUpdate!=dlg.AcctionUpdate|| fk.LineColor != dlg.LineColor)
                {
                    fk.Nombre = dlg.Nombre;
                    fk.AcctionUpdate =dlg.AcctionUpdate;
                    fk.AcctionDelete = dlg.AcctionDelete;
                    fk.LineColor= dlg.LineColor;
                    fk.Update();
                }
                if(fk.Get_TablaPadre().ID_Tabla!=tablaPadre.ID_Tabla)
                {
                    //cambiaron de tabla
                    //hay que eliminar todos los campos
                    foreach(CCampoReferencia campo in fk.Get_Campos())
                    {
                        campo.Delete();
                    }
                    //actualizo la relacion
                    fk.ID_TablaPadre = tablaPadre.ID_Tabla;
                    fk.Update();
                    //inserto los nuevos campos
                    foreach (UI.CCampoProFk obj in l)
                    {
                        Modelo.Insert_CampoReferencia(ID_FK, obj.ID_CampoPadre, obj.ID_CampoHijo);
                    }
                    return;
                }
                //quito los campos que se modificaron
                foreach (CCampoReferencia campo in fk.Get_Campos())
                {
                    bool encontrado = false;
                    foreach (UI.CCampoProFk obj in l)
                    {
                        if(obj.ID_CampoHijo==campo.ID_CampoHijo && obj.ID_CampoPadre==campo.ID_CampoPadre)
                        {
                            encontrado = true;
                            break;
                        }
                    }
                    if(encontrado==false)
                    {
                        campo.Delete();
                    }
                }
                //agrego los que faltan
                foreach (UI.CCampoProFk obj in l)
                {
                    bool encontrado = false;
                    foreach (CCampoReferencia campo in fk.Get_Campos())
                    {
                        if (obj.ID_CampoHijo == campo.ID_CampoHijo && obj.ID_CampoPadre == campo.ID_CampoPadre)
                        {
                            encontrado = true;
                            break;
                        }
                    }
                    if (encontrado == false)
                    {
                        Modelo.Insert_CampoReferencia(ID_FK, obj.ID_CampoPadre, obj.ID_CampoHijo);
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
