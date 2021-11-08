using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.Buscador
{
    public enum OPERADOR
    {
        AND
        ,OR
        ,NOT
        ,NONE
    };
 
    public class CFiltro : MotorDB.CTipoBusqueda
    {
        public  CFiltro()
        {
            operador = OPERADOR.NONE;
        }
        public  CFiltro(string cadena, MotorDB.EnumTipoObjeto tipo,OPERADOR oper)
        {
            Cadena = cadena;
            Tipo = tipo;
            operador = oper;
        }
        public OPERADOR operador
        {
            get;
            set;
        }
        static public bool operator==(CFiltro a,CFiltro b)
        {
            if(Object.ReferenceEquals(a,null))
            {
                return object.ReferenceEquals(b, null);
            }
            if (object.ReferenceEquals(b, null))
            {
                return false;
            }
            if (a.Cadena != b.Cadena)
                return false;
            if (a.operador != b.operador)
                return false;
            if (a.Tipo != b.Tipo)
                return false;
            return true;
        }
        static public bool operator !=(CFiltro a, CFiltro b)
        {
            return !(a == b);
        }
        public override string ToString()
        {
            string s="";
            switch(operador )
            {
                case OPERADOR.AND:
                    s = "Y ";
                    break;
                case OPERADOR.NONE:
                    s = "";
                    break;
                case OPERADOR.NOT:
                    s = "Excepto ";
                    break;
                case OPERADOR.OR:
                    s = "O ";
                    break;
            }
            switch(Tipo)
            {
                case MotorDB.EnumTipoObjeto.NONE:
                    s+="Todos;";
                    break;
                case MotorDB.EnumTipoObjeto.TABLE:
                    s+="Tablas;";
                    break;
                case MotorDB.EnumTipoObjeto.TYPE_TABLE:
                    s+="Type Table;";
                    break;
                case MotorDB.EnumTipoObjeto.VIEW:
                    s+="Vistas;";
                    break;
                case MotorDB.EnumTipoObjeto.PROCEDURE:
                    s+="Procediientos almacenados;";
                    break;
                case MotorDB.EnumTipoObjeto.FUNCION:
                    s+="Funciones;";
                    break;
                case MotorDB.EnumTipoObjeto.TRIGER:
                    s+="Triggers;";
                    break;
                case MotorDB.EnumTipoObjeto.CAMPO:
                    s+="Campos en objetos;";
                    break;
                case MotorDB.EnumTipoObjeto.CODE:
                    s+="En el codigo;";
                    break;
            }
                
            s += "\"" + Cadena+"\"";
            return s;
        }
    }
}
   