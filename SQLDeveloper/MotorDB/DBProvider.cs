using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorDB
{
    #region DELEGADOS 
    //public delegate void OnVerObjetoEvent(string nombre, MotorDB.EnumTipoObjeto tipo);
    
    public delegate void OnEventoVacio();
    #endregion
    //aqui concentro los delegados comunes de la aplicacion para no andar repitiendolos en todas partes
    //clase que encapsula y concentra la conexion a la base de datos
    public class DBProvider
    {
        public static MotorDB.IMotorDB DB
        {
            set;
            get;
        }
    }
}
