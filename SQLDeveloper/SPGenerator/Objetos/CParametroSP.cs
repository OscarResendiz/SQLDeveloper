using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGenerator.Objetos
{
    /// <summary>
    /// Summary description for CParametroSP.
    /// </summary>
    public enum TIPO_FILTRO
    {
        IGUAL = 1,
        LIKE = 2,
        MAYOR_QUE = 3,
        MENOR_QUE = 4,
        MAYOR_IGUAL = 5,
        MENOR_IGUAL = 6,
        DIFERENTE = 7
    }
    public class CParametroSP
    {
        public bool Modificado;//este se utiliza para el editor de docuemntacion
        public CParametroSP()
        {
            //
            // TODO: Add constructor logic here
            //
            Filtro = TIPO_FILTRO.IGUAL;
            Vacios = true;
            SelectedValor = true;
            Modificado = false;
        }
        public bool Vacios;
        public string Descripcion;
        public int Logitud;
        public int xprec;
        public int xscale;
        public string TipoNet;
        private string ftipo;
        public string tipo
        {
            get
            {
                return ftipo;
            }
            set
            {
                //quito unicamente los datos que esten entre parentesis
                bool parentesis = false;
                ftipo = "";
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '(')
                    {
                        parentesis = true;
                    }
                    else if (value[i] == ')')
                    {
                        parentesis = false;
                    }
                    else if (parentesis == false)
                    {
                        ftipo = ftipo + value[i];
                    }
                }
            }
        }
        public string nombre
        {
            get;
            set;
        }
        public string NULOS
        {
            get;
            set;
        }
        public int iscomputed;
        public bool ValidarUnicidad;
        public bool ValorFijo;
        public string Valor;
        public string Default;
        public bool AutoIncremental;
        public bool FLLavePrimaria;
        public bool Variable;
        public string collation;
        public bool LLavePrimaria
        {
            get
            {
                return FLLavePrimaria;
            }
            set
            {
                FLLavePrimaria = value;
                if (FLLavePrimaria == true)
                    NULOS = "NO";
            }
        }
        public bool LLaveForanea;
        public string DameCadena()
        {
            return tipo + " " + nombreC;
        }
        public string nombreC
        {
            get
            {
                string s = "";
                int i, n;
                n = nombre.Length;
                for (i = 0; i < n; i++)
                {
                    if (nombre[i] != '@')
                        s = s + nombre[i];
                }
                return s;
            }
        }
        public string TipoSP
        {
            get
            {
                if (tipo.ToLower().Trim() == "char")
                    return tipo + "(" + this.Logitud.ToString() + ")";
                if (tipo.ToLower().Trim() == "varchar")
                    return tipo + "(" + this.Logitud.ToString() + ")";
                return tipo;
            }
        }
        public override string ToString()
        {
            return nombre;
        }
        public TIPO_FILTRO Filtro;
        public bool EnableAlias;
        public string Alias;
        public bool Sum;
        public bool EnableCase;
        public List<Objetos.CCaso> Casos;
        public bool Descendente;
        public string SFiltro
        {
            get
            {
                string s = "=";
                switch (Filtro)
                {
                    case Objetos.TIPO_FILTRO.DIFERENTE:
                        s = "!=";
                        break;
                    case Objetos.TIPO_FILTRO.IGUAL:
                        s = "=";
                        break;
                    case Objetos.TIPO_FILTRO.LIKE:
                        s = " like ";
                        break;
                    case TIPO_FILTRO.MAYOR_IGUAL:
                        s = ">=";
                        break;
                    case TIPO_FILTRO.MAYOR_QUE:
                        s = ">";
                        break;
                    case TIPO_FILTRO.MENOR_IGUAL:
                        s = "<=";
                        break;
                    case TIPO_FILTRO.MENOR_QUE:
                        s = "<";
                        break;
                }
                return s;
            }
        }
        public string ExcepcionNoRepetibles;
        public string ExcepcionVacios;
        public bool SelectedValor;
        public string Tabla;//para el formulario de propiedades de agregar
        public List<CParametroSP> Filtros;
        public string Campo;
        public List<CParametroSP> Ordenamientos;
        public string Parametro;
        public int Precicion;
    }
}
