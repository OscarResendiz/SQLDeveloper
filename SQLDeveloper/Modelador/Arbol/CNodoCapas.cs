using Modelador.Modelo;
using Modelador.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EditorManager;

namespace Modelador.Arbol
{
    public class CNodoCapas: CNodoFolder
    {
        public CNodoCapas()
        {
            Nombre = "Capas";
        }
        public override void ModeloAsignado()
        {
            CargaCapas();
            Modelo.OnCapaInsert += new DelegateModeloDatosEvent(CapaInsert);
            Modelo.OnNuevo += new DelegateModeloEvent(ModeloNuevo);
        }
        private void CargaCapas()
        {
            List<Modelo.CCapa> capas = Modelo.Get_Capas();
            foreach (Modelo.CCapa obj in capas)
            {
                CNodoCapa nodo = new CNodoCapa();
                nodo.ID_Capa = obj.ID_Capa;
                Nodes.Add(nodo);
                nodo.Modelo = Modelo;
            }
        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            AddMenuItem("Nueva Capa", "IconoAgregar", MenuNuevaCapa_Click);
        }
        private void MenuNuevaCapa_Click(object sender, EventArgs e)
        {
            UI.FormPropiedadesCapa dlg = new UI.FormPropiedadesCapa();
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            Modelo.Insert_Capa(dlg.NombreCapa, dlg.CapaVisible);
        }
        private void CapaInsert(Modelo.ModeloDatos modelo, int ID_Capa)
        {
            CNodoCapa nodo = new CNodoCapa();
            nodo.ID_Capa = ID_Capa;
            Nodes.Add(nodo);
            nodo.Modelo = Modelo;

        }
        private void ModeloNuevo(ModeloDatos modelo)
        {
            foreach (CNodoBase nodo in Nodes)
            {
                nodo.Free();
            }
            Nodes.Clear();
        }
    }
}
