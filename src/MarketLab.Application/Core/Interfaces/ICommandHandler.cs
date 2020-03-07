using MarketLab.Application.Core.Models;
using MediatR;

namespace MarketLab.Application.Core.Interfaces
{
    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, ResponseBase<TResponse>> where TCommand : ICommand<TResponse>
    {
    }

}