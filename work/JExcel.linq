<Query Kind="Statements">
  <Reference>C:\ImExSVN\Lib\CSharpJExcel.dll</Reference>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>xlns = CSharpJExcel.Jxl</Namespace>
</Query>

var fullpath = @"C:\Users\samartsev\Desktop\abonents.xls";

var ws = new xlns.WorkbookSettings();
ws.setEncoding(Encoding.GetEncoding(1251).HeaderName);

xlns.Workbook book = xlns.Workbook.getWorkbook(new FileInfo(fullpath), ws);

var sheet = book.getSheet(0);

List<List<object>> rez = new List<List<object>>();

int rowct = sheet.getRows();
for (int i = 0; i < rowct; i++)
{
	var cells = sheet.getRow(i);
    
    var tmp = new List<object>();
    
    foreach(var cell in cells)
	    tmp.Add(cell.getContents());
    
    rez.Add(tmp);
}

book.close();

rez
.GroupBy(i => i.Count > 1 ? i[0].ToString() : "")
.OrderByDescending(i => i.Count())
.OnDemand("Дубли").Dump();

rez.Dump();