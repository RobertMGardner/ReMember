using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ReMember.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ReMemberContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ReMemberContext>>()))
            {
                //Look for any members
                if(context.Member.Any())
                {
                    return;
                }

                context.Member.AddRange(
                    new Member
                    {
                        MemberFirstName = "Jeff",
                        MemberLastName = "Durbin",
                        MemberAddress = "717 N Stapley Dr, Mesa, AZ 85203",
                        MemberPhoneNumber = "1234567890"
                    },
                    new Member
                    {
                        MemberFirstName = "Johnny",
                        MemberLastName = "Mac",
                        MemberAddress = "13248 Roscoe Blvd. Sun Valley, CA 91352",
                        MemberPhoneNumber = "1234567890"
                    },
                    new Member
                    {
                        MemberFirstName = "Gabriel",
                        MemberLastName = "Hughes",
                        MemberAddress = "1220 W 8th St, Junction City, KS 66441",
                        MemberPhoneNumber = "1234567890"
                    },
                    new Member
                    {
                        MemberFirstName = "Beki",
                        MemberLastName = "Hughes",
                        MemberAddress = "1220 W 8th St, Junction City, KS 66441",
                        MemberPhoneNumber = "1234567890"
                    },
                    new Member
                    {
                        MemberFirstName = "David",
                        MemberLastName = "Miller",
                        MemberAddress = "1008 Trailwood Drive Heber Springs, AR 72543",
                        MemberPhoneNumber = "1234567890"
                    }
                );

                context.SaveChanges();
            }

        }
    }
}
