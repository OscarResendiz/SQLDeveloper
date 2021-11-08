using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.TextEditor;
using MotorDB;
using ICSharpCode.TextEditor.Gui.CompletionWindow;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Data;
using System.IO;



namespace Inteliences
{
    public delegate System.Windows.Forms.Form OnParentFormEvent();
    public partial class CInteliences : Component, ICompletionDataProvider
    {
        #region Variables
        //        public FilteringTypeValues tipo;
        ITextAnaliser AnalizadorTexto;
        ICSharpCode.TextEditor.TextLocation CurPos;
        int CurOffset;
        private string CurQuery, CurWord, InspectedObjectName;
        FilteringTypeValues CurrentFilter;
        string FilterString;
        public string Filtro;
        AutoCompleteWindow ISense;
        //        CodeCompletionWindow ISense;
        TextEditorControl FEditor;
        bool CancelClose;
        int _FireAt;
        private MotorDB.IMotorDB FDB;
        private List< CInteliencesObject> LInteliencesObject;
        CBuffer cBuffer1;
        #endregion
        #region Eventos
        public event OnParentFormEvent OnParentForm;
        #endregion
        #region Estandar de componente base
        public CInteliences()
        {
            InitializeComponent();
        }

        public CInteliences(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion
        #region Propiedades del conponente
        public TextEditorControl Editor
        {
            get
            {
                return FEditor;
            }
            set
            {
                FEditor = value;
                if (FEditor != null)
                {
                    FEditor.ActiveTextAreaControl.TextArea.DoProcessDialogKey += new DialogKeyProcessor(OnDoProcessDialogKey);
                    if(AnalizadorTexto!=null)
                        AnalizadorTexto.SetTextEditor(FEditor);
                }
            }
        }
        public MotorDB.IMotorDB DB
        {
            get
            {
                return FDB;
            }
            set
            {
                FDB = value;
                cBuffer1 = cBufferProvider1.GetBuffer(FDB);
                if (AnalizadorTexto != null)
                    AnalizadorTexto.SetBuffer(cBuffer1);
                if (FDB != null)
                {
                    AnalizadorTexto = cAnaliseManager1.GetAnaliser(FDB.GetMotor().ToString());
                    if (FEditor != null)
                        AnalizadorTexto.SetTextEditor(FEditor);
                }
            }
        }
        public bool ShowingIntellisense
        {

            get
            {
                return ((ISense != null) && (!ISense.IsDisposed));
            }
        }
        public System.Windows.Forms.Form ParentForm
        {
            get
            {
                if (OnParentForm != null)
                    return OnParentForm();
                return null;
            }
        }
        public int FireAt
        {
            get
            {
                return _FireAt;
            }
            set
            {
                _FireAt = value;
            }
        }
        #endregion
        #region Implementacion de la inerface ICompletionDataProvider

        public System.Windows.Forms.ImageList ImageList
        {
            get
            {
                return imageList1;
            }
        }

        public string PreSelection
        {
            get
            {
                return null;
            }
        }

        public int DefaultIndex
        {
            get
            {
                return -1;
            }
        }

        public CompletionDataProviderKeyResult ProcessKey(char key)
        {
            if (char.IsLetterOrDigit(key) || key == '_')
            {
                return CompletionDataProviderKeyResult.NormalKey;
            }
            return CompletionDataProviderKeyResult.InsertionKey;
        }

        public bool InsertAction(ICompletionData data, TextArea textArea, int insertionOffset, char key)
        {
            textArea.Caret.Position = textArea.Document.OffsetToPosition(Math.Min(insertionOffset, textArea.Document.TextLength));
            return data.InsertAction(textArea, key);
        }

        #endregion
        #region funciones de inteliences
        bool OnDoProcessDialogKey(Keys keyData)
        {
            //si regresa true, el editor muestra la tecla y false para que la ignore
            #region Codigo Anterior para Intellisense, codigo propio no de ICSharp.TextEditor
            if (ShowingIntellisense)
            {
                #region Codigo para el Manejo de Teclas si el "IntelliSense" esta Activado
                switch (keyData)
                {
                    case Keys.Back:
                        ISense.Close();
                        if (FilterString != null && FilterString.Length > 0)
                        {
                            FilterString = FilterString.Remove(FilterString.Length - 1);
                            //FEditor.ActiveTextAreaControl.Caret.Position = FEditor.Document.OffsetToPosition(FEditor.ActiveTextAreaControl.Caret.Offset - 1);
                            //FEditor.Document.Insert(FEditor.ActiveTextAreaControl.Caret.Offset, "$");//(FEditor.ActiveTextAreaControl.Caret.Offset, 1);
                            //FEditor.ActiveTextAreaControl.Caret.Position = FEditor.Document.OffsetToPosition(FEditor.ActiveTextAreaControl.Caret.Offset + 1);
                            CancelClose = true;
                            ShowIntellisense();
                        }
                        return true;
                    case Keys.Escape:
                        ISense.Close();
                        break;
                    case Keys.OemMinus:
                        FilterString += "-";
                        ShowIntellisense();
                        //CancelClose = true;
                        return false;
                    case Keys.OemMinus | Keys.Shift:
                        FilterString += "_";
                        ShowIntellisense();
                        //CancelClose = true;
                        return false;
                    case (Keys)65601:
                    case Keys.A:
                    case (Keys)65602:
                    case Keys.B:
                    case (Keys)65603:
                    case Keys.C:
                    case (Keys)65604:
                    case Keys.D:
                    case (Keys)65605:
                    case Keys.E:
                    case (Keys)65606:
                    case Keys.F:
                    case (Keys)65607:
                    case Keys.G:
                    case (Keys)65608:
                    case Keys.H:
                    case (Keys)65609:
                    case Keys.I:
                    case (Keys)65610:
                    case Keys.J:
                    case (Keys)65611:
                    case Keys.K:
                    case (Keys)65612:
                    case Keys.L:
                    case (Keys)65613:
                    case Keys.M:
                    case (Keys)65614:
                    case Keys.N:
                    case (Keys)65615:
                    case Keys.O:
                    case (Keys)65616:
                    case Keys.P:
                    case (Keys)65617:
                    case Keys.Q:
                    case (Keys)65618:
                    case Keys.R:
                    case (Keys)65619:
                    case Keys.S:
                    case (Keys)65620:
                    case Keys.T:
                    case (Keys)65621:
                    case Keys.U:
                    case (Keys)65622:
                    case Keys.V:
                    case (Keys)65623:
                    case Keys.W:
                    case (Keys)65624:
                    case Keys.X:
                    case (Keys)65625:
                    case Keys.Y:
                    case (Keys)65626:
                    case Keys.Z:
                    case Keys.NumPad0:
                    case Keys.NumPad1:
                    case Keys.NumPad2:
                    case Keys.NumPad3:
                    case Keys.NumPad4:
                    case Keys.NumPad5:
                    case Keys.NumPad6:
                    case Keys.NumPad7:
                    case Keys.NumPad8:
                    case Keys.NumPad9:
                    case System.Windows.Forms.Keys.LButton | System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space:
                    case System.Windows.Forms.Keys.RButton | System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space:
                    case System.Windows.Forms.Keys.LButton | System.Windows.Forms.Keys.RButton | System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space:
                    case System.Windows.Forms.Keys.MButton | System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space:
                    case System.Windows.Forms.Keys.LButton | System.Windows.Forms.Keys.MButton | System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space:
                    case System.Windows.Forms.Keys.RButton | System.Windows.Forms.Keys.MButton | System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space:
                    case System.Windows.Forms.Keys.LButton | System.Windows.Forms.Keys.RButton | System.Windows.Forms.Keys.MButton | System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space:
                    case System.Windows.Forms.Keys.Back | System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space:
                    case System.Windows.Forms.Keys.LButton | System.Windows.Forms.Keys.Back | System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space:
                    case System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space:
                    case System.Windows.Forms.Keys.RButton | System.Windows.Forms.Keys.MButton | System.Windows.Forms.Keys.Back | System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space | System.Windows.Forms.Keys.F17:
                        //es el .
                        if (keyData == (System.Windows.Forms.Keys.RButton | System.Windows.Forms.Keys.MButton | System.Windows.Forms.Keys.Back | System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space | System.Windows.Forms.Keys.F17))
                            FilterString += ".";
                        else
                        FilterString += ((char)keyData).ToString();
                        ShowIntellisense();
                        return false;
                    case Keys.Delete:
                    case Keys.Left:
                    case Keys.Right:
                        return true;
                    default:
                        if (ShowingIntellisense)
                            return true;
                        else
                            return false;
                }
                #endregion
            }
            else
            {
                #region Switch para saber que se va a mostrar cuando se quiera hacer intellisense
                switch (keyData)
                {
                    case Keys.Control | Keys.OemPeriod://ctrl + . , forzar muestra de intellisense
                    case Keys.Space | Keys.Control://ctrl + space, forzar muestra de intellisense
                        CurrentFilter = FilteringTypeValues.All;
                        CurWord = GetWordAtOffsetMinusOne();
                        FilterString = CurWord;
                        //   FireAt = CurOffset;
                        ShowIntellisense();
                        return true;
                    case Keys.Space:
                        string WordBehind = GetWordAtOffset();
            int auxoffset2 = FEditor.Document.PositionToOffset(FEditor.ActiveTextAreaControl.Caret.Position);
                        return AnalizaEspacio();
//                    case Keys.OemPeriod:
                    //case Keys.Decimal: 
                      //  return ValidaPunto();
                    case Keys.T | Keys.Control://ctrl + t , mostrar tablas + vistas
                        CurrentFilter = FilteringTypeValues.Fields;
                        CurWord = GetWordAtOffsetMinusOne();
                        FilterString = CurWord;
                        FireAt = CurOffset;
                        ShowIntellisense();
                        break;
                    case Keys.P | Keys.Control://ctrl + p , mostrar procedimientos almacenados
                        CurrentFilter = FilteringTypeValues.Sps;
                        CurWord = GetWordAtOffsetMinusOne();
                        FilterString = CurWord;
                        FireAt = CurOffset;
                        ShowIntellisense();
                        break;
                    case Keys.D | Keys.Control://ctrl + d , mostrar variables 
                        CurrentFilter = FilteringTypeValues.Variables;
                        CurWord = GetWordAtOffsetMinusOne();
                        FilterString = CurWord;
                        FireAt = CurOffset;
                        AddVariables();
                        ShowIntellisense();
                        return true;
                    case Keys.Control | Keys.Q | Keys.Alt://aroba, @
                        //case Keys.RButton | Keys.ShiftKey | Keys.Space | Keys.Control | Keys.Alt:
                        //                        FEditor.Document.Insert(CurOffset, "@");

                        CurrentFilter = FilteringTypeValues.Variables;
                        CurWord = GetWordAtOffsetMinusOne();
                        FilterString = CurWord;
                        FireAt = CurOffset;
                        WordBehind = GetWordAtOffset();
                        auxoffset2 = FEditor.Document.PositionToOffset(FEditor.ActiveTextAreaControl.Caret.Position);
                        if (AddVariables() == false)
                            return false;
                        //ShowIntellisense();

                        ///------------
                        ///                            FEditor.Document.Insert(auxoffset2, " ");
                        // FEditor.ActiveTextAreaControl.Caret.Column += 1;
                        // auxoffset2++;
                        if (PuedoMostrarVariables(auxoffset2) == false)
                            return false;
                        CurOffset = auxoffset2;
                        FilterString = "";
                        FireAt = auxoffset2;
                        ShowIntellisense();

                        return true;
                    case Keys.S | Keys.Control://ctrl + s , mostrar snippets
                        MessageBox.Show("Ctr + S");
                        break;
                }
                #endregion
            }
            #endregion
            return false;
        }
        public void ShowIntellisense()
        {
            if (ShowingIntellisense)
            {
                ISense.Close();
            }
            ///-----------------
            ///-----------
            if (FilterString == null)
                FilterString = "";
            Filtro = FilterString;
            //tipo = CurrentFilter;           
            ISense = AutoCompleteWindow.ShowCompletionWindow(this.ParentForm, FEditor, FilterString, this, ' ', FireAt, FireAt + FilterString.Length);
            //ISense = CodeCompletionWindow.ShowCompletionWindow(this.ParentForm, FEditor, FilterString, this, ' ');//, FireAt, FireAt);// + FilterString.Length);
            if (ISense != null)
            {
                CancelClose = true;
                ISense.Closing += ISense_Closing;
                ISense.Closed += CodeCompletionWindowClosed;
            }
        }
        void ISense_Closing(object sender, CancelEventArgs e)
        {
            if (CancelClose)
            {
                CancelClose = false;
                e.Cancel = true;
            }
        }
        void CodeCompletionWindowClosed(object sender, EventArgs e)
        {
            if (ISense != null)
            {
                ISense.Closed -= CodeCompletionWindowClosed;
                ISense.Closing -= ISense_Closing;
                ISense.Dispose();
                ISense = null;
            }
        }
        private string GetWordAtOffsetMinusOne()
        {
            return "hola oscar";
        }
        private string GetWordAtOffset()
        {
            ICSharpCode.TextEditor.Document.TextWord CW;

            CW = FEditor.Document.GetLineSegment(FEditor.ActiveTextAreaControl.Caret.Line).GetWord(FEditor.ActiveTextAreaControl.Caret.Column);
            if (CW != null && CW.Word.Trim().Length > 0)
            {
                CurPos = new ICSharpCode.TextEditor.TextLocation(CW.Offset, FEditor.ActiveTextAreaControl.Caret.Line);
                CurOffset = FEditor.Document.PositionToOffset(CurPos);
            }
            else
            {
                if (FEditor.ActiveTextAreaControl.Caret.Column > 0)
                    CW = FEditor.Document.GetLineSegment(FEditor.ActiveTextAreaControl.Caret.Line).GetWord(FEditor.ActiveTextAreaControl.Caret.Column - 1);
                if (CW != null && CW.Word.Trim().Length > 0)
                {
                    CurPos = new ICSharpCode.TextEditor.TextLocation(CW.Offset, FEditor.ActiveTextAreaControl.Caret.Line);
                    CurOffset = FEditor.Document.PositionToOffset(CurPos);
                }
                else
                {
                    CurPos.X = FEditor.ActiveTextAreaControl.Caret.Column;
                    CurPos.Y = FEditor.ActiveTextAreaControl.Caret.Line;
                    CurOffset = FEditor.Document.PositionToOffset(CurPos);
                }
            }
            return CW == null ? "" : CW.Word;
        }
        public ICompletionData[] GenerateCompletionData(string fileName, TextArea textArea, char charTyped)
        {
            if (LInteliencesObject == null)
                return new CInteliencesObject[0];
            List<CInteliencesObject> tmp = new List<CInteliencesObject>();
            foreach( CInteliencesObject obj in LInteliencesObject )
            {
                if (obj.Text.ToUpper().Contains(fileName.ToUpper().Trim()))
                {
                    tmp.Add(obj);
                }
            }
            return tmp.ToArray();
        }
        private bool ValidaPunto()
        {
            return false;
        }
        private bool AddVariables()
        {
            LInteliencesObject = new List<CInteliencesObject>();
            List<string> l = AnalizadorTexto.GetVariableNames();
            if (l.Count == 0)
                return false;
            foreach (string s in l)
            {
                CInteliencesObject obj = new CInteliencesObject();
                obj.Text = s;
                LInteliencesObject.Add(obj);
            }
            return true;
        }
        #endregion
        private void CargaTablasVistas()
        {
            if (cBuffer1 == null)
                return;
            LInteliencesObject = new List<CInteliencesObject>();
            List<string> l = cBuffer1.GetTableNames();
            foreach(string s in l)
            {
                CInteliencesObject obj = new CInteliencesObject();
                obj.Text = s;
                LInteliencesObject.Add(obj);
            }
            //ahora las vistas
            l = cBuffer1.GetViewNames();
            foreach (string s in l)
            {
                CInteliencesObject obj = new CInteliencesObject();
                obj.Text = s;
                LInteliencesObject.Add(obj);
            }
            //me traigo las tablas que se encuentren dentro del codigo 
            l = AnalizadorTexto.GetTablesNames();
            foreach (string s in l)
            {
                CInteliencesObject obj = new CInteliencesObject();
                obj.Text = s;
                LInteliencesObject.Add(obj);
            }

        }
        private void CargaTablas()
        {
            if (cBuffer1 == null)
                return;
            LInteliencesObject = new List<CInteliencesObject>();
            List<string> l = cBuffer1.GetTableNames();
            foreach (string s in l)
            {
                CInteliencesObject obj = new CInteliencesObject();
                obj.Text = s;
                LInteliencesObject.Add(obj);
            }
            List<string> l2 = AnalizadorTexto.GetTablesNames();
            foreach (string s in l2)
            {
                CInteliencesObject obj = new CInteliencesObject();
                obj.Text = s;
                LInteliencesObject.Add(obj);
            }
        }
        private bool CargaCampos()
        {
            if (cBuffer1 == null)
                return false;
            AnalizadorTexto.SetBuffer(cBuffer1);
            LInteliencesObject = new List<CInteliencesObject>();
            List<string> l = cBuffer1.GetAllFields();
            if (l.Count() > 0)
            {

                foreach (string s in l)
                {
                    CInteliencesObject obj = new CInteliencesObject();
                    obj.Text = s;
                    LInteliencesObject.Add(obj);
                }
            }
            //me traigo tambien las variables
            l = AnalizadorTexto.GetVariableNames();
            if (l.Count > 0)
            {
                foreach (string s in l)
                {
                    CInteliencesObject obj = new CInteliencesObject();
                    obj.Text = s;
                    LInteliencesObject.Add(obj);
                }
            }
            l = AnalizadorTexto.GetAllFields();
            if (l.Count > 0)
            {
                foreach (string s in l)
                {
                    CInteliencesObject obj = new CInteliencesObject();
                    obj.Text = s;
                    LInteliencesObject.Add(obj);
                }
            }
            if (LInteliencesObject.Count() == 0)
                return false;
            return true;
        }
        /// <summary>
        /// Indica si hay o no hay que mostrar el inteliese
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        private bool PuedoMostrarVariables(int pos)
        {
            //por ahorita solo voy a validar la palabra clave declare
            //me traigo la linea en la que se quiere mostrar la variable
            int linea = FEditor.Document.GetLineNumberForOffset(pos);
            ICSharpCode.TextEditor.Document.LineSegment CW;
            CW = FEditor.Document.GetLineSegment(linea);
            foreach(ICSharpCode.TextEditor.Document.TextWord w in CW.Words)
            {
                if (w.Word.ToUpper().Trim() == "DECLARE")
                    return false;
            }
            return true;
        }
        private bool AnalizaEspacio()
        {
            AnalizadorTexto.SetTextEditor(FEditor);
            int auxoffset = FEditor.Document.PositionToOffset(FEditor.ActiveTextAreaControl.Caret.Position);
            string comando = AnalizadorTexto.GetSincronizadorAnterior(auxoffset);
            #region FROM, JOIN, DELETE, UPDATE
            if (comando == "FROM" || comando == "JOIN" || comando == "DELETE" || comando == "UPDATE")
            {
                //si es un FROM o un ON sacar la lista de tablas y vistas
                FEditor.Document.Insert(auxoffset, " ");
                FEditor.ActiveTextAreaControl.Caret.Column += 1;
                auxoffset++;
                CurOffset = auxoffset;

                CurrentFilter = FilteringTypeValues.Fields;
                FilterString = "";
                FireAt = CurOffset;
                if (comando == "DELETE" || comando == "UPDATE")
                    CargaTablas();
                else
                    CargaTablasVistas();
                ShowIntellisense();
                return true;
            }
            if (comando == "SET" || comando == "WHERE" || comando == "AND" || comando == "OR" || comando == "ON" || comando == "SELECT")
            {
                FEditor.Document.Insert(auxoffset, " ");
                FEditor.ActiveTextAreaControl.Caret.Column += 1;
                auxoffset++;
                CurOffset = auxoffset;

                CurrentFilter = FilteringTypeValues.Fields;
                FilterString = "";
                FireAt = CurOffset;
                CargaCampos();
                ShowIntellisense();
                return true;
            }
            #endregion
            return false;
        }
        private bool AnalizaEspacio1()
        {
            //me traigo la posicion de donde se dio el espacio
            #region codigo original
            string WordBehind = GetWordAtOffset();
            int auxoffset2 = FEditor.Document.PositionToOffset(FEditor.ActiveTextAreaControl.Caret.Position);
            if (WordBehind.Equals("FROM", StringComparison.CurrentCultureIgnoreCase) || WordBehind.Equals("JOIN", StringComparison.CurrentCultureIgnoreCase) || WordBehind.Equals("UPDATE", StringComparison.CurrentCultureIgnoreCase))
            {
                //si es un FROM o un ON sacar la lista de tablas y vistas
                FEditor.Document.Insert(auxoffset2, " ");
                FEditor.ActiveTextAreaControl.Caret.Column += 1;
                auxoffset2++;
                CurOffset = auxoffset2;

                CurrentFilter = FilteringTypeValues.Fields;
                FilterString = "";
                FireAt = CurOffset;
                CargaTablasVistas();
                ShowIntellisense();
                return true;
            }
            else if (WordBehind.Equals("DELETE", StringComparison.CurrentCultureIgnoreCase) || WordBehind.Equals("UPDATE", StringComparison.CurrentCultureIgnoreCase) || WordBehind.Equals("INTO", StringComparison.CurrentCultureIgnoreCase))
            {
                //si es un DELETE, un UPDATE o un INTO sacar la lista de tablas
                FEditor.Document.Insert(auxoffset2, " ");
                FEditor.ActiveTextAreaControl.Caret.Column += 1;
                auxoffset2++;
                CurOffset = auxoffset2;
                CurrentFilter = FilteringTypeValues.Fields;
                FilterString = "";
                FireAt = CurOffset;
                CargaTablas();
                ShowIntellisense();
                return true;
            }
            else if (WordBehind.Equals("INSERT", StringComparison.CurrentCultureIgnoreCase))
            {
                CargaTablas();
                ShowIntellisense();
                //si es un DELETE, un UPDATE o un INTO sacar la lista de tablas
                return false;
            }
            else if (WordBehind.Equals("SELECT", StringComparison.CurrentCultureIgnoreCase) || WordBehind.Equals("WHERE", StringComparison.CurrentCultureIgnoreCase) || WordBehind.Equals("OR", StringComparison.CurrentCultureIgnoreCase) || WordBehind.Equals("AND", StringComparison.CurrentCultureIgnoreCase) || WordBehind.Equals("BY", StringComparison.CurrentCultureIgnoreCase))
            {
                if (CargaCampos())
                    ShowIntellisense();
                return false;
            }
            return false;
            #endregion
        }
    }
}
