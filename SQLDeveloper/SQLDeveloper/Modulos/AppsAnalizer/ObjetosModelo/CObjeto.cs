using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SQLDeveloper.Modulos.AppsAnalizer.ObjetosModelo
{
    /// <summary>
    ///  representa a un objeto de la base de datos
    /// </summary>
    public class CObjeto : CObjetoBase
    {
        #region Propiedades
        /// <summary>
        /// identificador del objeto
        /// </summary>
        public int ID_Objeto
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
        /// id de la conexion a la que pertenece el objeto
        /// </summary>
        public int ID_Conexion
        {
            get;
            set;
        }
        /// <summary>
        /// Nombre del objeto
        /// </summary>
        public string Nombre
        {
            get;
            set;
        }
        /// <summary>
        /// tipo de objeto que representa. puede ser un Sp, una tabla, vista, etc
        /// </summary>
        public MotorDB.EnumTipoObjeto TipoObjeto
        {
            get;
            set;
        }
        /// <summary>
        /// Indica si el objeto fue eliminado de la base de datos
        /// </summary>
        public bool Eliminado
        {
            get;
            set;
        }
        /// <summary>
        /// Comentarios del usuario sobre el objeto
        /// </summary>
        public string Comentarios
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
        #endregion
        #region Metodos
        #region Manejo de objetos
        /// <summary>
        /// regresa la lista de objetos relacionado 
        /// </summary>
        /// <returns></returns>
        public List<CObjeto> getObjetos()
        {
            List<CObjeto> lista = new List<CObjeto>();
            List<CObjetoObjeto> l = Modelo.GetObjetoObjetos(this.ID_Objeto);
            foreach (CObjetoObjeto obj in l)
            {
                lista.Add(Modelo.GetObjeto(obj.ID_ObjetoHijo));
            }
            return lista;
        }
        /// <summary>
        /// agrega el objeto como hijo
        /// </summary>
        /// <param name="obj"></param>
        public void addObjeto(CObjeto obj)
        {
            if (this.ID_Objeto == obj.ID_Objeto)
                throw new Exception("El objeto no puede ser el mismo");
            if(Modelo.GetObjetoObjeto(this.ID_Objeto,obj.ID_Objeto)==null)
            {
                Modelo.InsertObjetoObjeto(this.ID_Objeto, obj.ID_Objeto);
            }
        }
        /// <summary>
        /// quita el objeto 
        /// </summary>
        /// <param name="obj"></param>
        public void removeObjeto(CObjeto obj)
        {
            Modelo.DeleteObjetoObjeto(this.ID_Objeto, obj.ID_Objeto);
        }
        #endregion
        #region manejo de codigos Objeto
        /// <summary>
        /// regresa la lista de objetos codigo
        /// </summary>
        /// <returns></returns>
        public List<CCodigoObjeto> getCodigos()
        {
            return Modelo.GetCodigoObjetos(this.ID_Objeto);
        }
        /// <summary>
        /// agrega codigo al objeto
        /// </summary>
        /// <param name="Codigo"></param>
        /// <param name="Cometarios"></param>
        public void createCodigoObjeto(string Codigo,  string Cometarios="" )
        {
            Modelo.InsertCodigoObjeto(ID_Objeto, DateTime.Now, Codigo, false, Cometarios);
        }
        #endregion
        #region Manejo de codigo Editable
        /// <summary>
        /// regresa la lista de codigos editables que pertenecen al objeto
        /// </summary>
        /// <returns></returns>
        public List<CCodigoEditable> getCodigosEditables()
        {
            return Modelo.GetCodigoEditables(this.ID_Objeto);
        }
        /// <summary>
        /// agrega un codigo editable al objeto
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="Codigo"></param>
        /// <param name="Comentarios"></param>
        public void createCodigoEditable( string Nombre, string Codigo, string Comentarios)
        {
            Modelo.InsertCodigoEditable(ID_Objeto, DateTime.Now, Nombre, Codigo, Comentarios);
        }
        #endregion
        #region Manejo de Archivos y carpetas
        /// <summary>
        /// regresa la lista de archivos donde se encuentra almacenado
        /// </summary>
        /// <returns></returns>
        public List<CArchivo> getArchivos()
        {
            List<CArchivo> l = new List<CArchivo>();
            List<CArchivoObjeto> l2= Modelo.GetArchivosObjeto(this.ID_Objeto);
            foreach(CArchivoObjeto obj in l2)
            {
                l.Add(Modelo.GetArchivo(obj.ID_Archivo));
            }
            return l;
        }
        /// <summary>
        /// regresa la lista de carpetas donde se encuentra almacenado el objeto
        /// </summary>
        /// <returns></returns>
        public List<CCarpeta> getCarpetas()
        {
            List<CCarpeta> l = new List<CCarpeta>();
            List<CObjetoCarpeta> l2 = Modelo.GetCarpetasObjeto(this.ID_Objeto);
            foreach(CObjetoCarpeta obj in l2)
            {
                l.Add(Modelo.GetCarpeta(obj.ID_Carpeta));
            }
            return l;
        }
        #endregion
        #region metodos del objeto
        /// <summary>
        /// elimina el objeto si no tiene relaciones
        /// </summary>
        public void delete()
        {
            if (Modelo.GetObjetosObjeto(this.ID_Objeto).Count > 0)
                throw new Exception("no se puede eliminar porque tiene objetos relacionados");
            if (getObjetos().Count > 0)
                throw new Exception("no se puede eliminar porque tiene objetos relacionados");
            if (getCodigos().Count > 0)
                throw new Exception("no se puede eliminar porque tiene codigos relacionados");
            if (getCodigosEditables().Count > 0)
                throw new Exception("no se puede eliminar porque tiene codigos editables relacionados");
            if (getCodigosEditables().Count > 0)
                throw new Exception("no se puede eliminar porque tiene codigos editables relacionados");
            if (getArchivos().Count > 0)
                throw new Exception("no se puede eliminar porque tiene archivos relacionados");
            if (getCarpetas().Count > 0)
                throw new Exception("no se puede eliminar porque tiene carpetas relacionadas");
            Modelo.DeleteObjeto(this.ID_Objeto);
        }
        /// <summary>
        /// elimina el objeto con todo y sus relaciones
        /// </summary>
        public void deleteCascade()
        {
            //eliino las relaciones de los objetos donde es padre
            foreach (CObjetoObjeto obj in Modelo.GetObjetoObjetos(this.ID_Objeto))
            {
                obj.delete();
            }
            //elimino las relaciones de objetos donde es hijo
            foreach (CObjetoObjeto obj in Modelo.GetObjetosObjeto(this.ID_Objeto))
            {
                obj.delete();
            }
            foreach (CCodigoObjeto obj in getCodigos())
            {
                obj.delete();
            }
            foreach(CCodigoEditable obj in getCodigosEditables())
            {
                obj.delete();
            }
            foreach(CArchivoObjeto obj in Modelo.GetArchivosObjeto(this.ID_Objeto))
            {
                obj.deleteCascade();
            }
            foreach(CObjetoCarpeta obj in Modelo.GetCarpetasObjeto(this.ID_Objeto))
            {
                obj.delete();
            }
            delete();
        }
        /// <summary>
        /// actualiza los datos del objeto en el modelo
        /// </summary>
        public void update(bool informar=true)
        {
            Modelo.UpdateObjeto(ID_Objeto, ID_Conexion, Nombre, TipoObjeto, Eliminado, Comentarios, BKColor, informar);
        }
        #endregion
        #endregion
        /// <summary>
        /// regresa el nombre del objeto con instancia y base de datos
        /// </summary>
        /// <returns></returns>
        public String GetNombreLargo()
        {
            if (Modelo == null)
                return Nombre;
            CConexion conexion = Modelo.GetConexion(this.ID_Conexion);
            CServidor servidor = Modelo.GetServidor(conexion.ID_Servidor);
            return servidor.Nombre + "->" + conexion.Nombre + "->" + this.Nombre;
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
            dr2[columna] = "(" + TipoObjeto.ToString()+ ") " +GetNombreLargo();
            tabla.Rows.Add(dr2);
            //ahora me traigo las dependencias
            List<CObjeto> objetos=            getObjetos();
            foreach(CObjeto objeto in objetos)
            {
                if (objeto.ID_Objeto != this.ID_Objeto)
                {
                    objeto.RepoteMapeo(tabla, dr2, nivel + 1);
                }
            }
        }
        #endregion
    }
}
   