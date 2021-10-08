using PaymentContext.Shared.Commands;

namespace PaymentContext.Shared.Handlers
{
    public interface ICommandHandler<T> where T : ICommand
    {
        ICommandResult Handle (T command);
    }
}
