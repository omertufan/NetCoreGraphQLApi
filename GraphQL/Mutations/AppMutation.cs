using GraphQL;
using GraphQL.Types;
using netcoregraphqlapi.Entities;
using netcoregraphqlapi.GraphQL.Types;
using netcoregraphqlapi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcoregraphqlapi.GraphQL.Mutations
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation(IMemberRepository memberRepository, ICouponRepository couponRepository)
        {
            Field<MemberType>(
                "addMember",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<MemberInputType>> { Name = "member" }),
                resolve: context =>
                {
                    var member = context.GetArgument<Member>("member");
                    return memberRepository.AddMember(member);
                }
            );


            Field<CouponType>(
              "updateCouponStatu",
              arguments: new QueryArguments(
                  new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "couponId" },
                  new QueryArgument<NonNullGraphType<CouponStatusEnumType>> { Name = "statu" }),
              resolve: context =>
              {
                  var statu = context.GetArgument<CouponStatus>("statu");
                  var couponId = context.GetArgument<int>("couponId");
                  return couponRepository.UpdateCoupon(couponId, statu);
              }
          );
        }
    }
}
