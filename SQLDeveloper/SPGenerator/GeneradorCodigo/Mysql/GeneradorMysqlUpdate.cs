using MotorDB;
using SPGenerator.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGenerator.GeneradorCodigo.Mysql
{
    internal class GeneradorMysqlUpdate : GeneradorCodigoBase, IGeneradorCodigo
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
                    Add("V_" + parametro.nombre + " " + parametro.TipoSP);
                }
                Add(")");
            }
            Add("\n");
            AddLine("begin");
            //veo si le pucieron comentarios
//            if (ComentarioNombreSP.Trim() != "")
  //          {
    //            AddLine("\t-- " + ComentarioNombreSP + "\n");
      //      }
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
                    AddLine("\tdeclare V_" + variable.nombre + " " + variable.TipoSP+";");
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
                        AddLine("\tif(ltrim(V_" + parametro.nombre + ")=\'\') then");
//                        AddLine("\tbegin");
                        //Version sim tiene comentarios
                        if (parametro.Descripcion.Trim() != "")
                        {

                            AddLine("\t\t-- " + parametro.Descripcion);
                        }
                        AddLine($"\t\tSIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '{parametro.ExcepcionVacios}';");
//                        AddLine("\t\tRAISERROR(\'" + parametro.ExcepcionVacios + "\', 16, 1)");
//                        AddLine("\t\treturn");
                        AddLine("\tend if;");
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
                        string norepetidos= $"\tif exists(select * from {  Tabla }  where {  parametro.nombre } = V_{ parametro.nombre}";
                        //agrego la llave primaria a la consulta
                        string spk = "";
                        //me traigo los parametros que pertenecen a la llave primaria
                        var l = (from p in Parametros where (from c in DatosAsistente.Tabla.PrimaryKey.Campos select c.Nombre).Contains(p.nombre) select p);
                        bool primerSpk = true;
                        foreach(var p in l)
                        {
                            if (p.nombre != parametro.nombre)
                            {
                                if (primerSpk == true)
                                {
                                    spk = spk + $" and( {p.nombre}!=V_{p.nombre}";
                                    primerSpk = false;

                                }
                                else
                                {
                                    spk = spk + $" or {p.nombre}!=V_{p.nombre}";

                                }
//                                spk = spk + $" or {p.nombre}!=V_{p.nombre}";
                            }
                        }
                        if(spk!="")
                        {
                            spk = spk + ")";
                        }
                        norepetidos += spk+ ") then";
                        AddLine(norepetidos);
                        //AddLine("\tif exists(select * from " + Tabla + " where " + parametro.nombre + "=V_" + parametro.nombre + ") then");
                        //                        AddLine("\tbegin");
                        //Version sim tiene comentarios
                        if (parametro.Descripcion.Trim() != "")
                        {

                            AddLine("\t\t-- " + parametro.Descripcion);
                        }
                        AddLine($"\t\tSIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '{parametro.ExcepcionNoRepetibles}';");
//                        AddLine("\t\tRAISERROR(\'" + parametro.ExcepcionNoRepetibles + "\', 16, 1)");
//                        AddLine("\t\treturn");
                        AddLine("\tend if;");
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
                        string setValorFijo = "\tset V_" + variable.nombre + "= " + variable.Valor;
                        if (setValorFijo.Contains(";") == false)
                            setValorFijo = setValorFijo + ";";
                        AddLine(setValorFijo);
                        //                        AddLine("\tselect V_" + variable.nombre + "= " + variable.Valor);
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
                        AddLine("\tselect V_" + variable.nombre + "=" + variable.Campo + " from " + variable.Tabla + " where " + s + s2);
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
                        s = s + ofk.CampoPadre + "=V_" + ofk.CampoHijo + " ";
                    }
                    AddLine("\tif not exists( select * from " + fk.TablaPadre + " where " + s + ") then");
//                    AddLine("\tbegin");
                    if (fk.Mensage != null && fk.Mensage.Trim() != "")
                    {
                        AddLine($"\t\tSIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '{fk.Mensage}';");
//                        AddLine("\t\tRAISERROR(\'" + fk.Mensage + "\', 16, 1)");
                    }
                    else
                    {
                        //no asignaron texto para la excepcion, por lo que genero uno automatico
                        AddLine($"\t\tSIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'No se encontró la relación con la tabla  {fk.TablaPadre}';");
//                        AddLine("\t\tRAISERROR(\'No se encontró la relación con la tabla " + fk.TablaPadre + "\', 16, 1)");
                    }
//                    AddLine("\t\treturn");
                    AddLine("\tend if;");
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
            //----------------------------------------------------------------------------
            AddLine("\t-- validando que el registro a actualizar exista");
            string ccpk = "";
            // me traigo los parametros que pertenecen a la llave primaria
            var l2 = (from p in Parametros where (from c in DatosAsistente.Tabla.PrimaryKey.Campos select c.Nombre).Contains(p.nombre) select p);
            bool primeroccpk = true;
            foreach (var c in l2)
            {
                if(primeroccpk)
                {
                    primeroccpk = false;
                    ccpk = ccpk+ $" {c.nombre}=V_{c.nombre}";
                }
                else
                {
                    ccpk = ccpk+ $" and {c.nombre}=V_{c.nombre}";
                }

            }
            AddLine("\tif not exists( select * from " + DatosAsistente.Tabla.Nombre + " where " + ccpk + ") then");
            AddLine($"\t\tSIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'No se enctro el registro a actualizar';");
            AddLine("\tend if;");
            //-------------------------------------------------------------------------
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
                if (DatosAsistente.Tabla.GetCampo(obj.nombre) != null) //DB.ExisteCampoTabla(Tabla, obj.nombre))
                {
                    ss = "";
                    if (DatosAsistente.Tabla.EsPrimaryKey(obj.nombre)==false)// obj.LLavePrimaria == false)
                    {
                        if (primero == true)
                        {
                            primero = false;
                        }
                        else
                        {
                            ss = ss + ",";
                        }
                        ss = ss + obj.nombre + "=V_" + obj.nombre;
                        AddLine("\t\t" + ss);
                    }
                    else
                    {
                        //es llave primaria, por lo que lo agrego en el where
                        if (primero2 == true)
                        {
                            primero2 = false;
                            //ss2 = ss2 + "\n\t\t";
                        }
                        else
                        {
                            ss2 = ss2 + "\n\t\tand ";
                        }
                        ss2 = ss2 + obj.nombre + "=V_" + obj.nombre;
                    }
                }
            }
            AddLine("\t where ");
            AddLine("\t\t" + ss2+";");
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
