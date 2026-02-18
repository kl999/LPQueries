<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var q = new Queue<int>(new []{1, 2, 3});

q.Dump();

q.Dequeue().Dump();
q.Dequeue().Dump();
q.Dequeue().Dump();
if(q.Count > 0) q.Dequeue().Dump();
q.Dump();

q.Enqueue(4);
q.Peek().Dump();

q.Dump();
