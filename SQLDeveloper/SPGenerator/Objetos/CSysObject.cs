using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorDB;
namespace SPGenerator.Objetos
{
    public class CSysObject
    {
        #region Datos Originales
        public string Nombre;
        public EnumTipoObjeto TipoObjeto;
        public override string ToString()
        {
            return Nombre;
        }
        #endregion

    }
}
