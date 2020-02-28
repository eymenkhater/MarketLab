namespace MarketLab.Application.Core.Interfaces.Identity
{
    public interface ICurrentUserService
    {
        int Id { get; set; }
        string Username { get; set; }
    }
}