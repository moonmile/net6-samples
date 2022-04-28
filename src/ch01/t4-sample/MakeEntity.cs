using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = ClosedXML.Excel;

namespace t4_sample
{
    public class MakeEntity
    {
        public static List<EntityItem>  LoadEntity( string excelpath, string tablename )
        {
            var items = new List<EntityItem>();
            using ( var wb = new Excel.XLWorkbook(excelpath))
            {
                var sheet = wb.Worksheets.FirstOrDefault( t => t.Name == tablename );
                if ( sheet != null )
                {
                    int r = 2;
                    while (sheet.Cell(r, 1).GetString() != "")
                    {
                        string propname = sheet.Cell(r, 1).GetString();
                        string typename = sheet.Cell(r, 2).GetString();
                        Type type = typeof(string);
                        if (typename.StartsWith("int")) type = typeof(int);
                        if (typename.StartsWith("varchar")) type = typeof(string);
                        if (typename.StartsWith("timestamp")) type = typeof(DateTime);
                        if (typename.StartsWith("tinyint")) type = typeof(bool);

                        bool nullable = false;
                        if (sheet.Cell(r,3).GetString() == "YES")
                        {
                            nullable = true;
                        }
                        items.Add( new EntityItem() { PropName = propname, Type = type, Nullable = nullable });
                        r++;
                    }
                }
            }
            return items;

        }

        public class EntityItem
        {
            public string PropName { get; set; } = "";  // プロパティ名
            public Type Type { get; set; } = typeof(string);  // 型名
            public bool Nullable { get; set; } = false; // NULL許容型
            public string ToProperty()
            {
                if ( this.Nullable  == false)
                {
                    return $"public ${this.Type.Name} {{ get; set; }}";
                } 
                else
                {
                    return $"public ${this.Type.Name}? {{ get; set; }}";
                }
            } 

        }
    }
}
