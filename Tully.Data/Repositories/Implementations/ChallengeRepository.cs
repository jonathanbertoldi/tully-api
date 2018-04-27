using Tully.Core.Models;

namespace Tully.Data.Repositories.Implementations
{
  public class ChallengeRepository : Repository<Challenge>, IChallengeRepository
  {
    public ChallengeRepository(Context context) : base(context)
    {

    }
  }
}