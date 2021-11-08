using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SQLDeveloper.Modulos.CSharpLibaryGenerator
{
    public class CNodoClases : CNodoFolder
    {
        private System.Windows.Forms.ContextMenuStrip MenuPrinciapl;
        private System.Windows.Forms.ToolStripMenuItem MenuAgregar;
        public CNodoClases()
        {
            Nombre = "Clases";
        }
        public override void ModeloAsignado()
        {
            Modelo.OnClassChange += new OnModeloNetEvent(ClassChange);
        }
        private void ClassChange(ModeloNet sender)
        {
            CargaModelo();
        }
        public override void CargaModelo()
        {
            List<CDataClass> l = Modelo.DameClases();
            //quito los que ya no estan
            for (int i = Nodes.Count - 1; i >= 0; i--)
            {
                CNodoClase nodo = (CNodoClase)Nodes[i];
                bool encontrado = false;
                foreach (CDataClass obj in l)
                {
                    if (nodo.ID_Class == obj.ID_Class)
                    {
                        nodo.Nombre = obj.Nombre;
                        encontrado = true;
                        break;
                    }
                }
                if (encontrado == false)
                {
                    Nodes.Remove(nodo);
                }
            }
            //ahora agrego los nuevos
            foreach (CDataClass obj in l)
            {
                bool encontrado = false;
                foreach (CNodoClase nodo in Nodes)
                {
                    if (nodo.ID_Class == obj.ID_Class)
                    {
                        encontrado = true;
                    }
                }
                if (encontrado == false)
                {
                    CNodoClase Nnodo = new CNodoClase();
                    Nnodo.ID_Class = obj.ID_Class;
                    Nnodo.Nombre = obj.Nombre;
                    Nnodo.Modelo = Modelo;
                    Nodes.Add(Nnodo);
                }
            }

        }
        protected override System.Windows.Forms.ContextMenuStrip CreaMenu()
        {
            this.MenuPrinciapl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuAgregar = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // MenuTabla
            // 
            this.MenuPrinciapl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAgregar,
            });
            this.MenuPrinciapl.Name = "MenuPrinciapl";
            this.MenuPrinciapl.Size = new System.Drawing.Size(202, 70);
            // 
            // MenuPrimaryKey
            // 
            this.MenuAgregar.Image = ((System.Drawing.Image)(resources.GetObject("IconoAgregar")));
            this.MenuAgregar.Name = "MenuAgregar";
            this.MenuAgregar.Size = new System.Drawing.Size(201, 22);
            this.MenuAgregar.Text = "Agregar Clase LINQ";
            this.MenuAgregar.Click += new System.EventHandler(this.MenuAgregar_Click);
            return MenuPrinciapl;
        }
        private void MenuAgregar_Click(object sender, EventArgs e)
        {
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.OnNombre += new Forms.ONFormNombreEvent(NuevaClase);
            dlg.ShowDialog();
        }
        private bool NuevaClase(Forms.FormNombre sender, string nombre)
        {
            try
            {
                Modelo.AgregaClase(nombre);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
