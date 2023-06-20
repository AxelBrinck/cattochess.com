namespace EventSourcingFramework;

public record CommandResult(bool Success, string? Message);