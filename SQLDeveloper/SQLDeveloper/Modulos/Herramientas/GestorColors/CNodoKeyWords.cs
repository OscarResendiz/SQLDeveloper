using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SintaxColor;
using System.Windows.Forms;
namespace SQLDeveloper.Modulos.Herramientas.GestorColors
{
    public delegate void CNodoKeyWordsEvent(CNodoKeyWords sender, CKeyWords keyWords);
    public class CNodoKeyWords:CNodoBase
    {
        public event CNodoKeyWordsEvent OnDelete;
        private System.Windows.Forms.ContextMenuStrip MenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem MenuEliminar;
        private CKeyWords KeyWords;
        public CNodoKeyWords()
        {
            Visor = new KeyWordControl();
            ContextMenuStrip = CreaMenu();
        }
        public override void Recarga()
        {
            if (Objeto == null)
                return;
            KeyWords = (CKeyWords)Objeto;
            KeyWords.OnKeyWordsNameChange += new OnKeyWordsNameChangeEvent(KeyWordsNameChange);
            Text = KeyWords.name;
            Visor.Objeto = KeyWords;            
        }
        public void KeyWordsNameChange(CKeyWords sender, string nombre)
        {
            Text = KeyWords.name;
        }
        protected override System.Windows.Forms.ContextMenuStrip CreaMenu()
        {
            MenuPrincipal = new ContextMenuStrip();
            MenuEliminar = new ToolStripMenuItem();
            //confiburo los menus
            this.MenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEliminar});
            this.MenuPrincipal.Name = "MenuFks";
            this.MenuPrincipal.Size = new System.Drawing.Size(202, 70);
            // 
            // MenuAgregar
            // 
            this.MenuEliminar.Image = ((System.Drawing.Image)(resources.GetObject("IconoEliminar")));
            this.MenuEliminar.Name = "MenuEliminar";
            this.MenuEliminar.Size = new System.Drawing.Size(201, 22);
            this.MenuEliminar.Text = "Eliminar";
            this.MenuEliminar.Click += new System.EventHandler(this.MenuEliminar_Click);

            return MenuPrincipal;
        }
        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            if (OnDelete != null)
            {
                if (MessageBox.Show("¿Eliminar el Grupo?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                OnDelete(this, (CKeyWords)this.Objeto);
            }

        }
    }
}
