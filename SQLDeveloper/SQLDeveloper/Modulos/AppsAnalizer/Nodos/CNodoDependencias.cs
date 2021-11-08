using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
//using Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using ICSharpCode.TextEditor.Document;
using ICSharpCode.TextEditor;
using System.Diagnostics;




namespace SQLDeveloper.Modulos.AppsAnalizer.Nodos
{
    public class CNodoDependencias : CNodoFolder
    {
        private TextEditor.CTextEdit FEditor = null;
        public TextEditor.CTextEdit Editor
        {
            get
            {
                return FEditor;
            }
            set
            {
                FEditor = value;
            }
        }
        public CNodoDependencias(int id_objeto)
        {
            ID_Objeto = id_objeto;
            Nombre = "Dependencias";
        }
        public override void ModeloAsignado()
        {
            Modelo.ObjetoObjetoDeleteEvent += new ObjetosModelo.OnAppModelEventDelegate(ObjetoObjetoDelete);
            Modelo.ObjetoObjetoInsertEvent += new ObjetosModelo.OnAppModelEventDelegate(ObjetoObjetoInsert);

            //CargaInformacion();
        }
        public override void Seleccionado()
        {
            base.Seleccionado();
            if(Nodes.Count==0)
            {
                CargaInformacion();
            }
        }
        public override void Free()
        {
            base.Free();
            Modelo.ObjetoObjetoDeleteEvent -= ObjetoObjetoDelete;
            Modelo.ObjetoObjetoInsertEvent -= ObjetoObjetoInsert;
        }
        private void CargaInformacion()
        {
            List<ObjetosModelo.CObjetoObjeto> lista = Modelo.GetObjetoObjetos(this.ID_Objeto);
            foreach(ObjetosModelo.CObjetoObjeto obj in lista)
            {
                CNodoDependencia nodo = new CNodoDependencia(obj.ID_ObjetoHijo,this.ID_Objeto);
                nodo.Modelo = this.Modelo;
                Nodes.Add(nodo);
            }
        }
        private void ObjetoObjetoDelete(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CObjetoObjeto objeto = (ObjetosModelo.CObjetoObjeto)obj;
            if (objeto.ID_ObjetoPadre != this.ID_Objeto)
                return;
            //busco el nodo
            foreach (CNodoBase nodo in Nodes)
            {
                if (nodo.GetType() == typeof(CNodoDependencia))
                {
                    if (nodo.ID_Objeto == objeto.ID_ObjetoHijo)
                    {
                        nodo.Free();
                        Nodes.Remove(nodo);
                        return;
                    }
                }
            }
        }
        public void ObjetoObjetoInsert(ObjetosModelo.CObjetoBase obj)
        {
            ObjetosModelo.CObjetoObjeto objeto = (ObjetosModelo.CObjetoObjeto)obj;
            if (objeto.ID_ObjetoPadre != this.ID_Objeto)
                return;
            foreach (CNodoBase n in Nodes)
            {
                if (n.GetType() == typeof(CNodoObjeto))
                {
                    CNodoObjeto n2 = (CNodoObjeto)n;
                    if (n2.ID_Objeto == objeto.ID_ObjetoHijo)
                        return;
                }
            }
            CNodoDependencia nodo = new CNodoDependencia(objeto.ID_ObjetoHijo, this.ID_Objeto);
            nodo.Modelo = this.Modelo;
            Nodes.Add(nodo);
        }
        public override void AgregaRegistrosReporte(System.Data.DataTable tabla, DataRow rp, int nivel)
        {
            //agrego un nubel mas a los campos
            if (Nodes.Count > 0)
            {
                foreach (CNodoBase n in Nodes)
                {
                    n.AgregaRegistrosReporte(tabla,rp, nivel);
                }

            }            
        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            this.AddMenuItem("Agregar Dependencia", "IconoAgregar", MenuAgregarObjeto);
            this.AddMenuItem("Ver conflictos", "calabera", MenuConflictos);
            this.AddMenuItem("Ver En Codigo", "buscar", MenuVerEnCodigo);
        }
        private void MenuAgregarObjeto(object sender, EventArgs e)
        {
            Formularios.FormBuscadorObjetos dlg = new Formularios.FormBuscadorObjetos(Modelo);
            dlg.ObjetoAgregadoEvent += new Formularios.FormBuscadorObjetosEvent(ObjetoAgregado);
            dlg.ShowDialog();
        }
        private void ObjetoAgregado(int id_objeto)
        {
            //veo si existe la dependencia
            if (Modelo.GetObjetoObjeto(ID_Objeto, id_objeto) == null)
            {
                //lo agrego
                Modelo.InsertObjetoObjeto(ID_Objeto, id_objeto);
            }
        }

        
        private void MenuConflictos(object sender, EventArgs e)
        {
            System.Windows.Forms.ColorDialog dlg = new System.Windows.Forms.ColorDialog();
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            int n = Nodes.Count;
            for (int i = 0; i < n; i++)
            {
                CNodoBase nodo1 = (CNodoBase)Nodes[i];
                if (nodo1.GetType() == typeof(CNodoDependencia))
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        CNodoBase nodo2 = (CNodoBase)Nodes[j];
                        if (nodo2.GetType() == typeof(CNodoDependencia))
                        {
                            ObjetosModelo.CObjeto obj1, obj2;
                            obj1 = Modelo.GetObjeto(nodo1.ID_Objeto);
                            obj2 = Modelo.GetObjeto(nodo2.ID_Objeto);
                            if (obj1.Nombre.ToUpper().Trim() == obj2.Nombre.ToUpper().Trim())
                            {
                                nodo1.BackColor = dlg.Color;
                                nodo2.BackColor = dlg.Color;
                            }
                        }
                    }
                }
            }
        }
        private void MenuVerEnCodigo(object sender, EventArgs e )
        {
            //me traigo el codigo de la base de datos
            CNodoObjeto padre=(CNodoObjeto)this.Parent;
            string codigo=padre.DameCodigo();
            ObjetosModelo.CObjeto obj = Modelo.GetObjeto(this.ID_Objeto);
            //mando a mostrar el codigo

                        //muestro el resultado
            if (Editor == null || Editor.Parent.Parent==null)
            {
                //me traigo el motor
                MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(padre.Conexion);
                //me traigo el acceso al formulario
                Formularios.FormAppsAnalizer dlg = (Formularios.FormAppsAnalizer)TreeView.Tag;
                //mando a mostrar el codigo
                Editor = (TextEditor.CTextEdit)dlg.VerCodigo(obj.Nombre, codigo, motor, padre.NombreServidor, padre.Conexion.Nombre);
            }
            else
            {
                Editor.CodigoFuente = codigo;
                System.Windows.Forms.TabControl tab = (System.Windows.Forms.TabControl)Editor.Parent.Parent;
                tab.SelectedTab = (System.Windows.Forms.TabPage)Editor.Parent;
            }
            List<ObjetosModelo.CObjetoObjeto> lista = Modelo.GetObjetoObjetos(this.ID_Objeto);
            foreach(ObjetosModelo.CObjetoObjeto dependencia in lista)
            {
                ObjetosModelo.CObjeto objeto=dependencia.getObjeto();
                MarcarCoincidencias(objeto.Nombre, false, true, Color.Yellow, Editor.getTCodigo());          
            }
            MarcarCoincidencias("EXEC", false, true, Color.Red, Editor.getTCodigo());
            MarcarCoincidencias("EXECUTE", false, true, Color.Red, Editor.getTCodigo());
            MarcarCoincidencias("UPDATE", false, true, Color.Red, Editor.getTCodigo());
            MarcarCoincidencias("JOIN", false, true, Color.Red, Editor.getTCodigo());
            MarcarCoincidencias("DELETE", false, true, Color.Red, Editor.getTCodigo());
            MarcarCoincidencias("FROM", false, true, Color.Red, Editor.getTCodigo());
            MarcarCoincidencias("INSERT", false, true, Color.Red, Editor.getTCodigo());
        }
        #region Resaltado de texto
        Dictionary<TextEditorControl, TextEditor.HighlightGroup> _highlightGroups = new Dictionary<TextEditorControl, TextEditor.HighlightGroup>();
        private Modulos.Editores.TextEditorSearcher _search;

        private void MarcarCoincidencias(string textoBuscar, bool CaseSensitive, bool WholeWords, Color ColorAplicar, ICSharpCode.TextEditor.TextEditorControl TCodigo)
        {
            if (!_highlightGroups.ContainsKey(TCodigo))
                _highlightGroups[TCodigo] = new TextEditor.HighlightGroup(TCodigo);
            TextEditor.HighlightGroup group = _highlightGroups[TCodigo];

            if (string.IsNullOrEmpty(textoBuscar))
            {
                // Clear highlights
                group.ClearMarkers();
            }
            else
            {
                if (_search == null)
                {
                    _search = new Modulos.Editores.TextEditorSearcher();
                    _search.Document = TCodigo.Document;
                }
                _search.LookFor = textoBuscar;
                _search.MatchCase = CaseSensitive;
                _search.MatchWholeWordOnly = WholeWords;

                bool looped = false;
                int offset = 0, count = 0;
                for (; ; )
                {
                    Modulos.Editores.TextRange range = _search.FindNext(offset, false, out looped);
                    if (range == null || looped)
                        break;
                    offset = range.Offset + range.Length;
                    count++;

                    var m = new TextMarker(range.Offset, range.Length,
                            TextMarkerType.SolidBlock, ColorAplicar, Color.Black);
                    group.AddMarker(m);
                }
                //                if (count == 0)
                //                  MessageBox.Show("Cadena buscada no encontrada.");
            }
            TCodigo.Refresh();
        }
        private void QuitaCoincidencias(string textoBuscar, bool CaseSensitive, bool WholeWords, Color ColorAplicar, ICSharpCode.TextEditor.TextEditorControl TCodigo)
        {
            if (!_highlightGroups.ContainsKey(TCodigo))
                _highlightGroups[TCodigo] = new TextEditor.HighlightGroup(TCodigo);
            TextEditor.HighlightGroup group = _highlightGroups[TCodigo];

            if (string.IsNullOrEmpty(textoBuscar))
            {
                // Clear highlights
                group.ClearMarkers();
            }
            else
            {
                if (_search == null)
                   _search = new Modulos.Editores.TextEditorSearcher();
                _search.LookFor = textoBuscar;
                _search.MatchCase = CaseSensitive;
               _search.MatchWholeWordOnly = WholeWords;

                bool looped = false;
                int offset = 0, count = 0;
                for (; ; )
                {
                    Modulos.Editores.TextRange range = _search.FindNext(offset, false, out looped);
                    if (range == null || looped)
                        break;
                    offset = range.Offset + range.Length;
                    count++;

                    var m = new TextMarker(range.Offset, range.Length,
                            TextMarkerType.SolidBlock, ColorAplicar, Color.Black);
                    group.RemoveMarker(m);
                }
            }
            TCodigo.Refresh();
        }
        #endregion
    }
}
   