"start
"

#thrwEx #-ErrorAction Stop
try
{
    new-item -path "C:\Users\samartsev\Desktop\evilTestsFolderMuahaha"`
        -name "1.txt" -Value "" -type file -ErrorAction Stop
}
Catch
{
    "ex"
    $_.Exception.ToString()
    #Break
}

"
end"

#--------------------------------------------------

function thrwEx
{
    throw [System.Exception] "Hello Exception!!!"
}