using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelador.UI
{
    public partial class FormSeleccionarTablas : Form
    {
        Modelo.ModeloDatos Modelo;
        int ID_Capa;
        List<Modelo.CTabla> Tablas;
        public FormSeleccionarTablas(Modelo.ModeloDatos modelo, int id_capa)            
        {
            Modelo = modelo;
            ID_Capa = id_capa;
            InitializeComponent();
        }

        private void FormSeleccionarTablas_Load(object sender, EventArgs e)
        {
            Tablas = new List<Modelo.CTabla>();
            List<Modelo.CTabla> l = Modelo.Get_Tablas();
            List<Modelo.CTabla> existentes = Modelo.Get_TablasCapa(ID_Capa);
            foreach(Modelo.CTabla obj in l)
            {
                bool ok = false;
                foreach(Modelo.CTabla obj2 in existentes)
                {
                    if (obj.ID_Tabla == obj2.ID_Tabla)
                        ok = true;
                }
                if (!ok)
                {
                    Tablas.Add(obj);
                }
            }
            MuestraTablas();
        }
        public List<Modelo.CTabla> DameTablas()
        {
            List<Modelo.CTabla> l = new List<Modelo.CTabla>();
            foreach (Modelo.CTabla obj in Lista.CheckedItems)
            {
                l.Add(obj);
            }
            return l;
        }
        private void MuestraTablas()
        {
            Lista.Items.Clear();
            foreach (Modelo.CTabla tabla in Tablas)
            {
                if (tabla.Nombre.ToUpper().Trim().Contains(TBuscar.Text.ToUpper().Trim()))
                {
                    Lista.Items.Add(tabla);
                }
            }
        }
        private void TBuscar_TextChanged(object sender, EventArgs e)
        {
            MuestraTablas();
        }
    }
}
