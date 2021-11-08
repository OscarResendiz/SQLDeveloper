using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.Visores.Variables
{
   public class CDefinicionCampo
    {
       public CDefinicionCampo()
       {
           PrimaryKey = false;
           AceptaNulos = true;
           Longitud = "";
           Tipo = "";
           Nombre = "";
       }
       public string Nombre
       {
           get;
           set;
       }
       public string Tipo
       {
           get;
           set;
       }
       public string Longitud
       {
           get;
           set;
       }
       public bool PrimaryKey
       {
           get;
           set;
       }
       public bool AceptaNulos
       {
           get;
           set;
       }
    }
}
