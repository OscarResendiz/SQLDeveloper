using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    public class CNodo
    {
        private bool Ultimo; //indica si es el ultimo nodo de la secuencia de la cadena
        public char Caracter; //almacena el caracter que le corresponde en la cadena
        private string Cadena; //almacena la cadena completa si y solo si es el ultimo nodo que la compone
        public bool Opener; //indica si el texto es un inciio de bloque
        public List<CNodo> Hijos;
        public int Posicion; //indica en que posision se encontro la coicidencia
        public bool Raiz;
        public CNodo()
        {
            Raiz = false; //por defualt no es la raiz
            Opener = false; //por default no lo es
            Ultimo = false; //por default no es el ultimo
        }
        public void Add(string cadena, bool opener, int pos = 0)
        {
            char c;
            if (cadena.Length  == pos)
            {
                //es el ultimo caracter de la cadena
                //asigno mis valores
                Cadena = cadena;
                Ultimo = true;
                Opener = opener;
                return;
            }
            //separa la cadena en componentes y la distribulle en el arbol
            if (Hijos == null)
                Hijos = new List<CNodo>();
            //me traigo el primer caracter de la cadena
             c = cadena[pos]; 
            //veo si ya existe el caracter
            foreach (CNodo n2 in Hijos)
            {
                if (n2.Caracter == c)
                {
                    //como ya esta, mando a insertar el resto de la cadena
                    n2.Add(cadena, opener, pos+1);
                    return;
                }
            }
            //no lo encontre, asi que lo agrego al arbol
            CNodo nodo = new CNodo();
            nodo.Caracter = c;
            Hijos.Add(nodo);
                nodo.Add(cadena, opener, pos + 1);
        }
        private bool esSeparador(char c)
        {
            switch (c)
            {
                case ' ':
                case '\n':
                case '\r':
                case '\t':
                    return true;
            }
            return false;
        }
        private bool EsMiCaracter(char c)
        {
            if (Caracter == ' ')
            {
                //es un separador
                if (esSeparador(c))
                {
                    return true;
                }
                else
                {
                    //se esperaba un separador, pero no lo es
                    return false;
                }
            }
            if (c == Caracter)
                return true;
            return false;
        }
        private CTocken CreaTocken(int pos)
        {
            CTocken obj = new CTocken();
            obj.Cadena = Cadena;
            obj.X = pos;
            obj.Y = 0;
            obj.Opener = Opener;
            return obj;

        }
        public CTocken Encuentra(string cadena, int pos)
        {
            char c;
            //pos indica desde que parte de la cadena hay que analizar
            #region Fin de cadena
            if (cadena.Length -1 == pos)
            {
                //es el ultimo caracter de la cadena
                c = cadena[pos];
                if (EsMiCaracter(c))
                {
                    //ya encontre el final de la cadena
                    //en teoria debe de coincidir con un nodo final
                    if (Ultimo)
                    {
                       if(Cadena.Length==1)
                            return CreaTocken(pos );
                       else
                            return CreaTocken(pos - Cadena.Length + 1); //OK
                    }
                }
                //no coincide con la cadena buscada
                return null;
            }
            #endregion
            //me traigo el caracter
            c = cadena[pos];
            #region No es raiz
            if (Raiz == false)
            {
                //no soy la raiz, por lo que tengo que comparar el caracter con el de la cadena
                if (EsMiCaracter(c))
                {
                    if(Ultimo)
                    {
                        // es el ultimo nodo y ya macheo
                        if (c == ' ')
                        {
                            if (Hijos != null)
                            {
                                foreach (CNodo nodo in Hijos)
                                {
                                    CTocken obj = nodo.Encuentra(cadena, pos + 1);
                                    if (obj != null)
                                    {
                                        //ya lo encontro, por lo que ya no busco mas
                                        return obj;
                                    }
                                }
                            }
                            return CreaTocken(pos - Cadena.Length + 1);//(pos - 1);
                        }
                        else
                        {
                            //posiblemente tenga mas hijos
                            if (Hijos != null)
                            {
                                foreach (CNodo nodo in Hijos)
                                {
                                    CTocken obj = nodo.Encuentra(cadena, pos + 1);
                                    if (obj != null)
                                    {
                                        //ya lo encontro, por lo que ya no busco mas
                                        return obj;
                                    }
                                }
                            }
                            if (Cadena.Length == 1)
                                return CreaTocken(pos);
                            else
                                return CreaTocken(pos - Cadena.Length + 1);
                        }
                    }
                    //si es mi caracter, por lo que busco en mis nodos hijos
                    foreach (CNodo nodo in Hijos)
                    {
                        CTocken obj = nodo.Encuentra(cadena, pos + 1);
                        if (obj != null)
                        {
                            //ya lo encontro, por lo que ya no busco mas
                            return obj;
                        }
                    }
                }
                else
                {
                    if (Ultimo && Caracter == ' ' && char.IsLetter(c) == false)
                    {
                        //espero un separador, pero posiblemente sea algun otro caracter
                        //no es una letra, por lo que lo acepto
                        return CreaTocken(pos - Cadena.Length + 1);// (pos -1);
                    }
                    //no es mi caracter, por lo que ya no sigo la busqueda
                    return null;
                }
            }
            #endregion
            #region Busqueda Normal
            //busca la cadena en el arbol
            foreach (CNodo nodo in Hijos)
            {
                CTocken obj = nodo.Encuentra(cadena, pos );
                if (obj != null)
                {
                    //ya lo encontro, por lo que ya no busco mas
                    return obj;
                }
            }
            //como no lo encontre entre los hijos regreso nulo
            return null;
            #endregion
        }
    }
}
