using System;
using System.Collections.Generic;
using System.Text;

namespace AnalizadorLexico
{
    public delegate void  OnErrorEvent(string msg);
    class CNodo
    {
        public event OnErrorEvent OnError;
        private CNodo Izquierdo;
        private CNodo Derecho;
        public string Dato;
        public CNodo(string dato)
        {
            Dato = dato;
        }
        private void OnErrorHadle(string msg)
        {
            if (OnError != null)
                OnError(msg);
        }
        public void Add(string s)
        {
            string t = s.ToLower().Trim();
            //esta en el mismo estado que yo
            //por lo que comparo el caracter para saber a donde le corresponde ir
            if (Dato== t)
            {
                if (OnError != null)
                    OnError("Item repetido " + Dato);
                return;
            }
            if (Dato.CompareTo(t)>0)
            {
                //va a nodo izquierdo
                if (Izquierdo == null)
                {
                    Izquierdo = new CNodo(t);
                    Izquierdo.OnError += new OnErrorEvent(OnErrorHadle);
                    return;
                }
                Izquierdo.Add(t);
                return;
            }
            //va en el derecho
            if (Derecho == null)
            {
                Derecho = new CNodo(t);
                Derecho.OnError += new OnErrorEvent(OnErrorHadle);
                return;
            }
            Derecho.Add(t);
            return;
        }
        public bool EstaCOntenido(string sa)
        {
            string s = sa.ToLower().Trim();
            //busca el caracter y el estdo
            if (Dato == s)
            {
                //es el que tengo, por lo que lo regreso
                return true;
            }
            //busco en donde pueda estar
            //busco por el caracter
            if (Dato.CompareTo(s)>0)
            {
                //esta en el izquierdo
                if (Izquierdo == null)
                    return false; //no se encontro
                return Izquierdo.EstaCOntenido(s);
            }
            //esta en el derecho
            if (Derecho == null)
                return false;
            return Derecho.EstaCOntenido(s);
        }
    }
}
