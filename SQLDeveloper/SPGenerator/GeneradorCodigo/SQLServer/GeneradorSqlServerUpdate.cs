using MotorDB;
using SPGenerator.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGenerator.GeneradorCodigo.SQLServer
{
    internal class GeneradorSqlServerUpdate : GeneradorCodigoBase, IGeneradorCodigo
    {
        private string NombreSP;
        private List<CParametroSP> Parametros;
        private List<CParametroSP> ValoresFijos;
        private string ComentarioNombreSP;
        private string Tabla;
        private List<CLLaveForanea> LLavesForaneas;
        CPrimaryKey PK;
        CDatosAsistenteSP DatosAsistente;
        public string GeneraCodigo(CDatosAsistenteSP datos)
        {
            DatosAsistente = datos;
            //genera el codigo del SP
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
                foreach (CParametroSP parametro in Parametros)
                {
                    if (primero == false)
                    {
                        Add(",");
                    }
                    else
                    {
                        primero = false;
                    }
                    Add("@" + parametro.nombre + " " + parametro.TipoSP);
                }
                Add(")");
            }
            Add(" as\n");
            AddLine("begin");
            //veo si le pucieron comentarios
            //if (ComentarioNombreSP.Trim() != "")
            //{
            //    AddLine("\t-- " + ComentarioNombreSP + "\n");
            //}
            string cmt = "";
            int ni, nn;
            nn = ComentarioNombreSP.Length;
            for (ni = 0; ni < nn; ni++)
            {
                if (ComentarioNombreSP[ni] == '\n' || ComentarioNombreSP[ni] == '\r')
                {
                    //se encontro un comentario
                    if (cmt.Trim() != "")
                    {
                        AddLine("\t" + cmt.Trim());
                        cmt = "";
                    }
                }
                else
                {
                    cmt = cmt + ComentarioNombreSP[ni];
                }
            }
            if (cmt.Trim() != "")
            {
                AddLine("\t" + cmt);
            }
            //veo si hay campos que van a tener valores fijos
            if (ValoresFijos.Count > 0)
            {
                AddLine("\t-- Declaración de variables que se requieren ");
                foreach (CParametroSP variable in ValoresFijos)
                {
                    AddLine("\tdeclare @" + variable.nombre + " " + variable.TipoSP);
                }
            }
            //veo si le asignaron comentarios a los parametros
            if (Parametros.Count > 0)
            {
                //genero lalista de parametros
                foreach (CParametroSP parametro in Parametros)
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
                foreach (CParametroSP parametro in Parametros)
                {
                    if (parametro.Vacios == false)
                    {
                        if (primero == true)
                        {
                            AddLine("\t-- Validando que no sean vacios");
                            primero = false;
                        }
                        AddLine("\tif(ltrim(@" + parametro.nombre + ")=\'\')");
                        AddLine("\tbegin");
                        //Version sim tiene comentarios
                        if (parametro.Descripcion.Trim() != "")
                        {

                            AddLine("\t\t-- " + parametro.Descripcion);
                        }
                        AddLine("\t\tRAISERROR(\'" + parametro.ExcepcionVacios + "\', 16, 1)");
                        AddLine("\t\treturn");
                        AddLine("\tend");
                    }
                }
            }
            //ahora valido que no se repitan los campos
            if (Parametros.Count > 0)
            {
                primero = true;
                foreach (CParametroSP parametro in Parametros)
                {
                    if (parametro.ValidarUnicidad == true)
                    {
                        if (primero == true)
                        {
                            AddLine("\t-- Validando que no se pueden repetir");
                            primero = false;
                        }
                        //----------------------------------
                        string s = "\tif exists(select 1 from " + Tabla + " where " + parametro.nombre + "=@" + parametro.nombre;// + ")";
                        if(PK.Campos.Count>1)
                        {
                            s = s + " and (";
                        }
                        else if(PK.Campos.Count == 1)
                        {
                            s = s + " and ";
                        }
                        bool primero3=true;
                        foreach (CCampoBase campo in PK.Campos)
                        {
                            if(primero3 == true)
                            {
                                primero3 = false;
                            }
                            else
                            {
                                s = s + " or ";
                            }
                                s = s + campo.Nombre + "<>@" + campo.Nombre;
                        }
                        if (PK.Campos.Count > 1)
                        {
                            s = s + " )";
                        }
                        s = s + ")";
                        //-------------------------------------
                        //AddLine("\tif exists(select 1 from " + Tabla + " where " + parametro.nombre + "=@" + parametro.nombre + ")");
                        AddLine(s);
                        AddLine("\tbegin");
                        //Version sim tiene comentarios
                        if (parametro.Descripcion.Trim() != "")
                        {

                            AddLine("\t\t-- " + parametro.Descripcion);
                        }
                        AddLine("\t\tRAISERROR(\'" + parametro.ExcepcionNoRepetibles + "\', 16, 1)");
                        AddLine("\t\treturn");
                        AddLine("\tend");
                    }
                }
            }
            //ahora me traigo los valores que son fijos
            if (ValoresFijos.Count > 0)
            {
                foreach (CParametroSP variable in ValoresFijos)
                {
                    if (variable.SelectedValor == true)
                    {
                        AddLine("\tselect @" + variable.nombre + "= " + variable.Valor);
                    }
                    else
                    {
                        //hay que obtenerlo desde una tabla
                        string s = "";
                        primero = true;
                        foreach (CParametroSP p in variable.Filtros)
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
                        foreach (CParametroSP o in variable.Ordenamientos)
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
                        AddLine("\tselect @" + variable.nombre + "=" + variable.Campo + " from " + variable.Tabla + " where " + s + s2);
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
                    //List<CCampoFK> fks = DB.DameCamposFK(fk.name);
                    //genero elselect
                    string s = "";
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
                        s = s + ofk.CampoPadre + "=@" + ofk.CampoHijo + " ";
                    }
                    AddLine("\tif not exists( select * from " + fk.TablaPadre + " where " + s + ")");
                    AddLine("\tbegin");
                    if (fk.Mensage != null && fk.Mensage.Trim() != "")
                    {
                        AddLine("\t\tRAISERROR(\'" + fk.Mensage + "\', 16, 1)");
                    }
                    else
                    {
                        //no asignaron texto para la excepcion, por lo que genero uno automatico
                        AddLine("\t\tRAISERROR(\'No se encontró la relación con la tabla " + fk.TablaPadre + "\', 16, 1)");
                    }
                    AddLine("\t\treturn");
                    AddLine("\tend");
                }
            }
            //ya termine de hacer todas las validaciones, por lo que procedo a hacer el insert
            List<CParametroSP> lista;
            lista = new List<CParametroSP>();
            //le agrego los parametros
            foreach (CParametroSP parametro in Parametros)
            {
                lista.Add(parametro);
            }
            foreach (CParametroSP parametro in ValoresFijos)
            {
                lista.Add(parametro);
            }
            AddLine("\t-- Actualizando el registro");
            primero = true;
            bool primero2 = true;
            string ss = "";
            string ss2 = "";
            AddLine("\tupdate ");
            AddLine("\t\t" + Tabla);
            AddLine("\tset ");
            foreach (CParametroSP obj in lista)
            {
                CCampo Campo = DatosAsistente.Tabla.GetCampo(obj.nombre);
                if (Campo != null) //DB.ExisteCampoTabla(Tabla, obj.nombre))
                {
                    ss = "";
                    if (DatosAsistente.Tabla.EsPrimaryKey(Campo)==false) //obj.LLavePrimaria == false)
                    {
                        if (primero == true)
                        {
                            primero = false;
                        }
                        else
                        {
                            ss = ss + ",";
                        }
                        ss = ss + obj.nombre + "=@" + obj.nombre;
                        AddLine("\t\t" + ss);
                    }
                    else
                    {
                        //es llave primaria, por lo que lo agrego en el where
                        if (primero2 == true)
                        {
                            primero2 = false;
                        }
                        else
                        {
                            ss2 = ss2 + " and ";
                        }
                        ss2 = ss2 + obj.nombre + "=@" + obj.nombre + "\n\r\t\t";
                    }
                }
            }
            AddLine("\t where ");
            AddLine("\t\t" + ss2);
            AddLine("end");
            return Codigo;
        }
        private void CargaDatos()
        {
            // en esta funcion se cargan los datos que los demas modulos del asistente se fueroncaprurando
            NombreSP = DatosAsistente.NombreSp;// (string)DameValor("NombreSP");
            Parametros = DatosAsistente.Parametros;// (List<CParametroSP>)DameValor("ListaParametros");
            ComentarioNombreSP = DatosAsistente.ComentarioNombreSP;// (string)DameValor("ComentarioNombreSP");
            Tabla = DatosAsistente.Tabla.Nombre;// (string)DameValor("Tabla");
            ValoresFijos = DatosAsistente.ValoresFijos;// (List<CParametroSP>)DameValor("AsisSelValFijos");
            LLavesForaneas = DatosAsistente.FreignKeys;// (List<CForeignKey>)DameValor("AsisForeigKeys");
            PK = DatosAsistente.Tabla.PrimaryKey;// DB.DameLLavePrimaria(Tabla);
        }
    }
}
