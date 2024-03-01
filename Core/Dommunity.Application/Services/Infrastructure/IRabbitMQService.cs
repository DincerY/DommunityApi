using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dommunity.Application.Services.Infrastructure;

public interface IRabbitMQService
{
    public void ExchangeDeclare(string exchangeName);
    public void QueueDeclare(string queueName);
    public string DefaultQueueDeclare();

    public void QueueBind(string exchangeName, string queueName , string bindingKey = "");
    public void BasicPublish(string exhangeName, byte[] body, string routingKey = "");




}