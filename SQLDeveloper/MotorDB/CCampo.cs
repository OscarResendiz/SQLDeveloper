using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorDB
{
    public class CCampo : CCampoBase
    {
        [
          Category("Basico"),
//          DefaultValue(45)
           Description("Especifica el porcentaje del ancho que ocupa la barra interior")
        ]
        public bool AceptaNulo
        {
            get;
            set;
        }
        [
          Category("Avanzado"),
           Description("Indica si el valor del campo se calcula de forma dinamica")
        ]
        public bool CampoCalculado
        {
            get;
            set;
        }
        [
          Category("Avanzado"),
           Description("Contiene la formula o el valor default dependiendo si el campo es calculado o tiene valor default")
        ]
        public string Formula

        {
            get;
            set;
        }
        [
          Category("Avanzado"),
           Description("Indica si el valor del campo se inicializa a un valor por default. El valor se almacena en formula")
        ]
        public bool EsDefault
        {
            get;
            set;
        }
        public CCampo()
        {
            AceptaNulo = true;
            CampoCalculado = false;
            Tipo = EnumTipoObjeto.CAMPO;
            DefaultName = "";
        }
        public string DefaultName
        {
            get;
            set;
        }
    }
}
