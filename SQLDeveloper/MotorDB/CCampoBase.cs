using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorDB
{
   public class CCampoBase: CObjeto
    {
        public CCampoBase()
        {
            Tipo = EnumTipoObjeto.CAMPO;
        }
        [
          Category("Basico"),
           //          DefaultValue(45)
           Description("Tipo de dato que almacena el campo")
        ]
        public CTipoDato TipoDato
        {
            get;
            set;
        }
        [
          Category("Basico"),
           //          DefaultValue(45)
           Description("Tamaño del dato que se almacena")
        ]
        public int Longitud
        {
            get;
            set;
        }
        public string GetTipoString()
        {
            //regresa la definicion del tipo
            string s=TipoDato.Nombre;
            if (TipoDato.UsaLongitud== TIPO_LONGITUD.OBLIGATORIO)
                s += "(" + Longitud + ")";
            return s;
        }
    }
}
