using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerConnect
{
    public class CConexion
    {
        public string Nombre
        {
            get;
            set;
        }
        public int ID_Conexion
        {
            get;
            set;
        }
        public string ConecctionString
        {
            get;
            set;
        }
        public int ID_Grupo
        {
            get;
            set;
        }
        public string GrupoName
        {
            get;
            set;
        }
        public string MotorDB
        {
            get;
            set;
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
