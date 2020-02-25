using System;
using MarketLab.Domain.Core.Constants;

namespace MarketLab.Domain.Core.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public int Status { get; set; } = StatusBase.Active;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}