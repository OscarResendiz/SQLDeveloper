using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SintaxColor;
namespace SQLDeveloper.Modulos.Herramientas.GestorColors
{
    class CNodoDigits:CNodoBase
    {
        CDigits Digits;

        public CNodoDigits()
            {
                Visor = new DigitsControl();
                Text = "Digitos";
        }
        public override void Recarga()
        {
            if (Objeto == null)
                return;
            Digits = (CDigits)Objeto;
            Digits.OnDigitsNameChange += new OnDigitsNameChangeEvent(DigitsNameChange);
            Visor.Objeto = Digits;
            Visor.Recarga();
            Text = Digits.name;
        }
        private void DigitsNameChange(CDigits sender, string nombre)
        {
            Text = nombre;
        }

    }
}
