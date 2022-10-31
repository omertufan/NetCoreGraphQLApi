using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using netcoregraphqlapi.GraphQL.Mutations;
using netcoregraphqlapi.GraphQL.Queries;
using System;

namespace netcoregraphqlapi.GraphQL.Schemas
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<AppQuery>();
            Mutation = provider.GetRequiredService<AppMutation>();
        }
    }
}
