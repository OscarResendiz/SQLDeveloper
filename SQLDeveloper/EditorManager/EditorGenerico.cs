using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorManager
{
    public delegate void OnShowEditorGenericoEvent(EditorGenerico editor,string text);
   public partial class EditorGenerico : UserControl
    {
        public bool Comparable
        {
            get;
            set;
        }
        public EditorGenerico()
        {
            InitializeComponent();
        }
        public virtual void Guardar()
        {
        }
        #region Opciones de Edicion
        public virtual void EdicionCopiar()
        {
        }
        public virtual void EdicionPegar()
        {
        }
        public virtual void EdicionCortar()
        {
        }
        #endregion
        #region Deshacer y rehacer
        public virtual void EdicionDeshacer()
        {
        }
        public virtual void EdicionReHacer()
        {
        }
        #endregion
        public virtual void Ejecutar()
        {
        }
        public virtual void Comentar()
        {
        }
        public virtual void DesComentar()
        {
        }
        public virtual void ReemplazarSiguiente(string textoBuscar, string TextoRemplazar, bool CaseSensitive, bool WholeWords)
        {
        }
        public virtual void RemplazarTodo(string textoBuscar, string TextoRemplazar, bool CaseSensitive, bool WholeWords)
        {
        }
        public virtual void MarcarCoincidencias(string textoBuscar, bool CaseSensitive, bool WholeWords, Color ColorAplicar)
        {
        }
        public virtual void VistaPrevia()
        {
        }
        public virtual void ConfigurarPagina()
        {
        }
        public virtual void Imprimir()
        {
        }
        public virtual void SetFocus()
        {
        }
        protected string Titulo
        {
            get
            {
                TabPage P = (TabPage)Parent;
                return P.Text;
                
            }
            set
            {
                TabPage P = (TabPage)Parent;
                P.Text = value;
            }
        }
        protected bool TabVisible
        {
            get
            {
                //regresa true si el tab al que pertenesco esta visible
                TabPage P = (TabPage)Parent;
                TabControl control = (TabControl)P.Parent;
                if (control == null)
                    return false;
                if(control.SelectedTab==P)
                {
                    return true;
                }
                return false;
            }  
        }
        protected virtual bool GetGuardado()
        {
            return FGuardado;
        }
        protected bool FGuardado=true;
        public bool Guardado
        {
            get
            {
                return GetGuardado();
            }
        }
        public string PageText
        {
            get
            {

                if (Parent != null)
                {
                    if (Parent.GetType() == typeof(TabPage))
                    {
                        TabPage p = (TabPage)Parent;
                        return p.Text;
                    }
                }
                return "";
            }
            set
            {
                if (Parent != null)
                {
                    if (Parent.GetType() == typeof(TabPage))
                    {
                        TabPage p = (TabPage)Parent;
                        p.Text = value;
                    }
                }
            }
        }
    }
}
