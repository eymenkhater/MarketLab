using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MarketLab.Application.Core.Dtos;
using MarketLab.Application.Core.Extensions;
using MarketLab.Application.Core.Handlers;
using MarketLab.Application.Core.Interfaces;
using MarketLab.Application.Core.Models;
using MarketLab.Domain.Core.Interfaces.Data.Repositories;
using MarketLab.Domain.ShoppingLists.Entities;

namespace MarketLab.Application.ShoppingLists.Commands.CreateShoppingListItem
{
    public class CreateShoppingListItemCommandHandler : ResponseBaseHandler<ShoppingListItemDto>, ICommandHandler<CreateShoppingListItemCommand, ShoppingListItemDto>
    {

        #region Fields
        private readonly IShoppingListItemRepository _shoppingListItemRepository;
        private readonly IMapper _mapper;
        #endregion

        #region CTOR
        public CreateShoppingListItemCommandHandler(
            IShoppingListItemRepository shoppingListItemRepository,
            IMapper mapper)
        {
            shoppingListItemRepository = _shoppingListItemRepository;
            _mapper = mapper;
        }
        #endregion
        public async Task<ResponseBase<ShoppingListItemDto>> Handle(CreateShoppingListItemCommand request, CancellationToken cancellationToken)
        {
            var shoppingListItem = _mapper.Map<ShoppingListItem>(request);

            (await _shoppingListItemRepository.CreateAsync(shoppingListItem)).ThrowIfRejected();

            var shoppingListItemDto = _mapper.Map<ShoppingListItemDto>(shoppingListItem);

            return OK(shoppingListItemDto);

        }
    }
}