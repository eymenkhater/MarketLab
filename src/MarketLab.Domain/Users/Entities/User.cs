using MarketLab.Domain.Core.Entities;

namespace MarketLab.Domain.Users.Entities
{
    public class User : EntityBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}