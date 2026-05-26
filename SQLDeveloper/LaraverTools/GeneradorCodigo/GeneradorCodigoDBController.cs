using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorDB;
namespace Laravel
{
    //public delegate void GeneradorCodigoDBControllerDelegate(GeneradorCodigoDBController obj);
    public class GeneradorCodigoDBController
    {
        //public event GeneradorCodigoDBControllerDelegate GeneradorCodigoDBControllerEvent;
        public GeneradorCodigoDBController() {
            ProdecimientosAlmacenados = new List<CObjeto>();
        }
        private List<CObjeto> ProdecimientosAlmacenados;
        public MotorDB.IMotorDB MotorDB
        {
            get;
            set;
        }
        public string NombreController
        {
            get;
            set;
        }
        public string NameSpace
        {
            get;
            set;
        }
        /// <summary>
        /// Agrega el nombre del SP a la lista de objetos
        /// </summary>
        /// <param name="nombreSp"></param>
        public void Add(String nombreSp)
        {
            if (MotorDB == null)
            {
                throw new Exception("No se ha asignado el motor de base de datos");
            }
            var objx=(from x in ProdecimientosAlmacenados where x.Nombre==nombreSp select x).ToList();
            if (objx.Count > 0)
                return; // ya existe en la lista

            List < CObjeto > lista = MotorDB.Buscar(nombreSp, EnumTipoObjeto.PROCEDURE);
            foreach (CObjeto obj in lista)
            {
                if (obj.Nombre == nombreSp)
                {
                    ProdecimientosAlmacenados.Add(obj);
                    return;
                }
            }
            throw new Exception($"No se encontró el sp{nombreSp} en la base de datos");
        }
        /// <summary>
        /// quita de la lista el sp 
        /// </summary>
        /// <param name="nombreSP"></param>
        public void Delete(string nombreSP)
        {
            var objx = (from x in ProdecimientosAlmacenados where x.Nombre == nombreSP select x).ToList();
            if (objx.Count == 0)
            {
                return;
            }
            var obj = objx.First();
            ProdecimientosAlmacenados.Remove(obj);
        }
        public List<string> DameListaSps()
        {
            var lista = new List<string>();
            foreach (CObjeto obj in ProdecimientosAlmacenados)
            {
                lista.Add(obj.Nombre);
            }
            return lista;
        }
        public string GeneraCodigo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?php");
            sb.AppendLine("");
//            sb.AppendLine($"namespace App\\Http\\Controllers\\API\\{NombreController};");
            sb.AppendLine($"namespace {NameSpace};");
            sb.AppendLine("");
            sb.AppendLine("use App\\Http\\Controllers\\Controller;");
            sb.AppendLine("use Illuminate\\Http\\Request;");
            sb.AppendLine("use DB;");
            sb.AppendLine("/*");
            sb.AppendLine("Agregar documentacion aqui");
            sb.AppendLine("*/");
            sb.AppendLine("");
            sb.AppendLine($"class {NombreController} extends Controller");
            sb.AppendLine("{");
            //agrego los SP
            foreach (var item in ProdecimientosAlmacenados)
            {
                sb.AppendLine(GeneraCodigoSP(item));
            }
            sb.AppendLine("}");

            return sb.ToString();
        }
        private string GeneraCodigoSP(CObjeto objeto)
        {
            StringBuilder sb = new StringBuilder();
            string s = $"\tpublic static function {objeto.Nombre}(";
            string s2 = "";
            List<CParametro> parametros=MotorDB.DameParametrosStoreProcedure(objeto.Nombre);
            bool primero = true;
            foreach (var parametro in parametros)
            {
                if (primero)
                {
                    primero = false;
                }
                else
                {
                    s = s + ",";
                    s2 = s2 + ",";
                }
                s = s + $"${parametro.Nombre}";
                s2 = s2 + $":{parametro.Nombre}";

            }
            s = s + ")";
            sb.AppendLine(s);
            sb.AppendLine("\t{");
            string s3 = $"\t\t$resultado = DB::select('call {objeto.Nombre}(" + s2 + ")'";

            //sb.AppendLine($"\t\t$resultado = DB::select('call {objeto.Nombre}("+s2+")',");
            if (parametros.Count > 0)
            {
                s3 = s3 + ",";
                sb.AppendLine(s3);
                sb.AppendLine("\t\t[");
                primero=true;
                foreach (var parametro in parametros)
                {
                    s = "";
                    if (primero)
                    {
                        primero = false;
                    }
                    else
                    {
                        s = s + ",";
                    }
                    s = s + $"'{parametro.Nombre}'=>${parametro.Nombre}";
                    sb.AppendLine("\t\t\t" + s);
                }
                sb.AppendLine("\t\t]);");
            }
            else
            {
                s3 = s3 + ");";
                sb.AppendLine(s3);
            }
            sb.AppendLine("\t\treturn $resultado[0];");
            sb.AppendLine("\t}");
            return sb.ToString();
        }
    }
}
