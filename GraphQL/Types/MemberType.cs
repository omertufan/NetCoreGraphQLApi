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
    public class MemberType : ObjectGraphType<Member>
    {
        public MemberType(ICouponRepository repository, IDataLoaderContextAccessor dataLoader)
        {
            Field(x => x.MemberId, type: typeof(IntGraphType)).Description("Üye Id");
            Field(x => x.FirstName, type: typeof(StringGraphType)).Description("Üye Adı");
            Field(x => x.LastName, type: typeof(StringGraphType)).Description("Üye Soyadı");
            Field(x => x.Balance, type: typeof(DecimalGraphType)).Description("Bakiye");
            Field(x => x.FormattedBalance, type: typeof(StringGraphType)).Description("Formatlı Bakiye");
            Field(x => x.UserName, type: typeof(StringGraphType)).Description("Kullanıcı Adı");
            Field(x => x.ProfilePhoto, type: typeof(StringGraphType)).Description("Profil Fotoğrafı");
            Field<ListGraphType<CouponType>>(
             "coupons",
              resolve: context =>
              {
                  var loader = dataLoader.Context.GetOrAddCollectionBatchLoader<int, Coupon>("GetCouponsByMemberIds", repository.GetCouponsByMemberIds);
                  return loader.LoadAsync(context.Source.MemberId);
              });
        }
    }
}
