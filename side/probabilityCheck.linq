<Query Kind="Statements" />

var odd = 0.5;

var rez = 1D;

for(int i = 0; i < 2; i++)
{
    rez *= odd;
    
    if(rez == 0) $"iteration {i} rez is 0".Dump();
}

rez.Dump();