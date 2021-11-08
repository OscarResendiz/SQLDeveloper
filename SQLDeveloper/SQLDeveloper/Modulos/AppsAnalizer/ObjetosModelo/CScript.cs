using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.ObjetosModelo
{
    /// <summary>
    /// representa un scrip
    /// </summary>
    public class CScript : CObjetoBase, ISalvable
    {
        #region Propiedades
        /// <summary>
        /// identificador del script
        /// </summary>
        public int ID_Script
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
        /// identificador de la conexion a la que pertenece
        /// </summary>
        public int ID_Conexion
        {
            get;
            set;
        }
        /// <summary>
        /// identificador de la carpeta en la que se encuentra
        /// </summary>
        public int ID_Carpeta
        {
            get;
            set;
        }
        /// <summary>
        /// codigo del script
        /// </summary>
        public string Codigo
        {
            get;
            set;
        }
        /// <summary>
        /// comentarios del usuario
        /// </summary>
        public string Comentarios
        {
            get;
            set;
        }
        /// <summary>
        /// nombre del script
        /// </summary>
        public string Nombre
        {
            get;
            set;
        }
        #endregion
        #region funciones
        /// <summary>
        /// elimina el script
        /// </summary>
        public void delete()
        {
            Modelo.DeleteScript(ID_Script);
        }
        /// <summary>
        /// actualiza los datos
        /// </summary>
        public void update()
        {
            Modelo.UpdateScript(this.ID_Script, this.ID_Conexion, this.ID_Carpeta, this.Codigo, this.Comentarios, this.Nombre);
        }
        #endregion
        #region implementacion de la interface ISalvable
        public string getCodigo()
        {
            return Codigo;
        }
        public void setCodigo(string codigo)
        {
            this.Codigo=codigo;
        }
        public void Guardar()
        {
            update();
        }
        public void GuardarComo(string nuevoNombre)
        {
           this.ID_Script= Modelo.InsertScript(this.ID_Conexion,this.ID_Carpeta,this.Codigo,this.Comentarios,nuevoNombre);
            this.Nombre=nuevoNombre;
        }
        public string getNombre()
        {
            return Nombre;
        }
        public void setNombre(string nombre)
        {
            Nombre=nombre;
        }
        public bool esTuId(int id)
        {
            return this.ID_Script == id;
        }
        #endregion
    }
}
   