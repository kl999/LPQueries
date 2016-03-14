<Query Kind="Program">
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
	var lst = new List<Node>();
	
	lst.Add(new Node("1st"));
	
	lst.Add(new Node("2nd"));
	
	lst[0].addCon(lst[1]);
	
	lst.Add(new Node("3rd"));
	
	lst[1].addCon(lst[2]);
	
	lst.Dump();
}

class Node
{
	public string name = "NoName";
	
	public Int64 pos = -1;
	
	public List<Node> cons = new List<Node>();
	
	public Node(string _name)
	{
		name = _name;
	}
	
	public void addCon(Node scnd)
	{
		oneWayCon(scnd);
		scnd.oneWayCon(this);
	}
	
	public void oneWayCon(Node scnd)
	{
		cons.Add(scnd);
	}
}