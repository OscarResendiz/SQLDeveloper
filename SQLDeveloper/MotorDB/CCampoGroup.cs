using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorDB
{
    public class CCampoGroup: CConstraint
    {
        protected List<CCampoBase> FCampos;
        public List<CCampoBase> Campos
        {
            get
            {
                return FCampos;
            }
            set
            {
                FCampos = value;
            }
        }
        public CCampoGroup()
        {
            FCampos = new List<CCampoBase>();
        }
        public void AddCampo(CCampoBase campo)
        {
            foreach (CCampoBase obj in FCampos)
            {
                if (obj.Nombre == campo.Nombre)
                    return;
            }
            FCampos.Add(campo);
        }
        public void RemoveCampo(string nombre)
        {
            foreach (CCampoBase obj in FCampos)
            {
                if (obj.Nombre == nombre)
                {
                    FCampos.Remove(obj);
                    return;
                }
            }
        }
        public bool ContieneCampo(CCampoBase campo)
        {
            //regresa true si el campo se encuentra en la lista
            foreach(CCampoBase obj in FCampos)
            {
                if (obj.Nombre == campo.Nombre)
                    return true;
            }
            return false;
        }
    }
}
