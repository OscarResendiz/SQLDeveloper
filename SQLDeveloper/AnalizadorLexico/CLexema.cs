using System;
using System.Collections.Generic;
using System.Text;

namespace AnalizadorLexico
{
    public class CLexema
    {
        public int Pos;
        public string cadena;
        public TIPO_LEX Tipo;
        public static bool operator ==(CLexema obj1,CLexema obj2)
        {
            //regresa true si son iguales.
            //caso especial si ambos son nulos regreso true
            if ((System.Object)obj1 == null && (System.Object)obj2 == null)
                return true;
            if ((System.Object)obj1 == null && (System.Object)obj2 != null)
                return false;
            if ((System.Object)obj1 != null && (System.Object)obj2 == null)
                return false;
            // se considera igual si son del mismo tipo y el texto es igual
            if(obj1.Tipo==obj2.Tipo && obj1.cadena==obj2.cadena)
                return true;
            return false;
        }
        public static bool operator !=(CLexema obj1, CLexema obj2)
        {
            //regresa true si son iguales.
            // se considera igual si son del mismo tipo y el texto es igual

            return !(obj1 == obj2);
        }
        public int Length
        {
            get
            {
                return cadena.Length;
            }
        }
        public override string ToString()
        {
            return "Pos=" + Pos.ToString() + "; Tipo=" + Tipo.ToString() + " Cadena=" + cadena;
        }
    }
}
