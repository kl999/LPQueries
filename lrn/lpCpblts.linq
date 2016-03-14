<Query Kind="Program">
  <Namespace>System.Data.Linq.SqlClient</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
    Util.HorizontalRun(
        true,
        new object[]
        {
            new Hyperlinq(new Action(() => 4.Dump()), "click"),
            " ",
            new Hyperlinq(new Action(() => 5.Dump()), "me")
        }
    ).Dump();
    
    "\nWorld.".Dump();
    Util.RawHtml("<H1>Hello!</H1>").Dump();
    
    new Hyperlinq(clrScr, "clrScr").Dump();
    
    Util.HorizontalRun(false, 78953, Util.Highlight(59875), Util.Metatext("95348")).Dump();
    
    new Hyperlinq(() => Util.ReadLine("prompt", "-", new[]{ "asd", "zxc", "qwe" }), "Suggest").Dump();
    
    Util.WithStyle(new object[]{ 9, "asdQWE", 3, 6 },
    @"font-size: 300%;
    font-family: ""Comic Sans MS"", ""Comic Sans"", cursive;
    color: #FF0000;
    background-color: green;").Dump();
    
    Util.DisplayWebPage("https://www.google.kz/?gfe_rd=cr&ei=zvCEVrq_F8u9wAO3tJHwAQ");
}

void clrScr()
{
    Util.ClearResults();
    
    Util.HorizontalRun(
        true,
        new object[]
        {
            new Hyperlinq(new Action(() => 4.Dump()), "click"),
            " ",
            new Hyperlinq(new Action(() => 5.Dump()), "me")
        }
    ).Dump();
    
    new Hyperlinq(clrScr, nameof(clrScr)).Dump();
}