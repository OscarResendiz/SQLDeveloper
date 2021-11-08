using Modelador.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Modelador.Arbol
{
    public class CNodoCampo: CNodoBase
    {
        public int ID_Campo
        {
            get;
            set;
        }
        public CCampo GetCampo()
        {
            return Modelo.Get_Campo(ID_Campo);
        }
        public CNodoCampo()
        {
            ImageIndex = 28;
            SelectedImageIndex = 28;
            Nombre = "Campo";
        }
        public override void ModeloAsignado()
        {
            base.ModeloAsignado();
            CCampo campo = GetCampo();
            Nombre = campo.NombreX;
            ToolTipText = campo.Comentarios;
            if(campo.PK)
            {
                ImageIndex = 15;
                SelectedImageIndex = 15;
            }
            Modelo.OnCampoUpdate += new DelegateModeloDatosEvent(CampoUpdate);
            Modelo.OnCampoDelete += new DelegateModeloDatosEvent(CampoDelete);
        }
        private void CampoUpdate(ModeloDatos modelo, int id_campo)
        {
            if (ID_Campo == id_campo)
            {
                CCampo campo = GetCampo();
                Nombre = campo.NombreX;
                ToolTipText = campo.Comentarios;
                if (campo.PK)
                {
                    ImageIndex = 15;
                    SelectedImageIndex = 15;
                }
            }
        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            AddMenuItem("Editar", "IconoEditar", MenuEditar_Click);
            AddMenuItem("Eliminar", "Eliminar", MenuEliminar_Click);
        }
        private void MenuEditar_Click(object sender, EventArgs e)
        {
            try
            {
                CCampo campo = GetCampo();
                UI.FormPropiedadesCampo dlg = new UI.FormPropiedadesCampo(Modelo);
                dlg.NombreX = campo.NombreX;
                dlg.Comentarios = campo.Comentarios;
                dlg.ID_TipoDato = campo.ID_TipoDato;
                dlg.Longitud = campo.Longitud;
                dlg.PK = campo.PK;
                dlg.AceptaNulos = campo.AceptaNulos;
                dlg.CampoCalculado = campo.Calculado;
                dlg.Formula = campo.Formula;
                dlg.EsDefault = campo.EsDefault;
                dlg.DefaultName = campo.DefaultName;
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                campo.NombreX = dlg.NombreX;
                campo.Comentarios = dlg.Comentarios;
                campo.ID_TipoDato = dlg.ID_TipoDato;
                campo.Longitud = dlg.Longitud;
                campo.PK = dlg.PK;
                campo.AceptaNulos = dlg.AceptaNulos;
                campo.Calculado = dlg.CampoCalculado;
                campo.Formula = dlg.Formula;
                campo.EsDefault = dlg.EsDefault;
                campo.DefaultName = dlg.DefaultName;
                campo.Update();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Eliminar el campo " + Nombre, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                GetCampo().Delete();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CampoDelete(ModeloDatos modelo, int id_Campo)
        {
            if(ID_Campo==id_Campo)
            {
                Remove();
            }
        }
    }
}
