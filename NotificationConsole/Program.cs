// See https://aka.ms/new-console-template for more information

using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

Console.WriteLine("Hello, World!");

ConnectionFactory factory = new ConnectionFactory();
IConnection connection = factory.CreateConnection();
IModel channel = connection.CreateModel();




var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine(message);
};


channel.BasicConsume("DincerYigit", autoAck: true, consumer);
channel.BasicConsume("GamzeYiğit", autoAck: true, consumer);
channel.BasicConsume("DilaraYiğit", autoAck: true, consumer);


Console.ReadLine();



