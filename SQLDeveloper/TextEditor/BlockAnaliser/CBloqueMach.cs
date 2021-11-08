using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    public class CBloqueMach
    {
        public CBloqueMach()
        {
            UseTextLine = false;
            MinimumLength = 0;
        }
        public CBloqueMach(string inicio, string fin, string textoRemplazo, bool useTextLine = false, int minimumLength = 0, bool apliaTabulador=false)
        {
            InicioMatch = inicio;
            FinMatch = fin;
            TextoRemplazo = textoRemplazo;
            UseTextLine = useTextLine;
            MinimumLength = minimumLength;
            ApliaTabulador = apliaTabulador;
        }
        public string InicioMatch
        {
            get;
            set;
        }
        public string FinMatch
        {
            get;
            set;
        }
        public string TextoRemplazo
        {
            get;
            set;
        }
        public bool UseTextLine
        {
            get;
            set;
        }
        public int MinimumLength
        {
            get;
            set;
        }
        public bool HaceMatch(CTocken obj1, CTocken obj2)
        {
            if (obj1 == null || obj2 == null)
                return false;
            //caso especial si son cadenas
            if ((obj1.Cadena.Trim() == "\'" && obj2.Cadena.Trim() == "\'") || (obj1.Cadena.Trim() == "\"" && obj2.Cadena.Trim() == "\""))
            {
                if (obj1.Cadena.ToLower().Trim() != InicioMatch.ToLower().Trim() || obj2.Cadena.ToLower().Trim() != FinMatch.ToLower().Trim())
                    return false;
                obj2.X += obj2.Cadena.Trim().Length;
                obj1.AplicaTabulador = ApliaTabulador;
                return true;
            }
            if (obj1.Opener == false)
                return false;
            if (obj2 == null)
                return false;
            if (obj2.Opener == true)
                return false;
            if (obj1.Cadena.ToLower().Trim() != InicioMatch.ToLower().Trim()|| obj2.Cadena.ToLower().Trim() != FinMatch.ToLower().Trim())
                return false;
            obj2.X += obj2.Cadena.Trim().Length;
            obj1.AplicaTabulador = ApliaTabulador;
            return true;

        }
        public string GetCadena(CTocken obj1, CTocken obj2, string buffer)
        {
            int i = 0;
            if (UseTextLine)
            {
                //hay que regresar el texto de la caneda
                if (buffer.Length > obj1.X + obj1.Cadena.Trim().Length + 1)
                {
                    return buffer.Substring(obj1.X + obj1.Cadena.Trim().Length + 1);
                }
            }
            if(MinimumLength>0)
            {
                //tiene una restriccion de un minimo de caracteres entre el inicio y el final
                if (obj1.Y == obj2.Y)
                {
                    if (obj2.X - obj1.X <= MinimumLength)
                        return ""; // una cadena vacia indica que no hay que tomarla en cuenta
                }
            }
            if (obj1.Cadena == "\'")
                i++;
            return TextoRemplazo;
        }
        public bool ApliaTabulador
        {
            get;
            set;
        }
    }
}
