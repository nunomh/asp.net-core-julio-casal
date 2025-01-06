using ASPNETCoreWebAPITutorial.GameStore.API.Dtos;
using ASPNETCoreWebAPITutorial.GameStore.API.Entities;

namespace ASPNETCoreWebAPITutorial.GameStore.API.Mapping
{
    public static class GameMapping
    {
        public static Game ToEntity(this CreateGameDto game){
			return new Game()
			{
				Name = game.Name,
				GenreId = game.GenreId,
				Price = game.Price,
				ReleaseDate = game.ReleaseDate
			};
		}
		
		public static GameSummaryDto ToDto(this Game game)
		{
			return new(
				game.Id,
				game.Name,
				game.Genre!.Name,
				game.Price,
				game.ReleaseDate
			);
		}
    }

}