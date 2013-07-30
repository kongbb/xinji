namespace CG.Access.MessageBus.Interfaces
{
    public interface IMessageBusFactory<T> where T : class
    {
        IMessageBus<T> Create(IMessageBusConfigManager configManager,
            IMessageBusLogger messageBusLogger);
    }
}