using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorDB;
namespace SPGenerator.Objetos
{
    public enum TIPO_SP
    {
        INSERT,
        UPDATE,
        DELETE,
        SELECT,
        CRUD
    };
    public class CDatosAsistenteSP
    {
        public TIPO_SP TipoSP {  get; set; }
        public CTabla Tabla { get; set; }
        public string NombreSp { get; set; }
        public List<CParametroSP> Parametros { get; set; } = new List<CParametroSP>();
        public List<CParametroSP> ValoresFijos { get; set; } = new List<CParametroSP>();
        public List<CParametroSP> CamposSelect { get; set; } = new List<CParametroSP>();
        public List<CLLaveForanea> FreignKeys { get; set; } = new List<CLLaveForanea>();
        public bool GenerarLLaveAutomaticamente { get; set; }
        public string ComentariosIniciales { get; set; }
        public bool GenerarExcepcion {  get; set; }
        public string TextoExcepcion { get; set; }
        public string ComentariosExcepcion { get; set; }
        public CParametroSP CampoLLave {  get; set; }
        public bool AsisGenLLave {  get; set; }
        public string ComentarioNombreSP {  get; set; }
        public List<CParametroSP> CamposOrdenamiento {  get; set; }
        public bool CHExcepcionParametros {  get; set; }
        public string ComentariosParametros { get; set; }
        public string ExcepcionParametros { get; set; }
        public bool ActivarDistinct {  get; set; }
        public bool AtcivarTop {  get; set; }
        public string Top {  get; set; }


    }
}
