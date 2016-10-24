Get-ADGroup -Filter 'samAccountName -like "Paynet*"' |
Format-Table SamAccountName, Name

$grName = "PaynetTerminalSystemAdministrator"

$gr = (Get-ADGroup $grName -Properties mail)

"----Group " + $grName + " members:"

Get-ADGroupMember $gr |
select SamAccountName, Name