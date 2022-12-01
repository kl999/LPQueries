<Query Kind="Program" />

void Main()
{
    foreach(var num in new[]{ 0, 1, 2, 5, 15, 25, 26, 27, 45, 485, 4643 })
    {
        var letters = numberToLetters(num);
        
        $"{num} = {letters}       < {lettersToNumber(letters)}".Dump();
    }
    
    "----------".Dump();
    
    for(int i = 0; i < 100000; i++)
    {
        var letters = numberToLetters(i);
        
        $"{i} = {letters}       < {lettersToNumber(letters)}".Dump();
    }
}

string numberToLetters(long number)
{
    var letterNums = new List<long>();
    
    for(;number >= 26;)
    {
        letterNums.Add(number % 26);
        number = number / 26;
    }
    
    letterNums.Add(number);
    
    letterNums.Reverse();
    
    return String.Join("", letterNums.Select(i => (char)((byte)i + 65)));
}

long lettersToNumber(string letters)
{
    var letterNums = letters.Reverse().Select(i => (long)i - 65).ToArray();
    
    long number = 0;
    
    for(int i = 0; i < letterNums.Length; i++)
    {
        number += (long)(letterNums[i] * Math.Pow(26, i));
    }

    return number;
}
