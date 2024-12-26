namespace ASPNETCoreWebAPITutorial.GameStore.API.Dtos;

public record class UpdateGameDto(
	string Name, 
	string Genre, 
	decimal Price,
	DateOnly ReleaseDate
	);
