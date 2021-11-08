using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
namespace SintaxColor
{
    public delegate void OnDigitsNameChangeEvent(CDigits sender, string nombre);
    public class CDigits:CObjetoBase
    {
        public event OnDigitsNameChangeEvent OnDigitsNameChange;
        private string Fname;
        public CDigits()
        {
            color = new CColor();
        }
        public string name
        {
            get
            {
                return Fname;
            }
            set
            {
                Fname = value;
                if (OnDigitsNameChange != null)
                    OnDigitsNameChange(this, Fname);
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
        public void Load(string linea)
        {
            name = ExtraeElemento(linea, "name");
            bold =bool.Parse( ExtraeElemento(linea, "bold"));
            italic =bool.Parse( ExtraeElemento(linea, "italic"));
            color.Code = ExtraeElemento(linea, "color");
        }
        public void Save(StreamWriter sw)
        {
            sw.WriteLine("\t<Digits name = \"" + name + "\" bold = \"" + bold.ToString().ToLower() + "\" italic = \"" + italic.ToString().ToLower() + "\" color=\"" + color + "\"/>");
        }
    }
}
