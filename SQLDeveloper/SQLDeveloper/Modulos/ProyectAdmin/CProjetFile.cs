using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.ProyectAdmin
{
    public class CProjetFile
    {
        public CProjetFile()
        {
            fecha = System.DateTime.Now;
        }
        public string FileName
        {
            get;
            set;
        }
        public string Path
        {
            get;
            set;
        }
        public DateTime fecha
        {
            get;
            set;
        }
    }
}
