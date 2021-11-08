using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.CreadorTabla
{
    class CpropiedadesCampo: CPropiedadesBase
    {
        private MotorDB.CCampo Campo;
        private MotorDB.CIdentidad Identidad;
        MotorDB.CPrimaryKey PK;
        public CpropiedadesCampo(MotorDB.CCampo obj, MotorDB.CIdentidad i=null)
        {
            Campo = obj;
            Identidad = i;
            PK = null;
        }
        [
          Category("Base"),
           Description("Nombre del campo")
        ]
        public string Nombre
        {
            get
            {
                return Campo.Nombre;
            }
        }
        [
          Category("Base"),
           Description("Tipo de dato")
        ]
        public string TipoDato
        {
            get
            {
                return Campo.GetTipoString();
            }
        }
        [
             Category("Base"),
           Description("Indica si el campo puede contener valores nulos")
        ]
        public bool AceptaNulos
        {
            get
            {
                return Campo.AceptaNulo;
            }
        }
        [
          Category("Inicializar"),
           Description("Indica si el campo es calculado. Si es calculado su valor se muestra en Expesion")
        ]
        public bool CampoCalculado
        {
            get
            {
                return Campo.CampoCalculado;
            }
        }
        [
          Category("Inicializar"),
           Description("muestra el valor al que se inicializa el campo en caso de que sea calculado o tenga valor por default")
        ]
        public string Expresion
        {
            get
            {
                return Campo.Formula;
            }
        }
        [
          Category("Inicializar"),
           Description("indica si el campo se inicializa en un valor por default. Su valor se muestra en Expresion")
        ]
        public bool CampoDefault
        {
            get
            {
                return Campo.EsDefault;
            }

        }
        [
          Category("Inicializar"),
           Description("Indica el nombre del CONSTRAINT default")
        ]
        public string DefaultName
        {
            get
            {
                return Campo.DefaultName;
;
    }

        }
        [
          Category("Identidad"),
           Description("Indica si el campo es auto incremental (Identity). La tabla solo puede tener un campo auto incremental ")
        ]
        public bool AutoIncremental
        {
            get
            {
                if(Identidad==null)
                        return false;
                if (Campo.Nombre != Identidad.Campo.Nombre)
                    return false;
                return true;
            }
        }
        [
          Category("Identidad"),
           Description("Indica en que valor va a comenzar el auto incremento ")
        ]
        public int ValorInicial
        {
            get
            {
                if (Identidad == null)
                    return 0;
                if (Campo.Nombre != Identidad.Campo.Nombre)
                    return 0;
                return Identidad.ValorInicial;
            }
        }
        [
          Category("Identidad"),
           Description("Indica como se va a ir incrementando campo conforme se insertan registros")
        ]
        public int Incremento
        {
            get
            {
                if (Identidad == null)
                    return 0;
                if (Campo.Nombre != Identidad.Campo.Nombre)
                    return 0;
                return Identidad.Incremento;

            }
        }
        public void SetPrimaryKey(MotorDB.CPrimaryKey pk)
        {
            PK = pk;
        }
        [
          Category("Primary Key"),
           Description("Indica si el campo pertenece a la llave primaria de la tabla")
        ]
        public bool PrimaryKey
        {
            get
            {
                if (PK == null)
                    return false;
                return true;
            }
        }
    }
}
