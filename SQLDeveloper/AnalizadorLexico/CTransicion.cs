using System;
using System.Collections.Generic;
using System.Text;

namespace AnalizadorLexico
{
    class CTransicion
    {
        public  int Estado;
        public int Sigiente;
        public bool Aceptar;
        public bool Avansar;
        public char Caracter;
        public TIPO_LEX Tipo;
        public CTransicion(int estado, int siguiente, bool aceptar, bool avansar,char caracter,TIPO_LEX tipo)
        {
            Estado = estado;
            Sigiente = siguiente;
            Aceptar = aceptar;
            Avansar = avansar;
            Caracter = caracter;
            Tipo = tipo;
        }
    }
}
