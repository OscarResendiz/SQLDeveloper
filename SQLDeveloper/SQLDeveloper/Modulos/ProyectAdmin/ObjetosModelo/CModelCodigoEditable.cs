using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.ProyectAdmin
{
    public class CModelCodigoEditable
    {
        public int ID_Objeto
        {
            get;
            set;
        }
        public DateTime Fecha
        {
            get;
            set;
        }
        public string Nombre
        {
            get;
            set;
        }
        public string Codigo
        {
            get;
            set;
        }
        public string Comentarios
        {
            get;
            set;
        }
    }
}
