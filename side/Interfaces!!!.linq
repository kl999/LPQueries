<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
  List<dirInt> dlst = new List<dirInt>();

  dlst.Add(new dirCl<aCl>("a"));

  dlst.Add(new dirCl<bCl>("b"));

  aInt a = null;
  foreach (dirInt obj in dlst)
  {
      a = obj.New("a");

      if (a != null)
      {
          break;
      }
  }

  if (a == null)
      Console.WriteLine("Error!");

  a.act(a, new bCl());

  Console.WriteLine(a.GetType());

  Console.WriteLine();
  Console.WriteLine();

  a = null;
  foreach (dirInt obj in dlst)
  {
      a = obj.New("b");

      if (a != null)
      {
          break;
      }
  }

  if (a == null)
      Console.WriteLine("Error!");

  a.act(a, new aCl());

  Console.WriteLine(a.GetType());

  Console.WriteLine();
  Console.WriteLine();
  Console.WriteLine();
  Console.WriteLine();

  List<aInt> iList = new List<aInt>();

  iList.Add(getCl("a", dlst));
  iList.Add(getCl("b", dlst));

  foreach (aInt i in iList)
  {
      i.act();
	  i.GetType().Dump();
  }
}

//add-----------------------------------------------------------------------------------

static aInt getCl(string name, List<dirInt> dlst)
{
  aInt a = null;
  foreach (dirInt obj in dlst)
  {
      a = obj.New(name);

      if (a != null)
      {
          break;
      }
  }
  return a;
}
        
    

interface dirInt
{
   aInt New(string name);
}

interface aInt
{
   string name { get; }

   void act(aInt a, aInt b);

   void act();
}

class dirCl<T> : dirInt where T : aInt, new()
{
   public string name;

   public dirCl(string name)
   {
       this.name = name;
   }

   public aInt New(string name)
   {
       if (name == this.name)
           return new T();

       return null;
   }
}

class aCl : aInt
{
   public string me { get { return "Me A. "; } }

   public string name { get { return "A"; } }

   int a = 10;

   public aCl()
   {

   }

   public void act(aInt a, aInt smth)
   {
       Console.WriteLine(((aCl)a).me + "A is good! Not some \"" + smth.name + "\" " + smth.GetType().Name);
   }

   public void act()
   {
       Console.WriteLine("Hello from A code is " + a);
   }
}

class bCl : aInt
{
   public string me { get { return "No. Me B! "; } }

   public string name { get { return "B"; } }

   string a = "Unknown";

   public bCl()
   {

   }

   public void act(aInt b, aInt smth)
   {
       Console.WriteLine(((bCl)b).me + "B is best!!! Not some \"" + smth.name + "\" " + smth.GetType().Name);
   }

   public void act()
   {
       Console.WriteLine("Hello from B code is " + a);
   }
}