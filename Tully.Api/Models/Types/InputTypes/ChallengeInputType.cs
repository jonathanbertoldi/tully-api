using GraphQL.Types;

namespace Tully.Api.Models.Types.InputTypes
{
  public class ChallengeInputType : InputObjectGraphType
  {
    public ChallengeInputType()
    {
      Name = "ChallengeInputType";

      Field<NonNullGraphType<StringGraphType>>("name");
      Field<NonNullGraphType<StringGraphType>>("description");
      Field<NonNullGraphType<IntGraphType>>("prizeExp");
    }
  }
}