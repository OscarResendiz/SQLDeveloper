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
    public class CNodoTipoDato: CNodoBase
    {
        public int ID_TipoDato
        {
            get;
            set;
        }
        public CNodoTipoDato()
        {
            Nombre = "Tipo dato";
        }
        public CTipoDato GetTipoDato()
        {
            return Modelo.Get_TipoDato(ID_TipoDato);
        }
        public override void ModeloAsignado()
        {
            base.ModeloAsignado();
            Nombre = GetTipoDato().Nombre;
            Modelo.OnTipoDatoDelete += new DelegateModeloDatosEvent(TipoDatoDelete);
            Modelo.OnTipoDatoUpdate += new DelegateModeloDatosEvent(TipoDatoUpdate);
        }
        private void TipoDatoDelete(Modelo.ModeloDatos modelo, int id_TipoDto)
        {
            if(id_TipoDto==ID_TipoDato)
            {
                Remove();
            }
        }
        private void TipoDatoUpdate(Modelo.ModeloDatos modelo, int id_TipoDto)
        {
            if (id_TipoDto == ID_TipoDato)
            {
                Nombre = GetTipoDato().Nombre;
            }

        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            AddMenuItem("Editar", "IconoEditar", MenuEditar_Click);
            AddMenuItem("Eliminar", "Eliminar", MenuEliminar_Click);
        }
        private void MenuEditar_Click(object sender, EventArgs arg)
        {
            try
            {
                CTipoDato obj = GetTipoDato();
                FormTipoDato dlg = new FormTipoDato();
                dlg.Nombre = obj.Nombre;
                dlg.TipoLongitud = obj.TipoLongitud;
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                obj.Nombre = dlg.Nombre;
                obj.TipoLongitud = dlg.TipoLongitud;
                obj.Update();
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void MenuEliminar_Click(object sender, EventArgs arg)
        {
            try
            {
                if (MessageBox.Show("Eliminar el tipo de dato: " + Nombre, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                GetTipoDato().Delete();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
