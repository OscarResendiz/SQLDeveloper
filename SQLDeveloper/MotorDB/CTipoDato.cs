using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorDB
{
    public enum TIPO_LONGITUD
    {
        OBLIGATORIO,
        OPCIONAL,
        NOREQUERIDO
    }
    public class CTipoDato: CObjeto
    {
        public TIPO_LONGITUD UsaLongitud
        {
            get;
            set;
        }
        public CTipoDato()
        {
            Tipo = EnumTipoObjeto.TIPEDATA;
        }
        public CTipoDato(string nombre, TIPO_LONGITUD usalong)
        {
            Nombre = nombre;
            UsaLongitud = usalong;
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
