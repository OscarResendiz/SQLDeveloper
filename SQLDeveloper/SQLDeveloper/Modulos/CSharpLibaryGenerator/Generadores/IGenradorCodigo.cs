using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.CSharpLibaryGenerator.Generadores
{
    public delegate void OnGenradorCodigoEvent(int maximo, int progreso, string mensaje);
    
    public interface IGenradorCodigo
    {
        event OnGenradorCodigoEvent OnProgreso;
        event OnGenradorCodigoEvent OnInicio;
        event OnGenradorCodigoEvent OnFin; 
        void Generar();
        void SetModelo(ModeloNet modelo);
    }
}
