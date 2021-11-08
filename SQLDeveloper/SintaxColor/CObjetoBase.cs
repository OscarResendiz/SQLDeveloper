using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SintaxColor
{
    public class CObjetoBase
    {
        //solo va a contener cosas que sean comunes a todos como algunos metodos utiles
        protected List<string> SeparaLineas(List<string> lineas, string inicio, string final, int pos, out int pofin)
        {
            int i = pos;
            List<string> l = new List<string>();
            //busco el inicio
            while (i < lineas.Count && lineas[i].ToLower().Contains(inicio.ToLower()) == false)
                i++;
            while (i < lineas.Count && lineas[i].ToLower().Contains(final.ToLower()) == false)
            {
                l.Add(lineas[i]);
                i++;
            }
            pofin = i;
            return l;
        }
        protected string ExtraeElemento(string cadena,string elemento)
        {
            string s = "";
            //regresa el texto que corresponde a dicho elemcnto
            // se supone que se encuentra en la siguiente forma
            //elemento = "texto"
            int pos = cadena.ToLower().IndexOf(elemento.ToLower());
            if (pos == -1)
                return ""; //no lo encontre por lo que regreso una cadena vacia
            pos += elemento.Length;
            //ahora busco el inicio de la cadena
            while (cadena[pos] != '\"')
                pos++;
            //ya encontre el inicio de la cadena
            //ahora me traigo la cadena
            pos++; //para saltarme Lazy primer comilla
            while (cadena[pos] != '\"')
            {
                s = s + cadena[pos];
                pos++;
            }
            return s;

        }
        protected string ExtraeLinea(List<string> lineas, string cadena)
        {
            try
            {
                int pos = 0;
                while (lineas[pos].ToLower().Contains(cadena.ToLower()) == false)
                    pos++;
                return lineas[pos];
            }
            catch(System.Exception)
            {
                return "";
            }
        }
        protected List<string> ExtraeLineas(List<string> lineas, string cadena)
        {
            List<string> l = new List<string>();
            foreach(string s in lineas)
            {
                if(s.ToLower().Contains(cadena.ToLower()) == true)
                {
                    l.Add(s);
                }
            }
            return l;
        }
        protected string ExtraeTexto(string cadena,string inicio,string final)
        {
            if (cadena == "")
                return "";
            int pi=cadena.ToLower().IndexOf(inicio.ToLower());
            int pf=cadena.ToLower().IndexOf(final.ToLower());
            pi+=inicio.Length;
            string s = cadena.Substring(pi, pf - pi);
            return s;
        }
    }
}
