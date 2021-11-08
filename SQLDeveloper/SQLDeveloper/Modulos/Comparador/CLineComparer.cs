using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.Comparador
{
    public class CLineComparer
    {
        protected List<CRangoDiferencia> Lista;
        protected int Pos1;
        protected int Pos2;
        protected string FLinea1;
        protected string FLinea2;
        protected int Tam1;
        protected int Tam2;
        protected int Minimo;
        protected int Iguales;
        protected int Diferentes;
        public CLineComparer()
        {
            Iguales = 0;
            Diferentes = 0;
            FLinea1 = "";
            FLinea2 = "";
            Tam1 = 0;
            Tam2 = 0;
            Lista = new List<CRangoDiferencia>();
        }
        public string Linea1
        {
            get
            {
                return FLinea1;
            }
            set
            {
                FLinea1 = value;
                if (CaseSencibity == false)
                    FLinea1 = FLinea1.ToUpper();
                Tam1 = FLinea1.Length;
                if (Tam1< Tam2)
                    Minimo = Tam1;
                else
                    Minimo = Tam2;
            }
        }
        public string Linea2
        {
            get
            {
                return FLinea2;
            }
            set
            {
                FLinea2 = value;
                if (CaseSencibity == false)
                    FLinea2 = FLinea2.ToUpper();
                Tam2 = FLinea2.Length;
                if (Tam2 < Tam1)
                    Minimo = Tam2;
                else
                    Minimo = Tam1;
            }
        }
        public bool CaseSencibity
        {
            get;
            set;
        }
        private CSincronizado Sincloniza(string s1, string s2, int pos1, int pos2)
        {
            //recorre pos2 hasta encontrar donde se sincronizan las cadenas
            // si no se sinconizan regresa -1 y la posicion conde se sincroniza s2
            int conteo = 0;
            int pos = -1;
            do
            {
                pos2++;
            }
            while (pos2 < s2.Length && s1[pos1] != s2[pos2]);
            //en este punto una de dos tengo sincronizado el siguiente caracter o llegue al final de la linea
            if(pos2==s2.Length)
            {
                //llegue al final de la linea, por lo que no encontre donde se sincroniza
                return null;
            }
            pos = pos2; //guardo donde se comeso a sincronizar
            //ahora cuento cuantos caracteres coinciden
            do
            {
                if (s1[pos1] == s2[pos2])
                    conteo++;
                //incremento ambos indices
                pos1++;
                pos2++;
            } 
            while (pos1 < s1.Length && pos2 < s2.Length && s1[pos1] == s2[pos2]);
            //veo cuantos coincidieron
            if(conteo>=3)
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
        private bool IgnonaCaracter(string l1, string l2, int p1,int p2)
            {
            //verifica si ignorando el caracter de la posicion actual, lodemas se sincroniza
            //incremento ambas posiciones
                p1++; p2++;
                int coincidencias = 0;
            while(l1.Length>p1 && l2.Length>p2 && l1[p1]==l2[p2])
            {
                coincidencias++;
                p1++;
                p2++;
            }
            //limite de coincidencias haceptables que para comenzar es 3
            return (coincidencias >= 3); 

        }
        public virtual int Compara()
        {
            if (FLinea1.Contains("END,") && FLinea2.Contains("END,"))
                Tam1 = Tam1;
            //regresa un % de diferencia
            //de entrada calculo los caracteres que son diferentes por el tamaño de la cadena
            Diferentes = Math.Abs(Tam1 - Tam2);
            //caso especial
            if(Tam1==0||Tam2==0)
            {
                if (Diferentes == 0)
                    return 90;
                //regreso el % por que no se pueden analizar
                return Iguales * 100 / (Iguales + Diferentes);
            }
            //comienso a recorrer las dos cadenas y comparar caracter por caracter
            Pos1 = 0;
            Pos2 = 0;
            do
            {
                if (FLinea1[Pos1] == FLinea2[Pos2])
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
                    if (IgnonaCaracter(FLinea1, FLinea2, Pos1, Pos2))
                    {
                        //marco la diferenci
                        Diferentes += 1;
                        CRangoDiferencia dif = new CRangoDiferencia();
                        dif.Inicio2 = Pos1;
                        dif.Longitud2 = 1;// Math.Abs(s1.Posicion - Pos2); ;
                        dif.Inicio1 = Pos1;
                        dif.Longitud1 = 1;
                        Lista.Add(dif);
                        //asigno el indice
                        Pos2 = Pos2 + 1;
                        Pos1 = Pos1 + 1;
                    }
                    else
                    {
                        //son diferentes. veo si hay alguna parte en ambas cadenas donde se sincronizan
                        CSincronizado s1 = Sincloniza(FLinea1, FLinea2, Pos1, Pos2);
                        CSincronizado s2 = Sincloniza(FLinea2, FLinea1, Pos2, Pos1);
                        //hay 4 opciones
                        #region 0,0 no se encontro ninguna coincidencia
                        if (s1 == null && s2 == null)
                        {
                            //no se encontro ninguna coincidencia
                            //marco la diferencia en ambos caracteres
                            Diferentes++;
                            CRangoDiferencia dif = new CRangoDiferencia();
                            dif.Inicio1 = Pos1;
                            dif.Longitud1 = 1;
                            dif.Inicio2 = Pos2;
                            dif.Longitud2 = 1;
                            Lista.Add(dif);
                            Pos1++;
                            Pos2++;
                        }
                        #endregion
                        #region 0,1 la cadena 2 se sincroniza mas adelante en la cadena1,
                        if (s1 == null && s2 != null)
                        {
                            //la cadena 2 se sincroniza mas adelante en la cadena1, 
                            //por lo que la diferencia entre ambos indices se suman a las diferencias
                            Diferentes += Math.Abs(s2.Posicion - Pos1);
                            //agrego la diferencia
                            CRangoDiferencia dif = new CRangoDiferencia();
                            dif.Inicio1 = Pos1;
                            dif.Longitud1 = Math.Abs(s2.Posicion - Pos1); ;
                            Lista.Add(dif);
                            //asigno el indice en pos2 para que continue con la comparacion
                            Pos1 = s2.Posicion;
                        }
                        #endregion
                        #region 1,0 la cadena 1 se sincroniza mas adelante en la cadena2
                        if (s1 != null && s2 == null)
                        {
                            //la cadena 1 se sincroniza mas adelante en la cadena2
                            //calculo la diferencia
                            Diferentes += Math.Abs(s1.Posicion - Pos2);
                            CRangoDiferencia dif = new CRangoDiferencia();
                            dif.Inicio2 = Pos2;
                            dif.Longitud2 = Math.Abs(s1.Posicion - Pos2); ;
                            Lista.Add(dif);
                            //asigno el indice
                            Pos2 = s1.Posicion;
                        }
                        #endregion
                        #region 1,1 ambas se sincronizan mas adelante,
                        if (s1 != null && s2 != null)
                        {
                            //ambas se sincronizan mas adelante,
                            //tomo como bueno el que se sincronice antes
                            if (s1.Posicion < s2.Posicion)
                            {
                                //se sincroniza primero s1
                                Diferentes += Math.Abs(s1.Posicion - Pos2);
                                CRangoDiferencia dif = new CRangoDiferencia();
                                dif.Inicio2 = Pos2;
                                dif.Longitud2 = Math.Abs(s1.Posicion - Pos2); ;
                                Lista.Add(dif);
                                //asigno el indice
                                Pos2 = s1.Posicion;
                            }
                            else
                            {
                                //se sincroniza primero la cadena2
                                Diferentes += Math.Abs(s2.Posicion - Pos1);
                                CRangoDiferencia dif = new CRangoDiferencia();
                                dif.Inicio1 = Pos1;
                                dif.Longitud1 = Math.Abs(s2.Posicion - Pos1); ;
                                Lista.Add(dif);
                                //asigno el indice en pos2 para que continue con la comparacion
                                Pos1 = s2.Posicion;
                            }
                        }
                        #endregion
                    }
                }
            }
            while (Pos2 < Tam2 && Pos1 < Tam1);
            //ya termine de comparar ambas cadena y ahora calculo el porcentaje de diferencia
            if (Tam1 > Tam2)
            {
                CRangoDiferencia dif = new CRangoDiferencia();
                dif.Inicio1 = Pos1;
                dif.Longitud1 = Math.Abs(Tam1 - Pos1); ;
                Lista.Add(dif);
            }
            if (Tam2 > Tam1)
            {
                CRangoDiferencia dif = new CRangoDiferencia();
                dif.Inicio2 = Pos2;
                dif.Longitud2 = Math.Abs(Tam2 - Pos2); ;
                Lista.Add(dif);
            }
            return Iguales * 100 / (Iguales + Diferentes);
        }
        public List<CRangoDiferencia> GetDetalle()
        {
            return Lista;
        }
    }
    public class CSincronizado
    {
        public int Posicion
        {
            get;
            set;
        }
        public int Coincidencias
        {
            get;
            set;
        }
        public override string ToString()
        {
            return "Posicion=" + Posicion.ToString() + "; Coincidencias=" + Coincidencias.ToString();
        }
    }
}
