using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorDB
{
    public enum EnumMomentTriger
    {
        BEFORE,
        AFTER,
        INSTEAD_OF     // se usa para hacer insersiones en vistas desde SQL server. Hay que ver si los demas motores lo soportan
    }
    public enum EnumEventTriger
    {
        INSERT,
        DELETE,
        UPDATE
    }
    public class CTrigger: CObjeto
    {
        public EnumMomentTriger Momento
        {
            get;
            set;
        }
        public EnumEventTriger Disparador
        {
            get;
            set;
        }
        public String CodigoFuente
        {
            get;
            set;
        }
        public CTrigger()
        {
            Tipo = EnumTipoObjeto.TRIGER;
            Momento = EnumMomentTriger.AFTER;
            Disparador = EnumEventTriger.INSERT;
        }
    }

}
