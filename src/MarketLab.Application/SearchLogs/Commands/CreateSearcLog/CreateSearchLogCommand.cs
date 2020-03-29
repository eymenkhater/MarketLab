using MarketLab.Application.Core.Interfaces;
using MarketLab.Application.SearchLogs.Commands.Base;

namespace MarketLab.Application.SearchLogs.Commands.CreateSearcLog
{
    public class CreateSearchLogCommand : SaveSearchLogCommand, ICommand<bool>
    {
        public CreateSearchLogCommand(string keywod, int foundedCount)
        {
            this.Keywod = keywod;
            this.FoundedCount = foundedCount;
        }
        public int UserId { get; set; }
    }
}