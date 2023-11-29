namespace Domain.DTOs;

public class SearchPostParametersDto
{
    public string? OwnerUsername { get; }
    public string? TitleContains { get; }

    public SearchPostParametersDto(string? ownerUsername, string? titleContains)
    {
        OwnerUsername = ownerUsername;
        TitleContains = titleContains;
    }
}