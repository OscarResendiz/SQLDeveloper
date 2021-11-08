using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using ICSharpCode.TextEditor.Document;
using ICSharpCode.TextEditor;
using System.Diagnostics;

namespace SQLDeveloper.Modulos.Editores
{
    public partial class CBuscador : UserControl
    {
        private ICSharpCode.TextEditor.TextEditorControl TCodigo;
        #region Variables para busqueda
        private TextEditorSearcher _search;
        public bool _lastSearchWasBackward = false;
        public bool _lastSearchLoopedAround;
        Dictionary<TextEditorControl, HighlightGroup> _highlightGroups = new Dictionary<TextEditorControl, HighlightGroup>();
        #endregion
        public CBuscador()
        {
            InitializeComponent();
            PanelRemplazar.Visible = CHRemplazar.Checked;
        }
        public ICSharpCode.TextEditor.TextEditorControl Editor
        {
            get
            {
                return TCodigo;
            }
            set
            {
                TCodigo = value;
                if (TCodigo != null)
                {
                    _search = new TextEditorSearcher();
                    _search.Document = TCodigo.Document;
                }
            }
        }
        private void CHRemplazar_CheckedChanged(object sender, EventArgs e)
        {
            PanelRemplazar.Visible = CHRemplazar.Checked;
        }


        private void BResaltar_Click(object sender, EventArgs e)
        {
            if (TBuscar.Text == "")
                return;
            if (colorDialog1.ShowDialog() != DialogResult.OK)
                return;
            CResaltar obj = new CResaltar();
            obj.Texto = TBuscar.Text;
            obj.Color = colorDialog1.Color;
            obj.Dock = DockStyle.Top;
            obj.OnActivoChange += new OnActivoChangeEvent(OnResaltarActivoChange);
            obj.OnClose += new OnCloseEvent(OnResaltarClose);
            obj.OnColorChange += new OnColorChangeEvent(OnResaltarColorChange);
            obj.BuscarAnterior += new OnCloseEvent(OnResaltarBuscarAnterior);
            obj.BuscarSiguiente += new OnCloseEvent(OnResaltarBuscarSiguiente);
            
    

            PanelResaltar.Controls.Add(obj);
            OnResaltarActivoChange(obj, obj.Color, obj.Activo);
        }


        private void SelectResult(TextRange range)
        {
            TextLocation p1 = TCodigo.Document.OffsetToPosition(range.Offset);
            TextLocation p2 = TCodigo.Document.OffsetToPosition(range.Offset + range.Length);
            TCodigo.ActiveTextAreaControl.SelectionManager.SetSelection(p1, p2);
            TCodigo.ActiveTextAreaControl.ScrollTo(p1.Line, p1.Column);
            // Also move the caret to the end of the selection, because when the user 
            // presses F3, the caret is where we start searching next time.
            TCodigo.ActiveTextAreaControl.Caret.Position =
                TCodigo.Document.OffsetToPosition(range.Offset + range.Length);
        }
        private TextRange FindNext(bool viaF3, bool searchBackward, string messageIfNotFound, string TextoBuscar, bool CaseSensitive, bool WholeWords)
        {
            if (string.IsNullOrEmpty(TextoBuscar))
            {
                return null;
            }
            if (_search == null)
                _search = new TextEditorSearcher();
            _search.Document = TCodigo.Document;
            _lastSearchWasBackward = searchBackward;
            _search.LookFor = TextoBuscar;
            _search.MatchCase = CaseSensitive;
            _search.MatchWholeWordOnly = WholeWords;

            var caret = TCodigo.ActiveTextAreaControl.Caret;
            if (viaF3 && _search.HasScanRegion && !caret.Offset.IsInRange(_search.BeginOffset, _search.EndOffset))
            {
                // user moved outside of the originally selected region
                _search.ClearScanRegion();
            }

            int startFrom = caret.Offset - (searchBackward ? 1 : 0);
            TextRange range = _search.FindNext(startFrom, searchBackward, out _lastSearchLoopedAround);
            if (range != null)
                SelectResult(range);
            else if (messageIfNotFound != null)
                MessageBox.Show(messageIfNotFound,"Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return range;
        }
        private void BAnterior_Click(object sender, EventArgs e)
        {
            FindNext(false, true, "No se encontró el elemento: "+ TBuscar.Text, TBuscar.Text, CHMayuscMinus.Checked, CHPalabraCompleta.Checked);
//            if(_lastSearchLoopedAround)
  //          {
    //            MessageBox.Show("No se encontraron mas elementos", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
      //      }
        }

        private void BSiguiente_Click(object sender, EventArgs e)
        {
            FindNext(false, false, "No se encontró el elemento: "+ TBuscar.Text, TBuscar.Text, CHMayuscMinus.Checked, CHPalabraCompleta.Checked);
//            if (_lastSearchLoopedAround)
  //          {
    //            MessageBox.Show("No se encontraron mas elementos", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
      //      }
        }

        private void InsertText(string text)
        {
            var textArea = TCodigo.ActiveTextAreaControl.TextArea;
            textArea.Document.UndoStack.StartUndoGroup();
            try
            {
                if (textArea.SelectionManager.HasSomethingSelected)
                {
                    textArea.Caret.Position = textArea.SelectionManager.SelectionCollection[0].StartPosition;
                    textArea.SelectionManager.RemoveSelectedText();
                }
                textArea.InsertString(text);
            }
            finally
            {
                textArea.Document.UndoStack.EndUndoGroup();
            }
        }
        private void RemplazarTodo(string textoBuscar, string TextoRemplazar, bool CaseSensitive, bool WholeWords)
        {
            int count = 0;
            // BUG FIX: if the replacement string contains the original search string
            // (e.g. replace "red" with "very red") we must avoid looping around and
            // replacing forever! To fix, start replacing at beginning of region (by 
            // moving the caret) and stop as soon as we loop around.
            TCodigo.ActiveTextAreaControl.Caret.Position =
                TCodigo.Document.OffsetToPosition(_search.BeginOffset);

            TCodigo.Document.UndoStack.StartUndoGroup();
            try
            {
                while (FindNext(false, false, null, textoBuscar, CaseSensitive, WholeWords) != null)
                {
                    if (_lastSearchLoopedAround)
                        break;

                    // Replace
                    count++;
                    InsertText(TextoRemplazar);
                }
            }
            finally
            {
                TCodigo.Document.UndoStack.EndUndoGroup();
            }
            if (count == 0)
                MessageBox.Show("No se encontro ninguna ocurrencia");
            else
            {
                MessageBox.Show(string.Format("Se reemplazaron {0} cadenas.", count));
            }
        }
        private void BRemplazarTodo_Click(object sender, EventArgs e)
        {
            RemplazarTodo(TBuscar.Text, TRemplazar.Text, CHMayuscMinus.Checked, CHPalabraCompleta.Checked);
        }
        private void ReemplazarSiguiente(string textoBuscar, string TextoRemplazar, bool CaseSensitive, bool WholeWords)
        {
            var sm = TCodigo.ActiveTextAreaControl.SelectionManager;
            if (string.Equals(sm.SelectedText, textoBuscar, StringComparison.OrdinalIgnoreCase))
                InsertText(TextoRemplazar);
            FindNext(false, _lastSearchWasBackward, "No se encontró el elemento", textoBuscar, CaseSensitive, WholeWords);
        }

        private void BRemplazar_Click(object sender, EventArgs e)
        {
            ReemplazarSiguiente(TBuscar.Text, TRemplazar.Text, CHMayuscMinus.Checked, CHPalabraCompleta.Checked);
        }
        private void MarcarCoincidencias(string textoBuscar, bool CaseSensitive, bool WholeWords, Color ColorAplicar)
        {
            if (!_highlightGroups.ContainsKey(TCodigo))
                _highlightGroups[TCodigo] = new HighlightGroup(TCodigo);
            HighlightGroup group = _highlightGroups[TCodigo];

            if (string.IsNullOrEmpty(textoBuscar))
            {
                // Clear highlights
                group.ClearMarkers();
            }
            else
            {
                if (_search == null)
                    _search = new TextEditorSearcher();
                _search.LookFor = textoBuscar;
                _search.MatchCase = CaseSensitive;
                _search.MatchWholeWordOnly = WholeWords;

                bool looped = false;
                int offset = 0, count = 0;
                for (;;)
                {
                    TextRange range = _search.FindNext(offset, false, out looped);
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
        private void QuitaCoincidencias(string textoBuscar, bool CaseSensitive, bool WholeWords, Color ColorAplicar)
        {
            if (!_highlightGroups.ContainsKey(TCodigo))
                _highlightGroups[TCodigo] = new HighlightGroup(TCodigo);
            HighlightGroup group = _highlightGroups[TCodigo];

            if (string.IsNullOrEmpty(textoBuscar))
            {
                // Clear highlights
                group.ClearMarkers();
            }
            else
            {
                if (_search == null)
                    _search = new TextEditorSearcher();
                _search.LookFor = textoBuscar;
                _search.MatchCase = CaseSensitive;
                _search.MatchWholeWordOnly = WholeWords;

                bool looped = false;
                int offset = 0, count = 0;
                for (;;)
                {
                    TextRange range = _search.FindNext(offset, false, out looped);
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
        private void OnResaltarActivoChange(CResaltar obj, Color color, bool status)
        {
            if (status)
            {
                MarcarCoincidencias(obj.Texto, CHMayuscMinus.Checked, CHPalabraCompleta.Checked, color);
            }
            else
            {
                QuitaCoincidencias(obj.Texto, CHMayuscMinus.Checked, CHPalabraCompleta.Checked, color);
            }
        }
        private void OnResaltarClose(CResaltar obj)
        {
            QuitaCoincidencias(obj.Texto, CHMayuscMinus.Checked, CHPalabraCompleta.Checked,obj.Color);
            PanelResaltar.Controls.Remove(obj);
        }

        private void OnResaltarColorChange(CResaltar obj, Color color)
        {
            MarcarCoincidencias(obj.Texto, CHMayuscMinus.Checked, CHPalabraCompleta.Checked, color);
        }
        private void OnResaltarBuscarAnterior(CResaltar obj)
        {
            FindNext(false, true, "No se encontró el elemento", obj.Texto, CHMayuscMinus.Checked, CHPalabraCompleta.Checked);
            if (_lastSearchLoopedAround)
            {
                MessageBox.Show("No se encontraron mas elementos", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void OnResaltarBuscarSiguiente(CResaltar obj)
        {
            FindNext(false, false, "No se encontró el elemento", obj.Texto, CHMayuscMinus.Checked, CHPalabraCompleta.Checked);
            if (_lastSearchLoopedAround)
            {
                MessageBox.Show("No se encontraron mas elementos", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
