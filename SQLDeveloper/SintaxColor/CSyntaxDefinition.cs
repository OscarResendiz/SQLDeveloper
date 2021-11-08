using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SintaxColor
{
    public class CSyntaxDefinition : CObjetoBase
    {
        public CSyntaxDefinition()
        {
            Digits = new CDigits();
            RuleSet = new CRuleSet();
            Environment = new CEnvironment();
            Properties = new CProperties();
        }
        public string name
        {
            get;
            set;
        }
        public string extensions
        {
            get;
            set;
        }
        public CDigits Digits
        {
            get;
            set;
        }
        public CRuleSet RuleSet
        {
            get;
            set;
        }
        public CEnvironment Environment
        {
            get;
            set;
        }
        public CProperties Properties
        {
            get;
            set;
        }
        public void Load(List<string> lineas)
        {
            int n;
            name=ExtraeElemento(lineas[0],"name");
            extensions =ExtraeElemento(lineas[0],"extensions");
            //ahora separo toda la parte del Environment
            Environment.Load(SeparaLineas(lineas, "Environment", "/Environment",0,out n));
            //ahora separo las propertys
            Properties.Load(SeparaLineas(lineas, "Properties", "/Properties", 0,out n));
            //ahora cargo el Digits
            Digits.Load(ExtraeLinea(lineas, "Digits"));
            //ahora me traigo los RuleSets
            RuleSet.Load(SeparaLineas(lineas, "RuleSet", "/RuleSet", 0,out n));
        }
        public void Save(StreamWriter sw)
        {
            sw.WriteLine("<SyntaxDefinition name = \""+name+"\" extensions = \""+extensions+"\">");
            Environment.Save(sw);
            Properties.Save(sw);
            Digits.Save(sw);
            RuleSet.Save(sw);
            sw.WriteLine("</SyntaxDefinition>");
        }
    }
}
