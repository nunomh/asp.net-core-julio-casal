using ASPNETCoreWebAPITutorial.GameStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebAPITutorial.GameStore.API.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
	public DbSet<Game> Games => Set<Game>();

	public DbSet<Genre> Genres => Set<Genre>();
}
