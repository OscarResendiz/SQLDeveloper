using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.Herramientas.GestorColors
{
    public class CFileName
    {
        private string FFileName;
        private string FShortFileName;
        public string FileName
        {
            get
            {
                return FFileName;
            }
            set
            {
                FFileName = value;
                if (FFileName == "")
                {
                    FShortFileName = "";
                    return;
                }
                int posExtencion = FFileName.LastIndexOf(".");
                int posBarra = FFileName.LastIndexOf("\\")+1;
                FShortFileName = FFileName.Substring(posBarra, posExtencion - posBarra);
            }
        }
        public string ShortFileName
        {
            get
            {
                return FShortFileName;
            }
        }
        public override string ToString()
        {
            return FShortFileName;
        }
    }
}
