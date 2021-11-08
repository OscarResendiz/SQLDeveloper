using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SintaxColor
{
    public class CRuleSet:CObjetoBase
    {
        public CRuleSet()
        {
            Spans = new List<CSpan>();
            KeyWords = new List<CKeyWords>();
        }
        public bool ignorecase
        {
            get;
            set;
        }
        public string Delimiters
        {
            get;
            set;
        }
        public List<CSpan> Spans
        {
            get;
            set;
        }
        public void AddSpan(CSpan obj)
        {
            Spans.Add(obj);
        }
        public List<CKeyWords> KeyWords
        {
            get;
            set;
        }
        public void AddKeyWords(CKeyWords obj)
        {
            KeyWords.Add(obj);
        }
        public void Load(List<string> Lineas)
        {
            ignorecase = bool.Parse(ExtraeElemento(ExtraeLinea(Lineas, "ignorecase"), "ignorecase"));
            Delimiters =ExtraeTexto( ExtraeLinea(Lineas, "Delimiters"),"<Delimiters>","</Delimiters>");
            int pos = 0;
            while (pos < Lineas.Count)
            {
                List<string> l = SeparaLineas(Lineas, "Span", "/Span", pos,out pos);
                if (l.Count > 0)
                {
                    CSpan obj = new CSpan();
                    obj.Load(l);
                    Spans.Add(obj);
//                    pos += l.Count;
                }
               else
                {
                    pos++;
                }
            }

            pos = 0;
            while(pos<Lineas.Count)
            {
                List<string> l = SeparaLineas(Lineas, "KeyWords", "/KeyWords", pos, out pos);
                if (l.Count > 0)
                {
                    CKeyWords obj = new CKeyWords();
                    obj.Load(l);
                    KeyWords.Add(obj);
//                    pos += l.Count;
                }
                else
                {
                    pos++;
                }
            }
        }
        public void Save(StreamWriter sw)
        {
            sw.WriteLine("\t<RuleSets>");
            sw.WriteLine("\t\t<RuleSet ignorecase = \"" + ignorecase.ToString().ToLower() + "\">");
            sw.WriteLine("\t\t\t<Delimiters>" + Delimiters + "</Delimiters>");
            foreach(CSpan obj in Spans)
            {
                obj.Save(sw);
            }
            foreach(CKeyWords obj in KeyWords)
            {
                obj.Save(sw);
            }
            sw.WriteLine("\t\t</RuleSet>");
            sw.WriteLine("\t</RuleSets>");
        }
    }
}
