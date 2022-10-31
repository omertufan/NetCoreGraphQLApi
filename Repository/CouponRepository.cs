using Microsoft.EntityFrameworkCore;
using netcoregraphqlapi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcoregraphqlapi.Repository
{
    public interface ICouponRepository
    {
        IEnumerable<Coupon> GetAllCouponsNyMemberId(int memberId);
        Task<ILookup<int, Coupon>> GetCouponsByMemberIds(IEnumerable<int> memberIds);
        Coupon UpdateCoupon(int couponId, CouponStatus status);
        IEnumerable<Coupon> GetByStatu(CouponStatus status);
        Coupon GetById(int id);

    }
    public class CouponRepository : ICouponRepository
    {
        private List<Coupon> _coupons;
        public CouponRepository()
        {
            _coupons = new List<Coupon> {

                new Coupon
                {
                    CouponId = 46906817,
                    CouponAmount = 14.00m,
                    CouponDate = DateTime.Now,
                    MatchCount = 5,
                    MaxGain = 65.72m,
                    MemberId = 111111,
                    Status = CouponStatus.Winning,
                    Thoughts = 10,
                    TotalRate = 4.69m

                },
                   new Coupon
                {
                    CouponId = 46906911,
                    CouponAmount = 10.00m,
                    CouponDate = DateTime.Now,
                    MatchCount = 1,
                    MaxGain = 48.00m,
                    MemberId = 111111,
                    Status = CouponStatus.Losing,
                    Thoughts = 10,
                    TotalRate = 4.80m

                },
                  new Coupon
                {
                    CouponId = 46906818,
                    CouponAmount = 14.00m,
                    CouponDate = DateTime.Now,
                    MatchCount = 1,
                    MaxGain = 65.72m,
                    MemberId = 222222,
                    Status = CouponStatus.Losing,
                    Thoughts = 10,
                    TotalRate = 4.69m

                },
                  new Coupon
                {
                    CouponId = 46906819,
                    CouponAmount = 14.00m,
                    CouponDate = DateTime.Now,
                    MatchCount = 1,
                    MaxGain = 65.72m,
                    MemberId = 333333,
                    Status = CouponStatus.Waiting,
                    Thoughts = 10,
                    TotalRate = 4.69m

                },
                 new Coupon
                {
                    CouponId = 46906820,
                    CouponAmount = 14.00m,
                    CouponDate = DateTime.Now,
                    MatchCount = 1,
                    MaxGain = 65.72m,
                    MemberId = 444444,
                    Status = CouponStatus.Winning,
                    Thoughts = 10,
                    TotalRate = 4.69m

                }



            };
        }

        public IEnumerable<Coupon> GetAllCouponsNyMemberId(int memberId)
        {
            return _coupons.Where(a => a.MemberId.Equals(memberId)).ToList();
        }

        public Coupon GetById(int id)
        {
            return _coupons.SingleOrDefault(o => o.CouponId.Equals(id));
        }

        public IEnumerable<Coupon> GetByStatu(CouponStatus status)
        {
            return _coupons.Where(o => o.Status == status);
        }

        public async Task<ILookup<int, Coupon>> GetCouponsByMemberIds(IEnumerable<int> memberIds)
        {
            var accounts = _coupons.Where(a => memberIds.Contains(a.MemberId)).ToList();
            return accounts.ToLookup(x => x.MemberId);
        }

        public Coupon UpdateCoupon(int couponId, CouponStatus status)
        {
            var coupon = _coupons.SingleOrDefault(o => o.CouponId.Equals(couponId));
            coupon.Status = status;
            return coupon;
        }
    }
}
