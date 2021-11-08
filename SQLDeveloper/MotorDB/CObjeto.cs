using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorDB
{
    public enum EnumTipoObjeto
    {
        TABLE,
        VIEW,
        TRIGER,
        PROCEDURE,
        FUNCION,
        PRIMARYKEY,
        IDENTITY,
        UNIQUE,
        CHECK,
        FOREIGNKEY,
        INDEX,
        CAMPO,
        TIPEDATA,
        NONE,
        CODE,
        DATABSE,
        DEFAULT,
        TABLA_FUNCION,
        TYPE_TABLE

    }
    public class CObjeto
    {
        public String Nombre
        {
            get;
            set;
        }
        public EnumTipoObjeto Tipo
        {
            get;
            set;
        }
        public override string ToString()
        {
            return Nombre;
        }
        static public bool operator ==(CObjeto a, CObjeto b)
        {
            if (Object.ReferenceEquals(a, null))
            {
                return object.ReferenceEquals(b, null);
            }
            //posiblemente el segundo sea nulo
            if(object.ReferenceEquals(b, null))
            {
                return false;
            }
            if (a.Nombre != b.Nombre)
                return false;
            if (a.Tipo != b.Tipo)
                return false;
            return true;
        }
        static public bool operator !=(CObjeto a, CObjeto b)
        {
            return !(a == b);
        }
    }
}
