using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelador.UI
{
    public partial class ControladorCapas : UserControl
    {
        private Modelo.ModeloDatos FModelo;
        public Modelo.ModeloDatos Modelo

        {
            get
            {
                return FModelo;
            }
            set
            {
                FModelo = value;
                if(FModelo!=null)
                {
                    FModelo.OnCapaDelete += new Modelo.DelegateModeloDatosEvent(CapaDelete);
                    FModelo.OnCapaInsert += new Modelo.DelegateModeloDatosEvent(CapaInsert);
                    FModelo.OnAbrir += new Modelo.DelegateModeloEvent(Abrir);
                    FModelo.OnNuevo += new Modelo.DelegateModeloEvent(Nuevo);
                    CargaCapas();
                }
            }
        }
        public ControladorCapas()
        {
            InitializeComponent();
        }
        private void CapaDelete(Modelo.ModeloDatos modelo,int id_capa)
        {
            foreach(Component obj in PanelContenedor.Controls)
            {
                if(obj.GetType()== typeof(ControlCapa))
                {
                    ControlCapa capa = (ControlCapa)obj;
                    if(capa.ID_Capa==id_capa)
                    {
                        PanelContenedor.Controls.Remove(capa);
                        return;
                    }
                }
            }
        }
        private void CapaInsert(Modelo.ModeloDatos modelo, int id_capa)
        {
            Modelo.CCapa capa = Modelo.Get_Capa(id_capa);
            ControlCapa Capa = new ControlCapa();
            Capa.ID_Capa = capa.ID_Capa;
            Capa.Modelo = Modelo;
            Capa.Dock = DockStyle.Top;
            PanelContenedor.Controls.Add(Capa);
        }
        private void Abrir(Modelo.ModeloDatos modelo)
        {
            if (Modelo != modelo)
                Modelo = modelo;
            PanelContenedor.Controls.Clear();
            CargaCapas();
        }
        private void Nuevo(Modelo.ModeloDatos modelo)
        {
            PanelContenedor.Controls.Clear();
            CargaCapas();
        }
        private void CargaCapas()
        {
            List<Modelo.CCapa> l = Modelo.Get_Capas();
            foreach(Modelo.CCapa capa in l)
            {
                ControlCapa Capa = new ControlCapa();
                Capa.ID_Capa = capa.ID_Capa;
                Capa.Modelo = Modelo;
                Capa.Dock = DockStyle.Top;
                PanelContenedor.Controls.Add(Capa);
            }
        }

        private void BAgregar_Click(object sender, EventArgs e)
        {
            UI.FormPropiedadesCapa dlg = new UI.FormPropiedadesCapa();
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            Modelo.Insert_Capa(dlg.NombreCapa, dlg.CapaVisible);
        }
    }
}
