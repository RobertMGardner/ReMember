using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReMember.Models
{
    public class Member
    {

        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string MemberFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string MemberLastName { get; set; }

        [Display(Name = "Address")]
        public string MemberAddress { get; set; }

        [Display(Name = "Phone Number")]
        [RegularExpression(@"^[0-9]*$")]
        [MaxLength(10), MinLength(10)]
        public string MemberPhoneNumber { get; set; }
    }
}
