using GraphQL;
using GraphQL.Types;
using Tully.Api.Models.Queries;

namespace Tully.Api.Models
{
  public class TullySchema : Schema
  {
    public TullySchema(IDependencyResolver resolver) : base(resolver)
    {
      Query = resolver.Resolve<TullyRootQuery>();
    }
  }
}