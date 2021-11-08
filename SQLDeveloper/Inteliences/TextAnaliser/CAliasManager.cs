using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteliences
{
    public class CAliasManager
    {
        private List<CAlias> ListaAlias;
       public CAliasManager()
        {
            ListaAlias = new List<CAlias>();
        }
        /// <summary>
        /// agrega un alias a la lista
        /// </summary>
        /// <param name="tabla"></param>
        /// <param name="alias"></param>
        public void Add(Compiler.Lexer.Lexema tabla, Compiler.Lexer.Lexema alias)
        {
            //si no existe la combinacion la agrego
            foreach(CAlias obj in ListaAlias)
            {
                if (obj.Tabla.Texto.ToUpper().Trim() == tabla.Texto.ToUpper().Trim() && obj.Alias.Texto.ToUpper().Trim() == alias.Texto.ToUpper().Trim())
                    return; //ya existe
            }
            ListaAlias.Add(new CAlias()
            {
                Alias=alias,
                Tabla=tabla
            });
        }
        /// <summary>
        /// Busca las relaciones entre alias y regresa la tabla origen inclusibe si estan anidados
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        public List< Compiler.Lexer.Lexema> DameTablaOrigen(string alias)
        {
            List<Compiler.Lexer.Lexema> l = new List<Compiler.Lexer.Lexema>();
            foreach(CAlias obj in ListaAlias)
            {
                if (obj.Alias.Texto.ToUpper().Trim() == alias.ToUpper().Trim())
                {
                    bool agregados = false;
                    foreach(Compiler.Lexer.Lexema lex in DameTablaOrigen(obj.Tabla.Texto))
                    {
                        agregados = true;
                        l.Add(lex);
                    }
                    if(agregados==false)
                        l.Add(obj.Tabla);
                }
            }
            return l;
        }
        /// <summary>
        /// borra toda la lista de alias almacenada
        /// </summary>
        public void Clear()
        {
            ListaAlias.Clear();
        }
    }
}
