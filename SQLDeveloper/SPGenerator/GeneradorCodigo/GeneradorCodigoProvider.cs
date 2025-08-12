using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGenerator.GeneradorCodigo
{
    /// <summary>
    /// regresa el genrador de codigo correspondiente al motor de base de datos
    /// </summary>
    internal class GeneradorCodigoProvider
    {
        public static IGeneradorCodigo DameGenerador(MotorDB.IMotorDB motor)
        {
            IGeneradorCodigo generador;
            if (motor.GetType()==typeof( MotorDB.CMotorMySQL))
            {
                generador = new MySqlGeneradorCodigo();
            }
            else if (motor.GetType() == typeof(MotorDB.CMotorSQLServer))
            {
                generador = new SqlGeneradorCodigo();
            }
            else
            {
                throw new Exception("Motor no implementado");
            }
            return generador;
        }
    }
}
