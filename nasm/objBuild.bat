echo off
set filename=objFile

del bin\%filename%.obj

echo ===NASM:===
nasm -f win32 src\%filename%.asm -o bin\%filename%.obj