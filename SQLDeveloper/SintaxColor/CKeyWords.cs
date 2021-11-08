using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
namespace SintaxColor
{
    public delegate void OnKeyWordsNameChangeEvent(CKeyWords sender,string nombre);
    public class CKeyWords:CObjetoBase
    {
        public event OnKeyWordsNameChangeEvent OnKeyWordsNameChange;
        public CKeyWords()
        {
            Keys = new List<CKey>();
            Color = new CColor();

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
                Fname = value;
                if (OnKeyWordsNameChange != null)
                    OnKeyWordsNameChange(this, Fname);
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
        public CColor Color
        {
            get;
            set;
        }
        public List<CKey> Keys
        {
            get;
            set;
        }
        public void Add(CKey obj)
        {
            Keys.Add(obj);
        }
        public void Load(List<string>Lineas )
        {
            string linea = ExtraeLinea(Lineas, "KeyWords");
            name = ExtraeElemento(linea, "name");
            bold =bool.Parse( ExtraeElemento(linea, "bold"));
            italic = bool.Parse(ExtraeElemento(linea, "italic"));
            Color.Code = ExtraeElemento(linea, "color");
            foreach(string s in ExtraeLineas(Lineas,"Key "))
            {
                CKey obj = new CKey();
                obj.Load(s);
                Keys.Add(obj);
            }
        }
        public void Save(StreamWriter sw)
        {
            sw.WriteLine("\t\t\t<KeyWords name =\"" + name + "\" bold=\"" + bold.ToString().ToLower() + "\" italic = \"" + italic.ToString().ToLower() + "\" color=\"" + Color.Code + "\">");
            foreach(CKey obj in Keys)
            {
                obj.Save(sw);
            }
            sw.WriteLine("\t\t\t</KeyWords>");
        }
    }
}
