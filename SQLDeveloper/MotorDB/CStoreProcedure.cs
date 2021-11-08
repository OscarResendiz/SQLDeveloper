using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorDB
{
    public class CStoreProcedure:CObjeto
    {
        private List<CParametro> FParametros;
        public List<CParametro> Parametros
        {
            get
            {
                return FParametros;
            }
        }
        public CStoreProcedure()
        {
            FParametros = new List<CParametro>();
            Tipo = EnumTipoObjeto.PROCEDURE;
        }
        public void AddParametro(CParametro parametro)
        {
            foreach(CParametro obj in FParametros)
            {
                if(obj.Nombre==parametro.Nombre)
                {
                    //ya existe por lo que no hay nececidad de agregarlo
                    return;
                }
            }
            FParametros.Add(parametro);
        }
        public void RemoveParametro(string nombre)
        {
            foreach(CParametro obj in FParametros)
            {
                if(obj.Nombre==nombre)
                {
                    FParametros.Remove(obj);
                    return;
                }
            }
        }
        public string CodigoFuente
        {
            get;
            set;
        }
    }
}
