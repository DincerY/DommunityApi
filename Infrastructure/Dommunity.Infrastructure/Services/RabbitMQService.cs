using Dommunity.Application.Services.Infrastructure;
using RabbitMQ.Client;

namespace Dommunity.Infrastructure.Services;

public class RabbitMQService : IRabbitMQService
{
    private readonly ConnectionFactory _connectionFactory;
    private readonly IConnection connection;
    private readonly IModel channel;

    public RabbitMQService(ConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
        connection = connectionFactory.CreateConnection();
        channel = connection.CreateModel();
    }

    public void ExchangeDeclare(string exhangeName)
    {
        channel.ExchangeDeclare(exhangeName, ExchangeType.Fanout);
    }

    public string DefaultQueueDeclare()
    {
        return channel.QueueDeclare().QueueName;
    }
    public void QueueDeclare(string queueName)
    {
        channel.QueueDeclare(
            queue : queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }

    public void QueueBind(string exchangeName, string queueName, string bindingKey = "")
    {
        channel.QueueBind(
            queue:queueName,
            exchange:exchangeName,
            routingKey: bindingKey);
    }

    public void BasicPublish(string exhangeName, byte[] body, string routingKey = "")
    {
        channel.BasicPublish(exhangeName,routingKey,body:body);
    }
}   