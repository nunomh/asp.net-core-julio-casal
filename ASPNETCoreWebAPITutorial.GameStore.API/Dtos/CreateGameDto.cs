using System.ComponentModel.DataAnnotations; // for [Required] and other validations

namespace ASPNETCoreWebAPITutorial.GameStore.API.Dtos;

public record class CreateGameDto(
	[Required][StringLength(50)] string Name,
	[Required][StringLength(20)] string Genre,
	[Range(1, 200)] decimal Price,
	DateOnly ReleaseDate
	);
