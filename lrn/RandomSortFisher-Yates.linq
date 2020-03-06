<Query Kind="Program" />

void Main()
{
    var arr = new int[10].Select((i, ind) => ind);
    
    var rand = new Random();
    
    sortRandom(arr, rand)
    //.Take(3)
    .Dump();
}

IEnumerable<T> sortRandom<T>(IEnumerable<T> q, Random rand)
{
    var arr = q.ToArray();
    
    var len = arr.Length;
    
    for(int i = 0; i < len; i++)
    {
        var to = rand.Next(len - i) + i;
        
        /*i.Dump();
        (len - i).Dump();
        to.Dump();
        "---".Dump();*/
        
        //var t = arr[to];
        yield return arr[to];
        arr[to] = arr[i];
        //arr[i] = t;
    }
}
