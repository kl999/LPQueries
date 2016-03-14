<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var str = @"NzUwMjExNDk5MDg4Ojo2MjAzOjo2MjAzMDAwMDAwMDA6OtCd0KMg0L/QviDQodCw0YDRi9Cw0YDQutC40L3RgdC60L7QvNGDINGA0LDQudC+0L3Rgzo60JrQvtC80LjRgtC10YIg0JrQsNC30L3QsNGH0LXQudGB0YLQstCwINCc0KQg0KDQmjo6MjA0MTA2Ojo5OTM6OtCo0YLRgNCw0YTRiyAg0LfQsCAg0L3QsNGA0YPRiNC10L3QuNC1INC30LDQutC+0L3QvtC00LDRgtC10LvRjNGB0YLQstCwINCg0LXRgdC/0YPQsdC70LjQutC4INCa0LDQt9Cw0YXRgdGC0LDQvSDQvtGCINGE0LjQt9C40YfQtdGB0LrQuNGFINC70LjRhi3Qs9GA0LDQttC00LDQvTo6NDg1NDo6ezAyN0RCNTc5LTZGNjUtNEQ0Mi04ODM5LTk5NTU0MjUzRUY5Rn06OjExMzUwNjo6Wjo6MTo60KDQntCi0JAg0J7QkdCU0J8g0KPQlNCfINCU0JLQlCDQky7QkNCh0KLQkNCd0JA6OkhFVDo60KjQotCg0JDQpCDQn9CeINCf0KDQntCi0J7QmtCe0JvQozo6MTkuMDkuMjAxMg==";
	
	var rez = Base64Decode(str).Dump("Rez");
	
	Base64Encode("Hello! how u managed to understand such a complex cipher?").Dump();
}

public static string Base64Encode(string plainText)
{
	var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
	return System.Convert.ToBase64String(plainTextBytes);
}

public static string Base64Decode(string base64EncodedData)
{
	var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
	return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
}