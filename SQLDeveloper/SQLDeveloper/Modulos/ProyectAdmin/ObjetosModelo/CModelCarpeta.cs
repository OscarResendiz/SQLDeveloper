using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.ProyectAdmin
{
    public class CModelCarpeta
    {
        public CModelCarpeta()
        {
            ID_Carpeta = 0; //el cero indica null
            Nombre = "Carpeta Nueva";
            ID_CarpetaPadre = 0;
        }
        public int ID_Carpeta
        {
            get;
            set;
        }
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
        public int ID_CarpetaPadre
        {
            get;
            set;
        }
    }
}
