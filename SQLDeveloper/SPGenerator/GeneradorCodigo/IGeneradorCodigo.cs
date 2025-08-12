using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorDB;
using SPGenerator.Objetos;

namespace SPGenerator
{
    public interface IGeneradorCodigo
    {
        string GeneraCodigo(CDatosAsistenteSP datos);
    }
}
