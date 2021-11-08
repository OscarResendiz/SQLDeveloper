using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SintaxColor
{
    public partial class SintaxColorManager : Component
    {
        private CSyntaxDefinition SyntaxDefinition;
        public SintaxColorManager()
        {
            SyntaxDefinition = new CSyntaxDefinition();
            InitializeComponent();
        }

        public SintaxColorManager(IContainer container)
        {
            container.Add(this);
            SyntaxDefinition = new CSyntaxDefinition();
            InitializeComponent();
        }
        public CSyntaxDefinition GetSyntaxDefinition()
        {
            return SyntaxDefinition;
        }
        public void LoadFile(string fileName)
        {
            if(File.Exists(fileName)==false)
            {
                throw new Exception("No existe el archivo: "+fileName);
            }
            //intento abrirlo
            StreamReader sr = File.OpenText(fileName);
            //leo la pimer linea del archivo y verifico que sea un XMl
            string s = sr.ReadLine();
            if(s.Contains("<?xml")==false)
            {
                throw new Exception("El archivo no ex XML: " + fileName);
            }
            //ahora voy eliminando las lineas hasta encontrar el inicio de SyntaxDefinition
            do
            {
                s = sr.ReadLine();
            }
            while (s.Contains("<SyntaxDefinition") == false);
            //ahora separo todo el archivo en linas para que cada seccion se encarge de leer su parte
            List<string> Lineas=new List<string>();
            do
            {
                Lineas.Add(s);
                s=sr.ReadLine();
            }
            while (s.Contains("</SyntaxDefinition>")==false);
            sr.Close();
            //hasta aqui ya tengo el archivo cargado
            if(Lineas.Count==0)
            {
                throw new Exception("El archivo esta vacio " );
            }
            //le paso las lineas al SyntaxDefinition
            SyntaxDefinition = new CSyntaxDefinition();
            SyntaxDefinition.Load(Lineas);
        }
        public void WriteFile(string filename)
        {
            StreamWriter sw = File.CreateText(filename);
            sw.WriteLine("<?xml version = \"1.0\"?>");
            SyntaxDefinition.Save(sw);
            sw.Close();
        }
    }
}
