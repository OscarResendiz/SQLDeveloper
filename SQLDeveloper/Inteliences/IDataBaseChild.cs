using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.TextEditor.Gui.CompletionWindow;
using ICSharpCode.TextEditor;

namespace Inteliences
{
    public enum FilteringTypeValues { Tables, Views, Sps, Code, Fields, Variables, Snippets, Childs, All };
    public enum DataType
    {
        DataBase,
        Table,
        View,
        StoredProcedure,
        Variable,
        Snippet,
        Field,
        KeyField,
        ForeignKeyField
    } ;

    public interface IDataBaseChild
    {
        int DBId { get; }
        string Name { get; }
        DataType Kind { get; }
        string Script { get; }
        //List<IDataBaseChild> Childs { get; }
        //   IDataBase Parent { get; }
        bool ChildWithName(string ChildName, bool NameStartWith);

        bool LlavePrimaria { get; set; }
        string Tipo { get; set; }
        int Precision { get; set; }
        bool Nullable { get; set; }
        bool Calculado { get; set; }
        bool LlaveForanea { get; set; }
        string Default { get; set; }
        int ReferenceID { get; set; }
        string ReferenceTable { get; set; }
        string ReferenceField { get; set; }
        bool IsIdentity { get; set; }
        string IdentityScript { get; set; }
        int Seed { get; set; }
        int Increment { get; set; }
    }
}
