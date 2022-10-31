using GraphQL.Types;
using netcoregraphqlapi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcoregraphqlapi.GraphQL.Types
{
    public class CouponStatusEnumType : EnumerationGraphType<CouponStatus>
    {
        public CouponStatusEnumType()
        {
            Name = "Status";
            Description = "Kupon Durumu";
        }
    }
}
