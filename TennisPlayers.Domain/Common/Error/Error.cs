namespace TennisPlayers.Domain.Common.Error;

public record Error
{
    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);
    public static readonly Error NullValue = new(
        "General.Null",
        "Null value was provided",
        ErrorType.Failure);
    public string Code { get; }
    public string Description { get; }
    public ErrorType Type { get; }
    
    public Error(string code, string description, ErrorType type)
    {
        Code = code;
        Description = description;
        Type = type;
    }
    
    public static Error NotFound(string code, string description) =>
        new(code, description, ErrorType.NotFound);
}