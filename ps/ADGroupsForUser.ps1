#Get-ADUser samartsev_26224
[string[]] $srch = @("самарцев*")
#$srch += "*Платон*"

foreach($srchs in $srch) {
$u = Get-ADUser -Filter{Name -like $srchs} `
    -Properties Mail, DisplayName, TelephoneNumber #*
$u

Get-ADPrincipalGroupMembership $u.SamAccountName |
Get-ADGroup -Properties mail |
Format-Table SamAccountName, mail, distinguishedName -Wrap
"
------------------------------
"
}