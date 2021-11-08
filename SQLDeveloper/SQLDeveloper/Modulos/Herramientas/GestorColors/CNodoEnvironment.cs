using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SintaxColor;
namespace SQLDeveloper.Modulos.Herramientas.GestorColors
{
    public class CNodoEnvironment:CNodoBase
    {
        public CNodoEnvironment()
        {
            Visor = new EnvironmentControl();
        }
        public override void Recarga()
        {
            Nodes.Clear();
            Text = "Variables de entorno";
            //recargo todos los items que me corresponden
            CEnvironment Environment = (CEnvironment)Objeto;
            Visor.Objeto = Environment;
        }
    }
}
