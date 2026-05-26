using MotorDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorSP
{
    public class SqlGeneradorCodigo : IGeneradorCodigo
    {
        public List<CDelete> FK_ComandoDelete(CForeignKey fk, IMotorDB DB, bool modo)
        {
            throw new NotImplementedException();
        }
    }
}
