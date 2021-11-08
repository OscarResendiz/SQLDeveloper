using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
namespace SintaxColor
{
    public delegate void OnSpanNameChangeEvent(CSpan sender, string nombre);
    public class CSpan : CObjetoBase
    {
        public event OnSpanNameChangeEvent OnSpanNameChange;
        public CSpan()
        {
            color = new CColor();
        }
        private string Fname;
        public string name
        {
            get
            {
                return Fname;
            }
            set
            {
                Fname=value;
                if (OnSpanNameChange != null)
                    OnSpanNameChange(this, Fname);
            }
        }
        public bool bold
        {
            get;
            set;
        }
        public bool italic
        {
            get;
            set;
        }
        public CColor color
        {
            get;
            set;
        }
        public bool stopateol
        {
            get;
            set;
        }
        public string Begin
        {
            get;
            set;
        }
        public string End
        {
            get;
            set;
        }
        public void Load(List<string> Lineas)
        {
            string cadena = ExtraeLinea(Lineas, "Span");
            name = ExtraeElemento(cadena, "name");
            bold = bool.Parse(ExtraeElemento(cadena, "bold"));
            italic = bool.Parse(ExtraeElemento(cadena, "italic"));
            color.Code = ExtraeElemento(cadena, "color");
            stopateol = bool.Parse(ExtraeElemento(cadena, "stopateol"));
            Begin = ExtraeTexto(ExtraeLinea(Lineas, "Begin"), "<Begin>", "</Begin>");
            End = ExtraeTexto(ExtraeLinea(Lineas, "End"), "<End>", "</End>");
        }
        public void Save(StreamWriter sw)
        {
            sw.WriteLine("\t\t\t<Span name =\"" + name + "\" bold =\"" + bold.ToString().ToLower() + "\" italic =\"" + italic.ToString().ToLower() + "\" color =\"" + color.Code + "\" stopateol =\"" + stopateol.ToString().ToLower() + "\">");
            sw.WriteLine("\t\t\t\t<Begin>"+Begin+"</Begin>");
            if(End!="")
            {
                sw.WriteLine("\t\t\t\t<End>"+End+"</End>");
            }
            sw.WriteLine("\t\t\t</Span>");
        }
    }
}
