using MediatR;

namespace BuildingBlocks.CQRS;

public interface ICommand : ICommand<Unit> // Não retorna resposta.
{
}
public interface ICommand<out TResponse> : IRequest<TResponse> // Retorna resposta.
{
}
