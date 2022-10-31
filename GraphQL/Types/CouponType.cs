using GraphQL.DataLoader;
using GraphQL.Types;
using netcoregraphqlapi.Entities;
using netcoregraphqlapi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcoregraphqlapi.GraphQL.Types
{
    public class CouponType : ObjectGraphType<Coupon>
    {
        public CouponType(ICouponDetailRepository repository, IDataLoaderContextAccessor dataLoader)
        {
            Field(x => x.MemberId, type: typeof(IntGraphType)).Description("Üye Id");
            Field(x => x.CouponId, type: typeof(IntGraphType)).Description("Kupon Id");
            Field(x => x.CouponAmount, type: typeof(DecimalGraphType)).Description("Kupon Tutarı");
            Field(x => x.CouponDate, type: typeof(DateTimeGraphType)).Description("Oynanma Tarihi");
            Field(x => x.MatchCount, type: typeof(IntGraphType)).Description("Maç Sayısı");
            Field(x => x.MaxGain, type: typeof(DecimalGraphType)).Description("Max. Kazanç");
            Field(x => x.Thoughts, type: typeof(StringGraphType)).Description("Misli");
            Field(x => x.TotalRate, type: typeof(DecimalGraphType)).Description("Toplam Oran");
            Field<CouponStatusEnumType>("Status", "Kupon Durumu");
            Field<ListGraphType<CouponDetailType>>(
             "details",
              resolve: context =>
              {
                  var loader = dataLoader.Context.GetOrAddCollectionBatchLoader<int, CouponDetail>("GetAllCouponDetailsPerCoupon", repository.GetCouponDetailsByCouponIds);
                  return loader.LoadAsync(context.Source.CouponId);
              });
        }
    }
}
