using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelador.Modelo
{
    public class CCampo : CBaseModelo
    {
        #region Propiedades
        /// <summary>
        /// id que identifica el campo
        /// </summary>
        public int ID_Campo
        {
            get;
            set;
        }
        /// <summary>
        /// nombre del campo
        /// </summary>
        public string NombreX
        {
            get;
            set;
        }
        /// <summary>
        /// comentarios sobre el campo
        /// </summary>
        public string Comentarios
        {
            get;
            set;
        }
        /// <summary>
        /// id de la tabla a la que pertenece
        /// </summary>
        public int ID_Tabla
        {
            get;
            set;
        }
        /// <summary>
        /// id del tipo de dato
        /// </summary>
        public int ID_TipoDato
        {
            get;
            set;
        }
        /// <summary>
        /// longitud del campo
        /// </summary>
        public int Longitud
        {
            get;
            set;
        }
        /// <summary>
        /// indica si es parte de la llave primaria
        /// </summary>
        public bool PK
        {
            get;
            set;
        }
        /// <summary>
        /// indica si acepta nulos
        /// </summary>
        public bool AceptaNulos
        {
            get;
            set;
        }
        /// <summary>
        /// indica si es un campo calculado
        /// </summary>
        public bool Calculado
        {
            get;
            set;
        }
        /// <summary>
        /// contiene la formula del campo calculado 
        /// </summary>
        public string Formula
        {
            get;
            set;
        }
        /// <summary>
        /// indica si es un valor default
        /// </summary>
        public bool EsDefault
        {
            get;
            set;
        }
        /// <summary>
        /// valor defuat
        /// </summary>
        public string DefaultName
        {
            get;
            set;
        }
        /// <summary>
        /// orden en que se encuentra dentro de la tabla
        /// </summary>
        public int Orden
        {
            get;
            set;
        }
        #endregion
        #region Metodos
        /// <summary>
        /// regresa la lista de indices a los que pertenece el campo
        /// </summary>
        /// <returns></returns>
        public List<CCampoIndex> Get_IndexsCampo()
        {
            return Modelo.Get_IndexsCampo(ID_Campo);
        }
        /// <summary>
        /// regresa la lista de referencias que hay hacia este campo
        /// </summary>
        /// <returns></returns>
        public List<CCampoReferencia> Get_ReferenciasCampo()
        {
            return Modelo.Get_ReferenciasCampo(ID_Campo);
        }
        /// <summary>
        /// regresa los uniques
        /// </summary>
        /// <returns></returns>
        public List<CCampoUnique> Get_Uniques()
        {
            return Modelo.Get_UniquesCampo(ID_Campo);
        }
        /// <summary>
        /// elimina el campo de la tabla
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void Delete()
        {
            if (Get_ReferenciasCampo().Count > 0)
            {
                throw new Exception("No se puede eliminar porque tiene refrencias a otras tablas");
            }
            foreach (CCampoIndex index in Get_IndexsCampo())
            {
                index.Delete();
            }
            foreach (CCampoUnique unique in Get_Uniques())
            {
                unique.Delete();
            }
            Modelo.Delete_Campo(ID_Campo);
        }
        /// <summary>
        /// actualiza el campo en el modelo
        /// </summary>
        public void Update()
        {
            Modelo.Update_Campo(ID_Campo, NombreX, ID_Tabla, ID_TipoDato, Longitud, PK, AceptaNulos, Calculado, Formula, EsDefault, DefaultName, Orden,Comentarios);
            //me traigo las llaves foraneas hijas para propagar el tipo de campo en caso de haber cambiado
            CTabla tbl = Modelo.Get_Tabla(ID_Tabla);

            List<CLlaveForanea> llaves = tbl.Get_FKHijas();
            //recorro las llaves foraneas para veri si el campo es el mismo que el que estoy modificando
            foreach(CLlaveForanea llave in llaves)
            {
                //me traigo los campos de la llave
                List<CCampoReferencia> campos=llave.Get_Campos();
                foreach(CCampoReferencia campo in campos)
                {
                    //veo si hace referencia a mi campo
                    if(campo.ID_CampoPadre==ID_Campo)
                    {
                        //ahora me traigo la tabla hija
                        CTabla tablaHija = llave.Get_TablaHija();
                        //me traigo el campo
                        List<CCampo> camposHijos = tablaHija.Get_Campos();
                        foreach(CCampo campohijo in camposHijos)
                        {
                            if(campohijo.ID_Campo==campo.ID_CampoHijo)
                            {
                                //checo si tienen el mismo tipo de dato
                                if(campohijo.ID_TipoDato!= ID_TipoDato)
                                {
                                    //hay que cambiar el tipo de dato
                                    campohijo.ID_TipoDato = ID_TipoDato;
                                    campohijo.Update();
                                }
                            }
                        }
                        
                    }
                }
            }
        }
        /// <summary>
        /// regresa la tabla a la que pertenece el campo
        /// </summary>
        /// <returns></returns>
        public CTabla Get_Tabla()
        {
            return Modelo.Get_Tabla(ID_Tabla);
        }
        /// <summary>
        /// regresa el tipo de datos al que pertenece el campo
        /// </summary>
        /// <returns></returns>
        public CTipoDato Get_TipoDato()
        {
            return Modelo.Get_TipoDato(ID_TipoDato);
        }
        #endregion
    }
}
