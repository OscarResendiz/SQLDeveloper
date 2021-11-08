using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MotorDB;

namespace Modelador.Modelo
{
    public class CLlaveForanea : CBaseModelo
    {
        #region Propiedades
        public int ID_FK
        {
            get;
            set;
        }
        public int ID_TablaPadre
        {
            get;
            set;
        }
        public int ID_TablaHija
        {
            get;
            set;
        }
        public string Nombre
        {
            get;
            set;
        }
        public Color LineColor
        {
            get;
            set;
        }
        public EnumAccionReferencial AcctionDelete
        {
            get;
            set;
        }
        public EnumAccionReferencial AcctionUpdate
        {
            get;
            set;
        }
        #endregion
        #region Metodos
        public void Update()
        {
            Modelo.Update_LlaveForanea(ID_FK, ID_TablaPadre, ID_TablaHija, Nombre,AcctionDelete,AcctionUpdate, LineColor);
        }
        public List<CCampoReferencia> Get_Campos()
        {
            return Modelo.Get_CamposReferencia(ID_FK);
        }
        public List<CLineaFK> Get_Lineas()
        {
            return Modelo.Get_LineasFk(this.ID_FK);
        }
        public void Delete()
        {
            //hay que eliminar en cascada
            foreach (CCampoReferencia campo in Get_Campos())
            {
                campo.Delete();
            }
            foreach (CLineaFK linea in Get_Lineas())
            {
                linea.Delete();
            }
            Modelo.Delete_LlaveForanea(this.ID_FK);
        }
        public CTabla Get_TablaPadre()
        {
            return Modelo.Get_Tabla(this.ID_TablaPadre);
        }
        public CTabla Get_TablaHija()
        {
            return Modelo.Get_Tabla(this.ID_TablaHija);
        }
        public void Delete_CampoReferencia(int ID_CampoPadre, int ID_CampoHijo)
        {
            Modelo.Delete_CampoReferencia(ID_FK, ID_CampoPadre, ID_CampoHijo);
        }
        public void Delete_Linea(int ID_LineaFk)
        {
            CLineaFK linea = Modelo.Get_LineaFK(ID_LineaFk);
            if (linea.ID_FK != this.ID_FK)
            {
                throw new Exception("La linea no pertenece a llave foranea");
            }
            Modelo.Delete_LineaFK(ID_LineaFk);
        }
        public void Insert_CampoReferencia(int ID_CampoPadre, int ID_CampoHijo)
        {
            CCampo CampoPadre = Modelo.Get_Campo(ID_CampoPadre);
            CCampo CampoHijo = Modelo.Get_Campo(ID_CampoHijo);
            if (CampoPadre.ID_Tabla != this.ID_TablaPadre)
            {
                throw new Exception("En campo no pertenece a la tabla padre");
            }
            if (CampoHijo.ID_Tabla != this.ID_TablaHija)
            {
                throw new Exception("En campo no pertenece a la tabla hija");
            }
            Modelo.Insert_CampoReferencia(ID_FK, ID_CampoPadre, ID_CampoHijo);
        }
        public void Insert_Linea(int XI, int YI, int XF, int YF, int Orden)
        {
            Modelo.Insert_LineaFK(ID_FK, XI, YI, XF, YF, Orden);
        }
        #endregion
    }
}
