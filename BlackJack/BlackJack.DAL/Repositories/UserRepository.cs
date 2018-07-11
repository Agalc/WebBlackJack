using BlackJack.DAL.Enteties;

namespace BlackJack.DAL.Repositories
{
  public class UserRepository : Repository<User>
  {
    UserRepository(BjContext context) :
      base(context)
    {

    }
  }
}
