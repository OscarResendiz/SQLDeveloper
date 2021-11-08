using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AnalizadorLexico;
//using AnalizadorLexico;

namespace SQLDeveloper.Modulos.Comparador
{
    public class CLineComparerLex : CLineComparer
    {
        private List<AnalizadorLexico.CLexema> Lexemas1;
        private List<AnalizadorLexico.CLexema> Lexemas2;
        private List<AnalizadorLexico.CLexema>  SeparaCadena(string cadena )
        {
            //separa la cadena en lexemas y lo almacena en la lista
            AnalizadorLexico.CAnaLex analizador = new AnalizadorLexico.CAnaLex();
            AnalizadorLexico.CLexema obj = null;
            List<AnalizadorLexico.CLexema> l = new List<AnalizadorLexico.CLexema>();
            analizador.Texto = cadena;
            do
            {
                obj = analizador.DameItem();
                if (obj != null)
                {
                    l.Add(obj);
                }
            }
            while (obj != null);
            return l;
        }
        private CSincronizado SinclonizaLex(List<AnalizadorLexico.CLexema>s1,List<AnalizadorLexico.CLexema>s2,int pos1, int pos2)
        {
            //recorre pos2 hasta encontrar donde se sincronizan las cadenas
            // si no se sinconizan regresa -1 y la posicion conde se sincroniza s2
            int conteo = 0;
            int pos = -1;
            //recorre pos2 hasta que se sincronice
            do
            {
                pos2++;
            }
            while (pos2 < s2.Count() && s1[pos1] != s2[pos2]);
            //en este punto una de dos tengo sincronizado el siguiente caracter o llegue al final de la linea
            if (pos2 == s2.Count())
            {
                //llegue al final de la linea, por lo que no encontre donde se sincroniza
                return null;
            }
            pos = pos2; //guardo donde se comeso a sincronizar
            //ahora cuento cuantos lexemas coinciden
            do
            {
                if (s1[pos1] == s2[pos2])
                    conteo++;
                //incremento ambos indices
                pos1++;
                pos2++;
            }
            while (pos1 < s1.Count() && pos2 < s2.Count()&& s1[pos1] == s2[pos2]);
            //veo cuantos coincidieron
            if (conteo >= 1)
            {
                //si coincidieron por lo meos 1 regreso la posicion
                CSincronizado obj = new CSincronizado();
                obj.Posicion = pos;
                obj.Coincidencias = conteo;
                return obj;
            }
            //como no se encontraron las coincidencias, regreso -1;
            return null;
        }
        public override int Compara()
        {
            //separo las cadenas en lexemas
            Lexemas1 = SeparaCadena(FLinea1);
            Lexemas2 = SeparaCadena(FLinea2);
            Tam1 = Lexemas1.Count();
            Tam2 = Lexemas2.Count;
            //ahora comienzo a comparar los lexemas
            //regresa un % de diferencia
            //de entrada calculo los caracteres que son diferentes por el tamaño de la cadena
            Diferentes = Math.Abs(Tam1 - Tam2);
            //caso especial
            if (Tam1 == 0 || Tam2 == 0)
            {
                if (Iguales == 0 && Diferentes == 0)
                    return 0;
                //regreso el % por que no se pueden analizar
                return Iguales * 100 / (Iguales + Diferentes);
            }
            //segundo caso especial: solo hay un separador de un solo lado 
            //if (Tam1 == 1&& Lexemas1[0].Tipo== TIPO_LEX.SEPARADOR & Tam2 >= 2)
            //{
            //    //regreso el % por que no se pueden analizar
            //    return Iguales * 100 / (Iguales + Diferentes);
            //}
            //if (Tam2 == 1 && Lexemas2[0].Tipo == TIPO_LEX.SEPARADOR & Tam1>= 2)
            //{
            //    //regreso el % por que no se pueden analizar
            //    return Iguales * 100 / (Iguales + Diferentes);
            //}

            
            //comienso a recorrer las dos cadenas y comparar caracter por caracter
            Pos1 = 0;
            Pos2 = 0;
            do
            {
                if (Lexemas1[Pos1] == Lexemas2[Pos2])
                {
                    //ambas letras son iguales
                    //incremento el contador de iguales
                    Iguales++;
                    //y paso a comprar los demas caracteres
                    Pos1++;
                    Pos2++;
                }
                else
                {
                    //son diferentes. veo si hay alguna parte en ambas cadenas donde se sincronizan
                    CSincronizado s1 = SinclonizaLex(Lexemas1, Lexemas2, Pos1, Pos2);
                    CSincronizado s2 = SinclonizaLex(Lexemas2, Lexemas1, Pos2, Pos1);
                    //hay 4 opciones
                    //00
                    //01
                    //10
                    //11
                    //00
                    if (s1 == null && s2 == null)
                    {
                        //no se encontro ninguna coincidencia
                        //marco la diferencia en ambos caracteres
                        Diferentes++;
                        CRangoDiferencia dif = new CRangoDiferencia();
                        dif.Inicio1 = Lexemas1[Pos1].Pos;
                        dif.Longitud1 = Lexemas1[Pos1].Length;
                        dif.Inicio2 = Lexemas2[Pos2].Pos;
                        dif.Longitud2 = Lexemas2[Pos2].Length;
                        Lista.Add(dif);
                        Pos1++;
                        Pos2++;
                    }
                    //01
                    if (s1 == null && s2 != null)
                    {
                        //la cadena 2 se sincroniza mas adelante en la cadena1, 
                        //por lo que la diferencia entre ambos indices se suman a las diferencias
                        do
                        {
                            Diferentes += Math.Abs(s2.Posicion - Pos1);
                            //agrego la diferencia
                            CRangoDiferencia dif = new CRangoDiferencia();
                            dif.Inicio1 = Lexemas1[Pos1].Pos;// Pos1
                            //                        dif.Longitud1 = Math.Abs(Lexemas2[s2.Posicion].Pos - Lexemas1[Pos1].Pos); ;
                            dif.Longitud1 = Lexemas1[Pos1].Length;// Math.Abs(Lexemas2[Pos2].Length - Lexemas1[Pos1].Length); 
                            Lista.Add(dif);
                            Pos1++;
                        }
                        while (Pos1 < s2.Posicion);   //asigno el indice en pos2 para que continue con la comparacion
                    }
                    //10
                    if (s1 != null && s2 == null)
                    {
                        //la cadena 1 se sincroniza mas adelante en la cadena2
                        //calculo la diferencia
                        do
                        {
                            Diferentes += Math.Abs(s1.Posicion - Pos2);
                            CRangoDiferencia dif = new CRangoDiferencia();
                            dif.Inicio2 = Lexemas2[Pos2].Pos;
                            dif.Longitud2 = Lexemas2[Pos2].Length;// Math.Abs(Lexemas1[Pos1].Length - ); 
                            Lista.Add(dif);
                            Pos2++;
                        }
                        while (Pos2 < s1.Posicion);  //asigno el indice
                    }
                    //11
                    if (s1 != null && s2 != null)
                    {
                        //ambas se sincronizan mas adelante,
                        //tomo como bueno el que se sincronice antes
                        if (s1.Coincidencias > s2.Coincidencias)
                        {
                            //se sincroniza primero s1
                            do
                            {
                                Diferentes += Math.Abs(s1.Posicion - Pos2);
                                CRangoDiferencia dif = new CRangoDiferencia();
                                dif.Inicio2 = Lexemas2[Pos2].Pos;
                                dif.Longitud2 = Lexemas2[Pos2].Length;// Math.Abs(Lexemas1[s1.Posicion].Length - ); 
                                Lista.Add(dif);
                                Pos2++;
                            }
                            while (Pos2 < s1.Posicion);
                            //asigno el indice

                        }
                        else
                        {
                            //se sincroniza primero la cadena2
                            do
                            {
                                Diferentes += Math.Abs(s2.Posicion - Pos1);
                                CRangoDiferencia dif = new CRangoDiferencia();
                                dif.Inicio1 = Lexemas1[Pos1].Pos;
                                dif.Longitud1 = Lexemas1[Pos1].Length;// Math.Abs(Lexemas2[Pos2].Length- ); 
                                Lista.Add(dif);
                                Pos1++;
                            }
                            while (Pos1 < s2.Posicion);     //asigno el indice en pos2 para que continue con la comparacion
                        }
                    }

                }
            }
            while (Pos2 < Tam2 && Pos1 < Tam1);
            //veo si hay diferencia en el numero items
            //si hay diferencias en longitud
            //uno de los dos forzosamente llego al final de la cadena y el otro le falta
            if (Pos1 < Tam1)
            {
                //la cadena 1 tiene items por recorrer
                do
                {
                    CRangoDiferencia dif = new CRangoDiferencia();
                    dif.Inicio1 = Lexemas1[Pos1].Pos;
                    dif.Longitud1 = Lexemas1[Pos1].Length;
                    Lista.Add(dif);
                    Pos1++;
                }
                while (Pos1 < Tam1);
            }
            if (Pos2 < Tam2)
            {
                //la cadena 1 tiene items por recorrer
                do
                {
                    CRangoDiferencia dif = new CRangoDiferencia();
                    dif.Inicio2 = Lexemas2[Pos2].Pos;
                    dif.Longitud2 = Lexemas2[Pos2].Length;
                    Lista.Add(dif);
                    Pos2++;
                }
                while (Pos2 < Tam2);
            }
            //ya termine de comparar ambas cadena y ahora calculo el porcentaje de diferencia
            return Iguales * 100 / (Iguales + Diferentes);
        }
    }
}
