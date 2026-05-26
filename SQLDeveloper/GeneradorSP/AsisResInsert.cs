using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MotorDB;
namespace GeneradorSP
{
    public partial class AsisResInsert : AsistBaseSP
    {
        private IMotorDB DB;
        private string Codigo;
        private string NombreSP;
        private List<Objetos.CParametro> Parametros;
        private List<Objetos.CParametro> ValoresFijos;
        private string ComentarioNombreSP;
        private string Tabla;
        private List<CForeignKey> LLavesForaneas;
        private bool GenerarLLave;
        private Objetos.CParametro CampoLLave;
        //private List<Objetos.CParametro> LLavesPrimarias;
        CPrimaryKey LLavesPrimarias;

        public AsisResInsert(IMotorDB db)
        {
            DB = db;
            InitializeComponent();
        }
        public override void Inicializate()
        {
            TTabla .Text= (string)DameValor("Tabla");
            TNomSP.Text = (string)DameValor("NombreSP");
            List<Objetos.CParametro> lista = (List<Objetos.CParametro>)DameValor("ListaParametros");
            ListaParametros.Items.Clear();
            foreach (Objetos.CParametro obj in lista)
            {
                ListaParametros.Items.Add(obj);
            }
            CHGenLLavePrimaria.Checked = (bool)DameValor("AsisGenLLave");
            TextoSiguiente("Finalizar");
        }
        private void CargaDatos()
        {
            // en esta funcion se cargan los datos que los demas modulos del asistente se fueroncaprurando
            NombreSP = (string)DameValor("NombreSP");
            Parametros = (List<Objetos.CParametro>)DameValor("ListaParametros");
            ComentarioNombreSP = (string)DameValor("ComentarioNombreSP");
            Tabla = (string)DameValor("Tabla");
            ValoresFijos = (List<Objetos.CParametro>)DameValor("AsisSelValFijos");
            LLavesForaneas = (List<CForeignKey>)DameValor("AsisForeigKeys");
            GenerarLLave = (bool)DameValor("AsisGenLLave");
            if (GenerarLLave == true)
            {
                CampoLLave = (Objetos.CParametro)DameValor("CampoLLave");
            }
            //me traigo las llaves primarias
            LLavesPrimarias = DB.DameLLavePrimaria(Tabla);
        }
        private void Add(string s)
        {
            Codigo = Codigo + s;
        }
        private void AddLine(string s)
        {
            Add(s + "\n");
        }
        public override void BSiguiente()
        {
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
                foreach (Objetos.CParametro parametro in Parametros)
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
            string comentario = (string)DameValor("ComentarioNombreSP");
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
                        s = "\t--" + cmt.Trim();
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
                s = "\t--" + cmt;
                AddLine(s);
            }
            //veo si hay campos que van a tener valores fijos
            if (ValoresFijos.Count > 0)
            {
                AddLine("\t--Declaración de variables que se requieren ");
                foreach (Objetos.CParametro variable in ValoresFijos)
                {
                    AddLine("\tdeclare @" + variable.nombre + " " + variable.TipoSP);
                }
            }
            if (GenerarLLave == true)
            {
                //declaro la variable que va a tener el nombre de la llave
                AddLine("\tdeclare @" + CampoLLave.nombre + " " + CampoLLave.TipoSP+" --variable utilizada para generar la llave");
            }
            //veo si le asignaron comentarios a los parametros
            if (Parametros.Count > 0)
            {
                //genero lalista de parametros
                foreach (Objetos.CParametro parametro in Parametros)
                {
                    if (parametro.Descripcion!=null && parametro.Descripcion.Trim() != "")
                    {
                        Add("\t--" + parametro.nombre + " " + parametro.Descripcion+"\n");
                    }
                }
            }
            //ahora agrego validaciones a los parametros
            if (Parametros.Count > 0)
            {
                primero = true;
                foreach (Objetos.CParametro parametro in Parametros)
                {
                    if (parametro.Vacios==false)
                    {
                        if(primero==true)
                        {
                            AddLine("\t--Validando que no sean vacios");
                            primero = false;
                        }
                        AddLine("\tif(ltrim(@" + parametro.nombre + ")=\'\')");
                        AddLine("\tbegin");
                        //Version sim tiene comentarios
                        if (parametro.Descripcion.Trim() != "")
                        {

                            AddLine("\t\t--" + parametro.Descripcion);
                        }
                        AddLine("\t\tRAISERROR(\'"+parametro.ExcepcionVacios+"\', 16, 1)");
                        AddLine("\t\treturn");
                        AddLine("\tend");
                    }
                }
            }
            //ahora valido que no se repitan los campos
            if (Parametros.Count > 0)
            {
                primero = true;
                foreach (Objetos.CParametro parametro in Parametros)
                {
                    if (parametro.ValidarUnicidad== true)
                    {
                        if (primero == true)
                        {
                            AddLine("\t--Validando que no se pueden repetir");
                            primero = false;
                        }
                        AddLine("\tif exists(select * from " + Tabla+ " where "+parametro.nombre+"=@"+parametro.nombre+")");
                        AddLine("\tbegin");
                        //Version sim tiene comentarios
                        if (parametro.Descripcion.Trim() != "")
                        {

                            AddLine("\t\t--" + parametro.Descripcion);
                        }
                        AddLine("\t\tRAISERROR(\'" + parametro.ExcepcionNoRepetibles+ "\', 16, 1)");
                        AddLine("\t\treturn");
                        AddLine("\tend");
                    }
                }
            }
            //ahora me traigo los valores que son fijos
            if (ValoresFijos.Count > 0)
            {
                foreach (Objetos.CParametro variable in ValoresFijos)
                {
                    if (variable.SelectedValor == true)
                    {
                        AddLine("\tselect @" + variable.nombre + "= " + variable.Valor);
                    }
                    else
                    {
                        //hay que obtenerlo desde una tabla
                        s = "";
                        primero=true;
                        foreach (Objetos.CParametro p in variable.Filtros)
                        {
                            if(primero==true)
                            {
                                primero=false;
                            }
                            else
                            {
                                s=s+" and ";
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
                            s=s+p.Campo;
                        }
                        //veo los ordenamientos
                        string s2 = "";
                        primero = true;
                        foreach (Objetos.CParametro o in variable.Ordenamientos)
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
                            s2 = s2+o.nombre;
                            if (o.Descendente == true)
                            {
                                s2 = s2 + " desc ";
                            }
                            else
                            {
                                s2 = s2 + " asc ";
                            }

                        }
                        AddLine("\tselect @"+variable.nombre+"="+variable.Campo+" from "+variable.Tabla+" where "+s+s2);
                    }
                }
            }
            //ahora valido las llaves foraneas para impedir que truene
            if (LLavesForaneas.Count > 0)
            {
                AddLine("\t--Validando llaves foráneas");
                foreach (CForeignKey fk in LLavesForaneas)
                {
                    //veo si tiene algun comentario
                    if (fk.Comentarios!=null && fk.Comentarios.Trim() != "")
                    {
                        AddLine("\t--"+fk.Comentarios);
                    }
                    //me traigo los campos y la tabla de la llave
                    //List<CCampoFK> fks=DB.DameCamposFK(fk.name);
                    //genero elselect
                     s="";
                    primero=true;
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
                    AddLine("\tif not exists( select * from "+fk.TablaPadre+" where "+s+")");
                    AddLine("\tbegin");
                    if (fk.Mensage!=null && fk.Mensage.Trim() != "")
                    {
                        AddLine("\t\tRAISERROR(\'" + fk.Mensage + "\', 16, 1)");
                    }
                    else
                    {
                        //no asignaron texto para la excepcion, por lo que genero uno automatico
                        AddLine("\t\tRAISERROR(\'No se encontró la relación con la tabla " + fk.TablaPadre+ "\', 16, 1)");
                    }
                    AddLine("\t\treturn");
                    AddLine("\tend");
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
                        s = s + pk.Nombre+"=@"+pk.Nombre;
                    }
                }
                 AddLine("\tif not exists( select * from " + Tabla +s+ ")");
                 AddLine("\tbegin");
                 AddLine("\t\tselect @" + CampoLLave.nombre+"=1");
                 AddLine("\tend");
                 AddLine("\telse");
                 AddLine("\tbegin");
                 AddLine("\t\tselect @" + CampoLLave.nombre + "=max("+CampoLLave.nombre+")+1 from " + Tabla +s+ " ");
                 AddLine("\tend");
             }
            //ya termine de hacer todas las validaciones, por lo que procedo a hacer el insert
             List<Objetos.CParametro> lista;
             lista = new List<Objetos.CParametro>();
            //le agrego los parametros
             foreach (Objetos.CParametro parametro in Parametros)
             {
                 lista.Add(parametro);
             }
             foreach (Objetos.CParametro parametro in ValoresFijos)
             {
                 lista.Add(parametro);
             }
             if (GenerarLLave == true)
             {
                 lista.Add(CampoLLave);
             }
            AddLine("\t--agregando el registro");
            primero = true;
            string ss = "";
            string ss2="";
            foreach (Objetos.CParametro obj in lista)
            {
                if (DB.ExisteCampoTabla(Tabla, obj.nombre))
                {
                    if (primero == true)
                    {
                        ss = "(";
                        ss2 = " values(";
                        primero = false;
                    }
                    else
                    {
                        ss = ss + ",";
                        ss2 = ss2 + ",";
                    }
                    ss = ss + obj.nombre;
                    ss2 = ss2 + "@" + obj.nombre;
                }
            }
            ss = ss + ")";
            ss2 = ss2 + ")";
            AddLine("\tinsert into " + Tabla + ss);
            AddLine("\t " + ss2);
            AddLine("end");
//            cTextColor1.AnalizaTexto();
            CodigoSP(NombreSP, Codigo);
            CloseEvent();
        }
    }
}

