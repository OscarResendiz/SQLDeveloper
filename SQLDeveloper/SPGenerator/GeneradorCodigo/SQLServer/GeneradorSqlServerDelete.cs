using MotorDB;
using SPGenerator.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGenerator.GeneradorCodigo.SQLServer
{
    internal class GeneradorSqlServerDelete : GeneradorCodigoBase, IGeneradorCodigo
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
                    Add("@" + parametro.nombre + " " + parametro.TipoSP);
                }
                Add(")");
            }
            Add(" as\n");
            AddLine("begin");
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
                        AddLine("\tif exists(select * from " + Tabla + " where " + parametro.nombre + "=@" + parametro.nombre + ")");
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
            //ahora valido las llaves foraneas para impedir que truene
            //if (LLavesForaneas.Count > 0)
            //{
            //    AddLine("\t-- Validando llaves foráneas");
            //    foreach (CForeignKey fk in LLavesForaneas)
            //    {
            //        ValidaLLaveForanea(fk,"\t");
            //    }
            //}
            //ya termine de hacer todas las validaciones, por lo que procedo a hacer el insert
            AddLine(Agregavalidaciones());
            AddLine(AgregaDeletes());
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
            AddLine("\tdelete ");
            AddLine("\t\t" + Tabla);
            foreach (CParametroSP obj in lista)
            {
                if (DatosAsistente.Tabla.GetCampo(obj.nombre)!=null)// DB.ExisteCampoTabla(Tabla, obj.nombre))
                {
                    ss = "";
                    if (obj.LLavePrimaria == false)
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
            NombreSP = DatosAsistente.NombreSp;
            Parametros = DatosAsistente.Parametros;
            ComentarioNombreSP = DatosAsistente.ComentarioNombreSP;
            Tabla = DatosAsistente.Tabla.Nombre;
            LLavesForaneas = DatosAsistente.FreignKeys;
            PK = DatosAsistente.Tabla.PrimaryKey;// DB.DameLLavePrimaria(Tabla);
        }
        private string Agregavalidaciones()
        {
            string s = "";
            if (LLavesForaneas.Count > 0)
            {
                AddLine("\t-- validando llaves foraneas");
                foreach (CForeignKey fk in LLavesForaneas)
                {
                    List<CDelete> cmds;
                }
            }
            return s;
        }
        private string AgregaDeletes()
        {
            string s = "";
            if (LLavesForaneas.Count > 0)
            {
                AddLine("\t-- eliminacion en cascada");
                foreach (CForeignKey fk in LLavesForaneas)
                {
                    List<CDelete> cmds;
                }
            }
            return s;
        }
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
        private void ValidaLLaveForanea(CForeignKey fk, string tabs)
        {
            string s = "";
            bool primero = true;
            string tab2 = tabs + "\t";
            string tab3 = tab2 + "\t";
            //me traigo los campos y la tabla de la llave
            List<CCampoReference> fks = fk.Campos;
            AddLine(tabs + "-- Genero unbucle para recorrer todos los registros de la tabla");
            AddLine(tabs + "declare @" + fk.Nombre + " int");
            AddLine(tabs + "select @" + fk.Nombre + " =1");
            AddLine(tabs + "while(@" + fk.Nombre + " =1)");
            AddLine(tabs + "begin");
            AddLine(tab2 + "-- vero si existen registros en la tabla " + fk.TablaHija);
            s = "if exists(select * from " + fk.TablaHija + " where ";
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
                s = s + obj.CampoHijo + "=@" + obj.CampoPadre;
            }
            AddLine(tab2 + s + ")");
            AddLine(tab2 + "begin");
            //veo si hay que generar una excepcion
            if (fk.GenerarExcepcion == true)
            {
                //como hay que generar una excepcion, ya no valido las tablas hijas
                //agrego el codigo para generar dicha excepcion
                if (fk.Mensage != null && fk.Mensage.Trim() != "")
                {
                    AddLine(tab3 + "RAISERROR(\'" + fk.Mensage + "\', 16, 1)");
                }
                else
                {
                    AddLine(tab3 + "RAISERROR(\'No se puede eliminar el registro de la tabla " + fk.TablaPadre + " porque la tabla " + fk.TablaHija + " contiene información\', 16, 1)");
                }
                AddLine(tab3 + "return");

            }
            else
            {
                //me traigo el primer registro encontrado con la llave foranea
                //me traigo los campos de lllave primaria que no esten dentro de la llave foranea
                CPrimaryKey pk = DatosAsistente.Tabla.PrimaryKey;// DB.DameLLavePrimaria(fk.TablaHija);
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
                        s = s + "@" + campo.Nombre + "=" + campo.Nombre;
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
                    s = s + obj.CampoHijo.Nombre + "=@" + obj.CampoPadre.Nombre;
                }
                if (tienecampos == true)
                {
                    AddLine(tab3 + s);
                }
                //hay que borar en cascada
                //                if (fk..Hijas != null)
                //              {
                //                foreach (CForeignKey obj in fk.Hijas)
                //              {
                //                ValidaLLaveForanea(obj, tab3);
                //          }
                //    }
                //ahora borro mi registro
                //ahora borro el olos registros hijos
                primero = true;
                s = "delete " + fk.TablaHija + " where ";
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
                    s = s + campo.Nombre + "=@" + campo.Nombre;
                }
                AddLine(tab3 + s);
            }
            AddLine(tab2 + "end");
            AddLine(tab2 + "else");
            AddLine(tab2 + "begin");
            AddLine(tab3 + "break");
            AddLine(tab2 + "end");
            AddLine(tabs + "end");
        }
        private void DeclareVariables(string tabs)
        {
            if (Variables == null)
                return;
            foreach (CCampo p in Variables)
            {
                AddLine(tabs + "declare @" + p.Nombre + " " + p.Tipo);
            }
        }
    }
}
