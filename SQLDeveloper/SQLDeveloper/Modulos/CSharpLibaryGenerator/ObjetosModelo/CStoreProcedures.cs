using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.CSharpLibaryGenerator
{
    public class CStoreProcedures
    {
        private string FObjetoRegreso;
        public int ID_Store
        {
            get;
            set;
        }
        public string Nombre
        {
            get;
            set;
        }
        public int ID_Conexion
        {
            get;
            set;
        }
        public int ID_Class
        {
            get;
            set;
        }
        public string ObjetoRegreso
        {
            get
            {
                if (FObjetoRegreso == "")
                    FObjetoRegreso = Nombre.Trim() + "Result";
                return FObjetoRegreso;
            }
            set
            {
                FObjetoRegreso = value;
            }
        }
        public bool Simple
        {
            get;
            set;
        }
    }
}
