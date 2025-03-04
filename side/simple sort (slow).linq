<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

//https://arxiv.org/pdf/2110.01111
var arr = Enumerable.Range(0, 10).ToArray();

//arr.Dump();

arr = arr.OrderBy(_ => Random.Shared.Next(100)).ToArray();

arr.Dump();

for(var i = 0; i < arr.Length; i++)
for(var j = 0; j < arr.Length; j++)
if(arr[i] < arr[j])
(arr[j], arr[i]) = (arr[i], arr[j]);

arr.Dump();
