using SPGenerator.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGenerator.GeneradorCodigo
{
    internal class MySqlGeneradorCodigo : GeneradorCodigoBase, IGeneradorCodigo
    {

        public string GeneraCodigo(CDatosAsistenteSP datos)
        {

            switch (datos.TipoSP)
            {
                case TIPO_SP.INSERT:
                    Codigo = new GeneradorCodigo.Mysql.GeneradorMysqlInsert().GeneraCodigo(datos);
                    break;
                case TIPO_SP.UPDATE:
                    Codigo = new GeneradorCodigo.Mysql.GeneradorMysqlUpdate().GeneraCodigo(datos);
                    break;
                case TIPO_SP.DELETE:
                    Codigo = new GeneradorCodigo.Mysql.GeneradorMysqlDelete().GeneraCodigo(datos);
                    break;
                case TIPO_SP.SELECT:
                    Codigo = new GeneradorCodigo.Mysql.GeneradorMysqlSelect().GeneraCodigo(datos);
                    break;
            }
            return Codigo;
        }
    }
}
