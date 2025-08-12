using MotorDB;
using SPGenerator.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGenerator.GeneradorCodigo.Mysql
{
    internal class GeneradorMysqlDelete : GeneradorCodigoBase, IGeneradorCodigo
    {
        private List<CParametroSP> Parametros;
        private string NombreSP;
        private string ComentarioNombreSP;
        private string Tabla;
        CDatosAsistenteSP DatosAsistente;
        private List<CLLaveForanea> LLavesForaneas;
        CPrimaryKey PK;
        private List<CCampo> Variables;
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
            AddLine("\nbegin");
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
                        //Version sim tiene comentarios
                        if (parametro.Descripcion.Trim() != "")
                        {

                            AddLine("\t\t-- " + parametro.Descripcion);
                        }
                        AddLine($"\t\tSIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '{parametro.ExcepcionVacios}';");
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
                        AddLine("\tif exists(select * from " + Tabla + " where " + parametro.nombre + "=V_" + parametro.nombre + ") then");
                        //Version sim tiene comentarios
                        if (parametro.Descripcion.Trim() != "")
                        {

                            AddLine("\t\t-- " + parametro.Descripcion);
                        }
                        AddLine($"\t\tSIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '{parametro.ExcepcionNoRepetibles}';");
                        AddLine("\tend if;");
                    }
                }
            }
            // valido que el registro a eliminar existe
            //----------------------------------------------------------------------------
            AddLine("\t-- validando que el registro a eliminar exista");
            string ccpk = "";
            // me traigo los parametros que pertenecen a la llave primaria
            var l2 = (from p in Parametros where (from c in DatosAsistente.Tabla.PrimaryKey.Campos select c.Nombre).Contains(p.nombre) select p);
            bool primeroccpk = true;
            foreach (var c in l2)
            {
                if (primeroccpk)
                {
                    primeroccpk = false;
                    ccpk = ccpk + $" {c.nombre}=V_{c.nombre}";
                }
                else
                {
                    ccpk = ccpk + $" and {c.nombre}=V_{c.nombre}";
                }

            }
            AddLine("\tif not exists( select * from " + DatosAsistente.Tabla.Nombre + " where " + ccpk + ") then");
            AddLine($"\t\tSIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'No se enctro el registro a Eliminar';");
            AddLine("\tend if;");
            //-------------------------------------------------------------------------

            //ahora valido las llaves foraneas para impedir que truene
            if (LLavesForaneas.Count > 0)
            {
                AddLine("\t-- Validando llaves foráneas");
                foreach (CLLaveForanea fk in LLavesForaneas)
                {
                    ValidaLLaveForanea(fk, "\t");
                }
            }
            //ya termine de hacer todas las validaciones, por lo que procedo a hacer el insert
//            AddLine(Agregavalidaciones());
  //          AddLine(AgregaDeletes());
            List<CParametroSP> lista;
            lista = new List<CParametroSP>();
            //le agrego los parametros
            foreach (CParametroSP parametro in Parametros)
            {
                lista.Add(parametro);
            }
            AddLine("\t-- eliminando el registro");
            primero = true;
            bool primero2 = true;
            string ss = "";
            string ss2 = "";
            AddLine("\tdelete from ");
            AddLine("\t\t" + Tabla);
            // me traigo los campos de la llave primaria
            var l = (from p in Parametros where (from c in DatosAsistente.Tabla.PrimaryKey.Campos select c.Nombre).Contains(p.nombre) select p);
            primero = true;
            ss = "";
            foreach(var c in l)
            {
                if(primero)
                {
                    primero = false;
                    ss = ss + c.nombre + "=V_" + c.nombre;

                }
                else
                {
                    ss = ss +"\n\t\t and "+ c.nombre + "=V_" + c.nombre;

                }
            }
            //foreach (CParametroSP obj in lista)
            //{
            //    if (DatosAsistente.Tabla.GetCampo(obj.nombre) != null)
            //    {
            //        ss = "";
            //        if (obj.LLavePrimaria == false)
            //        {
            //            if (primero == true)
            //            {
            //                primero = false;
            //            }
            //            else
            //            {
            //                ss = ss + ",";
            //            }
            //            ss = ss + obj.nombre + "=V_" + obj.nombre;
            //        }
            //        else
            //        {
            //            //es llave primaria, por lo que lo agrego en el where
            //            if (primero2 == true)
            //            {
            //                primero2 = false;
            //            }
            //            else
            //            {
            //                ss2 = ss2 + " and ";
            //            }
            //            ss2 = ss2 + obj.nombre + "=V_" + obj.nombre + "\n\r\t\t";
            //        }
            //    }
            //}
            AddLine("\t where ");
            AddLine("\t\t" + ss+";");
            AddLine("end");
            return Codigo;
        }
        private void CargaDatos()
        {
            // en esta funcion se cargan los datos que los demas modulos del asistente se fueroncaprurando
            NombreSP = DatosAsistente.NombreSp;
            Parametros = DatosAsistente.Parametros;
            ComentarioNombreSP = DatosAsistente.ComentarioNombreSP;
            Tabla = DatosAsistente.Tabla.Nombre;
            LLavesForaneas = DatosAsistente.FreignKeys;
            PK = DatosAsistente.Tabla.PrimaryKey;// DB.DameLLavePrimaria(Tabla);
        }
        //private string Agregavalidaciones()
        //{
        //    string s = "";
        //    if (LLavesForaneas.Count > 0)
        //    {
        //        AddLine("\t-- validando llaves foraneas");
        //        foreach (CForeignKey fk in LLavesForaneas)
        //        {
        //            List<CDelete> cmds;
        //        }
        //    }
        //    return s;
        //}
        //private string AgregaDeletes()
        //{
        //    string s = "";
        //    if (LLavesForaneas.Count > 0)
        //    {
        //        AddLine("\t-- eliminacion en cascada");
        //        foreach (CForeignKey fk in LLavesForaneas)
        //        {
        //            List<CDelete> cmds;
        //        }
        //    }
        //    return s;
        //}
        private void GeneraVariables(CForeignKey fk)
        {
            if (Variables == null)
            {
                Variables = new List<CCampo>();
            }
            //List<CCampoFK> fks = DB.DameCamposFK(fk.name);
            //List<CCampo> campos;
            CPrimaryKey pk = DatosAsistente.Tabla.PrimaryKey;// DB.DameLLavePrimaria(fk.TablaHija);
            foreach (CCampo obj in pk.Campos)
            {
                bool encontrado = false;
                //primero veo si es llave primaria
                //ahora checo si no esta como parametro del Sp
                foreach (CParametroSP p in Parametros)
                {
                    if (obj.Nombre.ToLower().Trim() == p.nombre.ToLower().Trim())
                    {
                        encontrado = true;
                        break;
                    }
                }
                if (encontrado == false)
                {
                    foreach (CCampo p in Variables)
                    {
                        if (obj.Nombre.ToLower().Trim() == p.Nombre.ToLower().Trim())
                        {
                            encontrado = true;
                            break;
                        }
                    }
                }
                if (encontrado == false)
                {
                    Variables.Add(obj);
                }
            }
            //            if (fk.Hijas == null)
            //              return;
            //        foreach (CForeignKey obj in fk.Hijas)
            //      {
            //        GeneraVariables(obj);
            //  }
        }
        private void ValidaLLaveForanea(CLLaveForanea fk, string tabs)
        {
            string s = "";
            bool primero = true;
            string tab2 = tabs + "\t";
            string tab3 = tab2 + "\t";
            //me traigo los campos y la tabla de la llave
            List<CCampoReference> fks = fk.Campos;
            AddLine(tabs + "-- veo si existen registros en la tabla " + fk.TablaHija);
            s = "if exists(select * from " + fk.TablaHija + " where ";
            //me traigo los campos de la llave foranea que esten dentro de los parametros
            var l = (from c in fk.Campos where (from p in Parametros select p.nombre).Contains(c.CampoPadre.Nombre) select c);
            foreach (CCampoReference obj in l)
            {
                if (primero == true)
                {
                    primero = false;
                }
                else
                {
                    s = s + " and ";
                }
                s = s + obj.CampoHijo + "=V_" + obj.CampoPadre;
            }
            AddLine(tabs + s + ") then");
            //veo si hay que generar una excepcion
            if (fk.GenerarExcepcion == true)
            {
                //como hay que generar una excepcion, ya no valido las tablas hijas
                //agrego el codigo para generar dicha excepcion
                if (fk.Mensage != null && fk.Mensage.Trim() != "")
                {
                    AddLine($"{tab2 } SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '{fk.Mensage}';");
                }
                else
                {
                    AddLine($"{tab2} SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'No se puede eliminar el registro de la tabla {fk.TablaPadre}  porque la tabla {fk.TablaHija} contiene información';");
                }

            }
            else
            {
                //me traigo el primer registro encontrado con la llave foranea
                //me traigo los campos de lllave primaria que no esten dentro de la llave foranea
                CPrimaryKey pk = DatosAsistente.Tabla.PrimaryKey;
                bool tienecampos = false;
                s = "select top 1 ";
                primero = true;
                foreach (CCampoBase campo in pk.Campos)
                {
                    //veo si no esta dentro de los campos de llave foranea
                    bool encontrado = false;
                    foreach (CCampoReference objfk in fks)
                    {
                        if (objfk.CampoHijo.Nombre == campo.Nombre)
                        {
                            encontrado = true;
                            break;
                        }
                    }
                    if (encontrado == false)
                    {
                        tienecampos = true;
                        if (primero == true)
                        {
                            primero = false;
                        }
                        else
                        {
                            s = s + ",";
                        }
                        s = s + "V_" + campo.Nombre + "=" + campo.Nombre;
                    }
                }
                s = s + " from " + fk.TablaHija + " where ";
                primero = true;
                foreach (CCampoReference obj in fks)
                {
                    if (primero == true)
                    {
                        primero = false;
                    }
                    else
                    {
                        s = s + " and ";
                    }
                    s = s + obj.CampoHijo.Nombre + "=V_" + obj.CampoPadre.Nombre;
                }
                if (tienecampos == true)
                {
                    AddLine(tab3 + s);
                }
                //hay que borar en cascada
                if (fk.Hijas != null)
                {
                    foreach (CLLaveForanea obj in fk.Hijas)
                    {
                        ValidaLLaveForanea(obj, tab2);
                    }
                }
                //ahora borro mi registro
                //ahora borro el olos registros hijos
                primero = true;
                s = "delete from " + fk.TablaHija + " where ";
                foreach (CCampoBase campo in pk.Campos)
                {
                    if (primero == true)
                    {
                        primero = false;
                    }
                    else
                    {
                        s = s + " and ";
                    }
                    s = s + campo.Nombre + "=V_" + campo.Nombre;
                }
                AddLine(tab2 + s+";");
            }
            AddLine(tabs + "end if;");
        }
        private void DeclareVariables(string tabs)
        {
            if (Variables == null)
                return;
            foreach (CCampo p in Variables)
            {
                AddLine(tabs + "declare V_" + p.Nombre + " " + p.Tipo);
            }
        }
    }
}
