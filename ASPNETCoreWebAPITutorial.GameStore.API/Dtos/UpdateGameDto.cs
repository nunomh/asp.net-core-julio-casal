using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreWebAPITutorial.GameStore.API.Dtos;

public record class UpdateGameDto(
	[Required][StringLength(50)] string Name,
	// [Required][StringLength(20)] string Genre,
	int GenreId,
	[Range(1, 200)] decimal Price,
	DateOnly ReleaseDate
	);
