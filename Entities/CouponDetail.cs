using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace netcoregraphqlapi.Entities
{
    public class CouponDetail
    {
        [Key]
        public int MatchId { get; set; }
        public string MatchName { get; set; }
        public string Result { get; set; }
        public decimal Rate { get; set; }


        [ForeignKey("CouponId")]
        public int CouponId { get; set; }
        public Coupon Coupon { get; set; }
    }
}
