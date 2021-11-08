using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.ProyectAdmin
{
    public class CModelObjeto
    {
        public CModelObjeto()
        {
            ID_Carpeta = 0;
            Resaltado = false;
        }
        public int ID_Conexion
        {
            get;
            set;
        }
        public string Nombre
        {
            get;
            set;
        }
        public MotorDB.EnumTipoObjeto TipoObjeto
        {
            get;
            set;
        }
        public int ID_Objeto
        {
            get;
            set;
        }
        public bool Eliminado
        {
            get;
            set;
        }
        public string Comentarios
        {
            get;
            set;
        }
        public int ID_Carpeta
        {
            get;
            set;
        }
        public bool Resaltado
        {
            get;
            set;
        }
    }
}
