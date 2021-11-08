using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

namespace TextEditor
{
    /// <summary>
    /// The class to generate the foldings, it implements ICSharpCode.TextEditor.Document.IFoldingStrategy
    /// </summary>
    public class SQLFoldingStrategy : IFoldingStrategy
    {
        /// <summary>
        /// Generates the foldings for our document.
        /// </summary>
        /// <param name="document">The current document.</param>
        /// <param name="fileName">The filename of the document.</param>
        /// <param name="parseInformation">Extra parse information, not used in this sample.</param>
        /// <returns>A list of FoldMarkers.</returns>
        private CBlockAnaliser Analizador ;
        List<FoldMarker> List;
        private bool Analizando;
        //creo un constructor
        public SQLFoldingStrategy()
        {
            Analizador = new CBlockAnaliser();
            List = new List<FoldMarker>();
            Analizador.OnAnalisisTerminado += new AnalisisTerminadoEvent(FinAnalisis);
            List = new List<FoldMarker>();
        }
        public List<FoldMarker> GenerateFoldMarkers(IDocument document, string fileName, object parseInformation)
        {
            if (Analizando == true)
                return List;
            Analizando = true;
            Analizador.Document = document;
            Analizador.Analiza();
            return List;
        }
        private void FinAnalisis(List<CBlock> lista)
        {
            //primero quito los que no estan listos
            int i = 0;
            while (List.Count > i)
            {
                bool Eliminar = true;
                FoldMarker fm = List[i];
                if (fm.FoldText.Contains("#"))
                    Eliminar = true;
                //lo busco en la nueva lista
                foreach (CBlock obj in lista)
                {
                    if(fm.StartLine==obj.Inicio.Y && fm.StartColumn==obj.Inicio.X && fm.EndLine==obj.Final.Y /*&& fm.EndColumn==obj.Final.X*/ && fm.FoldType==FoldType.Region )
                    {
                        if (fm.FoldText != obj.Text)
                            fm.FoldText = obj.Text;
                        Eliminar = false;
                        break; //ya lo encontre
                    }
                }
                if(Eliminar)
                {
                    //hay que eliminarlo porque no lo encontre
                    List.RemoveAt(i);
                }
                else
                {
                    //como no se elimino, verifico el sihguiente
                    i++;
                }
            }
            //ahora agrego los nuevos
            foreach (CBlock obj in lista)
            {
                bool agregar=true;
                foreach(FoldMarker fm in List)
                {
                    if (fm.StartLine == obj.Inicio.Y && fm.StartColumn == obj.Inicio.X && fm.EndLine == obj.Final.Y /*&& fm.EndColumn == obj.Final.X*/ && fm.FoldType == FoldType.Region )
                    {
                        agregar = false;
                        break; //ya lo encontre
                    }
                }
                if (agregar)
                {
                    List.Add(new FoldMarker(Analizador.Document, obj.Inicio.Y, obj.Inicio.X, obj.Final.Y, obj.Final.X, FoldType.Region, obj.Text, false));
                }
            }
            Analizando = false;
        }


        public List<FoldMarker> GenerateFoldMarkers2(IDocument document, string fileName, object parseInformation)
        {
            List<FoldMarker> list = new List<FoldMarker>();
            List<Point> Starters = new List<Point>();
            int linea, columna;
            List<string> StartFoldTokens = new List<string>();
            List<string> EndFoldTokens = new List<string>();
            string buffer, after_line;
            #region Definciion de bloques
            StartFoldTokens.Add("begin");
            EndFoldTokens.Add("end");
            StartFoldTokens.Add("--fold");
            EndFoldTokens.Add("--/fold");
            StartFoldTokens.Add("/*");
            EndFoldTokens.Add("*/");
            StartFoldTokens.Add("{");
            EndFoldTokens.Add("}");
            #endregion
            #region recorrido de todos los inicios de bloques
            for (int i = 0; i < StartFoldTokens.Count; i++)
            {
                #region Busqueda de los inicios de los bloques
                //primero buscar el folding de begin
                for (linea = 0; linea < document.TotalNumberOfLines; linea++)
                {
                    buffer = document.GetText(document.GetLineSegment(linea)).ToLower();
                    columna = 0;
                    columna = buffer.IndexOf(StartFoldTokens[i], columna);
                    while (columna >= 0)
                    {
                        Starters.Add(new Point(linea, columna));
                        columna += StartFoldTokens[i].Length;
                        columna = buffer.IndexOf(StartFoldTokens[i], columna);
                    }
                }
                #endregion
                #region Busqueda de los fines de bloques
                //luego buscar el cierre de begin, ie end
                for (linea = 0; linea < document.TotalNumberOfLines; linea++)
                {
                    buffer = document.GetText(document.GetLineSegment(linea)).ToLower();
                    columna = 0;
                    columna = buffer.IndexOf(EndFoldTokens[i], columna);
                    while (columna >= 0)
                    {
                        //ahora a partir de aqui tengo que buscar el starter mas grande que este mas
                        //atras de este ender que encontre
                        for (int rev = Starters.Count - 1; rev >= 0; rev--)
                        {
                           //si esta en una linea mas abajo el starter o en una columna mas a la derecha hay que saltarlo
                            if (Starters[rev].X > linea || (Starters[rev].X == linea && Starters[rev].Y > columna))
                                continue;
                            else
                            {
                                //ya encontro la pareja
                                after_line = document.GetText(document.GetLineSegment(Starters[rev].X)).Substring(Starters[rev].Y);
                                if (after_line.Length > StartFoldTokens[i].Length)
                                    after_line = after_line.Substring(StartFoldTokens[i].Length).Trim();
                                else
                                    after_line = "...";
                                list.Add(new FoldMarker(document, Starters[rev].X, Starters[rev].Y + StartFoldTokens[i].Length, linea, columna, FoldType.Region, after_line, false));
                                Starters.RemoveAt(rev);
                                break;
                            }
                        }
                        columna += EndFoldTokens[i].Length;
                        columna = buffer.IndexOf(EndFoldTokens[i], columna);
                        if (Starters.Count == 0)
                            break;
                    }
                }
                #endregion
                Starters.Clear();
            }
            #endregion
            return list;
        }
        public List<FoldMarker> GenerateFoldMarkers(IDocument document, string fileName, object parseInformation, string StartFoldToken, string EndFoldToken)
        {
            List<string> AuxIni = new List<string>();
            List<string> AuxFin = new List<string>();
            AuxIni.Add(StartFoldToken);
            AuxFin.Add(EndFoldToken);
            return GenerateFoldMarkers(document, fileName, parseInformation, AuxIni, AuxFin);
        }
        public List<FoldMarker> GenerateFoldMarkers(IDocument document, string fileName, object parseInformation, List<string> StartFoldTokens, List<string> EndFoldTokens)
        {
            List<FoldMarker> list = new List<FoldMarker>();
            List<Point> Starters = new List<Point>();
            int linea, columna, FoldingCouples;
            string buffer, after_line;

            if (StartFoldTokens == null || EndFoldTokens == null || StartFoldTokens.Count == 0 || EndFoldTokens.Count == 0)
                return list;
            FoldingCouples = Math.Min(StartFoldTokens.Count, EndFoldTokens.Count);
            for (int i = 0; i < FoldingCouples; i++)
            {
                //primero buscar inicio, el clave de inicio de codefolding, 
                for (linea = 0; linea < document.TotalNumberOfLines; linea++)
                {
                    buffer = document.GetText(document.GetLineSegment(linea)).ToLower();
                    columna = 0;
                    columna = buffer.IndexOf(StartFoldTokens[i], columna);
                    while (columna >= 0)
                    {
                        Starters.Add(new Point(linea, columna));
                        columna += StartFoldTokens[i].Length;
                        columna = buffer.IndexOf(StartFoldTokens[i], columna);
                    }
                }

                //luego buscar el cierre del codefolding
                for (linea = 0; linea < document.TotalNumberOfLines; linea++)
                {
                    buffer = document.GetText(document.GetLineSegment(linea)).ToLower();
                    columna = 0;
                    columna = buffer.IndexOf(EndFoldTokens[i], columna);
                    while (columna >= 0)
                    {
                        //ahora a partir de aqui tengo que buscar el starter mas avanzado que este mas
                        //atras de este ender que encontre
                        for (int rev = Starters.Count - 1; rev >= 0; rev--)
                        {
                            if (Starters[rev].X > linea || (Starters[rev].X == linea && Starters[rev].Y > columna))
                                continue;
                            else
                            {
                                after_line = document.GetText(document.GetLineSegment(Starters[rev].X)).Substring(Starters[rev].Y);
                                if (after_line.Length > StartFoldTokens[i].Length)
                                    after_line = after_line.Substring(StartFoldTokens[i].Length).Trim();
                                else
                                    after_line = "...";
                                list.Add(new FoldMarker(document, Starters[rev].X, Starters[rev].Y + StartFoldTokens[i].Length, linea, columna, FoldType.Region, after_line, false));
                                Starters.RemoveAt(rev);
                                break;
                            }
                        }
                        columna += EndFoldTokens[i].Length;
                        columna = buffer.IndexOf(EndFoldTokens[i], columna);
                    }
                }

                Starters.Clear();
            }

            return list;
        }
    }
    /// <summary>
    /// The class to generate the foldings, it implements ICSharpCode.TextEditor.Document.IFoldingStrategy
    /// </summary>
    public class CSharpFoldingStrategy : IFoldingStrategy
    {
        /// <summary>
        /// Generates the foldings for our document.
        /// </summary>
        /// <param name="document">The current document.</param>
        /// <param name="fileName">The filename of the document.</param>
        /// <param name="parseInformation">Extra parse information, not used in this sample.</param>
        /// <returns>A list of FoldMarkers.</returns>
        public List<FoldMarker> GenerateFoldMarkers(IDocument document, string fileName, object parseInformation)
        {
            List<FoldMarker> list = new List<FoldMarker>();
            List<Point> Starters = new List<Point>();
            int linea, columna;
            List<string> StartFoldTokens = new List<string>();
            List<string> EndFoldTokens = new List<string>();
            string buffer, after_line;

            StartFoldTokens.Add("#region");
            EndFoldTokens.Add("#endregion");
            StartFoldTokens.Add("/*");
            EndFoldTokens.Add("*/");

            for (int i = 0; i < StartFoldTokens.Count; i++)
            {
                //primero buscar el folding de begin
                for (linea = 0; linea < document.TotalNumberOfLines; linea++)
                {
                    buffer = document.GetText(document.GetLineSegment(linea)).ToLower();
                    columna = 0;
                    columna = buffer.IndexOf(StartFoldTokens[i], columna);
                    while (columna >= 0)
                    {
                        Starters.Add(new Point(linea, columna));
                        columna += StartFoldTokens[i].Length;
                        columna = buffer.IndexOf(StartFoldTokens[i], columna);
                    }
                }

                //luego buscar el cierre de begin, ie end
                for (linea = 0; linea < document.TotalNumberOfLines; linea++)
                {
                    buffer = document.GetText(document.GetLineSegment(linea)).ToLower();
                    columna = 0;
                    columna = buffer.IndexOf(EndFoldTokens[i], columna);
                    while (columna >= 0)
                    {
                        //ahora a partir de aqui tengo que buscar el starter mas grande que este mas
                        //atras de este ender que encontre
                        for (int rev = Starters.Count - 1; rev >= 0; rev--)
                        {
                            if (Starters[rev].X > linea || (Starters[rev].X == linea && Starters[rev].Y > columna))
                                continue;
                            else
                            {
                                after_line = document.GetText(document.GetLineSegment(Starters[rev].X)).Substring(Starters[rev].Y);
                                if (after_line.Length > StartFoldTokens[i].Length)
                                    after_line = after_line.Substring(StartFoldTokens[i].Length).Trim();
                                else
                                    after_line = "...";
                                list.Add(new FoldMarker(document, Starters[rev].X, Starters[rev].Y + StartFoldTokens[i].Length, linea, columna, FoldType.Region, after_line, false));
                                Starters.RemoveAt(rev);
                                break;
                            }
                        }
                        columna += EndFoldTokens[i].Length;
                        columna = buffer.IndexOf(EndFoldTokens[i], columna);
                        if (Starters.Count == 0)
                            break;
                    }
                }

                Starters.Clear();
            }

            return list;
        }
        public List<FoldMarker> GenerateFoldMarkers(IDocument document, string fileName, object parseInformation, string StartFoldToken, string EndFoldToken)
        {
            List<string> AuxIni = new List<string>();
            List<string> AuxFin = new List<string>();
            AuxIni.Add(StartFoldToken);
            AuxFin.Add(EndFoldToken);
            return GenerateFoldMarkers(document, fileName, parseInformation, AuxIni, AuxFin);
        }
        public List<FoldMarker> GenerateFoldMarkers(IDocument document, string fileName, object parseInformation, List<string> StartFoldTokens, List<string> EndFoldTokens)
        {
            List<FoldMarker> list = new List<FoldMarker>();
            List<Point> Starters = new List<Point>();
            int linea, columna, FoldingCouples;
            string buffer, after_line;

            if (StartFoldTokens == null || EndFoldTokens == null || StartFoldTokens.Count == 0 || EndFoldTokens.Count == 0)
                return list;
            FoldingCouples = Math.Min(StartFoldTokens.Count, EndFoldTokens.Count);
            for (int i = 0; i < FoldingCouples; i++)
            {
                //primero buscar inicio, el clave de inicio de codefolding, 
                for (linea = 0; linea < document.TotalNumberOfLines; linea++)
                {
                    buffer = document.GetText(document.GetLineSegment(linea)).ToLower();
                    columna = 0;
                    columna = buffer.IndexOf(StartFoldTokens[i], columna);
                    while (columna >= 0)
                    {
                        Starters.Add(new Point(linea, columna));
                        columna += StartFoldTokens[i].Length;
                        columna = buffer.IndexOf(StartFoldTokens[i], columna);
                    }
                }

                //luego buscar el cierre del codefolding
                for (linea = 0; linea < document.TotalNumberOfLines; linea++)
                {
                    buffer = document.GetText(document.GetLineSegment(linea)).ToLower();
                    columna = 0;
                    columna = buffer.IndexOf(EndFoldTokens[i], columna);
                    while (columna >= 0)
                    {
                        //ahora a partir de aqui tengo que buscar el starter mas avanzado que este mas
                        //atras de este ender que encontre
                        for (int rev = Starters.Count - 1; rev >= 0; rev--)
                        {
                            if (Starters[rev].X > linea || (Starters[rev].X == linea && Starters[rev].Y > columna))
                                continue;
                            else
                            {
                                after_line = document.GetText(document.GetLineSegment(Starters[rev].X)).Substring(Starters[rev].Y);
                                if (after_line.Length > StartFoldTokens[i].Length)
                                    after_line = after_line.Substring(StartFoldTokens[i].Length).Trim();
                                else
                                    after_line = "...";
                                list.Add(new FoldMarker(document, Starters[rev].X, Starters[rev].Y + StartFoldTokens[i].Length, linea, columna, FoldType.Region, after_line, false));
                                Starters.RemoveAt(rev);
                                break;
                            }
                        }
                        columna += EndFoldTokens[i].Length;
                        columna = buffer.IndexOf(EndFoldTokens[i], columna);
                    }
                }

                Starters.Clear();
            }

            return list;
        }
    }
}

