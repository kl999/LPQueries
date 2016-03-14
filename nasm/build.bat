echo off
set filename=function

del bin\%filename%.exe
del bin\%filename%.ilk
del bin\%filename%.obj
del bin\%filename%.pdb

echo ===NASM:===
nasm -f win32 src\%filename%.asm -o bin\%filename%.obj

echo __________________________________
echo ==================================
echo ----------------------------------

echo ===LINK:===
:/EXPORT:writenum
"C:\Program Files (x86)\Microsoft Visual Studio 11.0\VC\bin\link" /DEBUG /ENTRY:start /EXPORT:writenum /SUBSYSTEM:CONSOLE /nodefaultlib /OUT:bin\%filename%.exe c:\sp\nasm\bin\%filename%.obj kernel32.lib msvcrt.lib

echo __________________________________
echo ==================================
echo ----------------------------------

echo on

bin\%filename%

:pause 1>&2