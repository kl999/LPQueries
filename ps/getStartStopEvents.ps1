$log = Get-WinEvent -LogName "System" | where {
	#($_.TimeCreated -ge (Get-Date "03.04.2015")) -AND
	($_.id -eq 12 -OR $_.id -eq 13)
}

$log | select -first 20 @{ Name = "Log"; Expression =
{
	$row = ""
	
	$row += $_.TimeCreated.ToString("dd.MM.yyyy HH:mm:ss").PadLeft(19, ' ')
	
	if($_.Message -Match ".*запуска.*") { $row += " ► " }
	else { $row += " ▄ " }
	
	$row += ([string]([DateTime]$_.TimeCreated).DayOfWeek).PadRight(10, '-') + ">"
	
	if($_.Message -Match ".*запуска.*") { $row += "Start" }
	else { $row += "Stop" }
	
	$row
} }

"Show the rest of the records (y/n)?"

$q = [Console]::ReadLine()

if($q -eq "y")
{
	$log | select -skip 20 @{ Name = "Log"; Expression =
	{
		$row = ""
		
		$row += $_.TimeCreated.ToString("dd.MM.yyyy HH:mm:ss").PadLeft(19, ' ')
		
		if($_.Message -Match ".*запуска.*") { $row += " ► " }
		else { $row += " ▄ " }
		
		$row += ([string]([DateTime]$_.TimeCreated).DayOfWeek).PadRight(10, '-') + ">"
		
		if($_.Message -Match ".*запуска.*") { $row += "Start" }
		else { $row += "Stop" }
		
		$row
	} }
	
	$q = [Console]::ReadLine()
}