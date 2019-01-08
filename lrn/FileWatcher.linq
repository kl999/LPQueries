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
	Run();
}

[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
public static void Run()
{
	// Create a new FileSystemWatcher and set its properties.
	using(FileSystemWatcher watcher = new FileSystemWatcher())
    {
        watcher.Path = @"C:\";//\sp\";
    	
    	watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
        	| NotifyFilters.FileName | NotifyFilters.DirectoryName;
    //	NotifyFilters.LastAccess | NotifyFilters.LastWrite
    //    | NotifyFilters.FileName | NotifyFilters.DirectoryName;
    	
    	//watcher.Filter = "*.tmp";
    	
    	watcher.Changed += new FileSystemEventHandler(OnChanged);
    	watcher.Created += new FileSystemEventHandler(OnCreated);
    	watcher.Deleted += new FileSystemEventHandler(OnDeleted);
    	watcher.Renamed += new RenamedEventHandler(OnRenamed);
    	
    	// Begin watching.
        watcher.EnableRaisingEvents = true;
    	
    	watcher.IncludeSubdirectories = true;
        
        Console.ReadLine();
        
        watcher.Changed -= new FileSystemEventHandler(OnChanged);
    	watcher.Created -= new FileSystemEventHandler(OnCreated);
    	watcher.Deleted -= new FileSystemEventHandler(OnDeleted);
    	watcher.Renamed -= new RenamedEventHandler(OnRenamed);
    }
}

private static void OnChanged(object source, FileSystemEventArgs e)
{
	// Specify what is done when a file is changed, created, or deleted.
	Console.WriteLine(DateTime.Now.ToString() + " File changed: " +  e.FullPath + " " + e.ChangeType);
}

private static void OnCreated(object source, FileSystemEventArgs e)
{
	// Specify what is done when a file is created.
	Console.WriteLine(DateTime.Now.ToString() + " File created: " +  e.FullPath + " " + e.ChangeType);
}

private static void OnDeleted(object source, FileSystemEventArgs e)
{
	// Specify what is done when a file is deleted.
	Console.WriteLine(DateTime.Now.ToString() + " File deleted: " +  e.FullPath + " " + e.ChangeType);
}

private static void OnRenamed(object source, RenamedEventArgs e)
{
	// Specify what is done when a file is renamed.
	Console.WriteLine(DateTime.Now.ToString() + " File at: {0} renamed to {1}", e.OldFullPath, e.Name);
}