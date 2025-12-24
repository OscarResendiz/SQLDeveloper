using MotorDB;
using SPGenerator.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGenerator.GeneradorCodigo.Mysql
{
    internal class GeneradorMysqlInsert : GeneradorCodigoBase, IGeneradorCodigo
    {
        CDatosAsistenteSP DatosAsistente;
        private List<Objetos.CParametroSP> Parametros;
        private string NombreSP;
        private string ComentarioNombreSP;
        private string Tabla;
        private List<Objetos.CParametroSP> ValoresFijos;
        private List<CLLaveForanea> LLavesForaneas;
        private bool GenerarLLave;
        private Objetos.CParametroSP CampoLLave;
        CPrimaryKey LLavesPrimarias;
        private void CargaDatos()
        {
            // en esta funcion se cargan los datos que los demas modulos del asistente se fueroncaprurando
            NombreSP = DatosAsistente.NombreSp;
            Parametros = DatosAsistente.Parametros;
            ComentarioNombreSP = DatosAsistente.ComentarioNombreSP;
            Tabla = DatosAsistente.Tabla.Nombre;
            ValoresFijos = DatosAsistente.ValoresFijos;
            LLavesForaneas = DatosAsistente.FreignKeys;
            GenerarLLave = DatosAsistente.AsisGenLLave;
            if (GenerarLLave == true)
            {
                CampoLLave = DatosAsistente.CampoLLave;
            }
            //me traigo las llaves primarias
            LLavesPrimarias = DatosAsistente.Tabla.PrimaryKey;
        }
        public string GeneraCodigo(CDatosAsistenteSP datos)
        {
            DatosAsistente = datos;
            bool primero;
            Codigo = "";
            CargaDatos();
            // primero genero el cabecero del SP
            Add("create procedure " + NombreSP);
            //veo si tiene parametros
            if (Parametros.Count > 0)
            {
                //genero lalista de parametros
                Add("(");
                primero = true;
                foreach (Objetos.CParametroSP parametro in Parametros)
                {
                    if (primero == false)
                    {
                        Add(",");
                    }
                    else
                    {
                        primero = false;
                    }
                    Add("V" + parametro.nombre + " " + parametro.TipoSP);
                }
                Add(")");
            }
           // Add(" as\n");
            AddLine("\nbegin");
            //veo si le pucieron comentarios
            string comentario = DatosAsistente.ComentarioNombreSP;
            string cmt = "";
            int ni, nn;
            nn = comentario.Length;
            string s = "";
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
            //veo si hay campos que van a tener valores fijos
            if (ValoresFijos.Count > 0)
            {
                AddLine("\t-- Declaración de variables que se requieren ");
                foreach (Objetos.CParametroSP variable in ValoresFijos)
                {
                    AddLine("\tdeclare V" + variable.nombre + " " + variable.TipoSP+";");
                }
            }
            if (GenerarLLave == true)
            {
                //declaro la variable que va a tener el nombre de la llave
                AddLine("\tdeclare V" + CampoLLave.nombre + " " + CampoLLave.TipoSP + "; -- variable utilizada para generar la llave");
            }
            //veo si le asignaron comentarios a los parametros
            if (Parametros.Count > 0)
            {
                //genero lalista de parametros
                foreach (Objetos.CParametroSP parametro in Parametros)
                {
                    if (parametro.Descripcion != null && parametro.Descripcion.Trim() != "")
                    {
                        Add("\t-- " + parametro.nombre + " " + parametro.Descripcion + "\n");
                    }
                }
            }
            //ahora agrego validaciones a los parametros
            if (Parametros.Count > 0)
            {
                primero = true;
                foreach (Objetos.CParametroSP parametro in Parametros)
                {
                    if (parametro.Vacios == false)
                    {
                        if (primero == true)
                        {
                            AddLine("\t-- Validando que no sean vacios");
                            primero = false;
                        }
                        AddLine("\tif(ltrim(V" + parametro.nombre + ")=\'\') then");
                        //AddLine("\tbegin");
                        //Version sim tiene comentarios
                        if (parametro.Descripcion.Trim() != "")
                        {

                            AddLine("\t\t-- " + parametro.Descripcion);
                        }
                        AddLine($"\t\tSIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '{parametro.ExcepcionVacios}';");
                        //AddLine("\t\tRAISERROR(\'" + parametro.ExcepcionVacios + "\', 16, 1)");
                        //AddLine("\t\treturn");
                        AddLine("\tend if;");
                    }
                }
            }
            //ahora valido que no se repitan los campos
            if (Parametros.Count > 0)
            {
                primero = true;
                foreach (Objetos.CParametroSP parametro in Parametros)
                {
                    if (parametro.ValidarUnicidad == true)
                    {
                        if (primero == true)
                        {
                            AddLine("\t-- Validando que no se pueden repetir");
                            primero = false;
                        }
                        AddLine("\tif exists(select * from " + Tabla + " where " + parametro.nombre + "=V" + parametro.nombre + ") then");
                        //AddLine("\tbegin");
                        //Version sim tiene comentarios
                        if (parametro.Descripcion.Trim() != "")
                        {

                            AddLine("\t\t-- " + parametro.Descripcion);
                        }
                        AddLine($"\t\tSIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '{parametro.ExcepcionNoRepetibles}';");
                        //AddLine("\t\tRAISERROR(\'" + parametro.ExcepcionNoRepetibles + "\', 16, 1)");
                        //AddLine("\t\treturn");
                        AddLine("\tend if;");
                    }
                }
            }
            //ahora me traigo los valores que son fijos
            if (ValoresFijos.Count > 0)
            {
                foreach (Objetos.CParametroSP variable in ValoresFijos)
                {
                    if (variable.SelectedValor == true)
                    {
                        string setValorFijo = "\tset V" + variable.nombre + "= " + variable.Valor;
                        if (setValorFijo.Contains(";") == false)
                            setValorFijo= setValorFijo+";";
                        AddLine(setValorFijo);
                    }
                    else
                    {
                        //hay que obtenerlo desde una tabla
                        s = "";
                        primero = true;
                        foreach (Objetos.CParametroSP p in variable.Filtros)
                        {
                            if (primero == true)
                            {
                                primero = false;
                            }
                            else
                            {
                                s = s + " and ";
                            }
                            s = s + p.nombre;
                            switch (p.Filtro)
                            {
                                case Objetos.TIPO_FILTRO.DIFERENTE:
                                    s = s + "!=";
                                    break;
                                case Objetos.TIPO_FILTRO.IGUAL:
                                    s = s + "=";
                                    break;
                                case Objetos.TIPO_FILTRO.LIKE:
                                    s = s + " like ";
                                    break;
                                case Objetos.TIPO_FILTRO.MAYOR_IGUAL:
                                    s = s + ">=";
                                    break;
                                case Objetos.TIPO_FILTRO.MAYOR_QUE:
                                    s = s + ">";
                                    break;
                                case Objetos.TIPO_FILTRO.MENOR_IGUAL:
                                    s = s + "<=";
                                    break;
                                case Objetos.TIPO_FILTRO.MENOR_QUE:
                                    s = s + "<";
                                    break;
                            }
                            s = s + p.Campo;
                        }
                        //veo los ordenamientos
                        string s2 = "";
                        primero = true;
                        foreach (Objetos.CParametroSP o in variable.Ordenamientos)
                        {
                            if (primero == true)
                            {
                                primero = false;
                                s2 = " order by ";
                            }
                            else
                            {
                                s2 = s2 + ",";
                            }
                            s2 = s2 + o.nombre;
                            if (o.Descendente == true)
                            {
                                s2 = s2 + " desc ";
                            }
                            else
                            {
                                s2 = s2 + " asc ";
                            }

                        }
                        AddLine("\tselect " + variable.nombre + " into V" + variable.Campo + " from " + variable.Tabla + " where " + s + s2);
                    }
                }
            }
            //ahora valido las llaves foraneas para impedir que truene
            if (LLavesForaneas.Count > 0)
            {
                AddLine("\t-- Validando llaves foráneas");
                foreach (CForeignKey fk in LLavesForaneas)
                {
                    //veo si tiene algun comentario
                    if (fk.Comentarios != null && fk.Comentarios.Trim() != "")
                    {
                        AddLine("\t-- " + fk.Comentarios);
                    }
                    //me traigo los campos y la tabla de la llave
                    //genero elselect
                    s = "";
                    primero = true;
                    foreach (CCampoReference ofk in fk.Campos)
                    {
                        if (primero == true)
                        {
                            primero = false;
                        }
                        else
                        {
                            s = s + " and ";
                        }
                        s = s + ofk.CampoPadre + "=V" + ofk.CampoHijo + " ";
                    }
                    AddLine("\tif not exists( select * from " + fk.TablaPadre + " where " + s + ") then");
                    //AddLine("\tbegin");
                    if (fk.Mensage != null && fk.Mensage.Trim() != "")
                    {
                        AddLine($"\t\tSIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '{fk.Mensage}';");
                        //AddLine("\t\tRAISERROR(\'" + fk.Mensage + "\', 16, 1)");
                    }
                    else
                    {
                        //no asignaron texto para la excepcion, por lo que genero uno automatico
                        AddLine($"\t\tSIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '{fk.TablaPadre}';");
                        //AddLine("\t\tRAISERROR(\'No se encontró la relación con la tabla " + fk.TablaPadre + "\', 16, 1)");
                    }
                    //AddLine("\t\treturn");
                    AddLine("\tend if;");
                }
            }
            //verifico  si hay que generar una llave automaticamente
            if (GenerarLLave == true)
            {
                s = "";
                primero = true;
                foreach (CCampoBase pk in LLavesPrimarias.Campos)
                {
                    if (pk.Nombre != CampoLLave.nombre)
                    {
                        if (primero == true)
                        {
                            primero = false;
                            s = " where ";
                        }
                        else
                        {
                            s = s + " and ";
                        }
                        s = s + pk.Nombre + "=V" + pk.Nombre;
                    }
                }
                AddLine("\tif not exists( select * from " + Tabla + s + ")");
                AddLine("\tbegin");
                AddLine("\t\tselect V" + CampoLLave.nombre + "=1");
                AddLine("\tend");
                AddLine("\telse");
                AddLine("\tbegin");
                AddLine("\t\tselect V" + CampoLLave.nombre + "=max(" + CampoLLave.nombre + ")+1 from " + Tabla + s + " ");
                AddLine("\tend");
            }
            //ya termine de hacer todas las validaciones, por lo que procedo a hacer el insert
            List<Objetos.CParametroSP> lista;
            lista = new List<Objetos.CParametroSP>();
            //le agrego los parametros
            foreach (Objetos.CParametroSP parametro in Parametros)
            {
                lista.Add(parametro);
            }
            foreach (Objetos.CParametroSP parametro in ValoresFijos)
            {
                lista.Add(parametro);
            }
            if (GenerarLLave == true)
            {
                lista.Add(CampoLLave);
            }
            AddLine("\t-- agregando el registro");
            primero = true;
            string ss = "";
            string ss2 = "";
            foreach (Objetos.CParametroSP obj in lista)
            {
                if (DatosAsistente.Tabla.GetCampo(obj.nombre) != null)//DB.ExisteCampoTabla(Tabla, obj.nombre))
                {
                    if (primero == true)
                    {
                        ss = "(";
                        ss2 = "values(";
                        primero = false;
                    }
                    else
                    {
                        ss = ss + ",";
                        ss2 = ss2 + ",";
                    }
                    ss = ss + obj.nombre;
                    ss2 = ss2 + "V" + obj.nombre;
                }
            }
            ss = ss + ")";
            ss2 = ss2 + ")";
            AddLine("\tinsert into " + Tabla + ss);
            AddLine("\t " + ss2+";");
            AddLine("end");
            return Codigo;
        }
    }
}
