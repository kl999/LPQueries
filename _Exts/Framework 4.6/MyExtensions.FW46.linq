<Query Kind="Program">
  <Namespace>System.Data.OleDb</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.IO.MemoryMappedFiles</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

CrossProcCom cpc = new CrossProcCom("testFile");

void Main()
{
	// Write code to test your extensions here. Press F5 to compile and run.
	my.test();
	my.clean();
	
	string str = "asd qaz wsx axw esc abm bnm";
	
	my.forx2(
		0, 0, 10, 17
		,(i, j) =>
		{
			String.Format("{0} + {1} = {2}", i, j, (i + j)).Dump();
			
			if(str[i+j]=='a') {
			List<char> asd = str.ToList();
			asd[i+j+1]='|';
			str = String.Join("",asd);
			}
		}
		, (i)=>{i++; return i;}, (j)=>{j++; return j;}
		,() => 
		{
			"b----------".Dump();
		}
		,() =>
		{
			"a----------".Dump();
			"".Dump();
		}
		
	);
	
	str.Dump();
	
	//my.google("hi");
	
	imTst();
    
    my.fromBase64(my.toBase64("Hello world of pseudo criptography!").Dump("toBase64")).Dump("fromBase64");
    
    cpc.write("CroosProcess!");
    
    new[]{cpc}.OnDemand().Dump();
    
    cpc.read().Dump();
}

public void imTst()
{
	int h = 20,
		w = 20;
	
	Bitmap bmp = new Bitmap(h, w);
	
	int bLen = h * w * 4,
		len = h * w;
	
	byte[] buf = new byte[bLen];
	
	for(int i = 0; i < len; i++)
	{
		int tInd = i * 4,
			x = i % w,
			y = i / w;
		
		byte cl = 255;
		if(y % 2 == 0)
		{
			cl = 0;
		}
		buf[tInd + 2] = 0;
		buf[tInd + 1] = cl;
		buf[tInd] = 0;
		buf[tInd + 3] = 255;
	}
	
	bmp.fromBytes(buf);
	
	bmp.Dump("rez");
}

public static class MyExtensions
{
	
}

public class my
{
    public static System.Globalization.CultureInfo invC = System.Globalization.CultureInfo.InvariantCulture;
    public static Encoding enc1251 = Encoding.GetEncoding(1251);
    public static System.Globalization.CultureInfo en = new System.Globalization.CultureInfo("en-US");
    public static System.Globalization.CultureInfo ru = new System.Globalization.CultureInfo("ru-RU");
    
	public static void test()
	{
		"Dis iz da Tezt!!!".Dump();
	}
	
	public static void clean()
	{
		"".Dump();
		"".Dump();
		"".Dump();
		"--------------------------------------------".Dump();
		"".Dump();
		"".Dump();
		"".Dump();
	}
	
	public delegate int inc(int a);
	
	public int icnM(int i)
	{
		return ++i;
	}
	
	public static void forx2(int start1, int start2, int stop1, int stop2
				, Action<int, int> iter
				, inc iInc , inc jInc
				, Action befIter, Action afItre)
	{
		for(int i = start1; i < stop1; i = iInc(i))
		{
			befIter.Invoke();
			
			for(int j = start2; j < stop2; j = jInc(j))
			{
				iter.Invoke(i, j);
			}
			
			afItre.Invoke();
		}
	}
	
	public static void google(string searchQuery) 
	{
		string fixedSearchQuery = null;
	
		foreach (char character in searchQuery) 
		{
			if (Char.IsLetterOrDigit(character)) 
			{
				fixedSearchQuery += character;
			}
			else if (character == Char.Parse(" ")) 
			{
				fixedSearchQuery += "+";
			}
			else
			{
				fixedSearchQuery += Uri.HexEscape(character);
			}
		}
	
		string url = @"http://www.google.com/search?hl=en&q=" + fixedSearchQuery;
	
		try 
		{
			Process.Start(url);
		}
		catch(Exception ex) 
		{
			ex.Message.Dump();
		}
	}
	
	public static DataTable getDbf(string dir, string tabName)
	{
		string constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" + dir
			+ "\";Extended Properties=dBASE IV;User ID=Admin;Password=;";
		
		DataTable dt = null;
		
		using(OleDbConnection con = new OleDbConnection(constr))
		{
			con.Open();
			
			var sql = "select * from " + tabName;
			OleDbCommand cmd = new OleDbCommand(sql, con);
			
			DataSet ds = new DataSet(); ;
			OleDbDataAdapter da = new OleDbDataAdapter(cmd);
			da.Fill(ds);
			
			dt = ds.Tables[0];
			
			return dt;
		}
	}
    
    public static string toBase64(string plainText)
    {
      var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
      return System.Convert.ToBase64String(plainTextBytes);
    }
    
    public static string fromBase64(string base64EncodedData)
    {
      var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
      return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }
}

public static class supImg
{
	public static byte[] getBytes(this Bitmap bmp)
	{
		Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
		System.Drawing.Imaging.BitmapData bmpData =
		bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
		PixelFormat.Format32bppArgb);
		
		IntPtr ptr = bmpData.Scan0;
		
		int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
		byte[] rgbValues = new byte[bytes];
		
		System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
		
		bmp.UnlockBits(bmpData);
		
		return rgbValues;
	}
	
	public static void fromBytes(this Bitmap bmp, byte[] buf)
	{
		Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
		
		System.Drawing.Imaging.BitmapData bmpData =
		bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
		PixelFormat.Format32bppArgb);
		
		IntPtr ptr = bmpData.Scan0;
		
		int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
		
		System.Runtime.InteropServices.Marshal.Copy(buf, 0, ptr, bytes);
		
		bmp.UnlockBits(bmpData);
	}
	
	public static byte[] getGrayBytes(this Bitmap bmp)
	{
		//r 0.2 g 0.7 b 0.1
	
		byte[] rgbValues = bmp.getBytes();
		
		int len = rgbValues.Length / 4,
			origLen = rgbValues.Length;
		
		byte[] grayValues = new byte[len];
		
		for(int i = 0, i2 = 0; i < origLen; i += 4, i2++)
		{
			grayValues[i2] = (byte)(
				(rgbValues[i] / 10)
				+ (rgbValues[i + 1] * 7 / 10)
				+ (rgbValues[i + 2] * 2 / 10));
		}
		
		return grayValues;
	}
	
	public static void fromGrayBytes(this Bitmap bmp, byte[] buf)
	{
		int gLen = buf.Length,
			rgbLen = gLen * 4;
		
		byte[] rgbBuf = new byte[rgbLen];
		
		for(int g = 0, rgb = 0; g < gLen; g++, rgb += 4)
		{
			rgbBuf[rgb] = rgbBuf[rgb + 1] = rgbBuf[rgb + 2] = buf[g];
		
			rgbBuf[rgb + 3] = 255;
		}
		
		bmp.fromBytes(rgbBuf);
	}
    
    public static void fromGrayBytes(this Bitmap bmp, IEnumerable<byte> buf)
	{
		var rgbBuf = new List<byte>();
		
		foreach(var bt in buf)
		{
            rgbBuf.Add(bt);
            rgbBuf.Add(bt);
            rgbBuf.Add(bt);
            rgbBuf.Add(255);
		}
		
		bmp.fromBytes(rgbBuf.ToArray());
	}
	
	public static imgRgbaCl getRgba(byte[] buf, int height, int width)
	{
		return new imgRgbaCl(buf, height, width);
	}
	
	public class imgRgbaCl
	{
		pixel[,] pixels;
		
		public imgRgbaCl(byte[] buf, int height, int width)
		{
			if (buf.Length != (height * width * 4))
			throw new Exception("Buffer not for that picture?");
			
			pixels = new pixel[width, height];
			int x = 0, y = 0;
			
			for (int i = 0; i < buf.Length; i += 4)
			{
				pixels[x, y].b = buf[i + 0];
				pixels[x, y].g = buf[i + 1];
				pixels[x, y].r = buf[i + 2];
				pixels[x, y].a = buf[i + 3];
			}
			
			x++;
			
			if (x == width)
			{
				y++;
				x = 0;
			}
		}
		
		public byte[] getBytes()
		{
			List<byte> rez = new List<byte>();
			
			for (int i = 0; i < pixels.GetLength(0); i++)
			{
			for (int j = 0; j < pixels.GetLength(1); j++)
			{
			rez.Add((byte)pixels[i, j].b);
			rez.Add((byte)pixels[i, j].g);
			rez.Add((byte)pixels[i, j].r);
			rez.Add((byte)pixels[i, j].a);
			}
			}
			
			return rez.ToArray();
		}
		
		public pixel this[int x, int y]
		{
			get
			{
				return pixels[x, y];
			}
			
			set
			{
				pixels[x, y] = value;
			}
		}
	}
	
	public struct pixel
	{
		public int r
		{
			get 
			{
				return _r;
			}
			
			set
			{
				if (value < 0)
					_r = 0;
				else if (value > 255)
					_r = 255;
				else
					_r = value;
			}
		}
		private int _r;
		
		public int g
		{
			get
			{
				return _g;
			}
			
			set
			{
				if (value < 0)
					_g = 0;
				else if (value > 255)
					_g = 255;
				else
					_g = value;
			}
		}
		private int _g;
		
		public int b
		{
			get
			{
				return _b;
			}
			
			set
			{
				if (value < 0)
				_b = 0;
				else if (value > 255)
				_b = 255;
				else
				_b = value;
			}
		}
		private int _b;
		
		public int a
		{
			get
			{
				return _a;
			}
			
			set
			{
				if (value < 0)
					_a = 0;
				else if (value > 255)
					_a = 255;
				else
					_a = value;
			}
		}
		private int _a;
	}
}

/// <summary>
/// Cross Process Comunication
/// </summary>
public class CrossProcCom //Non the less
{
    public string fileName;

    MemoryMappedFile mmfile = null;

    MemoryMappedViewStream strm = null;
    
    Mutex mtx = null;
    
    public CrossProcCom(string fileName)
    {
        this.fileName = fileName;
        
        if(!Regex.IsMatch(fileName, @"^\w{1,200}$")) throw new Exception("fileName must be 1 to 100 letters. One word!");
        
        mmfile = MemoryMappedFile.CreateOrOpen(fileName, 1024L * 1024L * 100L, MemoryMappedFileAccess.ReadWrite, MemoryMappedFileOptions.None, System.IO.HandleInheritability.None);

        strm = mmfile.CreateViewStream(0, 1024L * 1024L * 100L, MemoryMappedFileAccess.ReadWrite);
        
        mtx = new Mutex(false, fileName + "Mutex");
    }
    
    public void write(string str)
    {
        var buf = new byte[1024L * 1024L * 100L];
        
        var t = Encoding.UTF8.GetBytes(str);
        t.CopyTo(buf, 0);
        
        mtx.WaitOne();
        
        strm.Write(buf, 0, buf.Length);
        
        mtx.ReleaseMutex();
    }
    
    public string read()
    {
        var buf = new byte[1024L * 1024L * 100L];
    
        mtx.WaitOne();
        
        strm.Read(buf, 0, buf.Length);
        
        mtx.ReleaseMutex();
        
        return Encoding.UTF8.GetString(buf.Where(i => i != 0).ToArray());
    }
}

public static class SimpleLoad
{
public static List<Obj> getObjects(string loaded, bool getFields = true)
{
string[] lines = loaded.Split('\n');

return getObjects(lines, getFields);
}

public static List<Obj> getObjects(string[] lines, bool getFields = true)
{
List<Obj> rez = new List<Obj>();

for (int i = 0; i < lines.Length; i++)
{
string tstr = lines[i].Trim();

Match m = Regex.Match(tstr, @"(?<=^\[).+(?=\]$)");

if (m.Success)
{
i = linesInObj(lines, m.Value, i, getFields, rez);
}
}

return rez;
}

static int linesInObj(string[] lines, string name, int i, bool getFields, List<Obj> rez)
{
List<Obj> objs = new List<Obj>();

Obj ldtObj = new Obj(name);

i++;

List<string> objLines = new List<string>();

for (; ; i++)
{
if (i >= lines.Length)
throw new Exception("Bad file");

string tstr2 = lines[i].Trim();

if (Regex.IsMatch(tstr2, @"(?<=^\[/)" + ldtObj.name + @"(?=\]$)"))
{
break;
}

Match m = Regex.Match(tstr2, @"(?<=^\[).+(?=\]$)");

if (m.Success)
{
i = linesInObj(lines, m.Value, i, getFields, objs);
}
else
objLines.Add(tstr2);
}

ldtObj.objs = objs.ToArray();

ldtObj.lines = objLines.ToArray();

if (getFields)
ldtObj.breakToFields();

rez.Add(ldtObj);

return i;
}

public static string objsToText(IEnumerable<Obj> objs)
{
string rez = "";

foreach (var o in objs)
{
rez += objToText(o);
}

rez = rez.Remove(rez.Length - 2, 2);

return rez;
}

private static string objToText(Obj o)
{
string rez = "";

rez += "[" + o.name + "]\n\n";

foreach (var f in o.fields)
{
rez += f.name;

if (f.value != null)
rez += " " + f.value;

rez += "\n";
}

if (o.objs != null && o.objs.Length > 0)
{
rez += "\n";

string tmp = "";

foreach (var o2 in o.objs)
{
tmp += objToText(o2);
}

tmp = tmp.Remove(tmp.Length - 2, 2);

tmp = "\t" + tmp.Replace("\n", "\n\t");

rez += tmp;

rez = rez.Remove(rez.Length - 1, 1);
}

rez += "\n[/" + o.name + "]\n\n\n";

return rez;
}

public class Obj
{
public string name;

public string[] lines;

public Field[] fields;

public Obj[] objs;

public Obj(string _name, string[] _lines = null)
{
name = _name;

lines = _lines;

objs = null;
}

public int breakToFields()
{
List<Field> tlist = new List<Field>();

foreach (string tstr in lines)
{
Match m;

m = Regex.Match(tstr, @"^\w+$");

if (m.Success)
{
tlist.Add(new Field(m.Value, null));
}

m = Regex.Match(tstr, @"^\w+(?=\s)");

if (m.Success)
{
tlist.Add(new Field(m.Value, Regex.Match(tstr, @"(?<=^\w+\s).*").Value));
}
}

fields = tlist.ToArray();

return tlist.Count;
}
}

public class Field
{
public string name;

public string value;

public Field(string _name, string _value)
{
name = _name;
value = _value;
}
}
}