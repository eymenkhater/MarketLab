using MarketLab.Application.Core.Models;
using MediatR;

namespace MarketLab.Application.Core.Interfaces
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, ResponseBase<TResponse>> where TQuery : IQuery<TResponse>
    {

    }
}