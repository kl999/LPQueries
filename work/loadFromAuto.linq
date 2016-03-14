<Query Kind="Statements" />

FileStream file = File.Open
	(@"D:\Документы\Car_Count_1\Car_Count_1\bin\Debug\autoLog.txt", FileMode.Open);


byte[] buf = new byte[file.Length];

file.Read(buf, 0, buf.Length);

string rez = Encoding.UTF8.GetString(buf, 0, buf.Length);

int len = rez.Length;

rez.Trim();

if(rez[len - 1] == '|')
{
	rez = rez.Remove(len - 1);
}

file.Close();
											
List<Tuple<int, int>> log = new List<Tuple<int, int>>();

{
string[] tmp = rez.Split('|');

foreach(string tstr in tmp)
{
	string[] t2 = tstr.Split(',');
	log.Add(Tuple.Create(Int32.Parse(t2[0]), Int32.Parse(t2[1])));
}
}

log.Dump();

//Log time

int rowCount = 325;

string[] rez2 = new string[rowCount];

for(int i = 0; i < rowCount; i++)
{
	decimal percent = (decimal)(i + 0) / rowCount;
	
	decimal wholeHours = (decimal)16 * percent;
	
	int hours = (int)wholeHours;
	
	decimal minPercent = wholeHours - hours;
	
	int minutes = (int)((decimal)60 * minPercent);
	
	if(hours <= 7)
	{
		hours += 17;
	}
	else
	{
		hours -= 7;
	}
	if(hours == 24)
		hours = 0;
	
	rez2[i] = string.Format("{0} ч. {1} мин.", hours, minutes);
}

rez2.Dump();