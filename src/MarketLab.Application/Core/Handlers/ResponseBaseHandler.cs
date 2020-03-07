using MarketLab.Application.Core.Models;

namespace MarketLab.Application.Core.Handlers
{
    public class ResponseBaseHandler<TResponse>
    {
        public ResponseBase<bool> OK() => new ResponseBase<bool>(true);
        public ResponseBase<TResponse> OK(TResponse data) => new ResponseBase<TResponse>(data);
    }
}