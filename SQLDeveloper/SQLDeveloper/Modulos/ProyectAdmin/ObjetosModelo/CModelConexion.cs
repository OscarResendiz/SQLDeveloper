using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.ProyectAdmin
{
   public class CModelConexion
    {
       public int ID_Conexion
       {
           get;
           set;
       }
       public int ID_Servidor
       {
           get;
           set;
       }
       public string Nombre
       {
           get;
           set;
       }
       public string ConecctionString
       {
           get;
           set;
       }
       public string MotorDB
       {
           get;
           set;
       }
    }
}
