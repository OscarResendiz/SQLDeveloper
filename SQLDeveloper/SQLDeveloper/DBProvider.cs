using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper
{
    #region DELEGADOS 
    //public delegate void OnVerObjetoEvent(string nombre, MotorDB.EnumTipoObjeto tipo);
    
    public delegate void OnPropiedadesEvent(Modulos.Visores.CPropiedadesBase obj);
    #endregion
}
