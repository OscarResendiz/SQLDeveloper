using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SintaxColor
{
    public delegate void PropertyNameChangeEvent(CProperty sender,string nombre);
    public class CProperty:CObjetoBase
    {
        public event PropertyNameChangeEvent PropertyNameChange;
        private string Fname;
        public string name
        {
            get
            {
                return Fname;
            }
            set
            {
                Fname = value;
                if (PropertyNameChange != null)
                    PropertyNameChange(this, Fname);
            }
        }
        public string value
        {
            get;
            set;
        }
        public void Load(string cadena)
        {
            name = ExtraeElemento(cadena, "name");
            value = ExtraeElemento(cadena, "value");
        }
        public void Save(StreamWriter sw)
        {
            sw.WriteLine("\t\t<Property name=\""+name+"\" value=\""+value+"\"/>");
        }
    }
}
