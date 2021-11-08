using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer.ObjetosModelo
{
    public class CCodigoEditable : CObjetoBase,ISalvable
    {
        #region propiedades
        /// <summary>
        /// clave unica que identifica al codigo editable
        /// </summary>
        public int ID_CodigoEditable
        {
            get;
            set;
        }
        /// <summary>
        /// Id que identifica al objeto al que pertenece
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
        /// Fecha en que se crea el codigo
        /// </summary>
        public DateTime Fecha
        {
            get;
            set;
        }
        /// <summary>
        /// Nombre del script
        /// </summary>
        public string Nombre
        {
            get;
            set;
        }
        /// <summary>
        /// Codigo que contiene
        /// </summary>
        public string Codigo
        {
            get;
            set;
        }
        /// <summary>
        /// Comentarios sobre el objeto
        /// </summary>
        public string Comentarios
        {
            get;
            set;
        }
        #endregion
        #region metodos
        /// <summary>
        /// actualiza los datos
        /// </summary>
        public void update()
        {
            Modelo.UpdateCodigoEditable(this.ID_CodigoEditable, this.ID_Objeto, this.Fecha, this.Nombre, this.Codigo, this.Comentarios);
        }
        /// <summary>
        /// constructor
        /// </summary>
        public CCodigoEditable()
        {
            //inicializa la hora
            Fecha = System.DateTime.Now;
        }
        /// <summary>
        /// elimina el codigo editable
        /// </summary>
        public void delete()
        {
            Modelo.DeleteCodigoEditable(this.ID_CodigoEditable);
        }
        #endregion
        #region implementacion de la interface ISalvable
        public string getCodigo()
        {
            return Codigo;
        }
        public void setCodigo(string codigo)
        {
            Codigo = codigo;
        }
        public void Guardar()
        {
            update();
        }
        public void GuardarComo(string nuevoNombre)
        {
            this.ID_CodigoEditable=Modelo.InsertCodigoEditable(this.ID_Objeto, System.DateTime.Now, nuevoNombre, Codigo, Comentarios);
            this.Nombre = nuevoNombre;
        }
        public string getNombre()
        {
            return Nombre;
        }
        public void setNombre(string nombre)
        {
            this.Nombre = nombre;
        }
        public bool esTuId(int id)
        {
            return this.ID_CodigoEditable == id;
        }
        #endregion
    }
}
   