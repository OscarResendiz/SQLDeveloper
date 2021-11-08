using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using ICSharpCode.TextEditor.Document;
using ICSharpCode.TextEditor;
using ICSharpCode;

namespace SQLDeveloper.Modulos.Comparador
{
    public partial class CompareViewer : EditorManager.EditorGenerico
    {
        Modulos.Comparador.CCOnfigComparator comparador = new Modulos.Comparador.CCOnfigComparator();
        Dictionary<TextEditorControl, TextEditor.HighlightGroup> GrupoIzquierdo = new Dictionary<TextEditorControl, TextEditor.HighlightGroup>();
        Dictionary<TextEditorControl, TextEditor.HighlightGroup> GrupoDerecho = new Dictionary<TextEditorControl, TextEditor.HighlightGroup>();
        private string FColorEditor = "SQL";
        public string ColorEditor
        {
            get
            {
                return FColorEditor;
            }
            set
            {
                FColorEditor = value;
                CargaColor();
            }
        }
        public CompareViewer()
        {
            InitializeComponent();
        }

        private void CompareViewer_Load(object sender, EventArgs e)
        {
            try
            {
                textComparator21.Sensibilidad = comparador.SensibilidadComparador;
                textComparator21.Algoritmo = comparador.AlgoritmoComparador;
                textComparator21.CaseSencibility = comparador.CaseSencibility;
                textComparator21.OnComparacionTerminada += new OnTextComparatorEvent(textComparator1_OnComparacionTerminada);
                textComparator21.Comparar();
                waitControl1.Left = (this.Width / 2) - (waitControl1.Width / 2);
                waitControl1.Top = (this.Height / 2) - (waitControl1.Height / 2);
                Contenedor.Panel1.Width = this.Width / 2;
            }
            catch (System.Exception)
            {
                return;
            }

        }
        private void CargaColor()
        {
            try
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\Colores";
                ICSharpCode.TextEditor.Document.FileSyntaxModeProvider provider = new ICSharpCode.TextEditor.Document.FileSyntaxModeProvider(appPath);
                ICSharpCode.TextEditor.Document.HighlightingManager.Manager.AddSyntaxModeFileProvider(provider);
                TCodigoIzqierdo.Document.HighlightingStrategy = ICSharpCode.TextEditor.Document.HighlightingManager.Manager.FindHighlighter(FColorEditor);
                //esta parte es para los tabuladores
                TCodigoIzqierdo.Document.FoldingManager.FoldingStrategy = new TextEditor.SQLFoldingStrategy();
                TCodigoIzqierdo.Document.FoldingManager.UpdateFoldings(null, null);

                TCodigoDerecho.Document.HighlightingStrategy = ICSharpCode.TextEditor.Document.HighlightingManager.Manager.FindHighlighter(FColorEditor);
                //esta parte es para los tabuladores
                TCodigoDerecho.Document.FoldingManager.FoldingStrategy = new TextEditor.SQLFoldingStrategy();
                TCodigoDerecho.Document.FoldingManager.UpdateFoldings(null, null);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string TextIzquierdo
        {
            get
            {
                return textComparator21.Texto1;
            }
            set
            {
                TCodigoIzqierdo.Text = value;
                textComparator21.Texto1 = value;
            }
        }
        public string TextoDerecho
        {
            get
            {
                return textComparator21.Texto2;
            }
            set
            {
                TCodigoDerecho.Text = value;
                textComparator21.Texto2 = value;
            }
        }
        public string TituloIzquierdo
        {
            get
            {
                return LIzquierdo.Text;
            }
            set
            {
                LIzquierdo.Text = value;
            }
        }
        public string TituloDerech
        {
            get
            {
                return LDerecho.Text;
            }
            set
            {
                LDerecho.Text = value;
            }
        }
        private void TCodigoIzqierdo_Scroll(object sender, ScrollEventArgs e)
        {
            //no hace nada
            MessageBox.Show(e.NewValue.ToString() + ": " + e.Type.ToString());
        }

        private void TCodigoDerecho_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void TCodigoIzqierdo_OnHScrollBarValueChanged(object sender, EventArgs e)
        {
            try
            {
                HScrollBar obj = (HScrollBar)sender;
                if (TCodigoDerecho.HScrollBar.Value != obj.Value)
                    TCodigoDerecho.HScrollBar.Value = obj.Value;
            }
            catch (System.Exception ex)
            {
                return;
            }

        }

        private void TCodigoIzqierdo_OnVScrollBarValueChanged(object sender, EventArgs e)
        {
            try
            {
                VScrollBar obj = (VScrollBar)sender;
                if (TCodigoDerecho.VScrollBar.Value != obj.Value)
                    TCodigoDerecho.VScrollBar.Value = obj.Value;
            }
            catch (System.Exception ex)
            {
                return;
            }
        }

        private void TCodigoDerecho_OnHScrollBarValueChanged(object sender, EventArgs e)
        {
            try
            {
                HScrollBar obj = (HScrollBar)sender;
                if (TCodigoIzqierdo.HScrollBar.Value != obj.Value)
                    TCodigoIzqierdo.HScrollBar.Value = obj.Value;
            }
            catch (System.Exception ex)
            {
                return;
            }
        }

        private void TCodigoDerecho_OnVScrollBarValueChanged(object sender, EventArgs e)
        {
            try
            {
                VScrollBar obj = (VScrollBar)sender;
                if (TCodigoIzqierdo.VScrollBar.Value != obj.Value)
                    TCodigoIzqierdo.VScrollBar.Value = obj.Value;
            }
            catch (System.Exception ex)
            {
                return;
            }
        }

        private void textComparator1_OnComparacionTerminada(List<CDiferencia> izquierda)
        {
            string si = "";
            string sd = "";
            int nlinea = 0;
            bool debug = false;
            if (izquierda == null)
                return;
            foreach (CDiferencia obj in izquierda)
            {
                #region lineas para debugear
                if (debug)
                {
                    si += (obj.Izquierda.NLinea + 1).ToString() + "->" + obj.Tipo.ToString() + "->" + obj.Izquierda.texto + "\n";
                    sd += (obj.Derecha.NLinea + 1).ToString() + "->" + obj.Tipo.ToString() + "->" + obj.Derecha.texto + "\n";
                }
                #endregion
                else
                {
                    si += obj.Izquierda.texto + "\n";
                    sd += obj.Derecha.texto + "\n";
                }
                nlinea++;
            }
            TCodigoIzqierdo.Text = si;
            TCodigoDerecho.Text = sd;
            if (!GrupoIzquierdo.ContainsKey(TCodigoIzqierdo))
                GrupoIzquierdo[TCodigoIzqierdo] = new TextEditor.HighlightGroup(TCodigoIzqierdo);
            TextEditor.HighlightGroup group = GrupoIzquierdo[TCodigoIzqierdo];

            if (!GrupoDerecho.ContainsKey(TCodigoDerecho))
                GrupoDerecho[TCodigoDerecho] = new TextEditor.HighlightGroup(TCodigoDerecho);
            TextEditor.HighlightGroup group2 = GrupoDerecho[TCodigoDerecho];

            int pos = 0;
            foreach (CDiferencia obj in izquierda)
            {
                switch (obj.Tipo)
                {
                    #region SOLO_IZQUIERDA
                    case TipoDiferencia.SOLO_IZQUIERDA:
                        if (obj.Izquierda.NLinea < TCodigoIzqierdo.Document.LineSegmentCollection.Count())
                        {
                            pos = TCodigoIzqierdo.Document.LineSegmentCollection[obj.Izquierda.NLinea].Offset;
                            var m = new TextMarker(pos, obj.Izquierda.texto.Length, TextMarkerType.Linea, comparador.ColorNuevaLinea, comparador.ColorLetraNuevaLinea);
                            m.LineNumber = obj.Izquierda.NLinea;
                            group.AddMarker(m);
                        }
                        if (obj.Derecha.NLinea < TCodigoDerecho.Document.LineSegmentCollection.Count())
                        {
                            pos = TCodigoDerecho.Document.LineSegmentCollection[obj.Derecha.NLinea].Offset;
                            var m = new TextMarker(pos, obj.Derecha.texto.Length, TextMarkerType.Linea, comparador.ColorLineaVirtual, Color.Black);
                            m.LineNumber = obj.Derecha.NLinea;
                            group2.AddMarker(m);
                        }
                        break;
                    #endregion
                    #region SOLO_DERECHA
                    case TipoDiferencia.SOLO_DERECHA:
                        if (obj.Derecha.NLinea < TCodigoDerecho.Document.LineSegmentCollection.Count())
                        {
                            pos = TCodigoDerecho.Document.LineSegmentCollection[obj.Derecha.NLinea].Offset;
                            var m1 = new TextMarker(pos, obj.Derecha.texto.Length, TextMarkerType.Linea, comparador.ColorNuevaLinea, comparador.ColorLetraNuevaLinea);
                            m1.LineNumber = obj.Derecha.NLinea;
                            group2.AddMarker(m1);
                        }
                        if (obj.Izquierda.NLinea < TCodigoIzqierdo.Document.LineSegmentCollection.Count())
                        {
                            pos = TCodigoIzqierdo.Document.LineSegmentCollection[obj.Izquierda.NLinea].Offset;
                            var m1 = new TextMarker(pos, 0, TextMarkerType.Linea, comparador.ColorLineaVirtual, Color.Black);
                            m1.LineNumber = obj.Izquierda.NLinea;
                            group.AddMarker(m1);
                        }
                        break;
                    #endregion
                    #region DIFERENTES
                    case TipoDiferencia.DIFERENTES:
                        pos = TCodigoIzqierdo.Document.LineSegmentCollection[obj.Izquierda.NLinea].Offset;
                        var m2 = new TextMarker(pos, obj.Izquierda.texto.Length, TextMarkerType.Linea, comparador.ColorDiferenciaLinea, comparador.ColoLetraLineaDiferente);
                        m2.LineNumber = obj.Izquierda.NLinea;
                        group.AddMarker(m2);

                        pos = TCodigoDerecho.Document.LineSegmentCollection[obj.Derecha.NLinea].Offset;
                        var m4 = new TextMarker(pos, obj.Derecha.texto.Length, TextMarkerType.Linea, comparador.ColorDiferenciaLinea, comparador.ColoLetraLineaDiferente);
                        m4.LineNumber = obj.Derecha.NLinea;
                        group2.AddMarker(m4);
                        //ahora marco con otro color el detalle de las diferencias
                        if (obj.HayDetalleDiferencias)
                        {
                            foreach (CRangoDiferencia detalle in obj.DetalleDiferencias)
                            {
                                if (detalle.Inicio1 != -1)
                                {
                                    pos = TCodigoIzqierdo.Document.LineSegmentCollection[obj.Izquierda.NLinea].Offset;
                                    var m5 = new TextMarker(pos + detalle.Inicio1, detalle.Longitud1, TextMarkerType.SolidBlock, comparador.ColorPalbraDiferente, comparador.ColorLetraDiferenciaDetalle);
                                    m5.LineNumber = obj.Izquierda.NLinea;
                                    group.AddMarker(m5);
                                }
                                if (detalle.Inicio2 != -1)
                                {
                                    pos = TCodigoDerecho.Document.LineSegmentCollection[obj.Derecha.NLinea].Offset;
                                    var m5 = new TextMarker(pos + detalle.Inicio2, detalle.Longitud2, TextMarkerType.SolidBlock, comparador.ColorPalbraDiferente, comparador.ColorLetraDiferenciaDetalle);
                                    m5.LineNumber = obj.Derecha.NLinea;
                                    group2.AddMarker(m5);
                                }
                            }
                        }
                        break;
                    #endregion
                }
            }
            waitControl1.Animar = false;
            waitControl1.Visible = false;
//            if (DlgEsperar!=null)
  //              DlgEsperar.Close();
        }

        private void textComparator1_OnComparacionTerminada()
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
    //        timer1.Enabled = false;
      //      DlgEsperar = new FormEsperar();
        //    DlgEsperar.ShowDialog();
        }
    }
}
