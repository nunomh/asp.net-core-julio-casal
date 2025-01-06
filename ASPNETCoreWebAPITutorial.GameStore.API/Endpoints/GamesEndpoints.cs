using ASPNETCoreWebAPITutorial.GameStore.API.Data;
using ASPNETCoreWebAPITutorial.GameStore.API.Dtos;
using ASPNETCoreWebAPITutorial.GameStore.API.Entities;
using ASPNETCoreWebAPITutorial.GameStore.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebAPITutorial.GameStore.API.Endpoints;

public static class GamesEndpoints
{
	const string GetGameEndpointName = "GetGame";

	// private static readonly List<GameSummaryDto> games = [
	// 	new(
	// 	1,
	// 	"Street Fighter II",
	// 	"Fighting",
	// 	19.99M,
	// 	new DateOnly(1992, 7, 15)),
	// new(
	// 	2,
	// 	"Final Fantasy XIV",
	// 	"Roleplaying",
	// 	59.99M,
	// 	new DateOnly(2010, 9, 30)),
	// new(
	// 	3,
	// 	"FIFA 23",
	// 	"Sports",
	// 	69.99M,
	// 	new DateOnly(2022, 9, 27)),
	// ];

	public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
	{
		var group = app.MapGroup("games")
					   .WithParameterValidation();
		// WithParameterValidation comes from MinimalApis.Extensions package. used to validate the parameters specified in the CreateGameDto like required
		// can be used here globally or in a specific endpoint

		// GET /games
		group.MapGet("/", (GameStoreContext dbContext) => 
			dbContext.Games
			.Include(game => game.Genre)
			.Select(game => game.ToGameSummaryDto())
			.AsNoTracking()
		);

		// GET /games/{id}
		group.MapGet("/{id}", (int id, GameStoreContext dbContext) =>
		{
			// GameDto? game = games.Find(game => game.Id == id); // commented out to use dbContext

			Game? game = dbContext.Games.Find(id);

			// return game is null ? Results.NotFound() : Results.Ok(game);
			return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());
		})
		.WithName(GetGameEndpointName);

		// POST /games
		group.MapPost("/", (CreateGameDto newGame, GameStoreContext dbContext) =>
		{
			// GameDto game = new(
			// 	games.Count + 1,
			// 	newGame.Name,
			// 	newGame.Genre,
			// 	newGame.Price,
			// 	newGame.ReleaseDate
			// ); // commented out to use dbContext

			// games.Add(game);



			// Game game = new()
			// {
			// 	Name = newGame.Name,
			// 	Genre = dbContext.Genres.Find(newGame.GenreId),
			// 	GenreId = newGame.GenreId,
			// 	Price = newGame.Price,
			// 	ReleaseDate = newGame.ReleaseDate
			// };

			Game game = newGame.ToEntity();
			// game.Genre = dbContext.Genres.Find(newGame.GenreId);

			dbContext.Games.Add(game);
			dbContext.SaveChanges();

			// GameSummaryDto gameDto = new(
			// 	game.Id,
			// 	game.Name,
			// 	game.Genre!.Name,
			// 	game.Price,
			// 	game.ReleaseDate
			// );

			// return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, gameDto); // 201 Created
			return Results.CreatedAtRoute(
				GetGameEndpointName, 
				new { id = game.Id }, 
				game.ToGameDetailsDto()
				); // 201 Created
		});


		// PUT /games/{id}
		group.MapPut("/{id}", (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) =>
		{
			// int index = games.FindIndex(game => game.Id == id);

			var existingGame = dbContext.Games.Find(id);

			// if (index == -1)
			// {
			// 	return Results.NotFound();
			// }
			if (existingGame is null)
			{
				return Results.NotFound();
			}

			// games[index] = new GameSummaryDto(
			// 	id,
			// 	updatedGame.Name,
			// 	updatedGame.Genre,
			// 	updatedGame.Price,
			// 	updatedGame.ReleaseDate
			// );
		
			dbContext.Entry(existingGame).CurrentValues.SetValues(updatedGame.ToEntity(id));
			dbContext.SaveChanges();

			return Results.NoContent(); // 204 No Content
		});

		// DELETE /games/{id}
		group.MapDelete("/{id}", (int id, GameStoreContext dbContext) =>
		{
			// games.RemoveAll(game => game.Id == id);

			dbContext.Games.Where(game => game.Id == id).ExecuteDelete();
			dbContext.SaveChanges();

			return Results.NoContent();
		});

		return group;
	}
}
