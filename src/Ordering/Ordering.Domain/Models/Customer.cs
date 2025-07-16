using Ordering.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Models
{
    public class Customer : Entity<Guid>
    {
        public string Name { get; private set; } = default!;
        public string Email { get; private set; } = default!;
    }
}
