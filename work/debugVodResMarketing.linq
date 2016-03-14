<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Data</Namespace>
  <Namespace>System.Data.OleDb</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var fnarr = new[]
		{
			@"C:\Users\samartsev\Desktop\connectors\ТОО Водные Ресурсы - Маркетинг\WRM.DBF",
		}.ToList();
	
	TransformDataBeforeImport(fnarr);
	
	File.ReadAllLines(fnarr.First(), Encoding.GetEncoding(1251))
	.Select(i => i.Split(';'))
	.GroupBy(i => i[0])
	.OrderByDescending(i => i.Count())
	.Dump();
}

public void TransformDataBeforeImport(List<string> sourceFiles)
{
  //Создаем новый файл CSV
  string commonPath = Path.GetDirectoryName(sourceFiles[0]);
  string singleFile = Path.Combine(commonPath, "sfile" + DateTime.Now.ToString("yyMMddHHmmss")) + ".csv";
  TextWriter writer = new StreamWriter(singleFile, false, Encoding.GetEncoding(1251));

  string fullpath = sourceFiles[0];
  string fileName = Path.GetFileNameWithoutExtension(fullpath);

  string constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" + commonPath
      + "\";Extended Properties=dBASE IV;User ID=Admin;Password=;";

  DataTable dt = null;

  using (OleDbConnection con = new OleDbConnection(constr))
  {
      var sql = "select * from " + fileName;
      OleDbCommand cmd = new OleDbCommand(sql, con);
      con.Open();
      DataSet ds = new DataSet(); ;
      OleDbDataAdapter da = new OleDbDataAdapter(cmd);
      da.Fill(ds);

      dt = ds.Tables[0];
  }

  foreach (var orow in dt.Rows)
  {
      var row = (DataRow)orow;

      string acc = ((double)row["COUNT"]).ToString("0");
      string adrAdnName = (string)row["ADRESS"];
	  
	  if(acc == "") continue;

      int ind = adrAdnName.LastIndexOf('(');

      string adr = adrAdnName.Substring(0, ind);
      string name = adrAdnName.Substring(ind + 1);
      name = name.Substring(0, name.Length - 1);

      var arr = new string[]
                {
                    acc,
                    name,
                    adr,
                };

      for (int i = 0; i < arr.Length; i++)
      {
          arr[i] = arr[i].Replace('\r', '\t');
          arr[i] = arr[i].Replace('\n', '\t');
      }

      writer.WriteLine(string.Join(";", arr));
  }

  writer.Close();
  sourceFiles.Clear();
  sourceFiles.Add(singleFile);
}