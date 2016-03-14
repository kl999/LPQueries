<Query Kind="Statements">
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

DirectoryInfo di = new DirectoryInfo("D:\\webroot");

if (di != null)
{
	DirectoryInfo[] subDirs = di.GetDirectories();
	if (subDirs.Length > 0)
	{
		"******* Directories are:\n".Dump();
		foreach (DirectoryInfo subDir in subDirs)
		{
			string name = subDir.Name;
			
			("--" + name + "--\n").Dump();
		}
	}

	FileInfo[] subFiles = di.GetFiles();
	if (subFiles.Length > 0)
	{
		"\n******* Files are:\n".Dump();
		foreach (FileInfo subFile in subFiles)
		{
			string name = subFile.Name;
			
			("[" + name + "]\n").Dump();
		}
	}
}