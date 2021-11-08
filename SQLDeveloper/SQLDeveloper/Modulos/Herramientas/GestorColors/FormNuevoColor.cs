using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace SQLDeveloper.Modulos.Herramientas.GestorColors
{
    public partial class FormNuevoColor : Form
    {
        public FormNuevoColor()
        {
            InitializeComponent();
        }
        private string GeneraCodigo(string nombre)
        {
            string s = "";
            s = s + "<?xml version = \"1.0\"?> \n";
            s = s + "<SyntaxDefinition name = \""+nombre+"\" extensions = \".sql\"> \n";
            s = s + "	<Environment> \n";
            s = s + "		<Default      color=\"#FFFF00\" bgcolor=\"#000000\"/> \n";
            s = s + "		<VRuler       color = \"Blue\"/> \n";
            s = s + "		<Selection    bgcolor = \"LightBlue\"/> \n";
            s = s + "		<LineNumbers  color = \"Teal\" bgcolor = \"SystemColors.Window\"/> \n";
            s = s + "		<InvalidLines color = \"Red\"/> \n";
            s = s + "		<EOLMarkers   color = \"White\"/> \n";
            s = s + "		<SpaceMarkers color = \"#E0E0E5\"/> \n";
            s = s + "		<TabMarkers   color = \"#E0E0E5\"/> \n";
            s = s + "		<CaretMarker  color = \"Yellow\"/> \n";
            s = s + "		<FoldLine     color = \"#808080\" bgcolor=\"Black\"/> \n";
            s = s + "		<FoldMarker   color = \"#808080\" bgcolor=\"White\"/> \n";
            s = s + "	</Environment> \n";
            s = s + "	<Properties> \n";
            s = s + "		<Property name=\"LineComment\" value=\"--\"/> \n";
            s = s + "	</Properties> \n";
            s = s + "	<Digits name = \"Digits\" bold = \"true\" italic = \"false\" color=\"#C0C0C0\"/> \n";
            s = s + "	<RuleSets> \n";
            s = s + "		<RuleSet ignorecase = \"true\"> \n";
            s = s + "			<Delimiters>=!&gt;&lt;+-/*%&amp;|^~.}{,;][?:()</Delimiters> \n";
            s = s + "			<Span name =\"LineComment\" bold =\"false\" italic =\"true\" color =\"#CE0000\" stopateol =\"true\"> \n";
            s = s + "				<Begin>--</Begin> \n";
            s = s + "			</Span> \n";
            s = s + "			<Span name =\"BlockComment\" bold =\"false\" italic =\"true\" color =\"#FF0000\" stopateol =\"false\"> \n";
            s = s + "				<Begin>/*</Begin> \n";
            s = s + "				<End>*/</End> \n";
            s = s + "			</Span> \n";
            s = s + "			<Span name =\"String\" bold =\"true\" italic =\"false\" color =\"#FFFFFF\" stopateol =\"false\"> \n";
            s = s + "				<Begin>&quot;</Begin> \n";
            s = s + "				<End>&quot;</End> \n";
            s = s + "			</Span> \n";
            s = s + "			<Span name =\"Character\" bold =\"true\" italic =\"false\" color =\"#FFFFFF\" stopateol =\"true\"> \n";
            s = s + "				<Begin>&apos;</Begin> \n";
            s = s + "				<End>&apos;</End> \n";
            s = s + "			</Span> \n";
            s = s + "			<KeyWords name =\"JoinKeywords\" bold=\"true\" italic = \"false\" color=\"#8080FF\"> \n";
            s = s + "				<Key word = \"INNER\" /> \n";
            s = s + "				<Key word = \"JOIN\" /> \n";
            s = s + "				<Key word = \"LEFT\" /> \n";
            s = s + "				<Key word = \"RIGHT\" /> \n";
            s = s + "				<Key word = \"OUTER\" /> \n";
            s = s + "				<Key word = \"UNION\" /> \n";
            s = s + "				<Key word = \"ON\" /> \n";
            s = s + "				<Key word = \"NOCOUNT\" /> \n";
            s = s + "				<Key word = \"OFF\" /> \n";
            s = s + "				<Key word = \"FULL\" /> \n";
            s = s + "			</KeyWords> \n";
            s = s + "			<KeyWords name =\"AliasKeywords\" bold=\"true\" italic = \"false\" color=\"#0000FF\"> \n";
            s = s + "				<Key word = \"AS\" /> \n";
            s = s + "			</KeyWords> \n";
            s = s + "			<KeyWords name =\"ComparisonKeywords\" bold=\"true\" italic = \"false\" color=\"#008080\"> \n";
            s = s + "				<Key word = \"AND\" /> \n";
            s = s + "				<Key word = \"OR\" /> \n";
            s = s + "				<Key word = \"LIKE\" /> \n";
            s = s + "				<Key word = \"IN\" /> \n";
            s = s + "				<Key word = \"EXISTS\" /> \n";
            s = s + "			</KeyWords> \n";
            s = s + "			<KeyWords name =\"DestructiveKeywords\" bold=\"true\" italic = \"false\" color=\"Red\"> \n";
            s = s + "				<Key word = \"DROP\" /> \n";
            s = s + "				<Key word = \"DELETE\" /> \n";
            s = s + "				<Key word = \"TRUNCATE\" /> \n";
            s = s + "			</KeyWords> \n";
            s = s + "			<KeyWords name =\"SpecializedKeywords\" bold=\"true\" italic = \"false\" color=\"#08D625\"> \n";
            s = s + "				<Key word = \"TOP\" /> \n";
            s = s + "				<Key word = \"DISTINCT\" /> \n";
            s = s + "				<Key word = \"LIMIT\" /> \n";
            s = s + "				<Key word = \"OPENDATASOURCE\" /> \n";
            s = s + "				<Key word = \"GO\" /> \n";
            s = s + "				<Key word = \"USE\" /> \n";
            s = s + "			</KeyWords> \n";
            s = s + "			<KeyWords name =\"TransactionKeyWords\" bold=\"true\" italic = \"false\" color=\"#DA800A\"> \n";
            s = s + "				<Key word = \"COMMIMT\" /> \n";
            s = s + "				<Key word = \"ROLLBACK\" /> \n";
            s = s + "				<Key word = \"TRANSACTION\" /> \n";
            s = s + "			</KeyWords> \n";
            s = s + "			<KeyWords name =\"DebugKeyWords\" bold=\"true\" italic = \"false\" color=\"#FF9900\"> \n";
            s = s + "				<Key word = \"TRY\" /> \n";
            s = s + "				<Key word = \"CATCH\" /> \n";
            s = s + "				<Key word = \"RAISERROR\" /> \n";
            s = s + "			</KeyWords> \n";
            s = s + "			<KeyWords name =\"CursorKeywords\" bold=\"true\" italic = \"false\" color=\"#00869E\"> \n";
            s = s + "				<Key word = \"CURSOR\" /> \n";
            s = s + "				<Key word = \"FOR\" /> \n";
            s = s + "				<Key word = \"OPEN\" /> \n";
            s = s + "				<Key word = \"FETCH\" /> \n";
            s = s + "				<Key word = \"NEXT\" /> \n";
            s = s + "				<Key word = \"CLOSE\" /> \n";
            s = s + "				<Key word = \"DEALLOCATE\" /> \n";
            s = s + "			</KeyWords> \n";
            s = s + "			<KeyWords name =\"SqlKeywords\" bold=\"true\" italic = \"false\" color=\"#000099\"> \n";
            s = s + "				<Key word = \"NOT\" /> \n";
            s = s + "				<Key word = \"SET\" /> \n";
            s = s + "				<Key word = \"DESC\" /> \n";
            s = s + "				<Key word = \"ASC\" /> \n";
            s = s + "				<Key word = \"EXEC\" /> \n";
            s = s + "				<Key word = \"WITH\" /> \n";
            s = s + "				<Key word = \"EXECUTE\" /> \n";
            s = s + "			</KeyWords> \n";
            s = s + "			<KeyWords name =\"SqlActionWords\" bold=\"true\" italic = \"false\" color=\"#0000A0\"> \n";
            s = s + "				<Key word = \"INSERT\" /> \n";
            s = s + "				<Key word = \"SELECT\" /> \n";
            s = s + "				<Key word = \"UPDATE\" /> \n";
            s = s + "				<Key word = \"FROM\" /> \n";
            s = s + "				<Key word = \"WHERE\" /> \n";
            s = s + "				<Key word = \"HAVING\" /> \n";
            s = s + "				<Key word = \"GROUP\" /> \n";
            s = s + "				<Key word = \"BY\" /> \n";
            s = s + "				<Key word = \"ORDER\" /> \n";
            s = s + "				<Key word = \"CREATE\" /> \n";
            s = s + "				<Key word = \"ALTER\" /> \n";
            s = s + "				<Key word = \"ADD\" /> \n";
            s = s + "				<Key word = \"NULL\" /> \n";
            s = s + "				<Key word = \"INTO\" /> \n";
            s = s + "				<Key word = \"VALUES\" /> \n";
            s = s + "			</KeyWords> \n";
            s = s + "			<KeyWords name =\"SqlTypes\" bold=\"true\" italic = \"false\" color=\"#80FFFF\"> \n";
            s = s + "				<Key word = \"VARCHAR\" /> \n";
            s = s + "				<Key word = \"NVARCHAR\" /> \n";
            s = s + "				<Key word = \"CHAR\" /> \n";
            s = s + "				<Key word = \"NCHAR\" /> \n";
            s = s + "				<Key word = \"INT\" /> \n";
            s = s + "				<Key word = \"TEXT\" /> \n";
            s = s + "				<Key word = \"NTEXT\" /> \n";
            s = s + "				<Key word = \"DOUBLE\" /> \n";
            s = s + "				<Key word = \"MONEY\" /> \n";
            s = s + "				<Key word = \"BIT\" /> \n";
            s = s + "				<Key word = \"DATETIME\" /> \n";
            s = s + "				<Key word = \"DECIMAL\" /> \n";
            s = s + "				<Key word = \"FLOAT\" /> \n";
            s = s + "			</KeyWords> \n";
            s = s + "			<KeyWords name =\"SqlObjects\" bold=\"true\" italic = \"true\" color=\"#FFFF00\"> \n";
            s = s + "				<Key word = \"TABLE\" /> \n";
            s = s + "				<Key word = \"PROC\" /> \n";
            s = s + "				<Key word = \"PROCEDURE\" /> \n";
            s = s + "				<Key word = \"FUNCTION\" /> \n";
            s = s + "				<Key word = \"VIEW\" /> \n";
            s = s + "				<Key word = \"TRIGGER\" /> \n";
            s = s + "				<Key word = \"INDEX\" /> \n";
            s = s + "				<Key word = \"DATABASE\" /> \n";
            s = s + "			</KeyWords> \n";
            s = s + "			<KeyWords name =\"FlowControlKeyWords\" bold=\"true\" italic = \"true\" color=\"Indigo\"> \n";
            s = s + "				<Key word = \"IF\" /> \n";
            s = s + "				<Key word = \"ELSE\" /> \n";
            s = s + "				<Key word = \"CASE\" /> \n";
            s = s + "				<Key word = \"WHEN\" /> \n";
            s = s + "				<Key word = \"THEN\" /> \n";
            s = s + "				<Key word = \"WHILE\" /> \n";
            s = s + "				<Key word = \"WAITFOR\" /> \n";
            s = s + "				<Key word = \"DELAY\" /> \n";
            s = s + "				<Key word = \"RETURN\" /> \n";
            s = s + "				<Key word = \"SWITCH\" /> \n";
            s = s + "				<Key word = \"BREAK\" /> \n";
            s = s + "			</KeyWords> \n";
            s = s + "			<KeyWords name =\"TSql\" bold=\"true\" italic = \"false\" color=\"#339900\"> \n";
            s = s + "				<Key word = \"DECLARE\" /> \n";
            s = s + "				<Key word = \"BEGIN\" /> \n";
            s = s + "				<Key word = \"END\" /> \n";
            s = s + "			</KeyWords> \n";
            s = s + "			<KeyWords name =\"Punctuation\" bold=\"false\" italic = \"false\" color=\"DarkSlateGray\"> \n";
            s = s + "				<Key word = \"(\" /> \n";
            s = s + "				<Key word = \")\" /> \n";
            s = s + "			</KeyWords> \n";
            s = s + "			<KeyWords name =\"Operators\" bold=\"false\" italic = \"false\" color=\"DarkSlateGray\"> \n";
            s = s + "				<Key word = \"&lt;\" /> \n";
            s = s + "				<Key word = \"&gt;\" /> \n";
            s = s + "				<Key word = \"=\" /> \n";
            s = s + "			</KeyWords> \n";
            s = s + "			<KeyWords name =\"Functions\" bold=\"true\" italic = \"false\" color=\"BlueViolet\"> \n";
            s = s + "				<Key word = \"SUBSTRING\" /> \n";
            s = s + "				<Key word = \"UPPER\" /> \n";
            s = s + "				<Key word = \"LOWER\" /> \n";
            s = s + "				<Key word = \"REVERSE\" /> \n";
            s = s + "				<Key word = \"REPLACE\" /> \n";
            s = s + "				<Key word = \"LTRIM\" /> \n";
            s = s + "				<Key word = \"RTRIM\" /> \n";
            s = s + "				<Key word = \"CAST\" /> \n";
            s = s + "				<Key word = \"CONVERT\" /> \n";
            s = s + "				<Key word = \"ISNULL\" /> \n";
            s = s + "				<Key word = \"DATEDIFF\" /> \n";
            s = s + "				<Key word = \"GETDATE\" /> \n";
            s = s + "			</KeyWords> \n";
            s = s + "			<KeyWords name =\"GroupByFunctions\" bold=\"true\" italic = \"false\" color=\"#AE1737\"> \n";
            s = s + "				<Key word = \"SUM\" /> \n";
            s = s + "				<Key word = \"COUNT\" /> \n";
            s = s + "				<Key word = \"MAX\" /> \n";
            s = s + "				<Key word = \"MIN\" /> \n";
            s = s + "				<Key word = \"AVG\" /> \n";
            s = s + "			</KeyWords> \n";
            s = s + "		</RuleSet> \n";
            s = s + "	</RuleSets> \n";
            s = s + "</SyntaxDefinition> \n";
            return s;
        }
        private string Directorio
        {
            get
            {
                return Application.StartupPath + "\\Colores";
            }
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            if(TNombre.Text.Trim()=="")
            {
                MessageBox.Show("Falta el nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string nombre = TNombre.Text;
//            string archivo = Directorio + "\\" + nombre + ".xshd";
            if (File.Exists(Archivo))
            {
                MessageBox.Show("El archivo ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                StreamWriter sw = File.CreateText(Archivo);
                sw.Write(GeneraCodigo(nombre));
                sw.Close();
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
        public string Archivo
        {
            get
            {
                string nombre = TNombre.Text;
                string archivo = Directorio + "\\" + nombre + ".xshd";
                return archivo;
            }
        }
    }
}
