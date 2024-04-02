using FintechService.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace FintechService.Domain.PFintechServiceAggregate
{
    public class Customer : Entity
    {
        [Required]
        public long IdentityNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

    }

}
