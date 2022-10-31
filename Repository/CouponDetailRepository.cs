using Microsoft.EntityFrameworkCore;
using netcoregraphqlapi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcoregraphqlapi.Repository
{
    public interface ICouponDetailRepository
    {
        IEnumerable<CouponDetail> GetAllCouponDetailsByCouponId(int couponId);
        Task<ILookup<int, CouponDetail>> GetCouponDetailsByCouponIds(IEnumerable<int> couponIds);

    }
    public class CouponDetailRepository : ICouponDetailRepository
    {

        private List<CouponDetail> _couponDetails;

        public CouponDetailRepository()
        {
            _couponDetails = new List<CouponDetail> {

                 new CouponDetail
                {
                    CouponId = 46906817,
                    MatchId = 781078,
                    MatchName = "PSV - NEC Nijmegen",
                    Rate = 1.28m,
                    Result = "1.Y Sonucu : 1"

                },
                new CouponDetail
                {
                    CouponId = 46906817,
                    MatchId = 115960,
                    MatchName = "Arsenal - Nottighan F.",
                    Rate = 1.25m,
                    Result = "Ev 1.Yarı Gol : 0,5 Üst"

                },
                new CouponDetail
                {
                    CouponId = 46906817,
                    MatchId = 174117,
                    MatchName = "Spezia - Fiorentina",
                    Rate = 1.66m,
                    Result = "Dep. 1.Yarı Gol : 0,5 Üst"

                },
                new CouponDetail
                {
                    CouponId = 46906817,
                    MatchId = 652681,
                    MatchName = "Beşiktaş Ümraniyespor",
                    Rate = 1.29m,
                    Result = "Ev 1.Yarı Gol : 0,5 Üst"

                },
                new CouponDetail
                {
                    CouponId = 46906817,
                    MatchId = 653066,
                    MatchName = "Kayserispor - Adana Demir",
                    Rate = 1.37m,
                    Result = "Karşıklık Gol : Var"

                },
                new CouponDetail
                {
                    CouponId = 46906911,
                    MatchId = 653669,
                    MatchName = "Inter -Sampdoria",
                    Rate = 3.37m,
                    Result = "Ms : 1"

                },
                new CouponDetail
                {
                    CouponId = 46906818,
                    MatchId = 651160,
                    MatchName = "İstanbulspor - Fenerbahçe",
                    Rate = 2.37m,
                    Result = "MS : 2"

                },
                new CouponDetail
                {
                    CouponId = 46906819,
                    MatchId = 113063,
                    MatchName = "Sivasspor - Cluj",
                    Rate = 1.77m,
                    Result = "IY : X"

                },
                new CouponDetail
                {
                    CouponId = 46906820,
                    MatchId = 654462,
                    MatchName = "Liverpool - Leeds United",
                    Rate = 1.90m,
                    Result = "IY : 1"

                }

            };
        }

        public IEnumerable<CouponDetail> GetAllCouponDetailsByCouponId(int couponId)
        {
            return _couponDetails.Where(a => a.CouponId.Equals(couponId)).ToList();
        }

        public async Task<ILookup<int, CouponDetail>> GetCouponDetailsByCouponIds(IEnumerable<int> couponIds)
        {
            var accounts =  _couponDetails.Where(a => couponIds.Contains(a.CouponId)).ToList();
            return accounts.ToLookup(x => x.CouponId);
        }
    }
}
