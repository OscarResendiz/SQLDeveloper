using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MotorDB;
using MotorDB.Motores.MySql;
namespace GeneradorScripts.Mysql
{
    public class GeneradoScripMysql
    {
        private List<string> ListaInicial;
        private List<string> ListaOrdenada;
        public MotorDB.IMotorDB Motor
        {
            get;
            set;
        }
        public string Directorio
        {
            get;
            set;
        }
        public void Generar()
        {
            GenerarTablas();
            GeneraVistas();
            GeneraFunciones();
            GeneraSps();
        }
        private void GenerarTablas()
        {
            List<CObjeto> lista = Motor.Buscar("", MotorDB.EnumTipoObjeto.TABLE);
            ListaInicial = new List<string>();
            foreach (CObjeto obj in lista)
            {
                ListaInicial.Add(obj.Nombre);
            }
            OrdenaTablas();
            //genero el scrip de cada tabla
            int id = 1;
            foreach (string tabla in ListaOrdenada)
            {
                GeneraScripTabla(tabla, id);
                id++;
            }
        }
        private void GeneraScripTabla(string tabla, int posicion)
        {
            if (System.IO.Directory.Exists($"$\"{{Directorio}}\\\\Tablas") == false)
            {
                System.IO.Directory.CreateDirectory($"$\"{{Directorio}}\\\\Tablas");
            }
            StreamWriter sw = System.IO.File.CreateText($"{Directorio}\\Tablas\\{posicion.ToString()}_{tabla}.sql");
            string codigo = Motor.DameCodigoTabla(tabla);
            sw.Write(codigo);
            sw.Close();
        }
        private void OrdenaTablas()
        {
            if (ListaInicial.Count == 0)
                return;
            //me traigo el primer objeto
            string tabla = ListaInicial[0];
            do
            {
                //veo si ya existe en la tabla ordenada
                if (ListaOrdenada.Contains(tabla))
                {
                    //ya existe, por lo que ya no la proceso
                    ListaInicial.Remove(tabla);
                    if (ListaInicial.Count == 0)
                        return;
                    //me traigo elprimero
                    tabla = ListaInicial[0];
                    continue;
                }
                //veo si tiene padres
                List<string> padres = DameTablasPadre(tabla);
                if (padres.Count > 0)
                {
                    tabla = padres[0];
                    continue;
                }
                //no tiene padres, por lo que lo agrego a la lista ordenada
                ListaOrdenada.Add(tabla);
                ListaInicial.Remove(tabla);
            }
            while (ListaInicial.Count > 0);
        }
        private List<string> DameTablasPadre(string tabla)
        {
            List<string> lista = new List<string>();
            List<CForeignKey> fks = Motor.DameLLavesForaneas(tabla);
            foreach (CForeignKey fk in fks)
            {
                lista.Add(fk.TablaPadre);
            }
            return lista;
        }
        private void GeneraVistas()
        {
            List<CObjeto> lista = Motor.Buscar("", EnumTipoObjeto.VIEW);
            int id = 1;
            foreach (CObjeto obj in lista)
            {
                CreaScripVista(obj.Nombre, id);
                id++;
            }
        }
        private void CreaScripVista(string vista, int posicion)
        {
            if (System.IO.Directory.Exists($"$\"{{Directorio}}\\\\Vistas") == false)
            {
                System.IO.Directory.CreateDirectory($"$\"{{Directorio}}\\\\Vistas");
            }
            StreamWriter sw = System.IO.File.CreateText($"{Directorio}\\Vistas\\{posicion.ToString()}_{vista}.sql");
            string codigo = Motor.DameCodigoVista(vista);
            sw.Write(codigo);
            sw.Close();

        }
        private void GeneraFunciones()
        {
            List<CObjeto> lista = Motor.Buscar("", EnumTipoObjeto.FUNCION);
            int id = 1;
            foreach (CObjeto obj in lista)
            {
                CreaScripFucion(obj.Nombre, id);
                id++;
            }
        }
        private void CreaScripFucion(string funcion, int posicion)
        {
            if (System.IO.Directory.Exists($"$\"{{Directorio}}\\\\Funciones") == false)
            {
                System.IO.Directory.CreateDirectory($"$\"{{Directorio}}\\\\Funciones");
            }
            StreamWriter sw = System.IO.File.CreateText($"{Directorio}\\Funciones\\{posicion.ToString()}_{funcion}.sql");
            string codigo = Motor.DameCodigoFuncction(funcion);
            sw.Write(codigo);
            sw.Close();

        }
        private void GeneraSps()
        {
            List<CObjeto> lista = Motor.Buscar("", EnumTipoObjeto.PROCEDURE);
            int id = 1;
            foreach (CObjeto obj in lista)
            {
                CreaScripProcedure(obj.Nombre, id);
                id++;
            }
        }
        private void CreaScripProcedure(string sp, int posicion)
        {
            if (System.IO.Directory.Exists($"$\"{{Directorio}}\\\\Sps") == false)
            {
                System.IO.Directory.CreateDirectory($"$\"{{Directorio}}\\\\Sps");
            }
            StreamWriter sw = System.IO.File.CreateText($"{Directorio}\\Sps\\{posicion.ToString()}_{sp}.sql");
            string codigo = Motor.DameCodigoStoreProcedure(sp);
            sw.Write(codigo);
            sw.Close();

        }
        
    }
}
