using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MotorDB
{
    public delegate void MotorDBMessageEvent(IMotorDB motor, string msg);
    public delegate void OnVerObjetoEvent(MotorDB.IMotorDB motor, string nombre, MotorDB.EnumTipoObjeto tipo);
    public interface IMotorDB
    {
        bool Conectar();
        void Desconectar();
        System.Windows.Forms.DialogResult ShowDlgConfig();
        System.Windows.Forms.DialogResult ShowDlgMultiConfig();
        string GetConecctionString();
        void SetConnectionString(string connectionString);
        List<CObjeto> Buscar(String nombre, EnumTipoObjeto tipo= EnumTipoObjeto.NONE);
        System.Data.IDataReader EjecutaQuery(string cadena);
        string DameCodigoTabla(string nombre);
        string DameCodigoTypeTable(string nombre);
        string DameCodigoVista(string nombre);
        string DameCodigoStoreProcedure(string nombre);
        string DameCodigoFuncction(string nombre);
        void CreaTabla(CTabla tabla);
        List<CObjeto> BuscaEnTablas(string campo);
        List<CObjeto> BuscaEnVistas(string campo);
        List<CCampo> DameCamposTabla(string tabla);
        List<CCampo> DameCamposTypeTabla(string tabla);
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
        CTabla DameTypeTable(string nombre);
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
        void CreaIndex(Cindex index,string tabla);
        void CreaPrimaryKey(CPrimaryKey pk, string tabla);
        void EliminaIndex(string tabla,string indice);
        void EliminaPk(string nombre);
        void AlterTable_AddColumn(string tabla, CCampo campo, CIdentidad identidad=null);
        void AlterTable_DropColumn(string tabla, string campo);
        void AlterTable_AddUnique(string tabla, CUnique unique);
        void AlterTable_DropUnique(string tabla,string unique);
        void AlterTable_DropDefault(string tabla,string defaultName);
        void AlterTable_AddCheck(string tabla, CCheck check);
        void AlterTable_DropChechk(string tabla, string check);
        void AlterTable_AlterColumn(string tabla, CCampo actual, CCampo nuevo);
        CVista DameVista(string nombre);
        EnumMotoresDB GetMotor();
        string DameCodigoTrigger(string nombre);
        DataSet Execute(string comando);
        DateTime DameFechaCreacion(string nombreObjeto);
        DateTime DameFechaModificacion(string nombreObjeto);
        string GetExcecute_StoreProcedure(string nombre);
        string GetExcecute_Function(string nombre);
        string GetStringError();
        string CreaScript(List<CObjeto> lista);
       /// <summary>
       /// regresa el proveedor que se utiliza para .net
       /// </summary>
       /// <returns></returns>
        string GetNetProvider();
       /// <summary>
       /// regresa una cadena con el nombre del tipo de dato equivalente en .NET
       /// </summary>
       /// <param name="tipo"></param>
       /// <returns></returns>
        string DameTipoDatoNet(CTipoDato tipo);
       /// <summary>
       /// regresa una serie de tablas con las tablas que regresa el SP
       /// </summary>
       /// <param name="nombre"></param>
       /// <returns></returns>
        List<CTabla> DameResultadoProcedimientoAlmacenado(string nombre);
       /// <summary>
       /// regresa una tabla con los campos del primer resultado que se encuente
       /// </summary>
       /// <param name="nombre"></param>
       /// <returns></returns>
        CTabla DamePrimerResultadoProcedimientoAlmacenado(string nombre);
       /// <summary>
       /// regresa el listado de palabras reservadas
       /// </summary>
       /// <returns></returns>
        List<string> DamePalabrasReservadas();
        void SuscribeErrorMessageEvent(MotorDBMessageEvent e);
        string GetConeccionString(int pos);
        string GetConnectionName(int pos);
        int GetConnectionsCount();
    }
}
   