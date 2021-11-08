using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerConnect
{
    public class CPropiedadesMotor
    {
        public CPropiedadesMotor()
        {
            Conexion = new CConexion();
        }
        public CConexion Conexion
        {
            get;
            set;
        }
        public string Grupo
        {
            get;
            set;
        }
    }
}
