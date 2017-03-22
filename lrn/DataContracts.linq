<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Namespace>System.Runtime.Serialization</Namespace>
</Query>

void Main()
{
	var ex1 = new ExDC()
  {
      //a = 5,
  };

  MemoryStream s = new MemoryStream();

  //Serialize the Record object to a memory stream using DataContractSerializer.  
  DataContractSerializer serializer = new DataContractSerializer(typeof(ExDC));
  serializer.WriteObject(s, ex1);

  s.Flush();
  s.Seek(0, SeekOrigin.Begin);

  var sr = new StreamReader(s);
  
  var str = sr.ReadToEnd();

  Console.WriteLine("|" + str + "|");
  
  s.Seek(0, SeekOrigin.Begin);
  
  serializer.ReadObject(s).Dump();
}

[DataContract(Namespace="myNs")]
class ExDC
{
	[DataMember]
	public int a = 3;
}