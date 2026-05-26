using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorDB;
namespace SPGenerator.Objetos
{
    /// <summary>
    /// Summary description for CLLaveForanea.
    /// </summary>
    public class CLLaveForanea: CForeignKey
    {
        public List<CLLaveForanea> Hijas { get; set; } =new List<CLLaveForanea>();
        public CLLaveForanea()
        {
            //
            // TODO: Add constructor logic here
            //
            GenerarExcepcion = true;
        }
        public bool Eliminar;
        public override string ToString()
        {
            return Nombre;
        }
        //nuevos datos
        public string Tabla;//nombre de la tabla padre
        public string Alias;//nombre corto de la tabla que le toca
        public List<CParametroSP> PrimariKey;//campos de la llave primaria de la tabla
        public List<CParametroSP> Variables;//lista de variables con las que se va a hacer el wuere y aplica para el nodo raiz
        public bool raiz;//indica si es en nodo raiz
        public List<CDelete> ComandoDelete(List<CParametroSP> variables, IMotorDB DB, bool modo)
        {
            List<CDelete> comandos = new List<CDelete>();
            CDelete comando = new CDelete();
            comando.Delete = Eliminar;
            comando.Mensage = Mensage;
            string tablapadre;
            //agrego la tabla al comando
            int nt;//numero de tabla
            int ntp;//numero de tabla padre
            List<CCampoFK> llaves;
            llaves = DB.DameCamposFK(Nombre);
            tablapadre = llaves[0].maestra;
            ntp = comando.AddFrom(tablapadre);
            nt = comando.AddFrom(llaves[0].hija);
            //ahora agrego mi seccion de where
            //como es la primer tabla, 
            //me traigo mis llave primaria de la tabla padre
            foreach (CParametroSP p in variables)
            {
                //veo si el campo esta en la tabla
                if (DB.ExisteCampoTabla(tablapadre, p.nombre))
                {
                    //si esta, por lo que la agrego a la lista del where
                    string cadena = "T" + ntp.ToString() + "." + p.nombre + "=@" + p.nombre;
                    comando.AddWhere(cadena);
                }
            }
            //ahora agrego la llave con la tabla padre
            //ahora agrego los where
            foreach (CCampoFK cfk in llaves)
            {
                string s = "T" + nt.ToString() + "." + cfk.columnahija + "=T" + ntp.ToString() + "." + cfk.columnaMaestra;
                comando.AddWhere(s);
            }

            //ahora reviso si tengo hijos
            if (Hijas == null)
            {
                //no tengo, por lo que termino
                if (modo == Eliminar)
                    comandos.Add(comando);
                return comandos;
            }
            //tengo hijos, por lo que recorro cada uno para que agregen su codigo al comando
            foreach (CLLaveForanea hija in Hijas)
            {
                //que agrege los demas comandos
                List<CDelete> l;
                l = hija.AgregaDelete(comando, DB, modo);
                //agrego todos los comandos a mi comando principal
                foreach (CDelete cd in l)
                {
                    comandos.Add(cd);
                }
            }
            //agrego mi comando al final de la lista
            if (modo == Eliminar)
                comandos.Add(comando);
            return comandos;
        }
        private List<CDelete> AgregaDelete(CDelete cmd, IMotorDB DB, bool modo)
        {
            List<CDelete> comandos = new List<CDelete>();
            CDelete Comando = new CDelete();
            //copio el comando para que por cada hijo le agrere sus porpios datos
            Comando.CpoiaComando(cmd);
            Comando.Delete = Eliminar;
            Comando.Mensage = Mensage;
            //agrego mi propia tabla
            int nt;
            nt = Comando.AddFrom(Tabla);
            int ntp; //numero de tabla padre
            //me traigo los campos involucrados en mi llave foranea
            List<CCampoFK> llaves;
            llaves = DB.DameCamposFK(Nombre);
            //agrego la tabla padre para obtener su numero de tabla
            ntp = Comando.AddFrom(llaves[0].maestra);
            //ahora agrego los where
            foreach (CCampoFK cfk in llaves)
            {
                string s = "T" + nt.ToString() + "." + cfk.columnahija + "=T" + ntp.ToString() + "." + cfk.columnaMaestra;
                Comando.AddWhere(s);
            }
            //ahora reviso si tengo hijos
            if (Hijas == null)
            {
                //no tengo, por lo que termino
                if (modo == Eliminar)
                    comandos.Add(Comando);
                return comandos;
            }
            //tengo hijos, por lo que recorro cada uno para que agregen su codigo al comando
            foreach (CLLaveForanea hija in Hijas)
            {
                //que agrege los demas comandos
                List<CDelete> l;
                l = hija.AgregaDelete(Comando, DB, modo);
                //agrego todos los comandos a mi comando principal
                foreach (CDelete cd in l)
                {
                    comandos.Add(cd);
                }
            }
            //agrego mi comando al final de la lista
            if (modo == Eliminar)
                comandos.Add(Comando);
            return comandos;
        }

    }
}
