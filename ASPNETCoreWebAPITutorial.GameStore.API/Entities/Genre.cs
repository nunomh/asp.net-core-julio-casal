namespace ASPNETCoreWebAPITutorial.GameStore.API.Entities;

public class Genre
{
	public int Id { get; set; }
	public required string Name { get; set; }
	public string EmptyStringExample1 { get; set; } = string.Empty;
	public string? EmptyStringExample2 { get; set; }
}
