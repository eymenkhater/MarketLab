using MarketLab.Application.Core.Models;
using MediatR;

namespace MarketLab.Application.Core.Interfaces
{
    public interface ICommand<TResponse> : IRequest<ResponseBase<TResponse>>
    {

    }
}