using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SQLDeveloper.Modulos.AppsAnalizer.Nodos
{
    class CNodoProyecto : CNodoFolder
    {
        Nodos.CNodoArchivos nodoArchivos;
        Nodos.CNodoObjetosDB objetosDB;
        public CNodoProyecto()
        {
            Nombre = "Proyecto";
        }
        public override void ModeloAsignado()
        {
            nodoArchivos = new Nodos.CNodoArchivos();
            nodoArchivos.Modelo = Modelo;
            Nodes.Add(nodoArchivos);
            objetosDB = new Nodos.CNodoObjetosDB();
            objetosDB.Modelo = Modelo;
            Nodes.Add(objetosDB);
            Modelo.NuevoModeloEvent += new ObjetosModelo.OnModeloEventDelegate(NuevoModelo);
            Modelo.AbrirModeloEvent += new ObjetosModelo.OnModeloEventDelegate(AbrirModelo);
        }
        public override void Free()
        {
            base.Free();
            Modelo.NuevoModeloEvent -= NuevoModelo;
            Modelo.AbrirModeloEvent -= AbrirModelo;
        }
        private void NuevoModelo(ObjetosModelo.AppModel obj)
        {
            EnableMenuItem("Propiedades", true);
        }
        private void AbrirModelo(ObjetosModelo.AppModel obj)
        {
            EnableMenuItem("Propiedades", true);

        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            AddMenuItem("Nuevo", "Nuevo", MenuNuevo_Click);
            AddMenuItem("Abrir", "Abrir", MenuAbrir_Click);
            AddMenuItem("Propiedades", "propiedades", MenuPropiedades_Click);
            AddMenuItem("Cerrar", "exit32", MenuCerrar_Click);
            EnableMenuItem("Propiedades", false);
        }
        private void MenuNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                //mando a crear el archivo
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Archivo de analisis|*.anl";
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;
                Modelo.Nuevo(dlg.FileName);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MenuAbrir_Click(object sender, EventArgs e)
        {
            Formularios.FormAppsAnalizer form = (Formularios.FormAppsAnalizer)TreeView.Tag;
            try
            {
                
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Archivo de analisis|*.anl";
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;
                form.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                Modelo.Abrir(dlg.FileName);
                form.Cursor = System.Windows.Forms.Cursors.Arrow;

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                form.Cursor = System.Windows.Forms.Cursors.Arrow;
            }

        }
        private void MenuCerrar_Click(object sender, EventArgs e)
        {
            Modelo.Cerrar();
        }
        private void MenuPropiedades_Click(object sender, EventArgs e)
        {
            Formularios.FormPropiedades dlg = new Formularios.FormPropiedades(Modelo);
            dlg.ShowDialog();
        }

    }
}
   