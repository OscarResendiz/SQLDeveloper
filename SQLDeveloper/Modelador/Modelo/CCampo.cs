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
        public int ID_Campo
        {
            get;
            set;
        }
        public string NombreX
        {
            get;
            set;
        }
        public string Comentarios
        {
            get;
            set;
        }
        public int ID_Tabla
        {
            get;
            set;
        }
        public int ID_TipoDato
        {
            get;
            set;
        }
        public int Longitud
        {
            get;
            set;
        }
        public bool PK
        {
            get;
            set;
        }
        public bool AceptaNulos
        {
            get;
            set;
        }
        public bool Calculado
        {
            get;
            set;
        }
        public string Formula
        {
            get;
            set;
        }
        public bool EsDefault
        {
            get;
            set;
        }
        public string DefaultName
        {
            get;
            set;
        }
        public int Orden
        {
            get;
            set;
        }
        #endregion
        #region Metodos
        public List<CCampoIndex> Get_IndexsCampo()
        {
            return Modelo.Get_IndexsCampo(ID_Campo);
        }
        public List<CCampoReferencia> Get_ReferenciasCampo()
        {
            return Modelo.Get_ReferenciasCampo(ID_Campo);
        }
        public List<CCampoUnique> Get_Uniques()
        {
            return Modelo.Get_UniquesCampo(ID_Campo);
        }
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
        public CTabla Get_Tabla()
        {
            return Modelo.Get_Tabla(ID_Tabla);
        }
        public CTipoDato Get_TipoDato()
        {
            return Modelo.Get_TipoDato(ID_TipoDato);
        }
        #endregion
    }
}
