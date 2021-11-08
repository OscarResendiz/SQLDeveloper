using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorDB
{
    public class CCampoFereneces: CObjeto
    {
        public CCampoFereneces(string columnaMaestra, CTipoDato TipoDatoMaestro, int LongitudMatesto, string columnahija, CTipoDato TipoDatoHijo, int LongitudHijo)
        {
            CampoPadre = new CCampoBase();
            CampoPadre.Nombre = columnaMaestra;
            CampoPadre.TipoDato = TipoDatoMaestro;
            CampoPadre.Longitud = LongitudMatesto;
            CampoHijo = new CCampoBase();
            CampoHijo.Nombre = columnahija;
            CampoHijo.TipoDato = TipoDatoHijo;
            CampoHijo.Longitud = LongitudHijo;
        }
        public CCampoFereneces(string columnaMaestra, string columnaHija, CTipoDato TipoDato, int longitud)
        {
            CampoPadre = new CCampoBase();
            CampoPadre.Nombre = columnaMaestra;
            CampoPadre.TipoDato = TipoDato;
            CampoPadre.Longitud = longitud;
            CampoHijo = new CCampoBase();
            CampoHijo.Nombre = columnaHija;
            CampoHijo.TipoDato = TipoDato;
            CampoHijo.Longitud = longitud;
        }
        public CCampoBase CampoPadre
        {
            get;
            set;
        }
        public CCampoBase CampoHijo
        {
            get;
            set;
        }
    }
}
