using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorDB
{
    public class CTabla: CObjeto
    {
        #region Variables internas
        private List<CCampo> FCampos;
        private List<CForeignKey> FForeignKeys;
        private List<CCheck> FChecks;
        private List<CUnique> FUniques;
        #endregion
        #region Propiedades de la tabla
        public CIdentidad Identidad
        {
            get;
            set;
        }
        public CPrimaryKey PrimaryKey
        {
            get;
            set;
        }
        public List<CCampo> Campos
        {
            get
            {
                return FCampos;
            }
        }
        public List<CForeignKey> ForeignKeys
        {
            get
            {
                return FForeignKeys;
            }
            set
            {
                FForeignKeys = value;
            }
        }
        public List<CCheck> Checks
        {
            get
            {
                return FChecks;
            }
            set
            {
                FChecks = value;
            }
        }
        public List<CUnique> Uniques
        {
            get
            {
                return FUniques;
            }
            set
            {
                FUniques = value;
            }
        }
        public List<Cindex> Indexs
        {
            get;
            set;
        }
        #endregion
        public CTabla()
        {
            Tipo = EnumTipoObjeto.TABLE;
            FCampos = new List<CCampo>(); //OK
            FForeignKeys = new List<CForeignKey>(); //ok
            FChecks = new List<CCheck>();  //
            FUniques = new List<CUnique>(); //
            Indexs = new List<Cindex>();
        }
        public void AddCampo(CCampo campo)
        {
            foreach(CCampo obj in FCampos)
            {
                if (obj.Nombre == campo.Nombre)
                    return;
            }
            FCampos.Add(campo);
        }
        public void RemoveCampo(string nombre)
        {
            foreach(CCampo obj in FCampos)
            {
                if(obj.Nombre==nombre)
                {
                    FCampos.Remove(obj);
                    return;
                }
            }
        }
        public void AddForeignKey(CForeignKey fk)
        {
            foreach(CForeignKey obj in FForeignKeys)
            {
                if(obj.Nombre==fk.Nombre)
                {
                    return;
                }
            }
            FForeignKeys.Add(fk);
        }
        public void RemoveForeignKey(string nombre)
        {
            foreach(CForeignKey obj in FForeignKeys)
            {
                if(obj.Nombre==nombre)
                {
                    FForeignKeys.Remove(obj);
                    return;
                }
            }
        }
        public void AddCheck(CCheck check)
        {
            foreach(CCheck obj in FChecks)
            {
                if (obj.Nombre == check.Nombre)
                    return;
            }
            FChecks.Add(check);
        }
        public void RemoveCheck(string nombre)
        {
            foreach(CCheck obj in FChecks)
            {
                if(obj.Nombre== nombre)
                {
                    FChecks.Remove(obj);
                    return;
                }
            }
        }
        public void AddUnique(CUnique unique)
        {
            foreach(CUnique obj in FUniques)
            {
                if (obj.Nombre == unique.Nombre)
                    return;
            }
            FUniques.Add(unique);
        }
        public void RemoveUnique(string nombre)
        {
            foreach(CUnique obj in FUniques)
            {
                if(obj.Nombre==nombre)
                {
                    FUniques.Remove(obj);
                    return;
                }
            }
        }
        public bool EsPrimaryKey(CCampo campo)
        {
            if (PrimaryKey == null)
                return false;
            return PrimaryKey.ContieneCampo(campo);
        }
        public bool EsForeignKey(CCampo campo)
        {
            if (FForeignKeys == null)
                return false;
            //recorro todas las llaves foraneas
            foreach(CForeignKey fk in FForeignKeys)
            {
                if (fk.ContieneCampo(campo))
                    return true;
            }
            return false;
        }
        public CCampo GetCampo(string nombre)
        {
            foreach(CCampo obj in FCampos)
            {
                if (obj.Nombre == nombre)
                    return obj;
            }
            return null;
        }
        public bool EsIdentidad(CCampo campo)
        {
            if (Identidad == null)
                return false;
            if (Identidad.Campo.Nombre == campo.Nombre)
                return true;
            return false;
        }
        public bool EsPrimaryKey(Cindex indice)
        {
            if (PrimaryKey == null)
                return false;
            if (indice.Nombre == PrimaryKey.Nombre)
                return true;
            return false;
        }
        public Cindex GetIndex(string index)
        {
            foreach (Cindex obj in Indexs)
            {
                if (obj.Nombre == index)
                    return obj;
            }
            return null;
        }
        public void RemoveIndex(string nombre)
        {
            foreach(Cindex obj in Indexs)
            {
                if(obj.Nombre==nombre)
                {
                    Indexs.Remove(obj);
                    return;
                }
            }
        }
        public void RemovePK()
        {
            PrimaryKey = null;
        }
        public void RemoveDeafult(string campo)
        {
            foreach(CCampo obj in Campos)
            {
                if(obj.Nombre==campo)
                {
                    obj.DefaultName = "";
                    if(obj.EsDefault)
                    {
                        obj.Formula = "";
                        obj.EsDefault = false;
                    }
                    return;
                }
            }
        }
        public void AddIndex(Cindex index)
        {
            foreach(Cindex obj in Indexs)
            {
                if(obj.Nombre==index.Nombre)
                {
                    throw new Exception("El Index ya existe");
                }
            }
            Indexs.Add(index);
        }
    }
}
