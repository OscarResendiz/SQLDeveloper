using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.CreadorTabla.Definicion
{
   public  class Refeneces
    {
        public static string TableName
        {
            get
            {
                return "Refeneces";
            }
        }
        public static string ID_FK
        {
            get
            {
                return "ID_FK";
            }
        }
        public static string CamposTablaPadre
        {
            get
            {
                return "CamposTablaPadre";
            }
        }
        public static string CampoHijo
        {
            get
            {
                return "CampoHijo";
            }
        }
    }
}
