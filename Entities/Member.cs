using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcoregraphqlapi.Entities
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfilePhoto { get; set; }
        public decimal Balance { get; set; }
        public string FormattedBalance { get; set; }

        public ICollection<Coupon> Coupons { get; set; }
    }
}
