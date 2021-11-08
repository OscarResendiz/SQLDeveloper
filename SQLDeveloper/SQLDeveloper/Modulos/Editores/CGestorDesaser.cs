using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.Editores
{
    public delegate void ONGestorDesaserEvent(bool valor);
    public partial class CGestorDesaser : Component
    {
        public event System.Windows.Forms.KeyEventHandler OnKeyUp;
        public event  ONGestorDesaserEvent OnDesaserChange;
        public event ONGestorDesaserEvent OnReHacerChange;
        public event ONGestorDesaserEvent OnTextChange;
        private List<CTextoSalvado> Lista;
        private List<CTextoSalvado> ListaRehacer;
        private string Ultimotexto;
        private ICSharpCode.TextEditor.TextEditorControl fEditor;
        private bool Deshaciendo = false;
        public CGestorDesaser()
        {
            if (Lista == null)
                Lista = new List<CTextoSalvado>();
            if (ListaRehacer == null)
                ListaRehacer = new List<CTextoSalvado>();
            InitializeComponent();
        }

        public CGestorDesaser(IContainer container)
        {
            if (Lista == null)
                Lista = new List<CTextoSalvado>();
            if (ListaRehacer == null)
                ListaRehacer = new List<CTextoSalvado>();
            container.Add(this);
            InitializeComponent();
        }
        public ICSharpCode.TextEditor.TextEditorControl Editor
        {
            get
            {
                return fEditor;
            }
            set
            {
                fEditor = value;
                if (fEditor == null)
                    return;
                Lista.Clear();
                if (OnDesaserChange != null)
                    OnDesaserChange(false);
               // Inserttext(fEditor.Text);
                fEditor.TextChanged += new EventHandler(TextChanged);
                fEditor.ActiveTextAreaControl.TextArea.KeyUp += new System.Windows.Forms.KeyEventHandler(Editor_KeyUp);
            }
        }
        public  bool PuedoDesaser
        {
            get
            {
                if (Lista.Count() == 0)
                    return false;
                return true;
            }
        }

        private void Inserttext(string texto)
        {
            CTextoSalvado obj = new CTextoSalvado();
            obj.texto = texto;
            obj.X = fEditor.ActiveTextAreaControl.Caret.Column;
            obj.Y= fEditor.ActiveTextAreaControl.Caret.Line;
            Lista.Add(obj);
            if (OnDesaserChange != null)
                OnDesaserChange(true);
            Ultimotexto = texto;
        }
        private void TextChanged(object sender, EventArgs e)
        {
            if (Deshaciendo)
                return;
            string texto = fEditor.Text;
            if (Ultimotexto != texto)
            {
                //cambio el texto, por lo que lo almaceno
                if (OnTextChange != null)
                    OnTextChange(true);
                Inserttext(texto);
                if (PuedoRehacer)
                {
                    //se invalidan los ultimos cambios
                    ListaRehacer.Clear();
                    if (OnReHacerChange != null)
                        OnReHacerChange(false);
                }
            }
        }
        public void Desaser()
        {
            CTextoSalvado obj = null;
            Deshaciendo = true;
            //regresa el ultimo texto almacenado
            string original = fEditor.Text;
            do
            {
                if (PuedoDesaser)
                {
                    //me traigo el ultimo dato para tenerlo a la mano
                    obj= Lista[Lista.Count() - 1];
                    Ultimotexto = obj.texto;
                    //elimino el ultimo dato
                    Lista.RemoveAt(Lista.Count() - 1);
                    if (Lista.Count() == 0)
                    {
                        if (OnDesaserChange != null)
                            OnDesaserChange(false);
                    }
                    ListaRehacer.Add(obj);
                    if (OnReHacerChange != null)
                        OnReHacerChange(true);
                }
                else
                {
                    fEditor.Text = TextoInicial;
                    fEditor.Refresh();
                    Deshaciendo = false;
                    return;
                }
            }
            while (original == Ultimotexto);
            fEditor.Text = Ultimotexto;
            fEditor.ActiveTextAreaControl.Caret.Column = obj.X+1;
            fEditor.ActiveTextAreaControl.Caret.Line = obj.Y;
            fEditor.Refresh();
            Deshaciendo = false;
        }
        public bool PuedoRehacer
        {
            get
            {
                if (ListaRehacer == null)
                    return false;
                if (ListaRehacer.Count() == 0)
                    return false;
                return true;
            }
        }
        public void ReHacer()
        {
            //regresa el ultimo texto desecho
            if (PuedoRehacer ==false)
            {
                return;
            }
            Deshaciendo = true;
            string origina = fEditor.Text;
            CTextoSalvado obj = null;
            do
            {
                if (PuedoRehacer )
                {
                    obj = ListaRehacer[ListaRehacer.Count() - 1];
                    ListaRehacer.RemoveAt(ListaRehacer.Count() - 1);
                    if(ListaRehacer.Count()==0)
                    {
                        if (OnReHacerChange != null)
                            OnReHacerChange(false);
                    }
                    Lista.Add(obj);
                    if (OnDesaserChange != null)
                        OnDesaserChange(true);
                }
                else
                {
                    Deshaciendo = false;
                    return;
                }
            }
            while (origina == obj.texto);
            fEditor.Text = obj.texto;
            fEditor.ActiveTextAreaControl.Caret.Column = obj.X + 1;
            fEditor.ActiveTextAreaControl.Caret.Line= obj.Y;
            fEditor.Refresh();
            Deshaciendo = false;
        }
        private void Editor_KeyUp(object sender, KeyEventArgs e)
        {
            //solo voy a poecesar las combinaciones de teclas de CTR+Z para desaser
            //y CTR+SIFT+Z para rehacer
            if (e.KeyCode == Keys.Z)
            {
                //ahora verifico si tambien la tecla control esta activa
                if (e.Control)
                {
                    //solo falta ver si la tecla sift esta activa
                    if (e.Shift)
                    {
                        //es rehacer
                        ReHacer();
                        return;
                    }
                    else
                    {
                        //deshacer
                        Desaser();
                        return;
                    }
                }
            }
            if (OnKeyUp != null)
                OnKeyUp(sender, e);
        }
        public string TextoInicial
        {
            get;
            set;

        }
    }
    public class CTextoSalvado
    {
        public string texto;
        public int X;
        public int Y;
    }
}
