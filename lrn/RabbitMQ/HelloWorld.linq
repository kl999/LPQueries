<Query Kind="Statements">
  <Reference Relative="..\..\_Exts\RabbitMQ.Client.dll">C:\Users\platon.s\Desktop\111\LPQueries\_Exts\RabbitMQ.Client.dll</Reference>
  <Namespace>RabbitMQ.Client</Namespace>
  <Namespace>RabbitMQ.Client.Events</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <RuntimeVersion>8.0</RuntimeVersion>
</Query>

void send()
{
	var factory = new ConnectionFactory { HostName = "localhost" };
	using var connection = factory.CreateConnection();
	using var channel = connection.CreateModel();

	channel.QueueDeclare(queue: "hello",
	                     durable: false,
	                     exclusive: false,
	                     autoDelete: false,
	                     arguments: null);

	const string message = "Hello World!";
	var body = Encoding.UTF8.GetBytes(message);

	channel.BasicPublish(exchange: string.Empty,
	                     routingKey: "hello",
	                     basicProperties: null,
	                     body: body);
	$" [x] Sent {message}".Dump();
}

async Task receive()
{
	var factory = new ConnectionFactory { HostName = "localhost" };
	using var connection = factory.CreateConnection();
	using var channel = connection.CreateModel();
	
	channel.QueueDeclare(queue: "hello",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);
	
	var consumer = new EventingBasicConsumer(channel);
	consumer.Received += (model, ea) =>
	{
	    var body = ea.Body.ToArray();
	    var message = Encoding.UTF8.GetString(body);
	    $" [x] Received {message}".Dump();
	};
	channel.BasicConsume(queue: "hello",
	                     autoAck: true,
	                     consumer: consumer);

	await Task.Delay(5000);
}

var t = receive();

await Task.Delay(500);

send();

t.Wait();
