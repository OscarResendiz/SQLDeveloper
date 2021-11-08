using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MotorDB
{
   public interface IMotorDB
    {
        bool Conectar();
        void Desconectar();
        System.Windows.Forms.DialogResult ShowDlgConfig();
        string GetConecctionString();
        void SetConnectionString(string connectionString);
        List<CObjeto> Buscar(String nombre, EnumTipoObjeto tipo= EnumTipoObjeto.NONE);
        System.Data.IDataReader EjecutaQuery(string cadena);
        string DameCodigoTabla(string nombre);
        string DameCodigoVista(string nombre);
        string DameCodigoStoreProcedure(string nombre);
        string DameCodigoFuncction(string nombre);
        void CreaTabla(CTabla tabla);
        List<CObjeto> BuscaEnTablas(string campo);
        List<CObjeto> BuscaEnVistas(string campo);
        List<CCampo> DameCamposTabla(string tabla);
        List<CCampoBase> DameCamposVista(string vista);
        List<CParametro> DameParametrosStoreProcedure(string sp);
        List<CParametro> DameParametrosFuncction(string funcion);
        CPrimaryKey DameLLavePrimaria(string tabla);
        List<CForeignKey> DameLLavesForaneas(string tablaHija);
        bool isExecuting();
        String GetConnectionName();
        void SetConnectionName(string nombre);
        List<CTipoDato> DameTiposDato();
        CTipoDato GetTipoDato(string nombre);
        string QueryCreaTabla(CTabla tabla);
        CTabla DameTabla(string nombre);
        List<CObjeto> DameDependenciasDe(string nombre);
        List<CObjeto> DameDependientesDe(string nombre);
        string GetDataBseName();
        List<CForeignKey> DameLLavesForaneasHijas(string tablaPadre);
        List<EnumAccionReferencial> DameAccionesReferencialesBorradoValidos();
        List<EnumAccionReferencial> DameAccionesReferencialesActualizadoValidos();
        void CreaForeignKey(CForeignKey fk);
        void EliminaForeignKey(CForeignKey fk);
        List<CTrigger> DameTrrigersTabla(string tabla);
        List<EnumMomentTriger> DameMomentosTriggerSoportados();
        List<EnumEventTriger> DameEventosTriggerSoportados();
    }
}
