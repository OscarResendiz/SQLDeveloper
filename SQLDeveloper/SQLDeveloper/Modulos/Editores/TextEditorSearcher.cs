using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.TextEditor.Document;
using ICSharpCode.TextEditor;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace SQLDeveloper.Modulos.Editores
{
    /// <summary>This class finds occurrances of a search string in a text 
    /// editor's IDocument... it's like Find box without a GUI.</summary>
    public class TextEditorSearcher : IDisposable
    {
        IDocument _document;
        public IDocument Document
        {
            get
            {
                return _document;
            }
            set
            {
                if (_document != value)
                {
                    ClearScanRegion();
                    _document = value;
                }
            }
        }

        // I would have used the TextAnchor class to represent the beginning and 
        // end of the region to scan while automatically adjusting to changes in 
        // the document--but for some reason it is sealed and its constructor is 
        // internal. Instead I use a TextMarker, which is perhaps even better as 
        // it gives me the opportunity to highlight the region. Note that all the 
        // markers and coloring information is associated with the text document, 
        // not the editor control, so TextEditorSearcher doesn't need a reference 
        // to the TextEditorControl. After adding the marker to the document, we
        // must remember to remove it when it is no longer needed.
        TextMarker _region = null;
        /// <summary>Sets the region to search. The region is updated 
        /// automatically as the document changes.</summary>
        public void SetScanRegion(ISelection sel)
        {
            SetScanRegion(sel.Offset, sel.Length);
        }
        /// <summary>Sets the region to search. The region is updated 
        /// automatically as the document changes.</summary>
        public void SetScanRegion(int offset, int length)
        {
            var bkgColor = _document.HighlightingStrategy.GetColorFor("Default").BackgroundColor;
            _region = new TextMarker(offset, length, TextMarkerType.SolidBlock,
                bkgColor.HalfMix(Color.FromArgb(160, 160, 160)));
            _document.MarkerStrategy.AddMarker(_region);
        }
        public bool HasScanRegion
        {
            get { return _region != null; }
        }
        public void ClearScanRegion()
        {
            if (_region != null)
            {
                _document.MarkerStrategy.RemoveMarker(_region);
                _region = null;
            }
        }
        public void Dispose() { ClearScanRegion(); GC.SuppressFinalize(this); }
        ~TextEditorSearcher() { Dispose(); }
        /// <summary>Begins the start offset for searching</summary>
        public int BeginOffset
        {
            get
            {
                if (_region != null)
                    return _region.Offset;
                else
                    return 0;
            }
        }
        /// <summary>Begins the end offset for searching</summary>
        public int EndOffset
        {
            get
            {
                if (_region != null)
                    return _region.EndOffset;
                else
                    return _document.TextLength;
            }
        }
        public bool MatchCase;
        public bool MatchWholeWordOnly;
        string _lookFor;
        string _lookFor2; // uppercase in case-insensitive mode
        public string LookFor
        {
            get { return _lookFor; }
            set { _lookFor = value; }
        }
        /// <summary>Finds next instance of LookFor, according to the search rules 
        /// (MatchCase, MatchWholeWordOnly).</summary>
        /// <param name="beginAtOffset">Offset in Document at which to begin the search</param>
        /// <remarks>If there is a match at beginAtOffset precisely, it will be returned.</remarks>
        /// <returns>Region of document that matches the search string</returns>
        public TextRange FindNext(int beginAtOffset, bool searchBackward, out bool loopedAround)
        {
            Debug.Assert(!string.IsNullOrEmpty(_lookFor));
            loopedAround = false;

            int startAt = BeginOffset, endAt = EndOffset;
            int curOffs = beginAtOffset.InRange(startAt, endAt);

            _lookFor2 = MatchCase ? _lookFor : _lookFor.ToUpperInvariant();

            TextRange result;
            if (searchBackward)
            {
                result = FindNextIn(startAt, curOffs, true);
                if (result == null)
                {
                    loopedAround = true;
                    result = FindNextIn(curOffs, endAt, true);
                }
            }
            else
            {
                result = FindNextIn(curOffs, endAt, false);
                if (result == null)
                {
                    loopedAround = true;
                   // result = FindNextIn(startAt, curOffs, false);
                }
            }
            return result;
        }
        private TextRange FindNextIn(int offset1, int offset2, bool searchBackward)
        {
            Debug.Assert(offset2 >= offset1);
            offset2 -= _lookFor.Length;

            // Make behavior decisions before starting search loop
            Func<char, char, bool> matchFirstCh;
            Func<int, bool> matchWord;
            if (MatchCase)
                matchFirstCh = (lookFor, c) => (lookFor == c);
            else
                matchFirstCh = (lookFor, c) => (lookFor == Char.ToUpperInvariant(c));
            if (MatchWholeWordOnly)
                matchWord = IsWholeWordMatch;
            else
                matchWord = IsPartWordMatch;

            // Search
            char lookForCh = _lookFor2[0];
            if (searchBackward)
            {
                for (int offset = offset2; offset >= offset1; offset--)
                {
                    if (matchFirstCh(lookForCh, _document.GetCharAt(offset)) && matchWord(offset))
                        return new TextRange(_document, offset, _lookFor.Length);
                }
            }
            else
            {
                for (int offset = offset1; offset <= offset2; offset++)
                {
                    if (matchFirstCh(lookForCh, _document.GetCharAt(offset)) && matchWord(offset))
                        return new TextRange(_document, offset, _lookFor.Length);
                }
            }
            return null;
        }
        private bool IsWholeWordMatch(int offset)
        {
            if (IsWordBoundary(offset) && IsWordBoundary(offset + _lookFor.Length))
                return IsPartWordMatch(offset);
            else
                return false;
        }
        private bool IsWordBoundary(int offset)
        {
            return offset <= 0 || offset >= _document.TextLength || !IsAlphaNumeric(offset - 1) || !IsAlphaNumeric(offset);
        }
        private bool IsAlphaNumeric(int offset)
        {
            char c = _document.GetCharAt(offset);
            return Char.IsLetterOrDigit(c) || c == '_';
        }
        private bool IsPartWordMatch(int offset)
        {
            string substr = _document.GetText(offset, _lookFor.Length);
            if (!MatchCase)
                substr = substr.ToUpperInvariant();
            return substr == _lookFor2;
        }
    }
}
