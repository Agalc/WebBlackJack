using System.Data.Entity;
using BlackJack.DAL.Enteties;

namespace BlackJack.DAL
{
  public class BjContext : DbContext
  {
    public DbSet<Game> Games { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<Round> Rounds { get; set; }

    public BjContext(string connectionString)
      : base(connectionString)
    {
    }
  }
}