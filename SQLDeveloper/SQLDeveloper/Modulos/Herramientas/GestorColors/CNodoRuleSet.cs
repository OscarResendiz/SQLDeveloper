using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SintaxColor;
using System.Windows.Forms;
namespace SQLDeveloper.Modulos.Herramientas.GestorColors
{
    class CNodoRuleSet:CNodoBase
    {
        CRuleSet RuleSet;
        private System.Windows.Forms.ContextMenuStrip MenuKeywords;
        private System.Windows.Forms.ToolStripMenuItem MenuAgregarKw;

        private System.Windows.Forms.ContextMenuStrip MenuSpans;
        private System.Windows.Forms.ToolStripMenuItem MenuAgregarspn;
        CNodoBase KeyWords;
        CNodoBase Spans;
        public CNodoRuleSet()
        {
            Visor = new RuleSetControl();
            Text = "Reglas";
        }
        private void CargaSpans(CNodoBase Spans)
        {
            Spans.Nodes.Clear();
            foreach (CSpan obj in RuleSet.Spans)
            {
                CNodoSpan span = new CNodoSpan();
                span.Objeto = obj;
                Spans.Nodes.Add(span);
                span.Recarga();
                span.OnDelete += new CNodoSpanEvent(EliminaSpan);
            }
        }
        private void CargaKeyWords(CNodoBase KeyWords)
        {
            KeyWords.Nodes.Clear();
            foreach (CKeyWords obj in RuleSet.KeyWords)
            {
                CNodoKeyWords KeyWord = new CNodoKeyWords();
                KeyWord.Objeto = obj;
                KeyWords.Nodes.Add(KeyWord);
                KeyWord.Recarga();
                KeyWord.OnDelete += new CNodoKeyWordsEvent(EliminaKeywords);
            }
        }
        public override void Recarga()
        {
            if (Objeto == null)
                return;
            RuleSet = (CRuleSet)Objeto;
            Nodes.Clear();
            Visor.Objeto = RuleSet;
            Visor.Recarga();
            Spans = new CNodoBase();
            Spans.Text = "Spans";
            Nodes.Add(Spans);
            Spans.ContextMenuStrip = CreaMenuSpans();
            CargaSpans(Spans);
            KeyWords = new CNodoBase();
            KeyWords.Text = "KeyWords";
            Nodes.Add(KeyWords);
            KeyWords.ContextMenuStrip = CreaMenuKeyWords();
            CargaKeyWords(KeyWords);
        }
        private ContextMenuStrip CreaMenuKeyWords()
        {
            MenuKeywords = new ContextMenuStrip();
            MenuAgregarKw = new ToolStripMenuItem();
            //confiburo los menus
            this.MenuKeywords.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAgregarKw});
            this.MenuKeywords.Name = "MenuFks";
            this.MenuKeywords.Size = new System.Drawing.Size(202, 70);
            // 
            // MenuAgregar
            // 
            this.MenuAgregarKw.Image = ((System.Drawing.Image)(resources.GetObject("IconoAgregar")));
            this.MenuAgregarKw.Name = "MenuAgregarKw";
            this.MenuAgregarKw.Size = new System.Drawing.Size(201, 22);
            this.MenuAgregarKw.Text = "Agregar Grupo de palabas clave";
            this.MenuAgregarKw.Click += new System.EventHandler(this.MenuAgregarKw_Click);

            return MenuKeywords;
        }
        private ContextMenuStrip CreaMenuSpans()
        {
            MenuSpans = new ContextMenuStrip();
            MenuAgregarspn = new ToolStripMenuItem();
            //confiburo los menus
            this.MenuSpans.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAgregarspn});
            this.MenuSpans.Name = "MenuFks";
            this.MenuSpans.Size = new System.Drawing.Size(202, 70);
            // 
            // MenuAgregar
            // 
            this.MenuAgregarspn.Image = ((System.Drawing.Image)(resources.GetObject("IconoAgregar")));
            this.MenuAgregarspn.Name = "MenuAgregarspn";
            this.MenuAgregarspn.Size = new System.Drawing.Size(201, 22);
            this.MenuAgregarspn.Text = "Agregar Grupo de spans";
            this.MenuAgregarspn.Click += new System.EventHandler(this.MenuAgregarspn_Click);

            return MenuSpans;
        }
        private void MenuAgregarKw_Click(object sender, EventArgs e)
        {
            FormPalabra dlg = new FormPalabra();
            dlg.Text = "Agregar";
            dlg.Texto = "Grupo";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            CKeyWords obj = new CKeyWords();
            obj.name = dlg.Palabra;
            RuleSet.KeyWords.Add(obj);
            CargaKeyWords(KeyWords);
        }
        private void MenuAgregarspn_Click(object sender, EventArgs e)
        {
            FormPalabra dlg = new FormPalabra();
            dlg.Text = "Agregar";
            dlg.Texto = "Grupo Span";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            CSpan obj = new CSpan();
            obj.name = dlg.Palabra;
            RuleSet.Spans.Add(obj);
            CargaSpans(Spans);
        }
        private void EliminaSpan(CNodoSpan sender, CSpan span)
        {
            RuleSet.Spans.Remove(span);
            CargaSpans(Spans);
        }
        private void EliminaKeywords(CNodoKeyWords sender, CKeyWords obj)
        {
            RuleSet.KeyWords.Remove(obj);
            CargaKeyWords(KeyWords);
        }
    }
}
