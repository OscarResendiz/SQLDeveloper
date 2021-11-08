using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
namespace SQLDeveloper.Modulos.CSharpLibaryGenerator.Generadores
{
    public partial class GeneradorCSharp : Component, IGenradorCodigo
    {
        private int Avance = 0;
        private List<CDataClass> Clases;
        private string ProjectName;
        private ModeloNet Modelo;
        private int Maximo = 0;
        private string Directorio;
        public event OnGenradorCodigoEvent OnProgreso;
        public event OnGenradorCodigoEvent OnInicio;
        public event OnGenradorCodigoEvent OnFin;
        public GeneradorCSharp()
        {
            InitializeComponent();
        }

        public GeneradorCSharp(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void SetModelo(ModeloNet modelo)
        {
            Modelo = modelo;
        }
        public void Generar()
        {
            if (BkGenerador.IsBusy == false)
            {
                Maximo = Modelo.DameSps().Count();
                Avance = 0;
                Clases = Modelo.DameClases();
                ProjectName = Modelo.ProjectName;
                if (Modelo.DirectorioDestino == "")
                {
                    if (folderBrowserDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        if (OnFin != null)
                        {
                            OnFin(Maximo, 0, "Proceso cancelado");
                        }
                        return;
                    }
                    Modelo.DirectorioDestino=folderBrowserDialog1.SelectedPath;
                }
                Directorio = Modelo.DirectorioDestino;
                if (OnInicio != null)
                {
                    OnInicio(Maximo, 0, "Iniciando proceso");
                }
                BkGenerador.RunWorkerAsync();
            }
        }
        private void CreaProyecto()
        {
            StreamWriter sw = null;
            try
            {
                Informa("Generando proyecto");
                //creo el archivo del proyecto
                sw = File.CreateText(Directorio + "\\" + ProjectName + ".csproj");
                sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                sw.WriteLine("<Project ToolsVersion=\"12.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">");
                sw.WriteLine("  <Import Project=\"$(MSBuildExtensionsPath)\\$(MSBuildToolsVersion)\\Microsoft.Common.props\" Condition=\"Exists('$(MSBuildExtensionsPath)\\$(MSBuildToolsVersion)\\Microsoft.Common.props')\" />");
                sw.WriteLine("  <PropertyGroup>");
                sw.WriteLine("    <Configuration Condition=\" '$(Configuration)' == '' \">Debug</Configuration>");
                sw.WriteLine("    <Platform Condition=\" '$(Platform)' == '' \">AnyCPU</Platform>");
                sw.WriteLine("    <ProjectGuid>{AA36C023-7F86-4489-88A4-4501251FF39F}</ProjectGuid>");
                sw.WriteLine("    <OutputType>Library</OutputType>");
                sw.WriteLine("    <AppDesignerFolder>Properties</AppDesignerFolder>");
                sw.WriteLine("    <RootNamespace>" + ProjectName + "</RootNamespace>");
                sw.WriteLine("    <AssemblyName>" + ProjectName + "</AssemblyName>");
                sw.WriteLine("    <TargetFrameworkVersion>v4.5</TargetFrameworkVersion>");
                sw.WriteLine("    <FileAlignment>512</FileAlignment>");
                sw.WriteLine("  </PropertyGroup>");
                sw.WriteLine("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' \">");
                sw.WriteLine("    <DebugSymbols>true</DebugSymbols>");
                sw.WriteLine("    <DebugType>full</DebugType>");
                sw.WriteLine("    <Optimize>false</Optimize>");
                sw.WriteLine("    <OutputPath>bin\\Debug\\</OutputPath>");
                sw.WriteLine("    <DefineConstants>DEBUG;TRACE</DefineConstants>");
                sw.WriteLine("    <ErrorReport>prompt</ErrorReport>");
                sw.WriteLine("    <WarningLevel>4</WarningLevel>");
                sw.WriteLine("  </PropertyGroup>");
                sw.WriteLine("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' \">");
                sw.WriteLine("    <DebugType>pdbonly</DebugType>");
                sw.WriteLine("    <Optimize>true</Optimize>");
                sw.WriteLine("    <OutputPath>bin\\Release\\</OutputPath>");
                sw.WriteLine("    <DefineConstants>TRACE</DefineConstants>");
                sw.WriteLine("    <ErrorReport>prompt</ErrorReport>");
                sw.WriteLine("    <WarningLevel>4</WarningLevel>");
                sw.WriteLine("  </PropertyGroup>");
                //se agregan la referencias
                sw.WriteLine("  <ItemGroup>");
                sw.WriteLine("    <Reference Include=\"System\" />");
                sw.WriteLine("    <Reference Include=\"System.Core\" />");
                sw.WriteLine("    <Reference Include=\"System.Data.Linq\" />");
                sw.WriteLine("    <Reference Include=\"System.Xml.Linq\" />");
                sw.WriteLine("    <Reference Include=\"System.Data.DataSetExtensions\" />");
                sw.WriteLine("    <Reference Include=\"Microsoft.CSharp\" />");
                sw.WriteLine("    <Reference Include=\"System.Data\" />");
                sw.WriteLine("    <Reference Include=\"System.Xml\" />");
                sw.WriteLine("  </ItemGroup>");
                sw.WriteLine("  <ItemGroup>");
                // se agregan las clases que hay que generar
                foreach (CDataClass clase in Clases)
                {
                    sw.WriteLine("   <Compile Include=\"" + clase.Nombre + ".designer.cs\">");
                    sw.WriteLine("      <AutoGen>True</AutoGen>");
                    sw.WriteLine("      <DesignTime>True</DesignTime>");
                    sw.WriteLine("      <DependentUpon>" + clase.Nombre + ".dbml</DependentUpon>");
                    sw.WriteLine("    </Compile>");
                }
                sw.WriteLine("    <Compile Include=\"Properties\\AssemblyInfo.cs\" />");
                //se agregan cosas
                sw.WriteLine("    <Compile Include=\"Properties\\Settings.Designer.cs\">");
                sw.WriteLine("      <AutoGen>True</AutoGen>");
                sw.WriteLine("      <DesignTimeSharedInput>True</DesignTimeSharedInput>");
                sw.WriteLine("      <DependentUpon>Settings.settings</DependentUpon>");
                sw.WriteLine("    </Compile>");
                sw.WriteLine("  </ItemGroup>");
                sw.WriteLine("  <ItemGroup>");
                sw.WriteLine("    <None Include=\"app.config\" />");
                foreach (CDataClass clase in Clases)
                {
                    sw.WriteLine("    <None Include=\"" + clase.Nombre + ".dbml\">");
                    sw.WriteLine("      <Generator>MSLinqToSQLGenerator</Generator>");
                    sw.WriteLine("      <LastGenOutput>" + clase.Nombre + ".designer.cs</LastGenOutput>");
                    sw.WriteLine("      <SubType>Designer</SubType>");
                    sw.WriteLine("    </None>");
                }
                sw.WriteLine("    <None Include=\"Properties\\Settings.settings\">");
                sw.WriteLine("      <Generator>SettingsSingleFileGenerator</Generator>");
                sw.WriteLine("      <LastGenOutput>Settings.Designer.cs</LastGenOutput>");
                sw.WriteLine("    </None>");

                sw.WriteLine("  </ItemGroup>");
                sw.WriteLine("  <ItemGroup>");
                sw.WriteLine("    <Service Include=\"{" + Guid.NewGuid() + "}\" />");
                sw.WriteLine("  </ItemGroup>");
                foreach (CDataClass clase in Clases)
                {
                    sw.WriteLine("  <ItemGroup>");
                    sw.WriteLine("    <None Include=\"" + clase.Nombre + ".dbml.layout\">");
                    sw.WriteLine("      <DependentUpon>" + clase.Nombre + ".dbml</DependentUpon>");
                    sw.WriteLine("    </None>");
                    sw.WriteLine("  </ItemGroup>");
                }
                //se vuelve a declarar las clases
                sw.WriteLine("  <Import Project=\"$(MSBuildToolsPath)\\Microsoft.CSharp.targets\" />");
                sw.WriteLine("  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. ");
                sw.WriteLine("       Other similar extension points exist, see Microsoft.Common.targets.");
                sw.WriteLine("  <Target Name=\"BeforeBuild\">");
                sw.WriteLine("  </Target>");
                sw.WriteLine("  <Target Name=\"AfterBuild\">");
                sw.WriteLine("  </Target>");
                sw.WriteLine("  -->");
                sw.WriteLine("</Project>");
                //termino
                sw.Close();
            }
            catch (System.Exception ex)
            {
                if (sw != null)
                {
                    sw.Close();
                }
                throw ex;
            }
        }
        private void CreaDbml(CDataClass clase)
        {
            StreamWriter sw = null;
            try
            {
                Informa("creando " + clase.Nombre + ".dbml");
                List<CConexion> conexiones = Modelo.DameConexionesClase(clase.ID_Class);
                if (conexiones.Count > 1)
                {
                    throw new Exception("No se puede tener varias conexiones en una clase");
                }
                CConexion conexion = conexiones[0];
                sw = File.CreateText(Directorio + "\\" + clase.Nombre + ".dbml");
                MotorDB.IMotorDB motor = conexion.DameMotor();
                sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?><Database Name=\"" + motor.GetDataBseName() + "\" Class=\"" + clase.Nombre + "DataContext\" xmlns=\"http://schemas.microsoft.com/linqtosql/dbml/2007\">");
                sw.WriteLine("  <Connection Mode=\"AppSettings\" ConnectionString=\"" + motor.GetConecctionString().Replace("\"", "") + "\" SettingsObjectName=\"" + ProjectName + ".Properties.Settings\" SettingsPropertyName=\"" + motor.GetDataBseName() + "ConnectionString\" Provider=\"" + motor.GetNetProvider() + "\" />");
                //genero el codigo para cada sp
                List<CStoreProcedures> Sps = Modelo.DameSpsClase(clase.ID_Class);
                foreach (CStoreProcedures sp in Sps)
                {
                    sw.WriteLine("  <Function Name=\"" + sp.Nombre + "\" Method=\"" + sp.Nombre + "\">");
                    //agrego los parametros
                    List<MotorDB.CParametro> parametros = motor.DameParametrosStoreProcedure(sp.Nombre);
                    foreach (MotorDB.CParametro parametro in parametros)
                    {
                        sw.WriteLine("    <Parameter Name=\"" + parametro.Nombre + "\" Type=\"" + motor.DameTipoDatoNet(parametro.TipoDato) + "\" DbType=\"" + parametro.TipoDato.Nombre + "\" />");
                    }
                    //ahora agrego los datos de resultado
                    MotorDB.CTabla res1 = motor.DamePrimerResultadoProcedimientoAlmacenado(sp.Nombre);
                    if (res1 != null)
                    {
                        //como el likq solo utiliza la primer tabla hago lo mismo
                        sw.WriteLine("    <ElementType Name=\"" + sp.Nombre + "Result\">");
                        //recorro los campos                    
                        foreach (MotorDB.CCampo campo in res1.Campos)
                        {
                            string s = "<Column Name=\"" + campo.Nombre + "\" Type=\"" + motor.DameTipoDatoNet(campo.TipoDato) + "\" DbType=\"" + campo.TipoDato.Nombre;
                            if (campo.TipoDato.UsaLongitud != MotorDB.TIPO_LONGITUD.NOREQUERIDO)
                            {
                                s += "(" + campo.Longitud + ")";
                            }
                            if (campo.AceptaNulo == false)
                            {
                                s += "\" NOT NULL CanBeNull=\"false\"";
                            }
                            else
                            {
                                s += "\" CanBeNull=\"true\"";
                            }
                            s += "/>";
                            sw.WriteLine(s);
                        }
                        sw.WriteLine("    </ElementType>");
                    }
                    sw.WriteLine("  </Function>");
                }
                sw.WriteLine("</Database>");
                sw.Close();
            }
            catch (System.Exception ex)
            {
                if (sw != null)
                {
                    sw.Close();
                    throw ex;
                }
            }
        }
        private string DameDbType(MotorDB.IMotorDB motor, MotorDB.CParametro parametro)
        {
            string s = parametro.Nombre + " " + parametro.TipoDato.Nombre;
            if (parametro.TipoDato.UsaLongitud == MotorDB.TIPO_LONGITUD.OBLIGATORIO)
            {
                s += "(" + parametro.Longitud + ")";
            }
            return s;
        }
        private string DameDbType(MotorDB.IMotorDB motor, MotorDB.CCampo campo)
        {
            string s = campo.Nombre + " " + campo.TipoDato.Nombre;
            if (campo.TipoDato.UsaLongitud == MotorDB.TIPO_LONGITUD.OBLIGATORIO)
            {
                s += "(" + campo.Longitud + ")";
            }
            return s;
        }
        private void ValidaClase(CDataClass clase)
        {
            List<CConexion> conexiones = Modelo.DameConexionesClase(clase.ID_Class);
            if (conexiones.Count > 1)
            {
                throw new Exception("No se puede tener varias conexiones en una clase");
            }
        }
        private void CreaLayout(CDataClass clase)
        {
            StreamWriter sw = null;
            try
            {
                Informa("creando " + clase.Nombre + ".dbml.layout");
                sw = File.CreateText(Directorio + "\\" + clase.Nombre + ".dbml.layout");
                sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                sw.WriteLine("<ordesignerObjectsDiagram dslVersion=\"1.0.0.0\" absoluteBounds=\"0, 0, 11, 8.5\" name=\"" + clase.Nombre + "\">");
                sw.WriteLine("  <DataContextMoniker Name=\"/" + clase.Nombre + "DataContext\" />");
                sw.WriteLine("</ordesignerObjectsDiagram>");
                sw.Close();
            }
            catch (System.Exception ex)
            {
                if (sw != null)
                    sw.Close();
                throw ex;
            }
        }
        private void CreaDesigner(CDataClass clase)
        {
            StreamWriter sw = null;
            try
            {
                Informa("creando " + clase.Nombre + ".designer.cs");
                List<CConexion> conexiones = Modelo.DameConexionesClase(clase.ID_Class);
                CConexion conexion = conexiones[0];
                MotorDB.IMotorDB motor = conexion.DameMotor();
                sw = File.CreateText(Directorio + "\\" + clase.Nombre + ".designer.cs");
                sw.WriteLine("#pragma warning disable 1591");
                sw.WriteLine("//------------------------------------------------------------------------------");
                sw.WriteLine("// <auto-generated>");
                sw.WriteLine("//     This code was generated by a tool.");
                sw.WriteLine("//     Runtime Version:4.0.30319.42000");
                sw.WriteLine("//");
                sw.WriteLine("//     Changes to this file may cause incorrect behavior and will be lost if");
                sw.WriteLine("//     the code is regenerated.");
                sw.WriteLine("// </auto-generated>");
                sw.WriteLine("//------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine("namespace " + ProjectName + "");
                sw.WriteLine("{");
                sw.WriteLine("	using System.Data.Linq;");
                sw.WriteLine("	using System.Data.Linq.Mapping;");
                sw.WriteLine("	using System.Data;");
                sw.WriteLine("	using System.Collections.Generic;");
                sw.WriteLine("	using System.Reflection;");
                sw.WriteLine("	using System.Linq;");
                sw.WriteLine("	using System.Linq.Expressions;");
                sw.WriteLine("	using System.ComponentModel;");
                sw.WriteLine("	using System;");
                sw.WriteLine("");
                sw.WriteLine("	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name=\"" + motor.GetDataBseName() + "\")]");
                sw.WriteLine("	public partial class " + clase.Nombre + "DataContext : System.Data.Linq.DataContext");
                sw.WriteLine("	{");
                sw.WriteLine("");
                sw.WriteLine("		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();");
                sw.WriteLine("");
                sw.WriteLine("    #region Extensibility Method Definitions");
                sw.WriteLine("    partial void OnCreated();");
                sw.WriteLine("    #endregion");
                sw.WriteLine("");
                sw.WriteLine("		public " + clase.Nombre + "DataContext() : ");
                sw.WriteLine("				base(global::" + ProjectName + ".Properties.Settings.Default." + motor.GetDataBseName() + "ConnectionString, mappingSource)");
                sw.WriteLine("		{");
                sw.WriteLine("			OnCreated();");
                sw.WriteLine("		}");
                sw.WriteLine("");
                sw.WriteLine("		public " + clase.Nombre + "DataContext(string connection) : ");
                sw.WriteLine("				base(connection, mappingSource)");
                sw.WriteLine("		{");
                sw.WriteLine("			OnCreated();");
                sw.WriteLine("		}");
                sw.WriteLine("");
                sw.WriteLine("		public " + clase.Nombre + "DataContext(System.Data.IDbConnection connection) : ");
                sw.WriteLine("				base(connection, mappingSource)");
                sw.WriteLine("		{");
                sw.WriteLine("			OnCreated();");
                sw.WriteLine("		}");
                sw.WriteLine("");
                sw.WriteLine("		public " + clase.Nombre + "DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : ");
                sw.WriteLine("				base(connection, mappingSource)");
                sw.WriteLine("		{");
                sw.WriteLine("			OnCreated();");
                sw.WriteLine("		}");
                sw.WriteLine("");
                sw.WriteLine("		public " + clase.Nombre + "DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : ");
                sw.WriteLine("				base(connection, mappingSource)");
                sw.WriteLine("		{");
                sw.WriteLine("			OnCreated();");
                sw.WriteLine("		}");
                //   sw.WriteLine("		[global::System.Data.Linq.Mapping.FunctionAttribute(Name=\"dbo.SP_PruebaASSET\")]");
                //creo el mapa de funciones
                List<CStoreProcedures> Sps = Modelo.DameSpsClase(clase.ID_Class);
                foreach (CStoreProcedures sp in Sps)
                {
                    sw.WriteLine("		[global::System.Data.Linq.Mapping.FunctionAttribute(Name=\"" + sp.Nombre + "\")]");
                    string s = "		public ISingleResult<" + sp.Nombre + "Result> " + sp.Nombre + "(";
                    //asigno parametros
                    List<MotorDB.CParametro> parametros = motor.DameParametrosStoreProcedure(sp.Nombre);
                    bool primero = true;
                    foreach (MotorDB.CParametro parametro in parametros)
                    {
                        if (primero == false)
                        {
                            s += ",";

                        }
                        primero = false;
                        s += "[global::System.Data.Linq.Mapping.ParameterAttribute(DbType=\"" + DameDbType(motor, parametro) + "\")] ";
                        s += motor.DameTipoDatoNet(parametro.TipoDato) + " " + parametro.Nombre;
                    }
                    s += ")";
                    sw.WriteLine(s);
                    sw.WriteLine("		{");
                    //hace la llamada al SP
                    s = "			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())),";
                    //asigo parametros
                    primero = true;
                    foreach (MotorDB.CParametro parametro in parametros)
                    {
                        if (primero == false)
                        {
                            s += ",";
                        }
                        primero = false;
                        s += parametro.Nombre + " ";
                    }
                    s += " );";
                    sw.WriteLine(s);
                    sw.WriteLine("			return ((ISingleResult<" + sp.Nombre + "Result>)(result.ReturnValue));");
                    sw.WriteLine("		}");
                }
                sw.WriteLine("	}");
                //creo las clases que representan los registros o tablas que regresan los Sps
                foreach (CStoreProcedures sp in Sps)
                {
                    Informa("generando " + sp.Nombre);
                    Avance++;
                    sw.WriteLine("");
                    sw.WriteLine("	public partial class " + sp.Nombre + "Result");
                    sw.WriteLine("	{");
                    //declaro las variables que pertenecen a la clase
                    MotorDB.CTabla res1 = motor.DamePrimerResultadoProcedimientoAlmacenado(sp.Nombre);
                    if (res1 != null)
                    {
                        //como el likq solo utiliza la primer tabla hago lo mismo
                        foreach (MotorDB.CCampo campo in res1.Campos)
                        {
                            sw.WriteLine("		private " + motor.DameTipoDatoNet(campo.TipoDato) + " _" + campo.Nombre + ";");
                        }
                    }
                    sw.WriteLine("		public " + sp.Nombre + "Result()");
                    sw.WriteLine("		{");
                    sw.WriteLine("		}");
                    if (res1 != null)
                    {
                        foreach (MotorDB.CCampo campo in res1.Campos)
                        {
                            sw.WriteLine("		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage=\"_" + campo.Nombre + "\", DbType=\"" + DameDbType(motor, campo) + "\")]");
                            sw.WriteLine("		public " + motor.DameTipoDatoNet(campo.TipoDato) + " " + campo.Nombre + "");
                            sw.WriteLine("		{");
                            sw.WriteLine("			get");
                            sw.WriteLine("			{");
                            sw.WriteLine("				return this._" + campo.Nombre + ";");
                            sw.WriteLine("			}");
                            sw.WriteLine("			set");
                            sw.WriteLine("			{");
                            sw.WriteLine("				if ((this._" + campo.Nombre + " != value))");
                            sw.WriteLine("				{");
                            sw.WriteLine("					this._" + campo.Nombre + " = value;");
                            sw.WriteLine("				}");
                            sw.WriteLine("			}");
                            sw.WriteLine("		}");
                        }
                    }
                    sw.WriteLine("	}");

                }
                sw.WriteLine("}");
                sw.WriteLine("#pragma warning restore 1591");
                sw.Close();
            }
            catch (System.Exception ex)
            {
                if (sw != null)
                {
                    sw.Close();
                    throw ex;
                }
            }
        }


        private void CreaClase(CDataClass clase)
        {
            CreaDbml(clase);
            CreaLayout(clase);
            CreaDesigner(clase);
            CreaCS(clase);
        }
        private void ValidaInfo()
        {
            //primero creo las clases
            foreach (CDataClass clase in Clases)
            {
                ValidaClase(clase);
            }

        }
        private void CreaAppConfig()
        {
            StreamWriter sw = null;
            try
            {
                Informa("Creando app.config");
                sw = File.CreateText(Directorio + "\\app.config");
                sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                sw.WriteLine("<configuration>");
                sw.WriteLine("    <configSections>");
                sw.WriteLine("    </configSections>");
                sw.WriteLine("    <connectionStrings>");
                List<CConexion> conexiones = Modelo.DameConexiones();
                foreach (CConexion conexion in conexiones)
                {
                    MotorDB.IMotorDB motor = conexion.DameMotor();
                    sw.WriteLine("        <add name=\"Libreria.Properties.Settings." + motor.GetDataBseName() + "ConnectionString\"");
                    sw.WriteLine("            connectionString=\"" + motor.GetConecctionString().Replace("\"", "") + "\"");
                    sw.WriteLine("            providerName=\"" + motor.GetNetProvider() + "\" />");
                }
                sw.WriteLine("    </connectionStrings>");
                sw.WriteLine("</configuration>");
                sw.Close();
            }
            catch (System.Exception ex)
            {
                if (sw != null)
                    sw.Close();
                throw ex;
            }
        }
        private void CreaCS(CDataClass clase)
        {
            StreamWriter sw = null;
            try
            {
                Informa("creando " + clase.Nombre + ".cs");
                sw = File.CreateText(Directorio + "\\" + clase.Nombre + ".cs");
                sw.WriteLine("namespace " + ProjectName + "");
                sw.WriteLine("{");
                sw.WriteLine("    partial class " + clase.Nombre + "DataContext");
                sw.WriteLine("    {");
                sw.WriteLine("    }");
                sw.WriteLine("}");
                sw.Close();
            }
            catch (System.Exception ex)
            {
                if (sw != null)
                    sw.Close();
                throw ex;
            }
        }
        private void BkGenerador_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //primero hago las validaciones correspondientes
                ValidaInfo();
                //primero creamos el proyecto
                CreaProyecto();
                //primero creo las clases
                foreach (CDataClass clase in Clases)
                {
                    CreaClase(clase);
                }
                CreaAppConfig();
                CreaAsambleInfo();
            }
            catch (System.Exception ex)
            {
                Informa("Error" + ex.Message);
                return;
            }
        }
        private void Informa(string mensaje)
        {
            BkGenerador.ReportProgress(Avance, mensaje);
        }
        private void BkGenerador_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (OnProgreso != null)
            {
                OnProgreso(Maximo, e.ProgressPercentage, e.UserState.ToString());
            }
        }

        private void BkGenerador_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (OnFin != null)
            {
                OnFin(Maximo, 0, "Fin del proceso");
            }
        }
        private void CreaAsambleInfo()
        {
            StreamWriter sw = null;
            try
            {
                string company = ((AssemblyCompanyAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyCompanyAttribute), false)).Company;
                Guid gid;
                gid = Guid.NewGuid();
                Informa("creando AssemblyInfo.cs");
                if (System.IO.Directory.Exists(Directorio + "\\Properties") == false)
                {
                    System.IO.Directory.CreateDirectory(Directorio + "\\Properties");
                }
                sw = File.CreateText(Directorio + "\\Properties\\AssemblyInfo.cs");
                sw.WriteLine("using System.Reflection;");
                sw.WriteLine("using System.Runtime.CompilerServices;");
                sw.WriteLine("using System.Runtime.InteropServices;");
                sw.WriteLine("");
                sw.WriteLine("// General Information about an assembly is controlled through the following ");
                sw.WriteLine("// set of attributes. Change these attribute values to modify the information");
                sw.WriteLine("// associated with an assembly.");
                sw.WriteLine("[assembly: AssemblyTitle(\"" + ProjectName + "\")]");
                sw.WriteLine("[assembly: AssemblyDescription(\"\")]");
                sw.WriteLine("[assembly: AssemblyConfiguration(\"\")]");
                sw.WriteLine("[assembly: AssemblyCompany(\"" + company + "\")]");
                sw.WriteLine("[assembly: AssemblyProduct(\"Libreria\")]");
                sw.WriteLine("[assembly: AssemblyTrademark(\"\")]");
                sw.WriteLine("[assembly: AssemblyCulture(\"\")]");
                sw.WriteLine("");
                sw.WriteLine("// Setting ComVisible to false makes the types in this assembly not visible ");
                sw.WriteLine("// to COM components.  If you need to access a type in this assembly from ");
                sw.WriteLine("// COM, set the ComVisible attribute to true on that type.");
                sw.WriteLine("[assembly: ComVisible(false)]");
                sw.WriteLine("");
                sw.WriteLine("// The following GUID is for the ID of the typelib if this project is exposed to COM");
                sw.WriteLine("[assembly: Guid(\"" + gid + "\")]");
                sw.WriteLine("// Version information for an assembly consists of the following four values:");
                sw.WriteLine("//");
                sw.WriteLine("//      Major Version");
                sw.WriteLine("//      Minor Version ");
                sw.WriteLine("//      Build Number");
                sw.WriteLine("//      Revision");
                sw.WriteLine("//");
                sw.WriteLine("// You can specify all the values or you can default the Build and Revision Numbers ");
                sw.WriteLine("// by using the '*' as shown below:");
                sw.WriteLine("// [assembly: AssemblyVersion(\"1.0.*\")]");
                sw.WriteLine("[assembly: AssemblyVersion(\"1.0.0.0\")]");
                sw.WriteLine("[assembly: AssemblyFileVersion(\"1.0.0.0\")]");
                sw.Close();
            }
            catch (System.Exception ex)
            {
                if (sw != null)
                    sw.Close();
                throw ex;
            }
        }
    }
}
