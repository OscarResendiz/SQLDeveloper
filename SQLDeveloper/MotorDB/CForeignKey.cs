using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorDB
{
    public enum EnumAccionReferencial
    {
        SET_NULL,
        CASCADE,
        RESTRICT,
        NO_ACTION,
        SET_DEFAULT
    }
    public class CForeignKey: CConstraint
    {
        public List<CCampoFereneces> Campos
        {
            get;
            set;
        }
        public CForeignKey()
        {
            Tipo = EnumTipoObjeto.FOREIGNKEY;
            AccionActualizar = EnumAccionReferencial.NO_ACTION;
            AccionBorrar = EnumAccionReferencial.NO_ACTION;
        }
        public string TablaPadre
        {
            get;
            set;
        }
        public string TablaHija
        {
            get;
            set;
        }
        public void Add(CCampoFereneces obj)
        {
            if (Campos == null)
                Campos = new List<CCampoFereneces>();
            Campos.Add(obj);
        }
        public bool ContieneCampo(CCampoBase campo)
        {
            if (Campos == null)
                return false;
            //regresa true si el campo se encuentra en la lista
            foreach (CCampoFereneces obj in Campos)
            {
                if (obj.CampoHijo.Nombre == campo.Nombre)
                    return true;
            }
            return false;
        }
        public EnumAccionReferencial AccionBorrar
        {
            get;
            set;
        }
        public EnumAccionReferencial AccionActualizar
        {
            get;
            set;
        }
    }
}
