using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;
namespace SQLDeveloper.Modulos.AppsAnalizer.ObjetosModelo
{
    public class CArchivo : CObjetoBase
    {
        private string FComentarios;
        #region propiedades
        /// <summary>
        /// Clave interna del archivo
        /// </summary>
        public int ID_Archivo
        {
            get
            {
                return IdObjeto;
            }
            set
            {
                IdObjeto = value;
            }
        }
        /// <summary>
        /// nombre completo del archivo con todo y ruta
        /// </summary>
        public string NombreArchivo
        {
            get;
            set;
        }
        /// <summary>
        /// indica el color con el que hay que resaltar el objeto        
        /// </summary>
        public System.Drawing.Color BKColor
        {
            get;
            set;
        }
        /// <summary>
        /// Comentarios del archivo
        /// </summary>
        public string Comentarios
        {
            get
            {
                return FComentarios;
            }
            set
            {
                if( value==null)
                {
                    FComentarios = "";
                }
                else
                {
                    FComentarios = value;
                }
            }
        }
        /// <summary>
        /// nombre del archivo sin ruta. es de solo lectura
        /// </summary>
        public string NombreCorto
        {
            get
            {
                if (!NombreArchivo.Contains('\\'))
                    return NombreArchivo;
                string[] l=NombreArchivo.Split('\\');
                return l[l.Length - 1];
            }
        }
        /// <summary>
        /// regresa la extencion del archivo
        /// </summary>
        public string Extencion
        {
            get
            {
                if (!NombreArchivo.Contains('.')) //no tiene extencion
                    return "";
                string[] l=NombreArchivo.Split('.');
                return l[l.Length-1];
            }
        }
        /// <summary>
        /// Regresa la ruta del archivo
        /// </summary>
        public string Ruta
        {
            get
            {
                if (!NombreArchivo.Contains('\\'))
                    return ""; //no tiene ruta
                int pos = 0;
                int pos2 = 0;
                while(pos<NombreArchivo.Length)
                {
                    if (NombreArchivo[pos] == '\\')
                        pos2 = pos;
                }
                return NombreArchivo.Substring(0, pos2);
            }
        }
        /// <summary>
        /// regresa la ruta del archivo separado por carpetas
        /// </summary>
        public string[] Carpetas
        {
            get
            {
                return Ruta.Split('\\');
            }
        }
        /// <summary>
        /// Id de la carpeta a la que pertenece el archivo      
        /// </summary>
        public int ID_Carpeta
        {
            get;
            set;
        }
        #endregion
        #region funciones
        #region manejo de objetos
        /// <summary>
        /// regresa la lista de objetos que se encuentan relacionados al archivo
        /// </summary>
        public List<CObjeto> getObjetos()
        {
            List<CObjeto> l = new List<CObjeto>();
            foreach (CArchivoObjeto obj in Modelo.GetArchivoObjetos(this.ID_Archivo))
            {
                l.Add(Modelo.GetObjeto(obj.ID_Objeto));
            }
            return l;
        }
        /// <summary>
        /// asigna el objeto al archivo
        /// </summary>
        /// <param name="obj"></param>
        public void addObjeto(CObjeto obj)
        {
            if (Modelo.GetArchivoObjeto(this.ID_Archivo, obj.ID_Objeto) != null)
                return; //ya existe la relacion
            Modelo.InsertArchivoObjeto(this.ID_Archivo, obj.ID_Objeto);
        }
        /// <summary>
        /// quita el objeto del archivo junto con las lineas asociadas
        /// </summary>
        /// <param name="obj"></param>
        public void removeObjeto(CObjeto obj)
        {
            Modelo.GetArchivoObjeto(this.ID_Archivo, obj.ID_Objeto).deleteCascade();
        }
        #endregion
        #region manejo de lineas
        /// <summary>
        /// agrega una linea al archivo donde se enconntro el objeto.
        /// agrega el objeto tambien al archivo
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="noLinea"></param>
        /// <param name="texto"></param>
        public void createLinea(CObjeto obj, int noLinea, string texto)
        {
            addObjeto(obj);
            Modelo.InsertLineaArchivo(this.ID_Archivo,texto);
        }
        #endregion
        #region funciones del archivo
        /// <summary>
        /// actualiza los datos del archivo
        /// </summary>
        public void update(bool informa=true)
        {
            Modelo.UpdateArchivo(this.ID_Archivo, this.NombreArchivo, this.ID_Carpeta,BKColor,Comentarios,informa);
        }
        /// <summary>
        /// elimina el archivo si no tiene objetos relacionados
        /// </summary>
        public void delete()
        {
            Modelo.DeleteArchivo(this.ID_Archivo);
        }
        /// <summary>
        /// elimina el archivo y todos sus objetos relacionados
        /// </summary>
        public void deleteCascade()
        {
            foreach (CLineaArchivo obj in Modelo.GetLineasArchivo(this.ID_Archivo))
            {
                obj.delete();
            }
            
            foreach(CArchivoObjeto obj in Modelo.GetArchivoObjetos(this.ID_Archivo))
            {
                obj.deleteCascade();
            }
            delete();
        }
        /// <summary>
        /// regresa la capeta en la cual esta contenido el archivo
        /// </summary>
        /// <returns></returns>
        public CCarpeta getCarpeta()
        {
            return Modelo.GetCarpeta(this.ID_Carpeta);
        }
        #endregion
        /// <summary>
        /// regresa las lineas del archivo asocidas
        /// </summary>
        /// <returns></returns>
        public List<CLineaArchivo> getLineas()
        {
            return Modelo.GetLineasArchivo(this.ID_Archivo);
        }

        #endregion
        public CArchivo()
        {
            FComentarios = "";
        }
        #region reportes
        public override void RepoteMapeo(DataTable tabla, DataRow dr, int nivel)
        {
            string columna = "Nivel" + (nivel + 1).ToString();
            DataRow dr2;
            //calculo el numero de columnas
            if (tabla.Columns.Count < (nivel + 1))
            {
                //hay que agregar la columna
                tabla.Columns.Add(columna);
            }
            //agrega el registro que e corresponde
            dr2 = tabla.NewRow();
            if (dr != null)
            {
                //relleno el registro con los datos anterioes
                for (int i = 0; i < nivel; i++)
                {
                    dr2[i] = dr[i];
                }
            }
            dr2[columna] = "(archivo) " + NombreCorto;
            tabla.Rows.Add(dr2);
            //ahora agrego los objetos
            List<CObjeto> objetos = getObjetos();
            foreach(CObjeto objeto in objetos)
            {
                objeto.RepoteMapeo(tabla, dr2, nivel + 1);
            }
        }
        #endregion
    }
}
   