using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Threading;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using MotorDB;

namespace LaraverTools.Modelo
{
    public delegate void DelegateModeloEvent(ModeloDatos modelo);

    partial class ModeloDatos
    {
        #region Eventos del modelo
        public event DelegateModeloEvent OnNuevo;
        public event DelegateModeloEvent OnAbrir;
        public event DelegateModeloEvent OnFileNameChange;
        #endregion
        #region Manejo de nivel general
        private string FFileName = "";
        private bool Fmodificando;
        public bool Modificado
        {
            get
            {
                return Fmodificando;
            }
        }
        /// <summary>
        /// nombre del archivo donde se almacena el modelo
        /// </summary>
        public string FileName
        {
            get
            {
                return FFileName;
            }
            set
            {
                FFileName = value;
                if (OnFileNameChange != null)
                    OnFileNameChange(this);
            }
        }
        /// <summary>
        /// hace una copia de seguridad
        /// </summary>
        private void Bakup()
        {
            try
            {
                string nombre = FFileName.Substring(0, FFileName.IndexOf('.')) + "_" + System.DateTime.Now.ToString("ddMMyyyy") + ".bak";
                WriteXml(nombre);
            }
            catch (System.Exception ex)
            {
                return;
            }
        }
        /// <summary>
        /// regresa el nombre del archivo del proyecto sin ruta ni extencion
        /// </summary>
        /// <returns></returns>
        public string getNombreCorto()
        {
            if (FileName.Trim() == "")
                return "";
            //separo por diagonales
            string[] txt = FFileName.Split('\\');
            //separo la extencion
            string[] txt2 = txt[txt.Length - 1].Split('.');
            return txt2[0];
        }
        /// <summary>
        /// inicializa el modelo para trabajar con datos limpios
        /// </summary>
        public void Nuevo()
        {
            //asigno el nuevo nombre
            FileName = "Modelo";
            // limpio los datos
            Clear();
            if (OnNuevo != null)
                OnNuevo(this);
            Inicializa();
        }
        /// <summary>
        /// abre un archivo
        /// </summary>
        /// <param name="fileName"></param>
        public void Abrir(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new Exception("No existe el archivo");
            }
            FileName = fileName;
            Clear();
            ReadXml(FFileName);
            if (OnAbrir != null)
                OnAbrir(this);
            Fmodificando = false;
        }
        public void Inicializa()
        {
            //            Insert_Capa("Principal", true);
            Fmodificando = false;
        }
        public void Cerrar()
        {

        }
        public void Guardar()
        {
            try
            {
                if (FFileName == "")
                {
                    throw new Exception("Falta el nombre del archivo");
                }
                WriteXml(FFileName);
                //ahora almaceno el bakup
                Bakup();
                Fmodificando = false;
            }
            catch (System.Exception ex)
            {
                Fmodificando = false;
                return;
            }
        }
        #endregion
    }
}
