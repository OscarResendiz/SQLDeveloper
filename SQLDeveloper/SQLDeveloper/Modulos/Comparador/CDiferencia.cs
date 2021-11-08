using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SQLDeveloper.Modulos.Comparador
{
    public enum TipoDiferencia
    {
        IGUALES,
        AGREGAGO_IZQUIERDO,
        AGREGAGO_DERECHO,
        ELIMINADO_IZQUIERDO,
        ELIMINADO_DERECHO,
        MODIFICADO,
        DIFERENTE_IZQUIERDO,
        DIFERENTE_DERECHO,
        SOLO_IZQUIERDA,
        SOLO_DERECHA,
        NO_ENCONTRADO,
        DIFERENTES
    }
    public class CDiferencia
    {
        public List<CRangoDiferencia> DetalleDiferencias
        {
            get;
            set;
        }
        public bool HayDetalleDiferencias
        {
            get
            {
                if (DetalleDiferencias == null)
                    return false;
                if (DetalleDiferencias.Count == 0)
                    return false;
                return true;

            }
        }
        public CDiferencia()
        {
            InicioIzquierdo = 0;
            InicioDerecho = 0;
            FinIzquierdo = -1;
            FinDerecho = -1;
        }
        public CLinea Izquierda
        {
            get;
            set;
        }
        public CLinea Derecha
        {
            get;
            set;
        }
        public int InicioIzquierdo 
        {
            get;
            set;
        }
        public int FinIzquierdo
        {
            get;
            set;
        }
        public int InicioDerecho
        {
            get;
            set;
        }
        public int FinDerecho
        {
            get;
            set;
        }
        public TipoDiferencia Tipo //Indica el tipo de diferencia
        {
            get;
            set;
        }
        public bool EsIgual(CDiferencia obj)
        {
            if (obj.Tipo != Tipo)
                return false;

            if (obj.Derecha == null && Derecha != null)
                return false;
            if (obj.Derecha != null && Derecha == null)
                return false;
/*            if (obj.Derecha != null && Derecha != null)
            {
                if (obj.Derecha.NLinea != Derecha.NLinea)
                    return false;
                if (obj.Derecha.texto != Derecha.texto)
                    return false;
            }
  */          if (obj.Izquierda == null && Izquierda.texto != null)
                return false;
            if (obj.Izquierda != null && Izquierda.texto == null)
                return false;
            if (obj.Izquierda != null && Izquierda != null)
            {
                if (obj.Izquierda.NLinea != Izquierda.NLinea)
                    return false;
                if (obj.Izquierda.texto != Izquierda.texto)
                    return false;
            }
            return true;
        }
    }
}
