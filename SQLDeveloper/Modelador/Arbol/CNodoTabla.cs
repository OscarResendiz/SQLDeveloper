using Modelador.Modelo;
using Modelador.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelador.Arbol
{
    public class CNodoTabla : CNodoBase
    {
        public int ID_Tabla
        {
            get;
            set;
        }
        public CNodoTabla()
        {
            ImageIndex = 7;
            SelectedImageIndex = 7;
            Nombre = "Tabla";
        }
        public virtual CTabla GetTabla()
        {
            return Modelo.Get_Tabla(ID_Tabla);
        }
        public override void ModeloAsignado()
        {
            base.ModeloAsignado();
            Nombre = GetTabla().Nombre;
            Modelo.OnTablaDelete += new DelegateModeloDatosEvent(TablaDelete);
            Modelo.OnTablaUpdate += new DelegateModeloDatosEvent(TablaUpdate);
            CNodoCampos nodo = new CNodoCampos();
            nodo.ID_Tabla = ID_Tabla;
            nodo.Modelo = Modelo;
            Nodes.Add(nodo);
            CNodoIndexs index = new CNodoIndexs();
            index.ID_Tabla = ID_Tabla;
            index.Modelo = Modelo;
            Nodes.Add(index);
            CNodoFks fks = new CNodoFks();
            fks.ID_Tabla = ID_Tabla;
            fks.Modelo = Modelo;
            BackColor = GetTabla().BKColor;
            ToolTipText= GetTabla().Comentarios;
            Nodes.Add(fks);
        }
        public override void Free()
        {
            base.Free();
            Modelo.OnTablaDelete -= TablaDelete;
            Modelo.OnTablaUpdate -= TablaUpdate;
        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            AddMenuItem("Editar", "IconoEditar", MenuEditar_Click);
            AddMenuItem("Resaltar", "Resaltar", MenuMarcar_Click);
            AddMenuSeparator();
            AddMenuItem("Eliminar", "Eliminar", MenuEliminar_Click);
        }
        private void MenuMarcar_Click(object sender, EventArgs e)
        {
            CTabla obj=GetTabla();
            System.Windows.Forms.ColorDialog dlg = new System.Windows.Forms.ColorDialog();
            dlg.Reset();
            dlg.FullOpen = true;
            dlg.Color = obj.BKColor;
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            obj.BKColor = dlg.Color;
            obj.Update();
        }

        private void TablaUpdate(ModeloDatos modelo, int id_Tabla)
        {
            if (ID_Tabla != id_Tabla)
                return;
            CTabla obj = GetTabla();
            if (obj == null)
                return;
            Nombre = obj.Nombre;
            BackColor = obj.BKColor;
            ToolTipText = obj.Comentarios;
        }
        private void TablaDelete(ModeloDatos modelo, int id_Tabla)
        {
            if (ID_Tabla == id_Tabla)
            {
                Free();
                Remove();
            }
        }
        private void MenuEditar_Click(object sender, EventArgs e)
        {
            try
            {
                CTabla tabla = GetTabla();
                FormPropiedadesTabla dlg = new FormPropiedadesTabla();
                dlg.Nombre = tabla.Nombre;
                dlg.Comentarios=tabla.Comentarios;
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;
                tabla.Nombre = dlg.Nombre;
                tabla.Comentarios = dlg.Comentarios;
                tabla.Update();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected virtual void MenuEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Eliminar la tabla " + Nombre, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                GetTabla().Delete();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
