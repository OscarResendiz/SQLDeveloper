using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SintaxColor
{
    public class CProperties:CObjetoBase
    {
        public CProperties()
        {
            Properties = new List<CProperty>();
        }
        public List<CProperty> Properties
        {
            get;
            set;
        }
        public void Load(List<string> lineas)
        {
            foreach (string s in ExtraeLineas(lineas, "Property"))
            {
                CProperty obj = new CProperty();
                obj.Load(s);
                Properties.Add(obj);
            }
        }
        public void Save(StreamWriter sw)
        {
            sw.WriteLine("\t<Properties>");
            foreach(CProperty obj in Properties)
            {
                obj.Save(sw);
            }
            sw.WriteLine("\t</Properties>");
        }
    }
}
