@echo off
set filename=hwsof

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
"C:\Program Files (x86)\Microsoft Visual Studio 14.0\VC\bin\link" /DEBUG /ENTRY:start /SUBSYSTEM:CONSOLE /nodefaultlib /OUT:bin\%filename%.exe c:\sp\nasm\bin\%filename%.obj kernel32.lib msvcrt.lib

:: /EXPORT:writenum

echo __________________________________
echo ==================================
echo ----------------------------------

echo on

bin\%filename%

:pause 1>&2