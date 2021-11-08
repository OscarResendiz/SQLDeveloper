using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SintaxColor;

namespace SQLDeveloper.Modulos.Comparador
{
    public class CCOnfigComparator
    {
        private ManagerConnect.ConfiguradorApp Configuracion;
        public CCOnfigComparator()
        {
            Configuracion = new ManagerConnect.ConfiguradorApp();
        }
        private Color DameColor(string parametro, Color col)
        {
            Configuracion.LoadConfig();
            CColor color = new CColor();
            string s = "";
            s = Configuracion.GetTextParameter(parametro);
            if (s == "")
            {
                return col;
            }
            color.Code = s;
            return color.Color;
        }
        private void GuardaColor(string parametro, Color col)
        {
            Configuracion.LoadConfig();
            CColor color = new CColor();
            color.Color = col;
            Configuracion.SetTextParameter(parametro, color.Code);
            Configuracion.SaveConfig();
        }
        public Color ColorDiferenciaLinea
        {
            get
            {
                return DameColor("ColorDiferenciaLinea", Color.DarkGreen);
            }
            set
            {
                GuardaColor("ColorDiferenciaLinea", value);
            }
        }
        public Color ColorPalbraDiferente
        {
            get
            {
                return DameColor("ColorPalbraDiferente", Color.DarkGreen);
            }
            set
            {
                GuardaColor("ColorPalbraDiferente", value);
            }
        }
        public Color ColorLineaVirtual
        {
            get
            {
                return DameColor("ColorLineaVirtual", Color.DarkGreen);
            }
            set
            {
                GuardaColor("ColorLineaVirtual", value);
            }
        }
        public Color ColorNuevaLinea
        {
            get
            {
                return DameColor("ColorNuevaLinea", Color.DarkGreen);
            }
            set
            {
                GuardaColor("ColorNuevaLinea", value);
            }
        }
        public string AlgoritmoComparador
        {
            get
            {
                Configuracion.LoadConfig();
                string s = "";
                s = Configuracion.GetTextParameter("AlgoritmoComparador");
                if (s == "")
                {
                    return "Palabra por palabra";
                }
                return s;
            }
            set
            {
                Configuracion.LoadConfig();
                Configuracion.SetTextParameter("AlgoritmoComparador",value);
                Configuracion.SaveConfig();
            }
        }
        public int SensibilidadComparador
        {
            get
            {
                Configuracion.LoadConfig();
                return Configuracion.GetIntParameter("SensibilidadComparador",15);
            }
            set
            {
                Configuracion.SetIntParameter("SensibilidadComparador",value);
            }
        }
        public Color ColoLetraLineaDiferente
        {
            get
            {
                return DameColor("ColoLetraLineaDiferente", Color.DarkGreen);
            }
            set
            {
                GuardaColor("ColoLetraLineaDiferente", value);
            }
        }
        public Color ColorLetraDiferenciaDetalle
        {
            get
            {
                return DameColor("ColorLetraDiferenciaDetalle", Color.DarkGreen);
            }
            set
            {
                GuardaColor("ColorLetraDiferenciaDetalle", value);
            }
        }
        public Color ColorLetraNuevaLinea
        {
            get
            {
                return DameColor("ColorLetraNuevaLinea", Color.DarkGreen);
            }
            set
            {
                GuardaColor("ColorLetraNuevaLinea", value);
            }
        }
        public bool CaseSencibility
        {
            get
            {
                Configuracion.LoadConfig();
                return Configuracion.GetBooleanParameter("CaseSencibility");

            }
            set
            {
                Configuracion.SetBooleanParameter("CaseSencibility", value);
            }
        }
    }
}
