using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.Visores.Variables
{
    public class CDefinicionTabla
    {
        private List<CDefinicionCampo> Campos;
        public CDefinicionTabla()
        {
            Campos = new List<CDefinicionCampo>();
        }
        public string Nombre
        {
            get;
            set;
        }
        public void Add(CDefinicionCampo campo)
        {
            Campos.Add(campo);
        }
        public List<CDefinicionCampo> DameCampos()
        {
            return Campos;
        }
    }
}
