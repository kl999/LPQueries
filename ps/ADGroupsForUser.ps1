#Get-ADUser samartsev_26224
$u = Get-ADUser -Filter{Name -like "самарцев*"} `
    -Properties Mail, DisplayName, TelephoneNumber
$u

Get-ADPrincipalGroupMembership $u.SamAccountName |
Get-ADGroup -Properties mail |
Format-Table SamAccountName, mail, distinguishedName -Wrap