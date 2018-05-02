using Tully.Core.Data;
using Tully.Core.Models;

namespace Tully.Data.Repositories
{
  public class ChallengeRepository : Repository<Challenge>, IChallengeRepository
  {
    public ChallengeRepository(TullyContext context) : base(context)
    {
    }
  }
}