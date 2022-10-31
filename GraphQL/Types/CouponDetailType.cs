using GraphQL.Types;
using netcoregraphqlapi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcoregraphqlapi.GraphQL.Types
{
    public class CouponDetailType : ObjectGraphType<CouponDetail>
    {
        public CouponDetailType()
        {
            Field(x => x.CouponId, type: typeof(IntGraphType)).Description("Kupon Id");
            Field(x => x.MatchId, type: typeof(IntGraphType)).Description("Maç Id.");
            Field(x => x.MatchName, type: typeof(StringGraphType)).Description("Maç Adı");
            Field(x => x.Rate, type: typeof(DecimalGraphType)).Description("Oran");
            Field(x => x.Result, type: typeof(StringGraphType)).Description("Sonuç");
        }
    }
}
