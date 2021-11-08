using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public delegate void ONGestorDesaserEvent(bool valor);
    public partial class CGestorDesaser : Component
    {
        public event System.Windows.Forms.KeyEventHandler OnKeyUp;
        public event  ONGestorDesaserEvent OnDesaserChange;
        public event ONGestorDesaserEvent OnReHacerChange;
        public event ONGestorDesaserEvent OnTextChange;
        private string Ultimotexto;
        private ICSharpCode.TextEditor.TextEditorControl fEditor;
        public CGestorDesaser()
        {
            InitializeComponent();
        }

        public CGestorDesaser(IContainer container)
        {
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
                if (OnDesaserChange != null)
                    OnDesaserChange(false);
                fEditor.TextChanged += new EventHandler(TextChanged);
                fEditor.ActiveTextAreaControl.TextArea.KeyUp += new System.Windows.Forms.KeyEventHandler(Editor_KeyUp);
            }
        }
        public  bool PuedoDesaser
        {
            get
            {
                if (fEditor == null)
                    return false;
                return fEditor.Document.UndoStack.CanUndo;
            }
        }
        private void TextChanged(object sender, EventArgs e)
        {
            string texto = fEditor.Text;
            if (Ultimotexto != texto)
            {
                //cambio el texto, por lo que lo almaceno
                if (OnTextChange != null)
                    OnTextChange(true);
                if (OnReHacerChange != null)
                    OnReHacerChange(PuedoRehacer);
                if (OnDesaserChange != null)
                    OnDesaserChange(PuedoDesaser);
            }
        }
        public void Desaser()
        {
            fEditor.Document.UndoStack.Undo();
        }
        public bool PuedoRehacer
        {
            get
            {
                if (fEditor == null)
                    return false;
                return fEditor.Document.UndoStack.CanRedo;
            }
        }
        public void ReHacer()
        {
            fEditor.Document.UndoStack.Redo();
        }
        private void Editor_KeyUp(object sender, KeyEventArgs e)
        {
            //solo voy a poecesar las combinaciones de teclas de CTR+SIFT+Z para rehacer
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
}
