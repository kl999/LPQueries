<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var queue = new PriorityQueue<string, int>();

queue.Enqueue("a", 3);
queue.Enqueue("c", 1);
queue.Enqueue("b", 2);

for(; queue.Count > 0;)
{
	queue.Dequeue().Dump();
}
