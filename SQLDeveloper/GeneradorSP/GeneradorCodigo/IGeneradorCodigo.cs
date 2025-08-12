using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorDB;

namespace GeneradorSP
{
    public interface IGeneradorCodigo
    {
        List<CDelete> FK_ComandoDelete(CForeignKey fk, IMotorDB DB, bool modo);
    }
}
