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
    public class CNodoProyecto : CNodoFolder
    {
        private Lienzo FLienzo;
        public event OnShowEditorGenericoEvent VerModelo;
        public CNodoProyecto()
        {
            Nombre = "Modelo";
        }
        public override void ModeloAsignado()
        {
            Inicializa();
            Modelo.OnNuevo += new DelegateModeloEvent(ModeloNuevo);
            Modelo.OnAbrir += new DelegateModeloEvent(EventoAbrir);
        }
        private void Inicializa()
        {
            CNodoTipoDatos ntd = new CNodoTipoDatos();
            ntd.Modelo = Modelo;
            Nodes.Add(ntd);
            //agrego el nodo de tablas
            CNodoTablas nodotblas = new CNodoTablas();
            nodotblas.Modelo = Modelo;
            Nodes.Add(nodotblas);
            //agrego las capas
            CNodoCapas nodocapas = new CNodoCapas();
            nodocapas.Modelo = Modelo;
            Nodes.Add(nodocapas);

        }
        public void VerDiseñador()
        {
            MenuVerDiseñador_Click(null, null);
        }
        public override void Free()
        {
            base.Free();
        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            AddMenuItem("Nuevo", "Nuevo", MenuNuevo_Click);
            AddMenuItem("Abrir", "Abrir", MenuAbrir_Click);
            AddMenuItem("Guardar", "filesave", MenuGuardar_Click);
            AddMenuItem("Guardar Como", "filesave", MenuGuardarComo_Click);
            AddMenuSeparator();
            AddMenuItem("Ver Diseñador", "Diagrama", MenuVerDiseñador_Click);
            AddMenuSeparator();
            AddMenuItem("Cerrar", "exit32", MenuCerrar_Click);
        }
        private void MenuNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if(Modelo.Modificado)
                {
                    if(MessageBox.Show("Desea guardar los cambios","Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question )== DialogResult.Yes)
                    {
                        MenuGuardar_Click(null, null);
                    }
                }
                Free();
                //mando a crear el archivo
                Nombre = "Modelo";
                Modelo.Nuevo();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MenuAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Archivo de Modelo|*.Mdl";
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;
                MenuNuevo_Click(null, null);
                Modelo.Abrir(dlg.FileName);
                Nodes.Clear();
                Nombre = Modelo.getNombreCorto();
                Inicializa();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message+": "+ex.StackTrace, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void MenuCerrar_Click(object sender, EventArgs e)
        {
            Modelo.Cerrar();
        }
        private void MenuGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Modelo.FileName.Trim() == "")
                {
                    MenuGuardarComo_Click(null, null);
                    return;
                }
                Modelo.Guardar();
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void MenuGuardarComo_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Archivo de Modelo|*.Mdl";
            dlg.FileName = Modelo.FileName;
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            Modelo.FileName = dlg.FileName;
            Modelo.Guardar();
            Nombre = Modelo.getNombreCorto();
        }
        private void ModeloNuevo(ModeloDatos modelo)
        {
            foreach(CNodoBase nodo in Nodes)
            {
                nodo.Free();
            }
            Nodes.Clear();
            Nombre = "Modelo";
            CNodoTipoDatos ntd = new CNodoTipoDatos();
            ntd.Modelo = Modelo;
            Nodes.Add(ntd);
        }
        private void MenuVerDiseñador_Click(object sender,EventArgs arg)
        {
            if(VerModelo!=null)
            {
                if (FLienzo == null)
                {
                    FLienzo = new Lienzo();
                    FLienzo.Modelo = Modelo;
                }
                VerModelo(FLienzo, Nombre);
            }
        }
        private void EventoAbrir(ModeloDatos modelo)
        {
            Nodes.Clear();
            Nombre = Modelo.getNombreCorto();
            Inicializa();
        }
    }
}
