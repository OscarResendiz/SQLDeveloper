using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;
namespace SQLDeveloper.Modulos.AppsAnalizer.ObjetosModelo
{
    /// <summary>
    /// objeto que representa una carpeta
    /// </summary>
    public class CCarpeta : CObjetoBase
    {
        #region propiedades
        /// <summary>
        /// id de la carpeta
        /// </summary>
        public int ID_Carpeta
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
        /// normbre de la carpeta
        /// </summary>
        public string Nombre
        {
            get;
            set;
        }
        /// <summary>
        /// id de la carpeta a la que pertenece
        /// </summary>
        public int ID_CarpetaPadre
        {
            get;
            set;
        }
        /// <summary>
        /// almacena comentarios sobre la carpeta
        /// </summary>
        public string Comentarios
        {
            get;
            set;
        }
        #endregion
        #region Metodos
        #region manejo de carpetas
        /// <summary>
        /// regresa las carpetas hijas
        /// </summary>
        /// <returns></returns>
        public List<CCarpeta> getCarpetas()
        {
            return Modelo.GetCarpetas(this.ID_Carpeta);
        }
        /// <summary>
        /// crea una nueeva carpeta dentro de esta
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="comentario"></param>
        public void createCarpeta(string nombre, string comentario = "")
        {
            Modelo.InsertCarpeta(nombre, comentario, this.ID_Carpeta);
        }
        /// <summary>
        /// asigna la carpeta a esta
        /// </summary>
        /// <param name="obj"></param>
        public void moveCarpeta(CCarpeta obj)
        {
            if (obj.ID_Carpeta == this.ID_Carpeta)
                throw new Exception("No se puede asignar la misma carpeta");
            obj.ID_CarpetaPadre = this.ID_Carpeta;
            obj.Update();
        }
        /// <summary>
        /// regresa la carpeta padre
        /// </summary>
        /// <returns></returns>
        public CCarpeta getPadre()
        {
            return Modelo.GetCarpetaPadre(this.ID_Carpeta);
        }
        /// <summary>
        /// mueve el archivo a la carpeta
        /// </summary>
        /// <param name="archivo"></param>
        public void MueveArchivo(CArchivo archivo)
        {
            Modelo.MueveArchivo(archivo.ID_Archivo, this.ID_Carpeta);
        }
        #endregion
        #region manejo de documentos
        /// <summary>
        /// regresa los documentos que pertenecen a la carpeta
        /// </summary>
        /// <returns></returns>
        public List<CDocumento> getDocumentos()
        {
            return Modelo.GetDocumentos(this.ID_Carpeta);
        }
        /// <summary>
        /// agrega un documento a la carpeta
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="texto"></param>
        public void createDocumento(string nombre, string texto)
        {
            Modelo.InsertDocumento(this.ID_Carpeta, texto, nombre);
        }
        /// <summary>
        /// mueve el documento a la carpeta
        /// </summary>
        /// <param name="doc"></param>
        public void moveDocumento(CDocumento doc)
        {
            if (doc.ID_Carpeta == this.ID_Carpeta)
                return;
            doc.ID_Carpeta = this.ID_Carpeta;
            doc.update();
        }
        #endregion
        #region manejo de scripts
        /// <summary>
        /// regresa la lista de scripts que pertenecen a la carpeta
        /// </summary>
        /// <returns></returns>
        public List<CScript> getScripts()
        {
            return Modelo.GetScripts(this.ID_Carpeta);
        }
        /// <summary>
        /// crea un script en la carpeta
        /// </summary>
        /// <param name="nombre">nombre del script</param>
        /// <param name="id_Conexion"> id de la conexion </param>
        /// <param name="codigo"> codigo que contiene el script</param>
        /// <param name="comentarios">comentarios</param>
        public void createScript(string nombre,int id_Conexion, string codigo="", string comentarios="")
        {
            Modelo.InsertScript(id_Conexion, ID_Carpeta, codigo, comentarios, nombre);
        }
        #endregion
        #region manejo de archivos
        /// <summary>
        /// regresa la lista de archivos que pertenecen a la carpeta
        /// </summary>
        /// <returns></returns>
        public List<CArchivo> getArchivos()
        {
            return Modelo.GetArchivos(this.ID_Carpeta);
        }
        /// <summary>
        /// crea un archivo en la carpeta
        /// </summary>
        /// <param name="NombreArchivo"></param>
        public void createArchivo(string NombreArchivo)
        {
            Modelo.InsertArchivo(NombreArchivo, this.ID_Carpeta,Color.White,"");
        }
        /// <summary>
        /// asigna un archivo existente a la carpeta
        /// </summary>
        /// <param name="obj"></param>
        public void moveArchivo(CArchivo obj)
        {
            Modelo.MueveArchivo(obj.ID_Archivo, this.ID_Carpeta);
        }
        /// <summary>
        /// mueve el script a la carpeta
        /// </summary>
        /// <param name="obj"></param>
        public void moveScript(CScript obj)
        {
            Modelo.MueveScript(obj.ID_Script, this.ID_Carpeta);
        }
        /// <summary>
        /// mueve el documento a la carpeta
        /// </summary>
        /// <param name="obj"></param>
        public void moveDocument(CDocumento obj)
        {
            Modelo.MueveDocumento(obj.ID_Document, this.ID_Carpeta);
        }
        /// <summary>
        /// mueve el objeto a la carpeta
        /// </summary>
        /// <param name="obj"></param>
        public void moveObjeto(CObjetoCarpeta obj)
        {
            if (obj.ID_Carpeta == this.ID_Carpeta)
                return;
            Modelo.MueveObjeto(obj.ID_Objeto,obj.ID_Carpeta,this.ID_Carpeta);
        }
        #endregion
        #region manejo de objetos
        /// <summary>
        /// regresa la lista de objetos almacenados en la carpeta
        /// </summary>
        /// <returns></returns>
        public List<CObjeto> getObjetos()
        {
            List<CObjeto> l = new List<CObjeto>();
            List<CObjetoCarpeta> tmp = this.Modelo.GetObjetosCarpeta(this.ID_Carpeta);
            foreach (CObjetoCarpeta obj in tmp)
            {
                l.Add(Modelo.GetObjeto(obj.ID_Objeto));
            }
            return l;
        }
        /// <summary>
        /// crea un objeto dentro de la carpeta
        /// </summary>
        /// <param name="id_Conexion"></param>
        /// <param name="nombre"></param>
        /// <param name="tipoObjeto"></param>
        /// <param name="eliminado"></param>
        /// <param name="comentarios"></param>
        /// <param name="bKColor"></param>
        public void createObjeto(int id_Conexion, string nombre, MotorDB.EnumTipoObjeto tipoObjeto, bool eliminado, string comentarios, System.Drawing.Color bKColor)
        {
            int id = this.Modelo.InsertObjeto(id_Conexion, nombre, tipoObjeto, eliminado, comentarios, bKColor);
            Modelo.InsertObjetoCarpeta(this.ID_Carpeta, id);
        }
        /// <summary>
        /// asigna el objeto a la carpeta
        /// </summary>
        /// <param name="obj"></param>
        public void addObjeto(CObjeto obj)
        {
            if (Modelo.GetObjetoCarpeta(this.ID_Carpeta, obj.ID_Objeto) != null)
                return; // ya existe la relacion, por lo que no hago nada
            Modelo.InsertObjetoCarpeta(this.ID_Carpeta, obj.ID_Objeto);
        }
        /// <summary>
        /// quita el objeto de la carpeta
        /// </summary>
        /// <param name="obj"></param>
        public void removeObjeto(CObjeto obj)
        {
            Modelo.DeleteObjetoCarpeta(this.ID_Carpeta, obj.ID_Objeto);
        }
        #endregion
        #region funciones de la carpeta
        /// <summary>
        /// actualiza los datos
        /// </summary>
        public void Update()
        {
            Modelo.UpdateCarpeta(this.ID_Carpeta, this.Nombre, this.ID_CarpetaPadre, this.Comentarios);
        }
        /// <summary>
        /// elimina la carpeta siempre y cuando este vacia
        /// </summary>
        public void delete()
        {
            if (getCarpetas().Count > 0)
                throw new Exception("La carpeta no esta vacia");
            if(getArchivos().Count>0)
                throw new Exception("La carpeta no esta vacia");
            if(getDocumentos().Count>0)
                throw new Exception("La carpeta no esta vaci");
            if(getObjetos().Count>0)
                throw new Exception("La carpeta no esta vaci");
            if(getScripts().Count>0)
                throw new Exception("La carpeta no esta vaci");
            Modelo.DeleteCarpeta(this.ID_Carpeta);
        }
        /// <summary>
        /// elimina la carpeta y todo su contenido
        /// </summary>
        public void deleteCascade()
        {
            foreach(CCarpeta obj in getCarpetas())
            {
                obj.deleteCascade();
            }
            foreach (CObjetoCarpeta obj in Modelo.GetObjetosCarpeta(this.ID_Carpeta))
            {
                obj.delete();
            }
            foreach(CArchivo obj in getArchivos())
            {
                obj.deleteCascade();
            }
            foreach(CDocumento obj in getDocumentos())
            {
                obj.delete();
            }
            foreach(CScript obj in getScripts())
            {
                obj.delete();
            }
            delete();
        }
        public string NombreCorto
        {
            get
            {
                string[] l = Nombre.Split('\\');
                return l[l.Count() - 1];
            }
        }

        #endregion
        #endregion
        #region Reortes
        public override void RepoteMapeo(DataTable tabla,DataRow dr, int nivel)
        {
            string columna = "Nivel" + (nivel + 1).ToString();
            DataRow dr2;
            //calculo el numero de columnas
            if(tabla.Columns.Count<(nivel+1))
            {
                //hay que agregar la columna
                tabla.Columns.Add(columna);
            }
            //agrega el registro que e corresponde
            dr2 = tabla.NewRow();
            if (dr != null)
            {
                //relleno el registro con los datos anterioes
                for(int i=0;i<nivel;i++)
                {
                    dr2[i] = dr[i];
                }
            }
            dr2[columna] = "(Carpeta) " + NombreCorto;
            tabla.Rows.Add(dr2);
            //ahora agrego mis demas carpetas hijas
            List<CCarpeta> carpetas = getCarpetas();
            foreach(CCarpeta carpeta in carpetas)
            {
                carpeta.RepoteMapeo(tabla, dr2, nivel+1);
            }
            //ahora agrego los archivos
            List<CArchivo> archivos = getArchivos();
            foreach(CArchivo archivo in archivos)
            {
                archivo.RepoteMapeo(tabla, dr2, nivel + 1);
            }
        }
        #endregion
    }
}
   