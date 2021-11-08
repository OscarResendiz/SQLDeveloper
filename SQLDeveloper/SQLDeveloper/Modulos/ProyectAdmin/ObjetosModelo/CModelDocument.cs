using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.ProyectAdmin
{
    public class CModelDocument
    {
        public CModelDocument()
        {
            ID_Document = 0;
            ID_Conexion = 0;
            ID_Carpeta = 0;
            Nombre = "Sin Nombre";
        }
        public int ID_Document
        {
            get;
            set;
        }
        public int ID_Conexion
        {
            get;
            set;
        }
        public int ID_Carpeta
        {
            get;
            set;
        }
        public string Nombre
        {
            get;
            set;
        }
    }
}
