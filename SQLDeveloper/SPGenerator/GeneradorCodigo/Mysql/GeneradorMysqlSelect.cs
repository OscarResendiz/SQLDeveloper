using SPGenerator.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGenerator.GeneradorCodigo.Mysql
{
    internal class GeneradorMysqlSelect : GeneradorCodigoBase, IGeneradorCodigo
    {
        List<CParametroSP> Campos;
        private string Tabla;
        List<CParametroSP> Parametros;
        CDatosAsistenteSP DatosAsistente;
        private string SP;
        public string GeneraCodigo(CDatosAsistenteSP datos)
        {
            DatosAsistente = datos;
            CargaDatos();
            //aqui se genera el codigo para crear el SP
            bool Agrupar = false;
            bool noagrupados = false;
            bool primero = true;
            string excepcion;
            string s = "CREATE PROCEDURE " + SP;
            s = s + "(";
            if (Parametros.Count > 0)
            {
                //agrego los parametros al SP
                foreach (CParametroSP obj in Parametros)
                {
                    if (primero == true)
                    {
                        primero = false;
                    }
                    else
                    {
                        s = s + ",";
                    }
                    s = s + "V_" + obj.nombre + " " + obj.TipoSP;
                }
            }
            s = s + ") ";
            //            else
            //          {
            //            s = s + " as";
            //      }
            //AddLine(s);
            AddLine(s);
            AddLine("begin");
            //agrego los comentarios del sp
            string comentario = DatosAsistente.ComentarioNombreSP;
            string cmt = "";
            int ni, nn;
            nn = comentario.Length;
            for (ni = 0; ni < nn; ni++)
            {
                if (comentario[ni] == '\n' || comentario[ni] == '\r')
                {
                    //se encontro un comentario
                    if (cmt.Trim() != "")
                    {
                        s = "\t" + cmt.Trim();
                        AddLine(s);
                        cmt = "";
                    }
                }
                else
                {
                    cmt = cmt + comentario[ni];
                }
            }
            if (cmt.Trim() != "")
            {
                s = "\t" + cmt;
                AddLine(s);
            }
            //veo si los parametros cuentan con comentarios
            if (Parametros.Count > 0)
            {
                //agrego los parametros al SP
                foreach (CParametroSP obj in Parametros)
                {
                    if (obj.Descripcion != null && obj.Descripcion.Trim() != "")
                    {
                        s = "\t-- V_" + obj.nombre + "\t" + obj.Descripcion;
                        AddLine(s);
                    }
                }
            }
            //verifico si hay que generar una excepcion si no se encuentran registros
            bool GenerarExcepcio = DatosAsistente.CHExcepcionParametros;
            if (GenerarExcepcio == true)
            {
                //muestro el comentario de la excepcion
                comentario = DatosAsistente.ComentariosParametros;
                if (comentario.Trim() != "")
                {
                    s = "\t-- " + comentario;
                    AddLine(s);
                }
                //genero la consulta
                s = "\tif not exists( select * from " + Tabla;
                //recorro los paramertos para generar la consulta
                if (Parametros.Count > 0)
                {
                    s = s + " where ";
                    primero = true;
                    //agrego los parametros al SP
                    foreach (CParametroSP obj in Parametros)
                    {
                        if (primero == true)
                            primero = false;
                        else
                            s = s + " and ";
                        if (obj.Filtro == Objetos.TIPO_FILTRO.LIKE)
                            s = s + obj.nombre + obj.SFiltro + "V_" + obj.nombre + "+\'%\'";
                        else
                            s = s + obj.nombre + obj.SFiltro + "V_" + obj.nombre;
                    }
                }
                s = s + ")";
                AddLine(s);
                AddLine("\tbegin");
                excepcion = DatosAsistente.ExcepcionParametros;// (string )DameValor("ExcepcionParametros");
                s = "\t\tRAISERROR(\'" + excepcion + "\', 16, 1)";
                AddLine(s);
                AddLine("\t\treturn");
                AddLine("\tend");
            }
            //genero la consulta
            //pongo los campos que se van a regresar
            s = "\tselect";
            //verifico si esta activada la opcion de distinct
            bool distinct = DatosAsistente.ActivarDistinct;// (bool)DameValor("ActivarDistinct");
            if (distinct == true)
            {
                s = s + "  distinct";
            }
            //verifico si esta activada la opcion de top
            bool top = DatosAsistente.AtcivarTop;// (bool)DameValor("AtcivarTop");
            if (top == true)
            {

                s = s + " top " + DatosAsistente.Top;// DameValor("Top");
            }
            AddLine(s);
            primero = true;
            foreach (CParametroSP obj in Campos)
            {
                s = "\t\t";
                if (primero == true)
                    primero = false;
                else
                    s = s + ",";
                //verifico si hay que hacer una sumatoria
                if (obj.Sum == true)
                {
                    Agrupar = true;
                    s = s + "sum(" + obj.nombre + ")";
                    //veo si se le asigno un alias
                    if (obj.Alias.Trim() != "")
                    {
                        //le asigno el alias
                        s = s + " as " + obj.Alias;
                    }
                    else
                    {
                        //como no tiene, le asigno el mismo nombre del campos
                        s = s + " as " + obj.nombre;
                    }
                }
                else if (obj.EnableCase == true)
                {
                    noagrupados = true;
                    //tiene asignado casos
                    s = s + "case " + obj.nombre;
                    //recorro todos loscasos
                    Objetos.CCaso objcdefault = null;
                    foreach (Objetos.CCaso objc in obj.Casos)
                    {
                        if (objc.When == "default")
                            objcdefault = objc;
                        else
                            s = s + " when " + objc.When + " then " + objc.Dhen;
                    }
                    if (objcdefault != null)
                    {
                        //tiene asignado el valor default
                        s = s + " else " + objcdefault.Dhen;
                    }
                    s = s + " end";
                    //veo si se le asigno un alias
                    if (obj.Alias.Trim() != "")
                    {
                        //le asigno el alias
                        s = s + " as " + obj.Alias;
                    }
                    else
                    {
                        //como no tiene, le asigno el mismo nombre del campos
                        s = s + " as " + obj.nombre;
                    }
                }
                else
                {
                    noagrupados = true;
                    //no se sumaliza
                    s = s + obj.nombre;
                    //veo si se le asigno un alias
                    if (obj.Alias != null && obj.Alias.Trim() != "")
                    {
                        //le asigno el alias
                        s = s + " as " + obj.Alias;
                    }
                }
                if (obj.Descripcion != null && obj.Descripcion.Trim() != "")
                    s = s + "-- " + obj.Descripcion;
                AddLine(s);
            }
            AddLine("\tfrom ");
            AddLine("\t\t" + Tabla);
            //recorro los paramertos para generar la consulta
            if (Parametros.Count > 0)
            {
                AddLine("\twhere ");
                primero = true;
                //agrego los parametros al SP
                foreach (CParametroSP obj in Parametros)
                {
                    s = "\t\t";
                    if (primero == true)
                        primero = false;
                    else
                        s = s + " and ";
                    if (obj.Filtro == Objetos.TIPO_FILTRO.LIKE)
                        s = s + obj.nombre + obj.SFiltro + "V_" + obj.nombre + "+\'%\'";
                    else
                        s = s + obj.nombre + obj.SFiltro + "V_" + obj.nombre;
                    AddLine(s);
                }
            }
            //veo si hay que agrupar los campos
            if (Agrupar == true && noagrupados == true)
            {
                AddLine("\tgroup by");
                //recorro todos los campos
                primero = true;
                foreach (CParametroSP obj in Campos)
                {
                    s = "\t\t";
                    if (primero == true)
                        primero = false;
                    else
                        s = s + ",";
                    if (obj.Sum == false)
                    {
                        s = s + obj.nombre;
                        AddLine(s);
                    }

                }
            }
            //veo si hay que ordenar
            List<CParametroSP> CamposOrdenamiento = DatosAsistente.CamposOrdenamiento;// (List<CParametroSP>)DameValor("CamposOrdenamiento");
            if (CamposOrdenamiento.Count > 0)
            {
                //si hay que ordenar
                AddLine("\torder by");
                primero = true;
                foreach (CParametroSP objo in CamposOrdenamiento)
                {
                    s = "\t\t";
                    if (primero == true)
                        primero = false;
                    else
                        s = s + ",";
                    s = s + objo.nombre;
                    if (objo.Descendente == true)
                        s = s + " desc";
                    AddLine(s);
                }
            }
            QuitaUltimoCaracter();
            AddLine(";");            
            AddLine("end");
            return Codigo;
        }
        private void CargaDatos()
        {
            //AddLine("-- Resumen del asistente");
            Tabla = DatosAsistente.Tabla.Nombre;//(string) DameValor("Tabla");
            //AddLine("-- Tabla utilizada: " + Tabla);
            SP = DatosAsistente.NombreSp;// (string)DameValor("NombreSP");
            //AddLine("-- Nombre del procedimiento almacenado: \'" + SP + "\'");
            //AddLine("-- Lista de parametros:");
            Parametros = DatosAsistente.Parametros;// (List<CParametroSP>)DameValor("ListaParametros");
            //foreach (CParametroSP obj in Parametros)
            //{
            //    AddLine("\t\'" + obj.nombre + "\' " + obj.tipo + "(" + obj.Logitud.ToString() + ")");
            //}
            //AddLine("-- Campos que va a regresar");
            Campos = DatosAsistente.CamposSelect;// (List<CParametroSP>)DameValor("Campos");
            //foreach (CParametroSP obj in Campos)
            //{
            //    AddLine("\t\'" + obj.nombre + "\'");
            //}

        }
    }
}
