using BlackJack.DAL.Enteties;

namespace BlackJack.DAL.Repositories
{
  public class CardRepository : Repository<Card>
  {
    CardRepository(BjContext context):
      base(context)
    {

    }
  }
}
