#Get-ADUser samartsev_26224
[string[]] $srch = @("*Молдабекова*амина*")
#$srch += "*Platon.Samartsev@kaspi.kz*"

foreach($srchs in $srch) {
$u = Get-ADUser -Filter{Name -like $srchs -or Mail -like $srchs} `
    -Properties Mail, DisplayName, TelephoneNumber #*
$u

Get-ADPrincipalGroupMembership $u.SamAccountName |
Get-ADGroup -Properties mail |
Format-Table SamAccountName, mail, distinguishedName -Wrap
"
------------------------------
"
}