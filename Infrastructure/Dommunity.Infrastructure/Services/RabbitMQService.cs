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
    public string QueueDeclare(string queueName)
    {
        return "";
    }

    public void QueueBind(string queueName,string exhange, string routingKey)
    {
    }

}