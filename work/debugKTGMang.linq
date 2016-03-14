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
			@"C:\Users\samartsev\Desktop\connectors\КТГ_Аймак_Манг. обл\KTGAktau районы\bd_gaz.DBF",
			@"C:\Users\samartsev\Desktop\connectors\КТГ_Аймак_Манг. обл\KTGAktau районы\bd_komb.DBF",
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

  foreach (var fullpath in sourceFiles)
  {
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

      if (fileName == "bd_gaz")
      {
          int ct = dt.Rows.Count;

          foreach (var orow in dt.Rows)
          {
              var row = (DataRow)orow;
			  
              var arr = new string[]
              {
                  ((string)(row["LIC_FCC"] ?? "")).ToString(),
                  (string)(row["FIO"].GetType() == typeof(DBNull) ? "" : row["FIO"]),
                  (string)(row["ADDRESS"].GetType() == typeof(DBNull) ? "" : row["ADDRESS"]),
                  ((double)row["SALDO"]).ToString("0.00"),
              };
			  
			  for (int i = 0; i < arr.Length; i++)
              {
                  arr[i] = arr[i].Replace('\r', '\t');
                  arr[i] = arr[i].Replace('\n', '\t');
              }

              writer.WriteLine(string.Join(";", arr));
          }
      }
      else if (fileName == "bd_komb")
      {
          int ct = dt.Rows.Count;

          foreach (var orow in dt.Rows)
          {
              var row = (DataRow)orow;
			  
//			  ((string)row["LIC_FCC"]).ToString().Dump();
//                  ((string)row["NAIM"])  .ToString().Dump();
//                  ((string)row["ADDRESS"]).ToString().Dump();

              var arr = new string[]
              {
                  ((string)(row["LIC_FCC"] ?? "")).ToString(),
                  (string)(row["NAIM"].GetType() == typeof(DBNull) ? "" : row["NAIM"]),
                  (string)(row["ADDRESS"].GetType() == typeof(DBNull) ? "" : row["ADDRESS"]),
                  "0.00",
              };
			  
			  for (int i = 0; i < arr.Length; i++)
              {
                  arr[i] = arr[i].Replace('\r', '\t');
                  arr[i] = arr[i].Replace('\n', '\t');
              }

              writer.WriteLine(string.Join(";", arr));
          }
      }
      else
      {
          throw new FormatException("Найден файл с именем, отличным от bd_gaz или bd_komb");
      }
  }

  writer.Close();
  sourceFiles.Clear();
  sourceFiles.Add(singleFile);
}