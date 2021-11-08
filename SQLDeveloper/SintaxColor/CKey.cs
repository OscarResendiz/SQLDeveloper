using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SintaxColor
{
    public class CKey:CObjetoBase
    {
        public string Word
        {
            get;
            set;
        }
        public void Load(string cadena)
        {
            Word = ExtraeElemento(cadena, "word");
        }
        public void Save(StreamWriter sw)
        {
            sw.WriteLine("\t\t\t\t<Key word = \""+Word+"\" />");
        }
        public override string ToString()
        {
            return Word;
        }
    }
}
