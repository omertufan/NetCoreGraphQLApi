using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace netcoregraphqlapi.Entities
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }
        public DateTime CouponDate { get; set; }
        public int MatchCount { get; set; }
        public decimal TotalRate { get; set; }
        public decimal CouponAmount { get; set; }
        public CouponStatus Status { get; set; }
        public int Thoughts { get; set; }
        public decimal MaxGain { get; set; }

        public ICollection<CouponDetail> Details { get; set; }

        [ForeignKey("MemberId")]
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
