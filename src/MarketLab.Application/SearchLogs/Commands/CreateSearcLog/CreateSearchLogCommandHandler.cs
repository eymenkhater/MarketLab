using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MarketLab.Application.Core.Extensions;
using MarketLab.Application.Core.Handlers;
using MarketLab.Application.Core.Interfaces;
using MarketLab.Application.Core.Interfaces.Identity;
using MarketLab.Application.Core.Models;
using MarketLab.Domain.Core.Interfaces.Data.Repositories;
using MarketLab.Domain.SearchLogs.Entities;

namespace MarketLab.Application.SearchLogs.Commands.CreateSearcLog
{
    public class CreateSearchLogCommandHandler : ResponseBaseHandler<bool>, ICommandHandler<CreateSearchLogCommand, bool>
    {
        #region Fields
        private readonly ISearchLogRepository _searchLogRepository;

        private readonly ICurrentUserService _currentUser;
        private readonly IMapper _mapper;
        #endregion

        #region CTOR
        public CreateSearchLogCommandHandler(
            ISearchLogRepository searchLogRepository,
            ICurrentUserService currentUser,
            IMapper mapper)
        {
            _searchLogRepository = searchLogRepository;
            _currentUser = currentUser;
            _mapper = mapper;
        }
        #endregion
        public async Task<ResponseBase<bool>> Handle(CreateSearchLogCommand request, CancellationToken cancellationToken)
        {
            request.UserId = _currentUser.User.Id;
            var searchLog = _mapper.Map<SearchLog>(request);

            (await _searchLogRepository.CreateAsync(searchLog)).ThrowIfRejected();

            return OK();
        }
    }
}