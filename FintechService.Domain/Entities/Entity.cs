using System;

namespace FintechService.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public void SetIsActive(bool value)
        {
            IsActive = value;
        }
    }
}