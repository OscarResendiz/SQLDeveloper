using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.ObjetosModelo
{
    /// <summary>
    /// Objeto que reresenta una extencion de archivo
    /// </summary>
    public class CExtencion : CObjetoBase
    {
        #region Propiedades
        /// <summary>
        /// identificador del archivo
        /// </summary>
        public int ID_Extencion
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
        /// extencion del archivo a tomar en cuenta
        /// </summary>
        public string Extencion
        {
            get;
            set;
        }
        #endregion
        #region Metodos
        /// <summary>
        /// actualiza los datos
        /// </summary>
        public void update()
        {
            Modelo.UpdateExtenciones(this.ID_Extencion, this.Extencion);
        }
        /// <summary>
        /// elimina la extencion del modelo
        /// </summary>
        public void delete()
        {
            Modelo.DeleteExtenciones(this.ID_Extencion);
        }
        public override string ToString()
        {
            return this.Extencion;
        }
        #endregion
    }
}
