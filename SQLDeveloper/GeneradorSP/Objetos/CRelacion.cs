using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorDB;
namespace GeneradorSP.Objetos
{
    public class CRelacion
    {
        public List<CCampoFK> CamposFK;
        public string TablaHija;
        public string TablaPadre;
        public bool EliminarCascada;
        public bool ActualisarCascada;
        public string Nombre;
    }
}
