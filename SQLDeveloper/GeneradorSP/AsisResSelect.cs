using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeneradorSP
{
    public partial class AsisResSelect : AsistBaseSP
    {
        private string Tabla;
        private string SP;
        List<Objetos.CParametro> Parametros;
        List<Objetos.CParametro> Campos;
        private string FCodigo;
        public AsisResSelect()
        {
            InitializeComponent();
        }
        private void AgregaLinea(string s)
        {
            richTextBox1.Text = richTextBox1.Text + s + "\n";
        }
        public override void Inicializate()
        {
            richTextBox1.Text = "";
            AgregaLinea("--Resumen del asistente");
            Tabla =(string) DameValor("Tabla");
            AgregaLinea("--Tabla utilizada: "+Tabla);
            SP = (string)DameValor("NombreSP");
            AgregaLinea("--Nombre del procedimiento almacenado: \'"+SP+"\'");
            AgregaLinea("--Lista de parametros:");
            Parametros = (List<Objetos.CParametro>)DameValor("ListaParametros");
            foreach (Objetos.CParametro obj in Parametros)
            {
                AgregaLinea("\t\'" + obj.nombre + "\' " + obj.tipo + "(" + obj.Logitud.ToString() + ")");
            }
            AgregaLinea("--Campos que va a regresar");
            Campos = (List<Objetos.CParametro>)DameValor("Campos");
            foreach (Objetos.CParametro obj in Campos)
            {
                AgregaLinea("\t\'" + obj.nombre+"\'");
            }
            EnableAnterior(true);
            EnableSiguiente(true);
            TextoSiguiente("Finalizar");
            cTextColor1.AnalizaTexto();

        }

        private void cTextColor1_OnCambiaFoco()
        {
            textBox1.Focus();
        }
        private void  AddLine(string s)
        {
            FCodigo = FCodigo + s + "\n";
        }
        public override void BSiguiente()
        {
            //aqui se genera el codigo para crear el SP
            bool Agrupar = false;
            bool noagrupados = false;
            bool primero = true;
            string excepcion;
            FCodigo = "";
            richTextBox1.Text = "";
            string s = "CREATE PROCEDURE " + SP;
            if (Parametros.Count > 0)
            {
                //agrego los parametros al SP
                s = s + "(";
                foreach (Objetos.CParametro obj in Parametros)
                {
                    if (primero == true)
                    {
                        primero = false;
                    }
                    else
                    {
                        s = s + ",";
                    }
                    s = s + "@" + obj.nombre + " " + obj.TipoSP;
                }
                s = s + ") as";
            }
            else
            {
                s = s + " as";
            }
            //AddLine(s);
            AgregaLinea(s);
            AgregaLinea("begin");
            //agrego los comentarios del sp
            string comentario = (string)DameValor("ComentarioNombreSP");
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
                        s = "\t--" + cmt.Trim();
                        AgregaLinea(s);
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
                AgregaLinea(s);
            }
            //veo si los parametros cuentan con comentarios
            if (Parametros.Count > 0)
            {
                //agrego los parametros al SP
                foreach (Objetos.CParametro obj in Parametros)
                {
                    if (obj.Descripcion!=null&&obj.Descripcion.Trim() != "")
                    {
                        s = "\t--@" + obj.nombre + "\t" + obj.Descripcion;
                        AgregaLinea(s);
                    }
                }
            }
            //verifico si hay que generar una excepcion si no se encuentran registros
            bool GenerarExcepcio = (bool)DameValor("CHExcepcionParametros");
            if (GenerarExcepcio == true)
            {
                //muestro el comentario de la excepcion
                comentario = (string)DameValor("ComentariosParametros");
                if (comentario.Trim() != "")
                {
                    s = "\t--" + comentario;
                    AgregaLinea(s);
                }
                //genero la consulta
                s = "\tif not exists( select * from "+Tabla;
                //recorro los paramertos para generar la consulta
                if (Parametros.Count > 0)
                {
                    s = s + " where ";
                    primero = true;
                    //agrego los parametros al SP
                    foreach (Objetos.CParametro obj in Parametros)
                    {
                        if (primero == true)
                            primero = false;
                        else
                            s = s + " and ";
                        if (obj.Filtro == Objetos.TIPO_FILTRO.LIKE)
                        s = s + obj.nombre + obj.SFiltro + "@" + obj.nombre+"+\'%\'";
                        else
                        s = s + obj.nombre + obj.SFiltro + "@" + obj.nombre;
                }
                }
                s = s + ")";
                AgregaLinea(s);
                AgregaLinea("\tbegin");
                excepcion=(string )DameValor("ExcepcionParametros");
                s = "\t\tRAISERROR(\'" + excepcion + "\', 16, 1)";
                AgregaLinea(s);
                AgregaLinea("\t\treturn");
                AgregaLinea("\tend");
            }
            //genero la consulta
            //pongo los campos que se van a regresar
            s = "\tselect";
            //verifico si esta activada la opcion de distinct
            bool distinct = (bool)DameValor("ActivarDistinct");
            if (distinct == true)
            {
                s = s + "  distinct";
            }
            //verifico si esta activada la opcion de top
            bool top = (bool)DameValor("AtcivarTop");
            if (top == true)
            {

                s = s + " top " + DameValor("Top");
            }
            AgregaLinea(s);
            primero = true;
            foreach (Objetos.CParametro obj in Campos)
            {
                s = "\t\t";
                if (primero == true)
                    primero = false;
                else
                    s =s+ ",";
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
                    Objetos.CCaso objcdefault=null; 
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
                    if (obj.Alias!=null&&obj.Alias.Trim() != "")
                    {
                        //le asigno el alias
                        s = s + " as " + obj.Alias;
                    }
                }
                if (obj.Descripcion != null && obj.Descripcion.Trim() != "")
                    s = s + "--" + obj.Descripcion;
                AgregaLinea(s);
            }
            AgregaLinea("\tfrom ");
            AgregaLinea("\t\t"+Tabla);
            //recorro los paramertos para generar la consulta
            if (Parametros.Count > 0)
            {
                AgregaLinea("\twhere ");
                primero = true;
                //agrego los parametros al SP
                foreach (Objetos.CParametro obj in Parametros)
                {
                    s = "\t\t";
                    if (primero == true)
                        primero = false;
                    else
                        s = s + " and ";
                    if (obj.Filtro == Objetos.TIPO_FILTRO.LIKE)
                        s = s + obj.nombre + obj.SFiltro + "@" + obj.nombre + "+\'%\'";
                    else
                        s = s + obj.nombre + obj.SFiltro + "@" + obj.nombre;
                    AgregaLinea(s);
                }
            }
            //veo si hay que agrupar los campos
            if (Agrupar == true && noagrupados==true)
            {
                AgregaLinea("\tgroup by");
                //recorro todos los campos
                primero = true;
                foreach (Objetos.CParametro obj in Campos)
                {
                    s = "\t\t";
                    if (primero == true)
                        primero = false;
                    else
                        s = s + ",";
                    if (obj.Sum == false)
                    {
                        s = s + obj.nombre;
                        AgregaLinea(s);
                    }

                }
            }
            //veo si hay que ordenar
            List<Objetos.CParametro> CamposOrdenamiento = (List<Objetos.CParametro>)DameValor("CamposOrdenamiento");
            if (CamposOrdenamiento.Count > 0)
            {
                //si hay que ordenar
                AgregaLinea("\torder by");
                primero=true;
                foreach (Objetos.CParametro objo in CamposOrdenamiento)
                {
                    s = "\t\t";
                    if (primero == true)
                        primero = false;
                    else
                        s = s + ",";
                    s = s + objo.nombre;
                    if (objo.Descendente == true)
                        s = s + " desc";
                    AgregaLinea(s);
                }
            }

            AgregaLinea("end");
            cTextColor1.AnalizaTexto();
            CodigoSP(SP, richTextBox1.Text);
            CloseEvent();
        }
    }
}

