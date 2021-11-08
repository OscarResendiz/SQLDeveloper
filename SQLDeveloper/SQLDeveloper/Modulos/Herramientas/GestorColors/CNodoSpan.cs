using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SintaxColor;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.Herramientas.GestorColors
{
    public delegate void CNodoSpanEvent(CNodoSpan sender, CSpan span);
    public class CNodoSpan:CNodoBase
    {
        public event CNodoSpanEvent OnDelete;
        private System.Windows.Forms.ContextMenuStrip MenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem MenuEliminar;
        private CSpan Span;
        public CNodoSpan()
        {
            Visor = new SpanControl();
            ContextMenuStrip = CreaMenu();
        }
        public override void Recarga()
        {
            if(Objeto==null)
                return;
            Span=(CSpan)Objeto;
            Span.OnSpanNameChange += new OnSpanNameChangeEvent(SpanNameChange);
            Text = Span.name;
            Visor.Objeto = Span;
        }
        public void SpanNameChange(CSpan sender, string nombre)
        {
            Text = Span.name;
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
            if(OnDelete!=null)
            {
                if (MessageBox.Show("¿Eliminar el sapn?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                OnDelete(this, (CSpan)this.Objeto);
            }
            
        }
    }
}
