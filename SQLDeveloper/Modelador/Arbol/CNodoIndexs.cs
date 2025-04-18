﻿using Modelador.Modelo;
using Modelador.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Modelador.Arbol
{
    public class CNodoIndexs: CNodoFolder
    {
        public int ID_Tabla
        {
            get;
            set;
        }
        private int Id_Index;
        public CNodoIndexs()
        {
            Nombre="Indices";
        }
        public override void ModeloAsignado()
        {
            base.ModeloAsignado();
            Modelo.OnIndexInsert += new Modelo.DelegateModeloDatosEvent(IndexInsert);
            CargaIndexs();
        }
        public override void Free()
        {
            base.Free();
            Modelo.OnIndexInsert -= IndexInsert;

        }
        public CTabla GetTabla()
        {
            return Modelo.Get_Tabla(ID_Tabla);
        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            AddMenuItem("Agregar Indice", "IconoAgregar", MenuAgregarIndex_Click);
        }

        private void CargaIndexs()
        {
            List<Modelo.CIndexX> l = GetTabla().Get_Indexs();
            foreach(Modelo.CIndexX indice in l)
            {
                CNodoIndex nodo = new CNodoIndex();
                nodo.ID_Index = indice.ID_Index;
                nodo.Modelo = Modelo;
                Nodes.Add(nodo);
            }

        }
        private void IndexInsert(ModeloDatos modelo , int ID_Index)
        {
            Modelo.CIndexX obj = Modelo.Get_Index(ID_Index);
            if (obj.ID_Tabla == ID_Tabla)
            {

                CNodoIndex nodo = new CNodoIndex();
                nodo.ID_Index = obj.ID_Index;
                nodo.Modelo = Modelo;
                Nodes.Add(nodo);
            }

        }
        private void MenuAgregarIndex_Click(Object sender, EventArgs arg)
        {
            FormPropiedadesIndex dlg = new FormPropiedadesIndex();
            dlg.OnCampoIndex += new OnFormPropiedadesCampoIndexEvent(CampoSeleccionado);
            dlg.OnIndex += new OnFormPropiedadesIndexEvent(IndiceSeleccionado);
            foreach(CCampo campo in GetTabla().Get_Campos())
            {
                dlg.AddCampoTabla(campo.Nombre);
            }
            dlg.ShowDialog();
        }
        private void IndiceSeleccionado(string nombre, bool pk, bool generarFuncion, bool MultiplesObjetos)
        {
            try
            {
                Id_Index = Modelo.Insert_IndexX(nombre, ID_Tabla, generarFuncion, MultiplesObjetos);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CampoSeleccionado(string NomCampo, bool descendente)
        {
            try
            {
                CIndexX index = Modelo.Get_Index(Id_Index);
                List<CCampo> campos = GetTabla().Get_Campos();
                foreach (CCampo campo in campos)
                {
                    if (campo.Nombre == NomCampo)
                    {
                        index.Insert_Campo(campo.ID_Campo, descendente);
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
