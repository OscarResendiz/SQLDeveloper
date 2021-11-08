using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.CreadorTabla.Definicion
{
    public class Identidad
    {
        public static string TableName
        {
            get
            {
                return "Identidad";
            }
        }
        public static string NombreIdentidad
        {
            get
            {
                return "NombreIdentidad";
            }
        }
        public static string CamposTabla
        {
            get
            {
                return "CamposTabla";
            }
        }
        public static string ID_Tabla
        {
            get
            {
                return "ID_Tabla";
            }
        }
        public static string ValorInicial
        {
            get
            {
                return "ValorInicial";
            }
        }
        public static string Incremento
        {
            get
            {
                return "Incremento";
            }
        }
    }
}
