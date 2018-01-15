#Get-ADUser samartsev_26224
[string[]] $srch = @("самарцев*")
#$srch += "*Platon.Samartsev@kaspi.kz*"

foreach($srchs in $srch) {
$u = Get-ADUser -Filter{Name -like $srchs -or Mail -like $srchs} `
    -Properties Mail, DisplayName, TelephoneNumber, `
    Deleted, AccountExpirationDate, AccountLockoutTime, `
    BadLogonCount, badPwdCount, CannotChangePassword, `
    Enabled, isDeleted, LastBadPasswordAttempt, LockedOut, `
    PasswordExpired, PasswordLastSet, PasswordNeverExpires, PasswordNotRequired #,*
$u
"
------------------------------
"
}