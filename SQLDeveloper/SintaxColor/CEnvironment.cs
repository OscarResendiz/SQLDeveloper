using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
namespace SintaxColor
{
    public class CEnvironment: CObjetoBase
    {
        public CEnvironment()
        {
            DefaultColor = new CColor();
            DefaultBgcolor = new CColor();
            VRulerColor = new CColor();
            SelectionBgcolor = new CColor();
            LineNumbersColor = new CColor();
            InvalidLinesColor = new CColor();
            EOLMarkersColor = new CColor();
            SpaceMarkersColor = new CColor();
            TabMarkersColor = new CColor();
            CaretMarkerColor = new CColor();
            FoldLineColor = new CColor();
            FoldLineBgcolor = new CColor();
            FoldMarkerColor = new CColor();
            FoldMarkerBgcolor = new CColor();
            LineNumbersBgcolor = new CColor();
        }
        public CColor DefaultColor
        {
            get;
            set;
        }
        public CColor DefaultBgcolor
        {
            get;
            set;
        }
        public CColor VRulerColor
        {
            get;
            set;
        }
        public CColor SelectionBgcolor
        {
            get;
            set;
        }
        public CColor LineNumbersColor
        {
            get;
            set;
        }
        public CColor LineNumbersBgcolor
        {
            get;
            set;
        }
        public CColor InvalidLinesColor
        {
            get;
            set;
        }
        public CColor EOLMarkersColor
        {
            get;
            set;
        }
        public CColor SpaceMarkersColor
        {
            get;
            set;
        }
        public CColor TabMarkersColor
        {
            get;
            set;
        }
        public CColor CaretMarkerColor
        {
            get;
            set;
        }
        public CColor FoldLineColor
        {
            get;
            set;
        }
        public CColor FoldLineBgcolor
        {
            get;
            set;
        }
        public CColor FoldMarkerColor
        {
            get;
            set;
        }
        public CColor FoldMarkerBgcolor
        {
            get;
            set;
        }
        public void Load(List<string> lineas)
        {
            string s=ExtraeLinea(lineas,"Default");
            DefaultColor.Code = ExtraeElemento(s, "color");
            DefaultBgcolor.Code = ExtraeElemento(s, "bgcolor");
            s = ExtraeLinea(lineas, "VRuler");
            VRulerColor.Code = ExtraeElemento(s, "color");
            s = ExtraeLinea(lineas, "Selection");
            SelectionBgcolor.Code = ExtraeElemento(s, "bgcolor");
            s = ExtraeLinea(lineas, "LineNumbers");
            LineNumbersColor.Code = ExtraeElemento(s, "color");
            LineNumbersBgcolor.Code = ExtraeElemento(s, "bgcolor");
            s = ExtraeLinea(lineas, "InvalidLines");
            InvalidLinesColor.Code = ExtraeElemento(s, "color");
            s = ExtraeLinea(lineas, "EOLMarkers");
            EOLMarkersColor.Code = ExtraeElemento(s, "color");
            s = ExtraeLinea(lineas, "SpaceMarkers");
            SpaceMarkersColor.Code = ExtraeElemento(s, "color");
            s = ExtraeLinea(lineas, "TabMarkers");
            TabMarkersColor.Code = ExtraeElemento(s, "color");
            s = ExtraeLinea(lineas, "CaretMarker");
            CaretMarkerColor.Code = ExtraeElemento(s, "color");
            s = ExtraeLinea(lineas, "FoldLine");
            FoldLineColor.Code = ExtraeElemento(s, "color");
            FoldLineBgcolor.Code = ExtraeElemento(s, "bgcolor");
            s = ExtraeLinea(lineas, "FoldMarker");
            FoldMarkerColor.Code = ExtraeElemento(s, "color");
            FoldMarkerBgcolor.Code = ExtraeElemento(s, "bgcolor");
        }
        public void Save(StreamWriter sw)
        {
            sw.WriteLine("\t<Environment>");
            sw.WriteLine("\t\t<Default      color=\""+DefaultColor.Code+"\" bgcolor=\""+DefaultBgcolor.Code+"\"/>");
            sw.WriteLine("\t\t<VRuler       color = \""+VRulerColor+"\"/>");
            sw.WriteLine("\t\t<Selection    bgcolor = \""+SelectionBgcolor+"\"/>");
            sw.WriteLine("\t\t<LineNumbers  color = \""+LineNumbersColor+"\" bgcolor = \"" + LineNumbersBgcolor + "\"/>");
            sw.WriteLine("\t\t<InvalidLines color = \""+InvalidLinesColor+"\"/>");
            sw.WriteLine("\t\t<EOLMarkers   color = \""+EOLMarkersColor+"\"/>");
            sw.WriteLine("\t\t<SpaceMarkers color = \""+SpaceMarkersColor+"\"/>");
            sw.WriteLine("\t\t<TabMarkers   color = \""+TabMarkersColor+"\"/>");
            sw.WriteLine("\t\t<CaretMarker  color = \""+CaretMarkerColor+"\"/>");
            sw.WriteLine("\t\t<FoldLine     color = \""+FoldLineColor+"\" bgcolor=\""+FoldLineBgcolor+"\"/>");
            sw.WriteLine("\t\t<FoldMarker   color = \""+FoldMarkerColor+"\" bgcolor=\""+FoldMarkerBgcolor+"\"/>");
            sw.WriteLine("\t</Environment>");
        }
    }
}
