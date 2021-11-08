using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.Analizadores
{
    /// <summary>
    /// contiene la relacion entre el motor y la conexion
    /// </summary>
    public class CMotorConexion
    {
        public ObjetosModelo.CConexion Conexion
        {
            get;
            set;
        }
        public MotorDB.IMotorDB Motor
        {
            get;
            set;
        }

    }
}
   