using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.ObjetosModelo
{
    /// <summary>
    /// Representa la linea donde se encontro el objeto y contiene la cadena
    /// </summary>
    public class CLineaArchivo : CObjetoBase
    {
        #region Propiedades
        /// <summary>
        /// id del archivo en el que se encontro el objeto
        /// </summary>
        public int ID_Archivo
        {
            get
            {
                return IdObjeto;
            }
            set
            {
                IdObjeto = value;
            }
        }
        /// <summary>
        /// numero de linea en la que se encontro la referencia del objeto
        /// </summary>
        public int ID_Linea
        {
            get;
            set;
        }
        /// <summary>
        /// texto de la cadena donde se encontro el objeto
        /// </summary>
        public string Texto
        {
            get;
            set;
        }
        #endregion
        #region funciones
        /// <summary>
        /// elimina la linea del modelo
        /// </summary>
        public void delete(bool reportar=true)
        {
            Modelo.DeleteLineaArchivo(this.ID_Linea,reportar);
        }
        /// <summary>
        /// actualiza los datos
        /// </summary>
        public void update()
        {
            Modelo.UpdateLineaArchivo(this.ID_Archivo, this.ID_Linea, this.Texto);
        }
        #endregion
        public override string ToString()
        {
            return Texto;
        }
    }
}
   