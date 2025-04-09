using Modelador.Modelo;
using Modelador.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagerConnect;
using MotorDB;

namespace Modelador.Arbol
{
    public class CNodoTipoDatos : CNodoFolder
    {
        public CNodoTipoDatos()
        {
            Nombre = "Tipos de datos";
        }
        public override void ModeloAsignado()
        {
            base.ModeloAsignado();
            CargaTiposDatos();
            Modelo.OnTipoDatoInsert += new Modelo.DelegateModeloDatosEvent(TipoDatoInsert);
        }
        private void CargaTiposDatos()
        {
            List<Modelo.CTipoDato> tipos = Modelo.Get_TiposDatos();
            foreach (Modelo.CTipoDato dato in tipos)
            {
                CNodoTipoDato nodo = new CNodoTipoDato();
                nodo.ID_TipoDato = dato.ID_TipoDato;
                nodo.Modelo = Modelo;
                Nodes.Add(nodo);
            }
        }
        private void TipoDatoInsert(ModeloDatos modelo, int ID_TipoDato)
        {
            CNodoTipoDato nodo = new CNodoTipoDato();
            nodo.ID_TipoDato = ID_TipoDato;
            nodo.Modelo = Modelo;
            Nodes.Add(nodo);
        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            AddMenuItem("Agregar", "IconoAgregar", MenuAgregar_Click);
            AddMenuItem("Importar", "IconoAgregar", MenuImportar_Click);
        }
        private void MenuAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                FormTipoDato dlg = new FormTipoDato();
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;
                Modelo.Insert_TipoDato(dlg.Nombre, dlg.TipoLongitud);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public override void Free()
        {
            base.Free();
            Modelo.OnTipoDatoInsert -= TipoDatoInsert;
        }
        private void MenuImportar_Click(object sender, EventArgs arg)
        {
            FormSelectConecion dlg = new FormSelectConecion();
            dlg.OnConexion += new OnFormConexionInicialEvent(OnConexionEvent);
            dlg.ShowDialog();
        }
        private void OnConexionEvent(string nombre, CConexion con)
        {
            try
            {
                IMotorDB motor = ControladorConexiones.DameMotor(con);
                List<MotorDB.CTipoDato> l = motor.DameTiposDato();
                foreach (MotorDB.CTipoDato obj in l)
                {
                    bool ok = false;
                    foreach(CNodoTipoDato nodo in Nodes)
                    {
                        if(nodo.Nombre.ToUpper().Trim()==obj.Nombre.ToUpper().Trim())
                        {
                            ok = true;
                            break;
                        }
                    }
                    if (ok == false)
                    {
                        Modelo.Insert_TipoDato(obj.Nombre, obj.UsaLongitud);
                    }
                }
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
