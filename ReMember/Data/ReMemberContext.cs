using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ReMember.Models
{
    public class ReMemberContext : DbContext
    {
        public ReMemberContext (DbContextOptions<ReMemberContext> options)
            : base(options)
        {
        }

        public DbSet<ReMember.Models.Member> Member { get; set; }
    }
}
