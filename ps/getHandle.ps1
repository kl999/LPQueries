$rez =  .\handle64.exe 1.txt -nobanner |
select @{ name = "name"; Expression = {
    [System.Text.RegularExpressions.Regex]::Match($_, "^(.*?)\s*pid:").Groups[1]
}},@{ name = "pid"; Expression = {
    [System.Text.RegularExpressions.Regex]::Match($_, "pid:\s(\d+)").Groups[1]
}}, @{ name = "path"; Expression = {
    [System.Text.RegularExpressions.Regex]::Match($_, "\w:\\.*$").Value
}} |
format-table -Wrap -AutoSize

$rez