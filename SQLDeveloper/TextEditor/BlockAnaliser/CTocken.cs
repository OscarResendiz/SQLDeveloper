using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TextEditor
{
    /*
     * clase encargada de almacenar un tocken
     * almacena la palabra y la posicion en que se ecuentra (numero de linea y numero de columna)
     */
    public class CTocken
    {
        public string Cadena;
        public Point Posicion;
        public bool Opener;
        public bool AplicaTabulador
        {
            get;
            set;
        }
        public CTocken()
        {
            AplicaTabulador = false;
            Posicion = new Point();
        }
        public CTocken(string cadena, int x, int y)
        {
            Cadena = cadena;
            Posicion = new Point();
            X = x;
            Y = y;
        }
        public int X
        {
            get
            {
                return Posicion.X;
            }
            set
            {
                Posicion.X = value;
            }
        }
        public int Y
        {
            get
            {
                return Posicion.Y;

            }
            set
            {
                Posicion.Y = value;
            }
        }
        public bool ValidarLetraINicial
        {
            get
            {
                //si inicia con una letra hay que validar 
                if (char.IsLetter(Cadena[0]))
                    return true;
                return false;
            }
        }
    }
}
