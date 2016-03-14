<Query Kind="Statements">
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft Visual Studio 11.0\Visual Studio Tools for Office\PIA\Office14\Microsoft.Office.Interop.Excel.dll</Reference>
  <Namespace>ex = Microsoft.Office.Interop.Excel</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

//Start a new workbook in Excel.
ex.Application exApp = new ex.Application();
ex.Workbooks exBooks = (ex.Workbooks)exApp.Workbooks;

ex.Workbook exBook = exBooks.Add(
    //Environment.CurrentDirectory + "\\temp.xlsx"
    @"c:\sp\ex1_.xlsx"
    ) as ex.Workbook;
    
ex.Worksheet exWSh = exBook.ActiveSheet as ex.Worksheet;

//Print head
exWSh.PageSetup.CenterHeader = "This is Excel page";

for (int i = 1; i <= 300; i++)
{
    exWSh.Cells[i, 1] = DateTime.Now.AddHours(-i);
    exWSh.Cells[i, 2] = "asd";
    exWSh.Cells[i, 3] = i;
}

exApp.Visible = true;