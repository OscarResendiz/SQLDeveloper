using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.ObjetosModelo
{
    /// <summary>
    /// contiene el codigo de la base de datos del objeto en un momento especifico del tiempo
    /// </summary>
    public class CCodigoObjeto : CObjetoBase
    {
        #region propiedades
        /// <summary>
        /// Identificado del objeto al que pertenece
        /// </summary>
        public int ID_Objeto
        {
            get;
            set;
        }
        /// <summary>
        /// Identificador del codigo
        /// </summary>
        public int ID_Codigo
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
        /// fecha en que se guardo el codigo. Sirve para mantener el historial
        /// </summary>
        public DateTime Fecha
        {
            get;
            set;
        }
        /// <summary>
        /// codigo que almacena
        /// </summary>
        public string Codigo
        {
            get;
            set;
        }
        /// <summary>
        /// Indica si ya fue visto por el usuario
        /// </summary>
        public bool Visto
        {
            get;
            set;
        }
        /// <summary>
        /// Contiene los comentarios hechos por el usuario
        /// </summary>
        public string Cometarios
        {
            get;
            set;
        }
        #endregion
        #region Metodos
        /// <summary>
        /// constructor
        /// </summary>
        public CCodigoObjeto()
        {
            Fecha = DateTime.Now;
        }
        /// <summary>
        /// actualiza los datos
        /// </summary>
        public void update()
        {
            Modelo.UpdateCodigoObjeto(this.ID_Objeto, this.ID_Codigo, this.Fecha, this.Codigo, this.Visto, this.Cometarios);
        }
        /// <summary>
        /// borra el codigo objeto
        /// </summary>
        public void delete()
        {
            Modelo.DeleteCodigoObjeto(this.ID_Codigo);
        }
        #endregion
    }
}
