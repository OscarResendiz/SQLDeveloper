using MotorDB;
using SPGenerator.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGenerator
{
    public class SqlGeneradorCodigo : GeneradorCodigoBase ,IGeneradorCodigo
    {

        public string GeneraCodigo(CDatosAsistenteSP datos)
        {
            
            switch (datos.TipoSP)
            {
                case TIPO_SP.INSERT:
                    Codigo = new GeneradorCodigo.SQLServer.GeneradorSqlServerInsert().GeneraCodigo(datos);
                    break;
                case TIPO_SP.UPDATE:
                    Codigo = new GeneradorCodigo.SQLServer.GeneradorSqlServerUpdate().GeneraCodigo(datos);
                    break;
                case TIPO_SP.DELETE:
                    Codigo = new GeneradorCodigo.SQLServer.GeneradorSqlServerDelete().GeneraCodigo(datos);
                    break;
                case TIPO_SP.SELECT:
                    Codigo = new GeneradorCodigo.SQLServer.GeneradorSqlServerSelect().GeneraCodigo(datos);
                    break;
            }
            return Codigo;
        }
    }
}
