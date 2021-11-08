using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.Analizadores
{
    /// <summary>
    /// clase que se utiliza para contener una cadena encontrada durante el analisis
    /// </summary>
    public class CLineaArchivoCadena
    {
        /// <summary>
        /// identificador del archivo
        /// </summary>
        public int ID_Archivo
        {
            get;
            set;
        }
        /// <summary>
        /// numero de linea dentro del archivo
        /// </summary>
        public int NLinea
        {
            get;
            set;
        }
        /// <summary>
        /// cadena encontrada
        /// </summary>
        public string Cadena
        {
            get;
            set;
        }
        /// <summary>
        /// nombre del archivo
        /// </summary>
        public string NombreArchivo
        {
            get;
            set;
        }
        public bool Encontrada
        {
            get;
            set;
        }
    }
}
   