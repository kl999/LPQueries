Get-ADGroup -Filter 'samAccountName -like "Paynet*"' |
select SamAccountName, name

$grName = "PaynetSystemAdministratorTerminal"

$gr = (Get-ADGroup $grName)

"
----Group " + $grName + " members:
"

Get-ADGroupMember $gr | select SamAccountName, Name