using FintechService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechService.Domain.PFintechServiceAggregate
{
    public class CustomerAccount:Entity
    {
        public Guid CustomerId { get; set; }
        public string AccountName { get; set; }
        public string Currency { get; set; }

    }
}
