Get-ADGroup -Filter 'samAccountName -like "Paynet*"' |
Format-Table SamAccountName, Name

$grName = "PaynetHunter"

$gr = (Get-ADGroup $grName -Properties mail)

$gr | Format-List

"----Group " + $grName + " members:"

Get-ADGroupMember $gr |
select SamAccountName, Name