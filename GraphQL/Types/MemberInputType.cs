using GraphQL.Types;
using netcoregraphqlapi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcoregraphqlapi.GraphQL.Types
{
    public class MemberInputType : InputObjectGraphType
    {
        public MemberInputType()
        {
            Name = "memberInput";
            Field<NonNullGraphType<StringGraphType>>("firstName");
            Field<NonNullGraphType<StringGraphType>>("lastName");
            Field<NonNullGraphType<StringGraphType>>("email");
            Field<NonNullGraphType<StringGraphType>>("password");

        }
    }
}
