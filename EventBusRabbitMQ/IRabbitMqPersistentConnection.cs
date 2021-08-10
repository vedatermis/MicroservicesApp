using System;
using RabbitMQ.Client;

namespace EventBusRabbitMQ
{
    public interface IRabbitMqPersistentConnection: IDisposable
    {
        bool IsConnected { get; }
        bool TryConnect();
        IModel CreateModel();
    }
}