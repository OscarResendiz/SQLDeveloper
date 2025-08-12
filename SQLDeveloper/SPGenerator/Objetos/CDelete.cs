using System;
using System.Collections.Generic;
using System.Text;

namespace SPGenerator
{
    public class CDelete
    {
        private List<string> lineas;
        public string tabs;
        public string tabs2;
        public bool Delete;//si es true es un comando de delete y si es false es select
        public List<CDato> from;//lista con las tablas que se van a involucrar en el comando
        public List<string> where;// lista de campos que componen el where
        public string Mensage;
        private string UltimaTabla, penultimaTabla;
        public int AddFrom(string tabla)
        {
            //agrega una tabla a la seccion from
            //le asigna su letra que le corresponde
            //y regresa la letra
            //si no existe la seccion la crea
            CDato d;
            int max = 1;
            if (from == null)
            {
                // es la primer tabla, por lo que le asigno la letra a
                from = new List<CDato>();
                d = new CDato();
                d.Nombre = tabla;
                d.Valor = 1;
                from.Add(d);
                UltimaTabla=tabla;
                penultimaTabla = "";
                return 1;
            }
            //no es la primera, asi quevoy a buscar aver si ya esta agregada
            foreach (CDato dx in from)
            {
                if (dx.Nombre == tabla)
                {
                    //si existe, por lo que simplemente regreso la letra que le corresponde
                    return (int)dx.Valor;
                }
                if (max < (int)dx.Valor)
                    max = (int)dx.Valor;
            }
            //no esta, hay que asignarle numero de tabla
            max++;
            d = new CDato();
            d.Valor = max;
            d.Nombre = tabla;
            from.Add(d);
            penultimaTabla = UltimaTabla;
            UltimaTabla = tabla;
            return max;
        }
        public void AddWhere(string dato)
        {
            string cadena = "";
            if (where == null)
            {
                //es el primer por lo que no lleva en and
                where = new List<string>();
            }
            else
            {
                //lleva el and
                cadena = "and ";
            }
            cadena = cadena + dato;
            where.Add(cadena);
        }
        public void CpoiaComando(CDelete cmd)
        {
            Delete = cmd.Delete;
            if (cmd.from != null)
            {
                from = new List<CDato>();
                foreach (CDato d in cmd.from)
                {
                    CDato d2 = new CDato();
                    d2.Nombre = d.Nombre;
                    d2.Valor = d.Valor;
                    from.Add(d2);
                }
            }
            if (cmd.where != null)
            {
                where = new List<string>();
                foreach (string s in cmd.where)
                {
                    string s2 = s;
                    where.Add(s2);
                }
            }
        }
        private void AddLine(string s)
        {
            //le agrega los tabuladores
            if (lineas == null)
                lineas = new List<string>();
            lineas.Add(tabs +tabs2+ " " + s+"\n");
        }
        private void VerificaTipo()
        {
            //string s="";
            if (Delete == true)
            {
                tabs2 = "";
                //siempre se elimina el ultimo de la lista
                int max = 0;
                foreach (CDato d in from)
                {
                    if ((int)d.Valor > max)
                        max = (int)d.Valor;
                }
                AddLine("delete ");
                AddLine("\tT" + max.ToString());
            }
            else
            {
                //es un select
                AddLine("if exists( select * ");
                tabs2 = "\t";

            }
        }
        public override string ToString()
        {
            if (lineas != null)
                lineas = null;
            //regresa el comando en texto
            string s="";
            //veo que tipo de comando es
            VerificaTipo();
            //ahora agrego la seccion de from
            AddLine("from ");
            bool primero = true;
            foreach (CDato d in from)
            {
                s = "\t";
                if (primero==false)
                {
                    s = s + ",";
                }
                primero = false;
                s = s +d.Nombre+" T"+d.Valor.ToString();
                AddLine(s);
            }
            //ahora agrego los where
            AddLine("where");
            foreach( string s2 in where)
            {
                AddLine("\t"+s2);
            }
            if (Delete == false)
            {
                //hay que agregar la excepcion
                tabs2 = "";
                AddLine(")");
                AddLine("begin");
                if (Mensage != null && Mensage.Trim() != "")
                {
                    AddLine("\tRAISERROR(\'" + Mensage + "\', 16, 1)");
                }
                else
                {
                    AddLine("\tRAISERROR(\'No se puede eliminar el registro de la tabla " + penultimaTabla+ " porque la tabla " + UltimaTabla+ " contiene información\', 16, 1)");
                }
                AddLine("\treturn");
                AddLine("end");
            }
            //ahora todo lo junto en una sola cadena
            s = "";
            foreach (string s2 in lineas)
            {
                s = s + s2;
            }

            return s;
        }
    }
}
