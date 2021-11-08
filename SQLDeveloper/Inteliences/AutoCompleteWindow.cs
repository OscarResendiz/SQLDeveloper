using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Gui.CompletionWindow;

namespace Inteliences
{
    public partial class AutoCompleteWindow : AbstractCompletionWindow
    {
        static ICompletionData[] completionData;
        CodeCompletionListView codeCompletionListView;
        VScrollBar vScrollBar = new VScrollBar();

        int startOffset;
        int endOffset;
        DeclarationViewWindow declarationViewWindow = null;
        Rectangle workingScreen;

        const int ScrollbarWidth = 16;
        bool showDeclarationWindow = true;

        public static AutoCompleteWindow ShowCompletionWindow(Form parent, TextEditorControl control, string fileName, ICompletionDataProvider completionDataProvider, char firstChar)
        {
            return ShowCompletionWindow(parent, control, fileName, completionDataProvider, firstChar, true);
        }
        public static AutoCompleteWindow ShowCompletionWindow(Form parent, TextEditorControl control, string fileName, ICompletionDataProvider completionDataProvider, char firstChar, int IOffset, int FOffset)
        {
            AutoCompleteWindow aux = ShowCompletionWindow(parent, control, fileName, completionDataProvider, firstChar, true);
            if (aux == null)
                return null;
            aux.startOffset = IOffset;
            aux.endOffset = FOffset;
            return aux;
        }
        public static AutoCompleteWindow ShowCompletionWindow(Form parent, TextEditorControl control, string fileName, ICompletionDataProvider completionDataProvider, char firstChar, bool showDeclarationWindow)
        {
            completionData = completionDataProvider.GenerateCompletionData(fileName, control.ActiveTextAreaControl.TextArea, firstChar);
            if (completionData == null || completionData.Length == 0)
            {
                return null;
            }
            AutoCompleteWindow codeCompletionWindow = new AutoCompleteWindow(completionDataProvider, parent, control, fileName, showDeclarationWindow);
            codeCompletionWindow.ShowCompletionWindow();
            return codeCompletionWindow;
        }

        AutoCompleteWindow(ICompletionDataProvider completionDataProvider, Form parentForm, TextEditorControl control, string fileName, bool showDeclarationWindow)
            : base(parentForm, control)
        {
            this.showDeclarationWindow = showDeclarationWindow;

            workingScreen = Screen.GetWorkingArea(Location);
            startOffset = control.ActiveTextAreaControl.Caret.Offset + 1;
            endOffset = startOffset;
            if (completionDataProvider.PreSelection != null)
            {
                startOffset -= completionDataProvider.PreSelection.Length + 1;
                endOffset--;
            }

            codeCompletionListView = new CodeCompletionListView(completionData);
            codeCompletionListView.ImageList = completionDataProvider.ImageList;
            codeCompletionListView.Dock = DockStyle.Fill;
            codeCompletionListView.SelectedItemChanged += new EventHandler(CodeCompletionListViewSelectedItemChanged);
            codeCompletionListView.DoubleClick += new EventHandler(CodeCompletionListViewDoubleClick);
            codeCompletionListView.Click += new EventHandler(CodeCompletionListViewClick);
            Controls.Add(codeCompletionListView);

            if (completionData.Length > 10)
            {
                vScrollBar.Dock = DockStyle.Right;
                vScrollBar.Minimum = 0;
                vScrollBar.Maximum = completionData.Length - 8;
                vScrollBar.SmallChange = 1;
                vScrollBar.LargeChange = 3;
                codeCompletionListView.FirstItemChanged += new EventHandler(CodeCompletionListViewFirstItemChanged);
                Controls.Add(vScrollBar);
            }

            this.drawingSize = GetListViewSize();
            SetLocation();

            declarationViewWindow = new DeclarationViewWindow(parentForm);
            SetDeclarationViewLocation();
            declarationViewWindow.ShowDeclarationViewWindow();
            control.Focus();
            CodeCompletionListViewSelectedItemChanged(this, EventArgs.Empty);

            if (completionDataProvider.DefaultIndex >= 0)
            {
                codeCompletionListView.SelectIndex(completionDataProvider.DefaultIndex);
            }

            if (completionDataProvider.PreSelection != null)
            {
                CaretOffsetChanged(this, EventArgs.Empty);
            }

            vScrollBar.Scroll += new ScrollEventHandler(DoScroll);
        }

        public void HandleMouseWheel(MouseEventArgs e)
        {
            int MAX_DELTA = 120; // basically it's constant now, but could be changed later by MS
            int multiplier = Math.Abs(e.Delta) / MAX_DELTA;

            int newValue;
            if (System.Windows.Forms.SystemInformation.MouseWheelScrollLines > 0)
            {
                newValue = this.vScrollBar.Value - (control.TextEditorProperties.MouseWheelScrollDown ? 1 : -1) * Math.Sign(e.Delta) * System.Windows.Forms.SystemInformation.MouseWheelScrollLines * vScrollBar.SmallChange * multiplier;
            }
            else
            {
                newValue = this.vScrollBar.Value - (control.TextEditorProperties.MouseWheelScrollDown ? 1 : -1) * Math.Sign(e.Delta) * vScrollBar.LargeChange;
            }
            vScrollBar.Value = Math.Max(vScrollBar.Minimum, Math.Min(vScrollBar.Maximum, newValue));
            DoScroll(this, null);
        }

        void CodeCompletionListViewFirstItemChanged(object sender, EventArgs e)
        {
            vScrollBar.Value = Math.Min(vScrollBar.Maximum, codeCompletionListView.FirstItem);
        }

        void SetDeclarationViewLocation()
        {
            //  This method uses the side with more free space
            int leftSpace = Bounds.Left - workingScreen.Left;
            int rightSpace = workingScreen.Right - Bounds.Right;
            Point pos;
            // The declaration view window has better line break when used on
            // the right side, so prefer the right side to the left.
            if (rightSpace * 2 > leftSpace)
                pos = new Point(Bounds.Right, Bounds.Top);
            else
                pos = new Point(Bounds.Left - declarationViewWindow.Width, Bounds.Top);
            if (declarationViewWindow.Location != pos)
            {
                declarationViewWindow.Location = pos;
            }
        }

        protected override void SetLocation()
        {
            base.SetLocation();
            if (declarationViewWindow != null)
            {
                SetDeclarationViewLocation();
            }
        }

        void CodeCompletionListViewSelectedItemChanged(object sender, EventArgs e)
        {
            ICompletionData data = codeCompletionListView.SelectedCompletionData;
            if (data != null && data.Description != null && showDeclarationWindow)
            {
                declarationViewWindow.Description = data.Description;
                SetDeclarationViewLocation();
            }
            else
            {
                declarationViewWindow.Size = new Size(0, 0);
            }
        }

        public override bool ProcessKeyEvent(char ch)
        {

            if (ch != '_' && ch != '-')
                return base.ProcessKeyEvent(ch);
            return !base.ProcessKeyEvent(ch);
        }

        protected override void CaretOffsetChanged(object sender, EventArgs e)
        {
            int offset = control.ActiveTextAreaControl.Caret.Offset;
            if (offset < startOffset || offset > endOffset)
            {
                Close();
            }
            else
            {
                codeCompletionListView.SelectItemWithStart(control.Document.GetText(startOffset, offset - startOffset));
            }
        }

        protected void DoScroll(object sender, ScrollEventArgs sea)
        {
            codeCompletionListView.FirstItem = vScrollBar.Value;
            codeCompletionListView.Refresh();
            control.ActiveTextAreaControl.TextArea.Focus();
        }

        protected override bool ProcessTextAreaKey(Keys keyData)
        {
            if (!Visible)
            {
                return false;
            }

            switch (keyData)
            {
                case Keys.Back:
                    --endOffset;
                    if (endOffset < startOffset)
                    {
                        Close();
                    }
                    return false;
                case Keys.Delete:
                    if (control.ActiveTextAreaControl.Caret.Offset <= endOffset)
                    {
                        --endOffset;
                    }
                    if (endOffset < startOffset)
                    {
                        Close();
                    }
                    return false;
                case Keys.Home:
                    codeCompletionListView.SelectIndex(0);
                    return true;
                case Keys.End:
                    codeCompletionListView.SelectIndex(completionData.Length - 1);
                    return true;
                case Keys.PageDown:
                    codeCompletionListView.PageDown();
                    return true;
                case Keys.PageUp:
                    codeCompletionListView.PageUp();
                    return true;
                case Keys.Down:
                    codeCompletionListView.SelectNextItem();
                    return true;
                case Keys.Up:
                    codeCompletionListView.SelectPrevItem();
                    return true;
                case Keys.Tab:
                case Keys.Return:
                    InsertSelectedItem();
                    return true;
            }
            return base.ProcessTextAreaKey(keyData);
        }

        void CodeCompletionListViewDoubleClick(object sender, EventArgs e)
        {
            InsertSelectedItem();
        }

        void CodeCompletionListViewClick(object sender, EventArgs e)
        {
            control.ActiveTextAreaControl.TextArea.Focus();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Dispose();
            codeCompletionListView.Dispose();
            codeCompletionListView = null;
            declarationViewWindow.Dispose();
            declarationViewWindow = null;
        }

        void InsertSelectedItem()
        {
            ICompletionData data = codeCompletionListView.SelectedCompletionData;
            if (data != null)
            {
                control.BeginUpdate();

                if (endOffset - startOffset > 0)
                {
                    try
                    {
                        int dif = endOffset - startOffset;
                        int startOffset2 = control.Document.PositionToOffset(control.ActiveTextAreaControl.Caret.Position);
                        control.Document.Remove(startOffset2 - dif, dif);
                        startOffset = startOffset2 - dif;
                    }
                    finally
                    {
                        control.ActiveTextAreaControl.Caret.Position = control.Document.OffsetToPosition(startOffset);
                    }
                }
                data.InsertAction(control.ActiveTextAreaControl.TextArea, '\0');
                control.EndUpdate();
            }
            Close();
        }

        Size GetListViewSize()
        {

            int height = 0;
            int width = 0;
            try
            {
                height = codeCompletionListView.ItemHeight * Math.Min(10, completionData.Length);
            }
            catch (System.Exception)
            {
                height = 1 * Math.Min(10, completionData.Length);
            }
            try
            {
                width = GetListViewWidth(codeCompletionListView.ItemHeight * 10, height);
            }
            catch (System.Exception)
            {
                width = GetListViewWidth(1 * 10, height);
            }
            return new Size(width, height);
        }

        /// <summary>
        /// Gets the list view width large enough to handle the longest completion data
        /// text string.
        /// </summary>
        /// <param name="defaultWidth">The default width of the list view.</param>
        /// <param name="height">The height of the list view.  This is
        /// used to determine if the scrollbar is visible.</param>
        /// <returns>The list view width to accommodate the longest completion 
        /// data text string; otherwise the default width.</returns>
        int GetListViewWidth(int defaultWidth, int height)
        {
            Graphics graphics = codeCompletionListView.CreateGraphics();
            float width = defaultWidth;

            for (int i = 0; i < completionData.Length; ++i)
            {
                float itemWidth = graphics.MeasureString(completionData[i].Text.ToString(), codeCompletionListView.Font).Width;
                if (itemWidth > width)
                {
                    width = itemWidth;
                }
            }
            graphics.Dispose();

            float totalItemsHeight = 0;
            try
            {
                totalItemsHeight = codeCompletionListView.ItemHeight * completionData.Length;
            }
            catch (System.Exception)
            {
                totalItemsHeight = completionData.Length;
            }

            if (totalItemsHeight > height)
            {
                width += ScrollbarWidth; // Compensate for scroll bar.
            }

            return (int)width;
        }
    }
}
