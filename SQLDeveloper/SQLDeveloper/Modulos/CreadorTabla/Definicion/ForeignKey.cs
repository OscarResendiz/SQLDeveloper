using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.CreadorTabla.Definicion
{
    public class ForeignKey
    {
        public static string TableName
        {
            get
            {
                return "ForeignKey";
            }
        }
        public static string ID_FK
        {
            get
            {
                return "ID_FK";
            }
        }
        public static string ID_AccionActualizar
        {
            get
            {
                return "ID_AccionActualizar";
            }
        }
        public static string ID_AccionBorrar
        {
            get
            {
                return "ID_AccionBorrar";
            }
        }
        public static string Nombre
        {
            get
            {
                return "Nombre";
            }
        }
        public static string ID_TablaPadre
        {
            get
            {
                return "ID_TablaPadre";
            }
        }
        public static string ID_TablaHija
        {
            get
            {
                return "ID_TablaHija";
            }
        }
    }
}
