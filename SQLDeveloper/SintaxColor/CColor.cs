using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace SintaxColor
{
    public class CColor
    {
        public string Code
        {
            get;
            set;
        }
        public Color Color
        {
            get
            {
                if (Code == "")
                    return Color.Black; //no tiene color
                try
                {
                    return System.Drawing.ColorTranslator.FromHtml(Code);
                }
                catch(System.Exception)
                {
                    return Color.Black;
                }
            }
            set
            {
                Code = "#" + value.R.ToString("X2") + value.G.ToString("X2") + value.B.ToString("X2");
            }
        }
        public override string ToString()
        {
            return Code;
        }
    }
}
