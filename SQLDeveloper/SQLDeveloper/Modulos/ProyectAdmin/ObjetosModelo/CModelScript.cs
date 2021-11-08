using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.ProyectAdmin
{
   public class CModelScript
    {
       public CModelScript()
       {
           ID_Carpeta = 0;
           ID_Script = 0;
           ID_Conexion = 0;
           Nombre = "Sin Nombre";
       }
       public int ID_Script
       {
           get;
           set;
       }
       public int ID_Conexion
       {
           get;
           set;
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
    }
}
