using MarketLab.Application.Core.Models;
using MediatR;

namespace MarketLab.Application.Core.Interfaces
{
    public interface IQuery<TResponse> : IRequest<ResponseBase<TResponse>>
    {

    }
}