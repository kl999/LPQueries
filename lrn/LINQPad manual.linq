<Query Kind="FSharpExpression">
  <Connection>
    <ID>b35e2479-3b0e-4dd6-bd5f-36670a7fe583</ID>
    <Driver Assembly="IQDriver" PublicKeyToken="5b59726538a49684">IQDriver.IQDriver</Driver>
    <Provider>Devart.Data.MySql</Provider>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAXpJ+KyRD6U+pcsygin2BCgAAAAACAAAAAAADZgAAwAAAABAAAACREX2+tLaFEppNNnO8ecpBAAAAAASAAACgAAAAEAAAAEHgtGt1TILs2eYyk9+Zx8M4AAAAOqFxxJYGkshKtROr2d/Y/tfVotVIlTygb+UiTZygbipu7XPLEyz9SQC6vx1ofCb+iSPzikzntkoUAAAAvSeOWuPI5AjsddgD8SRI31SXGAY=</CustomCxString>
    <Server>192.168.0.13</Server>
    <Database>avideo</Database>
    <UserName>video</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAXpJ+KyRD6U+pcsygin2BCgAAAAACAAAAAAADZgAAwAAAABAAAAAxoqwgcoRFGaWg4mq52TjmAAAAAASAAACgAAAAEAAAAOehqnKZvhaeJJ6wpD6EWU8IAAAAMI20flaJLuQUAAAAILu84iqrc3EC74EN3i8gqU8k2LI=</Password>
    <DisplayName>aVideo</DisplayName>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DriverData>
      <StripUnderscores>false</StripUnderscores>
      <QuietenAllCaps>false</QuietenAllCaps>
    </DriverData>
  </Connection>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

//---------------------------------------------------------------------------//
 // from http://stackoverflow.com/questions/3555317/linqpad-extension-methods //
//---------------------------------------------------------------------------//





LINQPad defines two extension methods (in LINQPad.Extensions), namely Dump() and Disassemble(). Dump() writes to the output window using LINQPad's output formatter and is overloaded
to let you specify a heading:

typeof (int).Assembly.Dump ();
typeof (int).Assembly.Dump ("mscorlib");
You can also specify a maximum recursion depth to override the default of 5 levels:

typeof (int).Assembly.Dump (1);              // Dump just one level deep
typeof (int).Assembly.Dump (7);              // Dump 7 levels deep
typeof (int).Assembly.Dump ("mscorlib", 7);  // Dump 7 levels deep with heading
Disassemble() disassembles any method to IL, returning the output in a string:

typeof (Uri).GetMethod ("GetHashCode").Disassemble().Dump();
In addition to those two extension methods, there are some useful static methods in LINQPad.Util. These are documented in autocompletion, and include:

Cmd - executes a shell command or external program
CreateXhtmlWriter - creates a text writer that uses LINQPad's Dump() formatter
SqlOutputWriter - returns the text writer that writes to the SQL output window
GetMyQueries, GetSamples - returns a collection of objects representing your saved queries / samples (for an example, execute a search using Edit | Search All)
Highlight - wraps an object so that it will highlight in yellow when Dumped
HorizontalRun - lets you Dump a series of objects on the same line
LINQPad also provides the HyperLinq class. This has two purposes: the first is to display ordinary hyperlinks:

new Hyperlinq ("www.linqpad.net").Dump();
new Hyperlinq ("www.linqpad.net", "Web site").Dump();
new Hyperlinq ("mailto:user@domain.com", "Email").Dump();
You can combine this with Util.HorizontalRun:

Util.HorizontalRun (true,
  "Check out",
   new Hyperlinq ("http://stackoverflow.com", "this site"),
  "for answers to programming questions.").Dump();
Result:

Check out this site for answers to programming questions.

The second purpose of HyperLinq is to dynamically build queries:

// Dynamically build simple expression:
new Hyperlinq (QueryLanguage.Expression, "123 * 234").Dump();

// Dynamically build query:
new Hyperlinq (QueryLanguage.Expression, @"from c in Customers
where c.Name.Length > 3
select c.Name", "Click to run!").Dump();
You can also write your own extension methods in LINQPad. Go to 'My Queries' and click the query called 'My Extensions'. Any types/methods that define here are accessible to all queries:

void Main()
{
  "hello".Pascal().Dump();  
}

public static class MyExtensions
{
  public static string Pascal (this string s)
  {
    return char.ToLower (s[0]) + s.Substring(1);
  }
}
In 4.46(.02) new classes and methods have been introduced:

DumpContainer (class)
OnDemand (extension method)
Util.ProgressBar (class)
Additionally, the Hyperlinq class now supports an Action delegate that will be called when you click the link, allowing you to react to it in code and not just link to external webpages.

DumpContainer is a class that adds a block into the output window that can have its contents replaced.

NOTE! Remember to .Dump() the DumpContainer itself in the appropriate spot.

To use:

var dc = new DumpContainer();
dc.Content = "Test";
// further down in the code
dc.Content = "Another test";
OnDemand is an extension method that will not output the contents of its parameter to the output window, but instead add a clickable link, that when clicked will replace the link with
the .Dump()ed contents of the parameter. This is great for sometimes-needed data structures that is costly or takes up a lot of space.

NOTE! Remember to .Dump() the results of calling OnDemand in the appropriate spot.

To use it:

Customers.OnDemand("Customers").Dump(); // description is optional
Util.ProgressBar is a class that can show a graphical progressbar inside the output window, that can be changed as the code moves on.

NOTE! Remember to .Dump() the Util.ProgressBar object in the appropriate spot.

To use it:

var pb = new Util.ProgressBar("Analyzing data");
for (int index = 0; index <= 100; index++)
{
    pb.Percent = index;
    Thread.Sleep(100);
}

To start vs debugger add:
Debugger.Launch()