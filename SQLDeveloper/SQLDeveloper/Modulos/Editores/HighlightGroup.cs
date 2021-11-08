using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;
using ICSharpCode.TextEditor;
using System.Diagnostics;

namespace SQLDeveloper.Modulos.Editores
{
    public class HighlightGroup : IDisposable
    {
        List<TextMarker> _markers = new List<TextMarker>();
        TextEditorControl _editor;
        IDocument _document;
        public HighlightGroup(TextEditorControl editor)
        {
            _editor = editor;
            _document = editor.Document;
        }
        public void AddMarker(TextMarker marker)
        {
            List<TextMarker> l;
            List<TextMarker> l2 = new List<TextMarker>();
            l = _document.MarkerStrategy.GetMarkers(marker.Offset, marker.Length);
            foreach (TextMarker m in l)
            {
                _document.MarkerStrategy.RemoveMarker(m);
            }
            foreach (TextMarker m2 in _markers)
            {
                if (m2.Offset != marker.Offset || m2.Length != marker.Length)
                {
                    l2.Add(m2);
                }
            }
            _markers = l2;
            _markers.Add(marker);
            _document.MarkerStrategy.AddMarker(marker);

        }
        public void RemoveMarker(TextMarker marker)
        {
            List<TextMarker> l;
            List<TextMarker> l2 = new List<TextMarker>();
            l = _document.MarkerStrategy.GetMarkers(marker.Offset, marker.Length);
            foreach (TextMarker m in l)
            {
                _document.MarkerStrategy.RemoveMarker(m);
            }
            foreach (TextMarker m2 in _markers)
            {
                if (m2.Offset != marker.Offset || m2.Length != marker.Length)
                {
                    l2.Add(m2);
                }
            }
            _markers = l2;
        }
        public void ClearMarkers()
        {
            foreach (TextMarker m in _markers)
                _document.MarkerStrategy.RemoveMarker(m);
            _markers.Clear();
            try
            {
                _editor.Refresh();
            }
            catch (System.Exception)
            {
                ;
            }
        }
        public void Dispose() { ClearMarkers(); GC.SuppressFinalize(this); }
        ~HighlightGroup() { Dispose(); }

        public IList<TextMarker> Markers { get { return _markers.AsReadOnly(); } }
    }
}
