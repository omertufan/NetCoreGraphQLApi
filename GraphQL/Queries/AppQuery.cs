using GraphQL;
using GraphQL.Types;
using netcoregraphqlapi.Entities;
using netcoregraphqlapi.GraphQL.Types;
using netcoregraphqlapi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcoregraphqlapi.GraphQL.Queries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IMemberRepository memberRepository, ICouponRepository couponRepository)
        {
            Field<ListGraphType<MemberType>>(
               "members",
               resolve: context => memberRepository.GetAll()
           );

            Field<MemberType>(
                "member",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "memberId" }),
                resolve: context =>
                {
                    int id = context.GetArgument<int>("memberId");
                    return memberRepository.GetById(id);
                }
            );

            Field<ListGraphType<CouponType>>(
              "coupons",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CouponStatusEnumType>> { Name = "statu" }),
              resolve: context =>
              {
                  var statu = context.GetArgument<CouponStatus>("statu");
                  return couponRepository.GetByStatu(statu);
              }
          );


            Field<CouponType>(
             "coupon",
             arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "couponId" }),
             resolve: context =>
             {
                 var id = context.GetArgument<int>("couponId");
                 return couponRepository.GetById(id);
             }
         );
        }
    }
}
