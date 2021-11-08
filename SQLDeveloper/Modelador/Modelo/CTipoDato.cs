using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorDB;
namespace Modelador.Modelo
{

    public class CTipoDato : CBaseModelo
    {
        #region Propiedades
        public int ID_TipoDato
        {
            get;
            set;
        }
        public string Nombre
        {
            get;
            set;
        }
        public TIPO_LONGITUD TipoLongitud
        {
            get;
            set;
        }
        #endregion
        #region Metodos
        public void Update()
        {
            Modelo.Update_TipoDato(ID_TipoDato, Nombre, TipoLongitud);
        }
        /// <summary>
        /// regresa la lista de campos que tienen el tipo de dato
        /// </summary>
        /// <returns></returns>
        public List<CCampo> Get_CampoTipoDato()
        {
            return Modelo.Get_CamposTipoDato(ID_TipoDato);
        }
        public void Delete()
        {
            if (Get_CampoTipoDato().Count > 0)
            {
                throw new Exception("No se puede eliminar porque tiene campos asociados");
            }
            Modelo.Delete_TipoDato(ID_TipoDato);
        }
        public override string ToString()
        {
            return Nombre;
        }
        #endregion
    }
}
